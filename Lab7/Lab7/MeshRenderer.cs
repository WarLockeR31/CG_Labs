using MathPrimitives;
using Topology;

namespace Renderer;

public enum ProjectionType { Perspective, Axonometric }

public sealed class MeshRenderer
{
	public	const double	StandardDistance = -200;
	public	const int		GridExtent = 1000;
	public	const double	StandardFOV = 70;
	public	const double	StandardScale = 40;
	
	public ProjectionType	Projection	{ get; set; } = ProjectionType.Perspective;
	public Polyhedron		Model		{ get; set; } = null;

	public Mat4		ModelTransform	{ get; set; } = Mat4.Identity;
	public Mat4		ViewTransform	{ get; set; } = Mat4.Translation(0, 0, StandardDistance);
	public double	FOV				{ get; set; } = StandardFOV;

	public double Distance
	{
		get => _distance;
		set
		{
			_distance = -value;
			ViewTransform = Mat4.Translation(0, 0, _distance);
		}
	}


	// Рисовальные настройки
	public bool		Wireframe		{ get; set; } = true;
	public Pen		WirePen			{ get; set; } = Pens.Black;
	public Brush	VertexBrush		{ get; set; } = Brushes.Firebrick;
	public float	VertexRadius	{ get; set; } = 3f;
	
	// Grid settings
	public bool		ShowGrid		{ get; set; } = true;
	public double	GridSpacing		{ get; set; } = 20.0; // шаг сетки в мировых единицах
	public Pen		GridPen			{ get; set; } = Pens.Silver;
	public Pen		AxisPen			{ get; set; } = Pens.DimGray;
	
	private double _distance = StandardDistance;

	public MeshRenderer()
	{
		//Model.Vertices = Model.Vertices.Select(x => x + Vec3.UnitX * 10 + Vec3.UnitY * 7).ToList();
	}
	
	public void ApplyModelTransformWorld(Mat4 m) => ModelTransform = m * ModelTransform;
	public void ApplyModelTransformLocal(Mat4 m) => ModelTransform = ModelTransform * m;

	public void ResetView()
	{
		ModelTransform = Mat4.Identity;
		ViewTransform  = Mat4.Translation(0, 0, _distance);
	}
	
	public Vec3[] CurModelTransform() => Model.Vertices.Select(v => ModelTransform.TransformPoint(v)).ToArray();
	
	public void Render(Graphics g, Rectangle viewport)
	{
		if (Model is null || Model.Vertices.Count == 0) return;


		g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

		var viewWorld = ViewTransform * Mat4.IsometricRotation();
		var world = viewWorld * ModelTransform;
		var transformed = Model.Vertices.Select(v => world.TransformPoint(v)).ToArray();
		Mat4 proj;

		Vec2[] screen;
		if (Projection == ProjectionType.Perspective)
		{
			const double deg = Math.PI / 180.0;
			var aspect = (double)viewport.Width / Math.Max(1, viewport.Height);
			proj   = Mat4.PerspectiveFovY(fovYdeg: FOV, aspect: aspect, zn: 0.1, zf: 100000); 

			var ndc = transformed.Select(v => proj.TransformPoint(v)).ToArray(); 
			screen = ToViewport(ndc, viewport);
		}
		else
		{
			var aspect = (double)viewport.Width / Math.Max(1, viewport.Height);

			double vHalf = 80.0;            // полувысота видимой области
			double hHalf = vHalf * aspect;  // ширина под аспект

			proj = Mat4.Orthographic(-hHalf, hHalf, -vHalf, vHalf, zn: -1000, zf: 1000);
			var ndc = transformed.Select(v => proj.TransformPoint(v)).ToArray();
			screen = ToViewport(ndc, viewport);
		}

		if (ShowGrid)
		{
			DrawGridXZ(g, viewport, viewWorld, proj);
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

	private static Vec2 ToViewport(Vec3 ndc, Rectangle vp)
	{
		double cx = vp.Left + vp.Width  * 0.5;
		double cy = vp.Top  + vp.Height * 0.5;
		double sx = vp.Width  * 0.5;
		double sy = vp.Height * 0.5;
		
		return new Vec2(cx + ndc.X * sx, cy - ndc.Y * sy);
	}

	private void DrawSegment3D(Graphics g, Rectangle vp, in Vec3 a, in Vec3 b, in Mat4 world, in Mat4 proj, Pen pen)
	{
		var A = (proj * world).TransformPointToVec4(a);
		var B = (proj * world).TransformPointToVec4(b);

		if (!ClipSegmentInClipSpace(A, B, out var CA, out var CB))
			return;

		var pA = ClipToScreen(CA, vp);
		var pB = ClipToScreen(CB, vp);
		g.DrawLine(pen, (float)pA.X, (float)pA.Y, (float)pB.X, (float)pB.Y);
	}

	private void DrawGridXZ(Graphics g, Rectangle vp, in Mat4 world, in Mat4 proj)
	{
		int n = GridExtent;
		double s = GridSpacing;

		for (int i = -n; i <= n; i++)
		{
			// X parallel
			var a = new Vec3(-n * s, 0, i * s);
			var b = new Vec3( n * s, 0, i * s);
			DrawSegment3D(g, vp, a, b, world, proj, i == 0 ? AxisPen : GridPen);

			// Z parallel
			a = new Vec3(i * s, 0, -n * s);
			b = new Vec3(i * s, 0,  n * s);
			DrawSegment3D(g, vp, a, b, world, proj, i == 0 ? AxisPen : GridPen);
		}
	}

	private static bool ClipSegmentInClipSpace(in Vec4 A, in Vec4 B, out Vec4 CA, out Vec4 CB)
	{
		double t0 = 0.0, t1 = 1.0;
		double dx = B.X - A.X, dy = B.Y - A.Y, dz = B.Z - A.Z, dw = B.W - A.W;

		// хотим p(t) = A + t*(B-A); для каждой плоскости вида  f(t) = n·p(t) ≤ 0
		// используем форму p*t ≤ q, где p = n·(B-A), q = -n·A  (эквивалентно «подвигаем» всё в A)
		static bool ClipOne(double p, double q, ref double t0, ref double t1)
		{
			const double eps = 1e-12;
			if (Math.Abs(p) < eps) return q >= 0;   // параллельно плоскости: либо весь внутри, либо весь вне
			double t = q / p;
			if (p < 0) { if (t > t0) t0 = t; if (t0 > t1) return false; } // входим
			else       { if (t < t1) t1 = t; if (t0 > t1) return false; } // выходим
			return true;
		}

		if (!ClipOne( dx - dw,  A.W - A.X, ref t0, ref t1)) { CA=default; CB=default; return false; } // x ≤ w
		if (!ClipOne(-dx - dw,  A.W + A.X, ref t0, ref t1)) { CA=default; CB=default; return false; } // x ≥ -w

		if (!ClipOne( dy - dw,  A.W - A.Y, ref t0, ref t1)) { CA=default; CB=default; return false; } // y ≤ w
		if (!ClipOne(-dy - dw,  A.W + A.Y, ref t0, ref t1)) { CA=default; CB=default; return false; } // y ≥ -w

		if (!ClipOne( dz - dw,  A.W - A.Z, ref t0, ref t1)) { CA=default; CB=default; return false; } // z ≤ w
		if (!ClipOne(-dz - dw,  A.W + A.Z, ref t0, ref t1)) { CA=default; CB=default; return false; } // z ≥ -w

		CA = new Vec4(A.X + dx*t0, A.Y + dy*t0, A.Z + dz*t0, A.W + dw*t0);
		CB = new Vec4(A.X + dx*t1, A.Y + dy*t1, A.Z + dz*t1, A.W + dw*t1);
		return true;
	}

	
	// Делим на w и в пиксели
	private static Vec2 ClipToScreen(in Vec4 c, Rectangle vp)
	{
	    const double eps = 1e-12;
	    double invW = Math.Abs(c.W) > eps ? 1.0 / c.W : 0.0;
	    double xN = c.X * invW, yN = c.Y * invW;
	    double cx = vp.Left + vp.Width * 0.5, cy = vp.Top + vp.Height * 0.5;
	    double sx = vp.Width * 0.5, sy = vp.Height * 0.5;
	    return new Vec2(cx + xN * sx, cy - yN * sy);
	}
}
