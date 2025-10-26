using MathPrimitives;
using Topology;

namespace Renderer;

public enum ProjectionType { Perspective, Axonometric }

public sealed class MeshRenderer
{
	private const double Distance = -200;
	
	public ProjectionType	Projection { get; set; } = ProjectionType.Perspective;
	public Polyhedron		Model { get; set; } = Polyhedron.RegularTetrahedron(40);

	// Параметры модели/вида/проекции
	public Mat4		ModelTransform	{ get; set; } = Mat4.Identity /** Mat4.RotationY(Math.PI / 8) * Mat4.RotationX(-Math.PI / 10)*/;
	public Mat4		WorldTransform	{ get; set; } = Mat4.Identity;
	public Mat4		ViewTransform	{ get; set; } = Mat4.Translation(0, 0, Distance);
	public double	Focal			{ get; set; } = 10; // пиксели


	// Рисовальные настройки
	public bool		Wireframe		{ get; set; } = true;
	public Pen		WirePen			{ get; set; } = Pens.Black;
	public Brush	VertexBrush		{ get; set; } = Brushes.Firebrick;
	public float	VertexRadius	{ get; set; } = 3f;
	public bool		AutoFit			{ get; set; } = false;

	public MeshRenderer()
	{
		//Model.Vertices = Model.Vertices.Select(x => x + Vec3.UnitX * 10 + Vec3.UnitY * 7).ToList();
	}

	public void ApplyModelTransform(Mat4 m) => ModelTransform = m * ModelTransform;
	public void ApplyWorldTransform(Mat4 m) => WorldTransform = m * WorldTransform;

	public void ResetView()
	{
		ModelTransform = Mat4.Identity;
		WorldTransform = Mat4.Identity;
		ViewTransform  = Mat4.Translation(0, 0, Distance);
	}


	/// <summary>
	/// Рисует текущую модель в указанный Graphics и прямоугольник вывода.
	/// Control не требуется — можно вызывать из любого места (Form.Paint, PictureBox.Paint и т.п.).
	/// </summary>
	public void Render(Graphics g, Rectangle viewport)
	{
		if (Model is null || Model.Vertices.Count == 0) return;


		g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

		var world = ViewTransform * WorldTransform * Mat4.IsometricRotation() * ModelTransform;
		var transformed = Model.Vertices.Select(v => world.TransformPoint(v)).ToArray();


		Vec2[] screen;
		if (Projection == ProjectionType.Perspective)
		{
			const double deg = Math.PI / 180.0;
			var aspect = (double)viewport.Width / Math.Max(1, viewport.Height);
			var proj   = Mat4.PerspectiveFovY(fovYdeg: Focal, aspect: aspect, zn: 0.1, zf: 10000); 

			var ndc = transformed.Select(v => proj.TransformPoint(v)).ToArray(); 
			screen = ToViewport(ndc, viewport);
		}
		else
		{
			//transformed = transformed.Select(v => new Vec3(-v.X, -v.Y, v.Z)).ToArray(); //TODO: REMOVE KOSTYL
			var proj = Mat4.Orthographic(left:-80, right:80, bottom:-80, top:80, zn:-1000, zf:1000);
			var ndc = transformed.Select(v => proj.TransformPoint(v)).ToArray();
			screen = ToViewport(ndc, viewport);
		}


		if (Wireframe)
		{
			foreach (var face in Model.Faces)
			{
				for (int i = 0; i < face.Indices.Length; i++)
				{
					int a = face.Indices[i];
					int b = face.Indices[(i + 1) % face.Indices.Length];
					var pa = screen[a];
					var pb = screen[b];
					g.DrawLine(WirePen, (float)pa.X, (float)pa.Y, (float)pb.X, (float)pb.Y);
				}
			}
		}


		foreach (var p in screen)
		{
			var x = (float)p.X;
			var y = (float)p.Y;
			g.FillEllipse(VertexBrush, x - VertexRadius, y - VertexRadius, VertexRadius * 2, VertexRadius * 2);
		}
	}


	private static Vec2[] ToScreen(IReadOnlyList<Vec3> pts, Rectangle viewport)
	{
		double minX = double.PositiveInfinity, minY = double.PositiveInfinity;
		double maxX = double.NegativeInfinity, maxY = double.NegativeInfinity;
		foreach (var p in pts)
		{
			if (p.X < minX) minX = p.X;
			if (p.X > maxX) maxX = p.X;
			if (p.Y < minY) minY = p.Y;
			if (p.Y > maxY) maxY = p.Y;
		}

		double w = Math.Max(1e-6, maxX - minX), h = Math.Max(1e-6, maxY - minY);
		double pad = 0.1; // 10%
		double scaleX = viewport.Width / (w * (1 + pad * 2));
		double scaleY = viewport.Height / (h * (1 + pad * 2));
		double s = Math.Min(scaleX, scaleY);


		double cx = (minX + maxX) * 0.5;
		double cy = (minY + maxY) * 0.5;


		var list = new Vec2[pts.Count];
		for (int i = 0; i < pts.Count; i++)
		{
			var p = pts[i];
			double sx = (p.X - cx) * s + (viewport.Left + viewport.Width * 0.5);
			double sy = (p.Y - cy) * s + (viewport.Top + viewport.Height * 0.5);
			list[i] = new Vec2(sx, sy);
		}

		return list;
	}
	
	private static Vec2[] ToViewport(IReadOnlyList<Vec3> ndc, Rectangle vp)
	{
		// ndc: после проекции и деления на w (TransformPoint уже делит на w)
		// x_ndc, y_ndc ∈ [-1,1]; центр кадра — principal point
		double cx = vp.Left + vp.Width * 0.5;
		double cy = vp.Top  + vp.Height * 0.5;
		double sx = vp.Width * 0.5;
		double sy = vp.Height * 0.5;

		var outPts = new Vec2[ndc.Count];
		for (int i = 0; i < ndc.Count; i++)
		{
			var p = ndc[i];
			double x = cx + p.X * sx;
			double y = cy - p.Y * sy; // экранный Y вниз
			outPts[i] = new Vec2(x, y);
		}
		return outPts;
	}
}
