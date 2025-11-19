using MathPrimitives;
using System.Security.Cryptography.Xml;
using Topology;

namespace Renderer;

public enum ProjectionType { Perspective, Axonometric }

public enum RenderMode { Wireframe, ZBuffer, Gouraud, Phong, Textured }
public sealed class MeshRenderer
{
	public const double	StandardDistance = -200;
	public const int	GridExtent = 1000;
	public const double	StandardFOV = 70;
	public const double	StandardScale = 40;
	
	public ProjectionType	Projection	{ get; set; } = ProjectionType.Perspective;
	public RenderMode		RenderMode	{ get; set; } = RenderMode.Wireframe;
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
            UpdateViewTransform();
        }
	}

    public double YawDegrees
    {
        get => _yawDeg;
        set 
		{ 
			_yawDeg = value; 
			UpdateViewTransform(); 
		}
    }

    public double PitchDegrees
    {
        get => _pitchDeg;
        set
        {
            _pitchDeg = Math.Clamp(value, -89.9, 89.9);
            UpdateViewTransform();
        }
    }

    public Vec3 ViewDirection => _viewDir;

	// Texture settings
    public Texture	CurrentTexture		{ get; set; }
    public bool		UseTexture			{ get; set; } = false;
    public bool		UseBilinearFilter	{ get; set; } = true;

    // Drawing settings
    public bool		Wireframe			{ get; set; } = true;
	public Pen		WirePen				{ get; set; } = Pens.Black;
	public Brush	VertexBrush			{ get; set; } = Brushes.Firebrick;
	public float	VertexRadius		{ get; set; } = 3f;
	
	// Grid settings
	public bool		ShowGrid			{ get; set; } = true;
	public double	GridSpacing			{ get; set; } = 20.0; // шаг сетки в мировых единицах
	public Pen		GridPen				{ get; set; } = Pens.Silver;
	public Pen		AxisPen				{ get; set; } = Pens.DimGray;
	
    // Backface culling
    public bool		CullBackFaces		{ get; set; } = true;
	public bool		DrawBackVertices	{ get; set; } = false;

    // Normals
    public bool		ShowFaceNormals 	{ get; set; } = false;
    public Pen		NormalPen			{ get; set; } = Pens.MediumVioletRed;
    public double	NormalLength		{ get; set; } = 20.0;

    // Lighting
    public Vec3		LightPosition   	{ get; set; } = new Vec3(200, 200, 200);
    public Color	ObjectColor    		{ get; set; } = Color.CornflowerBlue;
    public double	Ambient       		{ get; set; } = 0.15;
    public double	SpecularStrength	{ get; set; } = 0.5; 
    public double	SpecularExponent	{ get; set; } = 32.0; 

	// Private fields
	private double	_distance	= StandardDistance;
	private Vec3	_viewDir	= new Vec3(0, 0, -1);
	private double	_yawDeg		= 45.0;
	private double	_pitchDeg	= 35.26438968;

	private double[,]	_zBuffer;
	private Color[,]	_colorBuffer;
	private bool		_zBufferInitialized = false;
	
    public MeshRenderer()
	{
        UpdateViewTransform();

        CurrentTexture = Texture.Checkerboard();
    }
	
	public void ApplyModelTransformWorld(Mat4 m) => ModelTransform = m * ModelTransform;
	public void ApplyModelTransformLocal(Mat4 m) => ModelTransform = ModelTransform * m;

	public void ResetView()
	{
		ModelTransform = Mat4.Identity;
		ViewTransform  = Mat4.Translation(0, 0, _distance);
        _yawDeg = 45.0;
        _pitchDeg = 35.26438968;
    }
	
	public Vec3[] CurModelTransform() => Model.Vertices.Select(v => ModelTransform.TransformPoint(v)).ToArray();

    public void Render(Graphics g, Rectangle viewport)
    {
        if (Model is null || Model.Vertices.Count == 0) return;

        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        var viewWorld = ViewTransform;
        var world = viewWorld * ModelTransform;
        var transformed = Model.Vertices.Select(v => world.TransformPoint(v)).ToArray();
        Mat4 proj;

        Vec2[] screen;
        Vec3[] ndc = null;

        if (Projection == ProjectionType.Perspective)
        {
            const double deg = Math.PI / 180.0;
            var aspect = (double)viewport.Width / Math.Max(1, viewport.Height);
            proj = Mat4.PerspectiveFovY(fovYdeg: FOV, aspect: aspect, zn: 0.1, zf: 100000);
            ndc = transformed.Select(v => proj.TransformPoint(v)).ToArray();
            screen = ToViewport(ndc, viewport);
        }
        else
        {
            var aspect = (double)viewport.Width / Math.Max(1, viewport.Height);
            double vHalf = 80.0;
            double hHalf = vHalf * aspect;
            proj = Mat4.Orthographic(-hHalf, hHalf, -vHalf, vHalf, zn: -1000, zf: 1000);
            ndc = transformed.Select(v => proj.TransformPoint(v)).ToArray();
            screen = ToViewport(ndc, viewport);
        }

		bool zMode =
			RenderMode == RenderMode.ZBuffer ||
			RenderMode == RenderMode.Gouraud ||
			RenderMode == RenderMode.Phong  ||
			RenderMode == RenderMode.Textured;

		if (ShowGrid && !zMode)
		{
			DrawGridXZ(g, viewport, viewWorld, proj);
		}


		Color[]? vertexColors = null;
		if (RenderMode == RenderMode.Gouraud)
		{
			// world = ViewTransform * ModelTransform — модель→вид
			vertexColors = ComputeLambertVertexColors(world, transformed);
		}

		if (RenderMode == RenderMode.ZBuffer)
		{
			RenderZBuffer(g, viewport, transformed, screen, ndc, proj);
		}
		else if (RenderMode == RenderMode.Gouraud)
		{
			RenderGouraudZ(g, viewport, transformed, screen, ndc, proj, vertexColors!);
		}
		else if (RenderMode == RenderMode.Phong)
		{
			if (Model.VertexNormals == null || Model.VertexNormals.Count != Model.Vertices.Count)
				Model.GenerateVertexNormals();

			var modelToViewPhong = viewWorld * ModelTransform;
			var vertexNormalsViewPhong =
				Model.VertexNormals.Select(n => modelToViewPhong.TransformDirection(n).Normalize()).ToArray();

			RenderPhongZ(g, viewport, transformed, screen, ndc, proj, vertexNormalsViewPhong);
		}
		else if (RenderMode == RenderMode.Textured)
		{
			RenderTextured(g, viewport, transformed, screen, ndc, proj);
		}
		else
		{
			RenderWireframe(g, viewport, transformed, screen, ndc, proj);
		}

    }

    #region Gouraud
    //---------------------------------------------------- GOURAUD ----------------------------------------------------
    private static Color ShadeColor(Color baseColor, double intensity)
    {
        intensity = Math.Clamp(intensity, 0.0, 1.0);
        int r = (int)(baseColor.R * intensity);
        int g = (int)(baseColor.G * intensity);
        int b = (int)(baseColor.B * intensity);
        return Color.FromArgb(r, g, b);
    }

    private Color[] ComputeLambertVertexColors(in Mat4 modelToView, Vec3[] vertsView)
    {
        if (Model == null)
            return Array.Empty<Color>();

        if (Model.VertexNormals == null || Model.VertexNormals.Count != Model.Vertices.Count)
            Model.GenerateVertexNormals();

        var lightView = ViewTransform.TransformPoint(LightPosition);

        var colors = new Color[Model.Vertices.Count];

        for (int i = 0; i < Model.Vertices.Count; i++)
        {
            var nModel = Model.VertexNormals![i];
            var nView = modelToView.TransformDirection(nModel).Normalize();

            var posView = vertsView[i];
            var L = (lightView - posView).Normalize();

            double ndotl = Math.Max(0.0, Vec3Math.Dot(nView, L));

            // I = Ia + Id = Ambient + (1 - Ambient) * max(0, N·L)
            double intensity = Ambient + (1.0 - Ambient) * ndotl;

            colors[i] = ShadeColor(ObjectColor, intensity);
        }

        return colors;
    }

	private void RenderGouraudZ(Graphics g, Rectangle viewport,
								Vec3[] transformed,
								Vec2[] screen, Vec3[] ndc, Mat4 proj,
								Color[] vertexColors)
	{
		if (Model == null) return;

		int width  = viewport.Width;
		int height = viewport.Height;

		ClearZBuffer(width, height);

		// Сетка тоже через Z-буфер, чтобы пряталась за моделью
		if (ShowGrid)
		{
			RenderGridXZ_ZBuffered(viewport, ViewTransform, proj);
		}

		foreach (var face in Model.Faces)
		{
			if (CullBackFaces && !IsFaceFrontFacing(face, transformed, Projection))
				continue;

			var idx = face.Indices;
			if (idx.Length < 3) continue;

			// Фан-триангуляция
			for (int i = 1; i + 1 < idx.Length; i++)
			{
				int i0 = idx[0];
				int i1 = idx[i];
				int i2 = idx[i + 1];

				var p0 = screen[i0];
				var p1 = screen[i1];
				var p2 = screen[i2];

				var c0 = vertexColors[i0];
				var c1 = vertexColors[i1];
				var c2 = vertexColors[i2];

				double z0 = ndc[i0].Z;
				double z1 = ndc[i1].Z;
				double z2 = ndc[i2].Z;

				RasterizeTriangleGouraudZ(p0, p1, p2,
					z0, z1, z2,
					c0, c1, c2,
					viewport);
			}
		}

		DisplayZBuffer(g, viewport);
	}


    private void RasterizeTriangleGouraudZ(
    	Vec2 p0, Vec2 p1, Vec2 p2,
    	double z0, double z1, double z2,
    	Color c0, Color c1, Color c2,
    	Rectangle viewport)
	{
	    double minX = Math.Max(viewport.Left,  Math.Min(p0.X, Math.Min(p1.X, p2.X)));
	    double maxX = Math.Min(viewport.Right - 1, Math.Max(p0.X, Math.Max(p1.X, p2.X)));
	    double minY = Math.Max(viewport.Top,   Math.Min(p0.Y, Math.Min(p1.Y, p2.Y)));
	    double maxY = Math.Min(viewport.Bottom - 1, Math.Max(p0.Y, Math.Max(p1.Y, p2.Y)));
	
	    if (minX > maxX || minY > maxY) return;
	
	    int startX = (int)Math.Floor(minX);
	    int endX   = (int)Math.Ceiling(maxX);
	    int startY = (int)Math.Floor(minY);
	    int endY   = (int)Math.Ceiling(maxY);
	
	    double area = EdgeFunction(p0, p1, p2);
	    if (Math.Abs(area) < 1e-12) return;
	
	    const double eps = -1e-6;
	
	    for (int y = startY; y <= endY; y++)
	    {
	        for (int x = startX; x <= endX; x++)
	        {
	            var p = new Vec2(x + 0.5, y + 0.5);
	
	            double w0 = EdgeFunction(p1, p2, p) / area;
	            double w1 = EdgeFunction(p2, p0, p) / area;
	            double w2 = EdgeFunction(p0, p1, p) / area;
	
	            if (w0 >= eps && w1 >= eps && w2 >= eps)
	            {
	                double z = w0 * z0 + w1 * z1 + w2 * z2;
	
	                if (x < 0 || x >= _zBuffer.GetLength(0) ||
	                    y < 0 || y >= _zBuffer.GetLength(1))
	                    continue;
	
	                if (z < _zBuffer[x, y])
	                {
	                    _zBuffer[x, y] = z;
	
	                    double r = w0 * c0.R + w1 * c1.R + w2 * c2.R;
	                    double gCol = w0 * c0.G + w1 * c1.G + w2 * c2.G;
	                    double b = w0 * c0.B + w1 * c1.B + w2 * c2.B;
	
	                    int ir = (int)Math.Clamp(r,    0.0, 255.0);
	                    int ig = (int)Math.Clamp(gCol, 0.0, 255.0);
	                    int ib = (int)Math.Clamp(b,    0.0, 255.0);
	
	                    _colorBuffer[x, y] = Color.FromArgb(ir, ig, ib);
	                }
	            }
	        }
	    }
	}
	
    #endregion

    #region Phong Shading
	//---------------------------------------------------- PHONG ----------------------------------------------------
    private Color ShadeNormalAtPoint(in Vec3 normalView, in Vec3 posView, in Vec3 lightView, in Vec3 viewDir)
    {
        // Источник света
        var L = (lightView - posView).Normalize();
        var N = normalView;
        var R = Vec3Math.Reflect(-L, N);
        var V = (-viewDir).Normalize();

        double ndotl = Math.Max(0.0, Vec3Math.Dot(N, L));

        double diffuse = ndotl;

        var H = (L + V).Normalize();
        double ndoth = Math.Max(0.0, Vec3Math.Dot(N, H));
        double specular = Math.Pow(ndoth, SpecularExponent);

        // I = Ia + Id + Is = Ambient + Diffuse * (1 - Ambient) + Specular * SpecularStrength
        double intensity = Ambient + diffuse * (1.0 - Ambient) + specular * SpecularStrength;

        intensity = Math.Clamp(intensity, 0.0, 1.0);

        int r = (int)(ObjectColor.R * intensity);
        int g = (int)(ObjectColor.G * intensity);
        int b = (int)(ObjectColor.B * intensity);

        return Color.FromArgb(Math.Min(255, r), Math.Min(255, g), Math.Min(255, b));
    }

    private void RasterizeTrianglePhongZ(
	    Vec2 p0, Vec2 p1, Vec2 p2,
	    double z0, double z1, double z2,
	    Vec3 n0, Vec3 n1, Vec3 n2,
	    Vec3 v0, Vec3 v1, Vec3 v2,
	    Vec3 lightView,
	    Vec3 viewDir,
	    Rectangle viewport)
	{
	    double minX = Math.Max(viewport.Left,  Math.Min(p0.X, Math.Min(p1.X, p2.X)));
	    double maxX = Math.Min(viewport.Right - 1, Math.Max(p0.X, Math.Max(p1.X, p2.X)));
	    double minY = Math.Max(viewport.Top,   Math.Min(p0.Y, Math.Min(p1.Y, p2.Y)));
	    double maxY = Math.Min(viewport.Bottom - 1, Math.Max(p0.Y, Math.Max(p1.Y, p2.Y)));
	
	    if (minX > maxX || minY > maxY) return;
	
	    int x0 = (int)Math.Floor(minX);
	    int x1 = (int)Math.Ceiling(maxX);
	    int y0 = (int)Math.Floor(minY);
	    int y1 = (int)Math.Ceiling(maxY);
	
	    double area = EdgeFunction(p0, p1, p2);
	    if (Math.Abs(area) < 1e-12) return;
	
	    const double eps = -1e-6;
	
	    for (int y = y0; y <= y1; y++)
	    {
	        for (int x = x0; x <= x1; x++)
	        {
	            var p = new Vec2(x + 0.5, y + 0.5);
	
	            double w0 = EdgeFunction(p1, p2, p) / area;
	            double w1 = EdgeFunction(p2, p0, p) / area;
	            double w2 = EdgeFunction(p0, p1, p) / area;
	
	            if (w0 >= eps && w1 >= eps && w2 >= eps)
	            {
	                double z = w0 * z0 + w1 * z1 + w2 * z2;
	
	                if (x < 0 || x >= _zBuffer.GetLength(0) ||
	                    y < 0 || y >= _zBuffer.GetLength(1))
	                    continue;
	
	                if (z < _zBuffer[x, y])
	                {
	                    _zBuffer[x, y] = z;
	
	                    // Интерполяция позиции и нормали в видовых координатах
	                    var posView = w0 * v0 + w1 * v1 + w2 * v2;
	                    var nViewUnnormalized = w0 * n0 + w1 * n1 + w2 * n2;
	                    var nView = Vec3Math.Normalize(nViewUnnormalized);
	
	                    Color c = ShadeNormalAtPoint(nView, posView, lightView, viewDir);
	                    _colorBuffer[x, y] = c;
	                }
	            }
	        }
	    }
	}


	private void RenderPhongZ(Graphics g, Rectangle viewport,
							  Vec3[] transformed,
							  Vec2[] screen, Vec3[] ndc, Mat4 proj,
							  Vec3[] vertexNormalsView)
	{
		if (Model == null) return;

		int width  = viewport.Width;
		int height = viewport.Height;

		ClearZBuffer(width, height);

		if (ShowGrid)
		{
			RenderGridXZ_ZBuffered(viewport, ViewTransform, proj);
		}

		var lightView = ViewTransform.TransformPoint(LightPosition);
		var viewDir   = new Vec3(0, 0, 1);

		foreach (var face in Model.Faces)
		{
			if (CullBackFaces && !IsFaceFrontFacing(face, transformed, Projection))
				continue;

			var idx = face.Indices;
			if (idx.Length < 3) continue;

			for (int i = 1; i + 1 < idx.Length; i++)
			{
				int i0 = idx[0];
				int i1 = idx[i];
				int i2 = idx[i + 1];

				var p0 = screen[i0];
				var p1 = screen[i1];
				var p2 = screen[i2];

				var n0 = vertexNormalsView[i0];
				var n1 = vertexNormalsView[i1];
				var n2 = vertexNormalsView[i2];

				var v0 = transformed[i0]; // уже в view-space
				var v1 = transformed[i1];
				var v2 = transformed[i2];

				double z0 = ndc[i0].Z;
				double z1 = ndc[i1].Z;
				double z2 = ndc[i2].Z;

				RasterizeTrianglePhongZ(
					p0, p1, p2,
					z0, z1, z2,
					n0, n1, n2,
					v0, v1, v2,
					lightView,
					viewDir,
					viewport);
			}
		}

		DisplayZBuffer(g, viewport);
	}

    #endregion
	
	# region Grid
	//---------------------------------------------------- GRID ----------------------------------------------------
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
	
	private void RenderGridXZ_ZBuffered(Rectangle vp, in Mat4 world, in Mat4 proj)
	{
		int n = GridExtent;
		double s = GridSpacing;

		for (int i = -n; i <= n; i++)
		{
			bool isAxis = (i == 0);
			Color col = (isAxis ? AxisPen : GridPen).Color;

			// X-параллельная линия
			var a = new Vec3(-n * s, 0, i * s);
			var b = new Vec3( n * s, 0, i * s);
			DrawSegment3D_ZBuffered(vp, in a, in b, in world, in proj, col);

			// Z-параллельная линия
			a = new Vec3(i * s, 0, -n * s);
			b = new Vec3(i * s, 0,  n * s);
			DrawSegment3D_ZBuffered(vp, in a, in b, in world, in proj, col);
		}
	}
	
	private void DrawSegment3D_ZBuffered(Rectangle vp,
										 in Vec3 a, in Vec3 b,
										 in Mat4 world, in Mat4 proj,
										 Color color)
	{
		var m = proj * world;

		var A = m.TransformPointToVec4(a);
		var B = m.TransformPointToVec4(b);

		if (!ClipSegmentInClipSpace(A, B, out var CA, out var CB))
			return;

		var pA = ClipToScreen(CA, vp);
		var pB = ClipToScreen(CB, vp);

		const double eps = 1e-12;
		double invWA = Math.Abs(CA.W) > eps ? 1.0 / CA.W : 0.0;
		double invWB = Math.Abs(CB.W) > eps ? 1.0 / CB.W : 0.0;

		double zA = CA.Z * invWA;
		double zB = CB.Z * invWB;

		RasterizeLineZBuffer(pA, pB, zA, zB, color, vp);
	}
	
	private void RasterizeLineZBuffer(Vec2 p0, Vec2 p1,
									  double z0, double z1,
									  Color color,
									  Rectangle viewport)
	{
		int width  = viewport.Width;
		int height = viewport.Height;

		double x0 = p0.X;
		double y0 = p0.Y;
		double x1 = p1.X;
		double y1 = p1.Y;

		double dx = x1 - x0;
		double dy = y1 - y0;

		int steps = (int)Math.Ceiling(Math.Max(Math.Abs(dx), Math.Abs(dy)));
		if (steps <= 0) return;

		double sx = dx / steps;
		double sy = dy / steps;
		double sz = (z1 - z0) / steps;

		double x = x0;
		double y = y0;
		double z = z0;

		for (int i = 0; i <= steps; i++)
		{
			int ix = (int)Math.Round(x);
			int iy = (int)Math.Round(y);

			if (ix >= 0 && ix < width && iy >= 0 && iy < height)
			{
				// тот же критерий, что и у треугольников: чем меньше Z, тем ближе
				if (z < _zBuffer[ix, iy])
				{
					_zBuffer[ix, iy]   = z;
					_colorBuffer[ix, iy] = color;
				}
			}

			x += sx;
			y += sy;
			z += sz;
		}
	}
	#endregion

    #region Backface culling
	//---------------------------------------------------- BACKFACE CULLING ----------------------------------------------------
    private static bool TryComputeFaceCenterAndNormal(in Face face, Vec3[] vView,
                                                  out Vec3 center, out Vec3 normal)
    {
        var idx = face.Indices;
        center = Vec3.Zero;
        normal = Vec3.Zero;
        if (idx.Length < 3) return false;

        // центр – среднее по вершинам (в видовых координатах)
        for (int i = 0; i < idx.Length; i++)
            center += vView[idx[i]];
        center = center / idx.Length;

        // нормаль – фан-триангуляция (в видовых координатах)
        var a = vView[idx[0]];
        for (int k = 1; k + 1 < idx.Length; k++)
        {
            var b = vView[idx[k]];
            var c = vView[idx[k + 1]];
            normal += Vec3Math.Cross(b - a, c - a);
        }
        normal = normal.Normalize();
        return normal != Vec3.Zero;
    }

    // Возвращает true, если грань фронт-фейсна (видима)
    private static bool IsFaceFrontFacing(in Face face, Vec3[] vView, ProjectionType projType)
    {
        if (!TryComputeFaceCenterAndNormal(face, vView, out var c, out var n)) return false;

        if (projType == ProjectionType.Perspective)
        {
            // камера в начале координат видового пространства, направление к камере ~ (-c)
            // фронт-фейс, если нормаль направлена к камере: dot(n, -c) > 0  <=> dot(n, c) < 0
            return Vec3Math.Dot(n, c) < 0.0;
        }
        else
        {
            // ортографическая проекция: постоянное направление взгляда (0,0,-1) в видовом
            return Vec3Math.Dot(n, new Vec3(0, 0, -1)) < 0.0;
        }
    }


    #endregion
	
	#region ZBuffer
	//---------------------------------------------------- ZBuffer ----------------------------------------------------
    private void InitializeZBuffer(int width, int height)
    {
        _zBuffer = new double[width, height];
        _colorBuffer = new Color[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                _zBuffer[x, y] = double.MaxValue;
                _colorBuffer[x, y] = Color.White; // фон
            }
        }
        _zBufferInitialized = true;
    }

    private void ClearZBuffer(int width, int height)
    {
        if (!_zBufferInitialized || _zBuffer.GetLength(0) != width || _zBuffer.GetLength(1) != height)
        {
            InitializeZBuffer(width, height);
            return;
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                _zBuffer[x, y] = double.MaxValue;
                _colorBuffer[x, y] = Color.White;
            }
        }
    }

	private void RenderZBuffer(Graphics g, Rectangle viewport,
							   Vec3[] transformed, Vec2[] screen, Vec3[] ndc, Mat4 proj)
	{
		int width  = viewport.Width;
		int height = viewport.Height;

		ClearZBuffer(width, height);

		if (ShowGrid)
		{
			RenderGridXZ_ZBuffered(viewport, ViewTransform, proj);
		}

		foreach (var face in Model.Faces)
		{
			if (CullBackFaces && !IsFaceFrontFacing(face, transformed, Projection))
				continue;

			var idx = face.Indices;
			if (idx.Length < 3) continue;

			for (int i = 1; i + 1 < idx.Length; i++)
			{
				int i0 = idx[0];
				int i1 = idx[i];
				int i2 = idx[i + 1];

				var p0 = screen[i0];
				var p1 = screen[i1];
				var p2 = screen[i2];

				double z0 = ndc[i0].Z;
				double z1 = ndc[i1].Z;
				double z2 = ndc[i2].Z;

				var v0 = transformed[i0];
				var v1 = transformed[i1];
				var v2 = transformed[i2];

				var faceNormal = Vec3Math.Cross(v1 - v0, v2 - v0).Normalize();
				var lightDir   = (LightPosition - v0).Normalize();
				double intensity = Math.Max(0.1, Vec3Math.Dot(faceNormal, lightDir));

				Color faceColor = ShadeColor(ObjectColor, intensity);

				RasterizeTriangleZBuffer(p0, p1, p2, z0, z1, z2, faceColor, viewport);
			}
		}

		DisplayZBuffer(g, viewport);
	}



    private void RasterizeTriangleZBuffer(Vec2 p0, Vec2 p1, Vec2 p2, double z0, double z1, double z2, Color color, Rectangle viewport)
    {
        double minX = Math.Max(viewport.Left, Math.Min(p0.X, Math.Min(p1.X, p2.X)));
        double maxX = Math.Min(viewport.Right - 1, Math.Max(p0.X, Math.Max(p1.X, p2.X)));
        double minY = Math.Max(viewport.Top, Math.Min(p0.Y, Math.Min(p1.Y, p2.Y)));
        double maxY = Math.Min(viewport.Bottom - 1, Math.Max(p0.Y, Math.Max(p1.Y, p2.Y)));

        if (minX > maxX || minY > maxY) return;

        int startX = (int)Math.Floor(minX);
        int endX = (int)Math.Ceiling(maxX);
        int startY = (int)Math.Floor(minY);
        int endY = (int)Math.Ceiling(maxY);

        double area = EdgeFunction(p0, p1, p2);
        if (Math.Abs(area) < 1e-12) return;

        for (int y = startY; y <= endY; y++)
        {
            for (int x = startX; x <= endX; x++)
            {
                Vec2 p = new Vec2(x + 0.5, y + 0.5);

                double w0 = EdgeFunction(p1, p2, p) / area;
                double w1 = EdgeFunction(p2, p0, p) / area;
                double w2 = EdgeFunction(p0, p1, p) / area;

                if (w0 >= -1e-6 && w1 >= -1e-6 && w2 >= -1e-6)
                {
                    double z = w0 * z0 + w1 * z1 + w2 * z2;

                    if (x >= 0 && x < _zBuffer.GetLength(0) && y >= 0 && y < _zBuffer.GetLength(1))
                    {
                        if (z < _zBuffer[x, y])
                        {
                            _zBuffer[x, y] = z;
                            _colorBuffer[x, y] = color;
                        }
                    }
                }
            }
        }
    }

    // Отображение содержимого Z-буфера
    private void DisplayZBuffer(Graphics g, Rectangle viewport)
    {
        using (var bitmap = new Bitmap(viewport.Width, viewport.Height))
        {
            for (int y = 0; y < viewport.Height; y++)
            {
                for (int x = 0; x < viewport.Width; x++)
                {
                    bitmap.SetPixel(x, y, _colorBuffer[x, y]);
                }
            }
            g.DrawImage(bitmap, viewport.Left, viewport.Top);
        }
    }
	#endregion
	
	#region Textured render
	//---------------------------------------------------- TEXTURED RENDER ----------------------------------------------------
    private void RenderTextured(Graphics g, Rectangle viewport, Vec3[] transformed,
                             Vec2[] screen, Vec3[] ndc, Mat4 proj)
    {
        if (Model?.TextureCoords == null || Model.TextureCoords.Count != Model.Vertices.Count)
        {
            Model?.GenerateSimpleTextureCoords();
        }

        int width = viewport.Width;
        int height = viewport.Height;

        ClearZBuffer(width, height);
		
		if (ShowGrid)
		{
			RenderGridXZ_ZBuffered(viewport, ViewTransform, proj);
		}

        foreach (var face in Model.Faces)
        {
            if (CullBackFaces && !IsFaceFrontFacing(face, transformed, Projection))
                continue;

            var idx = face.Indices;
            if (idx.Length < 3) continue;

            for (int i = 1; i + 1 < idx.Length; i++)
            {
                int i0 = idx[0];
                int i1 = idx[i];
                int i2 = idx[i + 1];

                var p0 = screen[i0];
                var p1 = screen[i1];
                var p2 = screen[i2];

                double z0 = ndc[i0].Z;
                double z1 = ndc[i1].Z;
                double z2 = ndc[i2].Z;

                var uv0 = Model.TextureCoords[i0];
                var uv1 = Model.TextureCoords[i1];
                var uv2 = Model.TextureCoords[i2];

                RasterizeTexturedTriangle(p0, p1, p2, z0, z1, z2, uv0, uv1, uv2, viewport);
            }
        }

        DisplayZBuffer(g, viewport);
    }

    private void RasterizeTexturedTriangle(Vec2 p0, Vec2 p1, Vec2 p2,
                                         double z0, double z1, double z2,
                                         Vec2 uv0, Vec2 uv1, Vec2 uv2,
                                         Rectangle viewport)
    {
        double minX = Math.Max(viewport.Left, Math.Min(p0.X, Math.Min(p1.X, p2.X)));
        double maxX = Math.Min(viewport.Right - 1, Math.Max(p0.X, Math.Max(p1.X, p2.X)));
        double minY = Math.Max(viewport.Top, Math.Min(p0.Y, Math.Min(p1.Y, p2.Y)));
        double maxY = Math.Min(viewport.Bottom - 1, Math.Max(p0.Y, Math.Max(p1.Y, p2.Y)));

        if (minX > maxX || minY > maxY) return;

        int startX = (int)Math.Floor(minX);
        int endX = (int)Math.Ceiling(maxX);
        int startY = (int)Math.Floor(minY);
        int endY = (int)Math.Ceiling(maxY);

        double area = EdgeFunction(p0, p1, p2);
        if (Math.Abs(area) < 1e-12) return;

        for (int y = startY; y <= endY; y++)
        {
            for (int x = startX; x <= endX; x++)
            {
                Vec2 p = new Vec2(x + 0.5, y + 0.5);

                double w0 = EdgeFunction(p1, p2, p) / area;
                double w1 = EdgeFunction(p2, p0, p) / area;
                double w2 = EdgeFunction(p0, p1, p) / area;

                if (w0 >= -1e-6 && w1 >= -1e-6 && w2 >= -1e-6)
                {
                    double z = w0 * z0 + w1 * z1 + w2 * z2;

                    // ИНТЕРПОЛЯЦИЯ UV-КООРДИНАТ
                    double u = w0 * uv0.X + w1 * uv1.X + w2 * uv2.X;
                    double v = w0 * uv0.Y + w1 * uv1.Y + w2 * uv2.Y;

                    if (x >= 0 && x < _zBuffer.GetLength(0) && y >= 0 && y < _zBuffer.GetLength(1))
                    {
                        if (z < _zBuffer[x, y])
                        {
                            _zBuffer[x, y] = z;

                            // СЕМПЛИРОВАНИЕ ТЕКСТУРЫ
                            Color texColor = UseBilinearFilter
                                ? CurrentTexture.SampleBilinear(u, v)
                                : CurrentTexture.Sample(u, v);

                            _colorBuffer[x, y] = texColor;
                        }
                    }
                }
            }
        }
    }
	#endregion
	
	private static double EdgeFunction(Vec2 a, Vec2 b, Vec2 c)
	{
		return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
	}
	
	private static Vec2[] ToViewport(IReadOnlyList<Vec3> ndc, Rectangle vp)
	{
		double cx = vp.Left + vp.Width * 0.5;
		double cy = vp.Top  + vp.Height * 0.5;
		double sx = vp.Width * 0.5;
		double sy = vp.Height * 0.5;

		var outPts = new Vec2[ndc.Count];
		for (int i = 0; i < ndc.Count; i++)
		{
			var p = ndc[i];
			double x = cx + p.X * sx;
			double y = cy - p.Y * sy; 
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

	private void RenderWireframe(Graphics g, Rectangle viewport, Vec3[] transformed,
                                Vec2[] screen, Vec3[] ndc, Mat4 proj)
    {
        foreach (var face in Model.Faces)
        {
            if (CullBackFaces && !IsFaceFrontFacing(face, transformed, Projection))
                continue;

            for (int i = 0; i < face.Indices.Length; i++)
            {
                int a = face.Indices[i];
                int b = face.Indices[(i + 1) % face.Indices.Length];
                var pa = screen[a];
                var pb = screen[b];
                g.DrawLine(WirePen, (float)pa.X, (float)pa.Y, (float)pb.X, (float)pb.Y);
            }
        }

        bool[] vertexVisible;
        if (!CullBackFaces)
        {
            vertexVisible = Enumerable.Repeat(true, Model.Vertices.Count).ToArray();
        }
        else
        {
            vertexVisible = new bool[Model.Vertices.Count];
            foreach (var face in Model.Faces)
            {
                if (IsFaceFrontFacing(face, transformed, Projection))
                    foreach (var vi in face.Indices) vertexVisible[vi] = true;
            }
        }

        for (int i = 0; i < screen.Length; i++)
        {
            if (!vertexVisible[i])
                continue;

            var p = screen[i];
            g.FillEllipse(VertexBrush,
                (float)p.X - VertexRadius, (float)p.Y - VertexRadius,
                VertexRadius * 2, VertexRadius * 2);
        }

        if (ShowFaceNormals)
        {
            foreach (var face in Model.Faces)
            {
                if (!TryComputeFaceCenterAndNormal(face, transformed, out var c, out var n))
                    continue;
                if (CullBackFaces && !IsFaceFrontFacing(face, transformed, Projection))
                    continue;

                var tip = c + n * NormalLength;
                var cNdc = proj.TransformPoint(c);
                var tipNdc = proj.TransformPoint(tip);

                var cScr = ToViewport(cNdc, viewport);
                var tipScr = ToViewport(tipNdc, viewport);

                g.DrawLine(NormalPen, (float)cScr.X, (float)cScr.Y, (float)tipScr.X, (float)tipScr.Y);
            }
        }
    }
	
	private static bool ClipSegmentInClipSpace(in Vec4 A, in Vec4 B, out Vec4 CA, out Vec4 CB)
	{
		double t0 = 0.0, t1 = 1.0;
		double dx = B.X - A.X, dy = B.Y - A.Y, dz = B.Z - A.Z, dw = B.W - A.W;

		static bool ClipOne(double p, double q, ref double t0, ref double t1)
		{
			const double eps = 1e-12;
			if (Math.Abs(p) < eps) return q >= 0;   
			double t = q / p;
			if (p < 0) { if (t > t0) t0 = t; if (t0 > t1) return false; }
			else       { if (t < t1) t1 = t; if (t0 > t1) return false; } 
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
	
	private static Vec2 ClipToScreen(in Vec4 c, Rectangle vp)
	{
	    const double eps = 1e-12;
	    double invW = Math.Abs(c.W) > eps ? 1.0 / c.W : 0.0;
	    double xN = c.X * invW, yN = c.Y * invW;
	    double cx = vp.Left + vp.Width * 0.5, cy = vp.Top + vp.Height * 0.5;
	    double sx = vp.Width * 0.5, sy = vp.Height * 0.5;
	    return new Vec2(cx + xN * sx, cy - yN * sy);
	}

    private void UpdateViewTransform()
    {
        const double deg = Math.PI / 180.0;

        var ry = Mat4.RotationY(_yawDeg * deg);
        var rx = Mat4.RotationX(_pitchDeg * deg);

        ViewTransform = Mat4.Translation(0, 0, _distance) * rx * ry;

        var forward = (ry * rx).TransformPoint(new Vec3(0, 0, -1));
        _viewDir = forward.Normalize();
    }
}