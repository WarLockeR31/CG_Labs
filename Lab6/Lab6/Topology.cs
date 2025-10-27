using MathPrimitives;

namespace Topology;

public readonly struct Face
{
	public readonly int[] Indices; // indices into Polyhedron.Vertices
	public Face(params int[] idx) { Indices = idx; }
}


public sealed class Polyhedron
{
	public List<Vec3> Vertices = new();
	public readonly List<Face> Faces = new();


	public Polyhedron(IEnumerable<Vec3> vertices, IEnumerable<Face> faces)
	{
		Vertices.AddRange(vertices);
		Faces.AddRange(faces);
	}

	public static Polyhedron RegularTetrahedron(double scale = 1.0)
	{
		// Symmetric tetra: corners of a cube with even number of negatives
		var v = new List<Vec3>
		{
			new (+1, +1, +1),
			new (-1, -1, +1),
			new (-1, +1, -1),
			new (+1, -1, -1)
		}.Select(p => p * scale).ToList();
		
		var faces = new List<Face>
		{
			new(0,1,2),
			new(0,3,1),
			new(0,2,3),
			new(1,3,2)
		};
		return new Polyhedron(v, faces);
	}
	
	public static Polyhedron RegularHexahedron(double scale = 1.0)
	{
		var v = new List<Vec3>
		{
			new(-1,-1,-1), // 0
			new(+1,-1,-1), // 1
			new(+1,+1,-1), // 2
			new(-1,+1,-1), // 3
			new(-1,-1,+1), // 4
			new(+1,-1,+1), // 5
			new(+1,+1,+1), // 6
			new(-1,+1,+1), // 7
		}.Select(p => p * scale).ToList();

		var faces = new List<Face>
		{
			new(0,1,2,3), // z = -1 
			new(4,5,6,7), // z = +1 
			new(0,4,5,1), // y = -1 
			new(3,7,6,2), // y = +1 
			new(0,3,7,4), // x = -1 
			new(1,5,6,2), // x = +1 
		};

		return new Polyhedron(v, faces);
	}

	public static Polyhedron RegularOctahedron(double scale = 1.0)
	{
		// Vertices on axis
		var v = new List<Vec3>
		{
			new(+1, 0, 0), // 0: +X
			new(-1, 0, 0), // 1: -X
			new(0, +1, 0), // 2: +Y
			new(0, -1, 0), // 3: -Y
			new(0, 0, +1), // 4: +Z 
			new(0, 0, -1), // 5: -Z 
		}.Select(p => p * scale).ToList();

		var faces = new List<Face>
		{
			// +Z
			new(4,0,2),
			new(4,2,1),
			new(4,1,3),
			new(4,3,0),

			// -Z
			new(5,2,0),
			new(5,1,2),
			new(5,3,1),
			new(5,0,3),
		};

		return new Polyhedron(v, faces);
	}
	
	public static Polyhedron RegularIcosahedron(double radius = 1.0)
	{
		double phi = (1.0 + Math.Sqrt(5.0)) * 0.5; // золотое сечение
		double r = radius;           // радиус колец (цилиндра)
		double h = r * 0.5;          // высота колец
		double p = r * (0.5 + 1.0 / phi); // полюса

		var verts = new List<Vec3>(12);

		// Vertices: Top
		verts.Add(new Vec3(0, +p, 0)); // 0

		// Vertices: Top circle
		for (int k = 0; k < 5; k++)
		{
			double ang = 2.0 * Math.PI * k / 5.0;
			verts.Add(new Vec3(r * Math.Cos(ang), +h, r * Math.Sin(ang))); // 1..5
		}

		// Vertices: Bottom circle
		for (int k = 0; k < 5; k++)
		{
			double ang = 2.0 * Math.PI * k / 5.0 + Math.PI / 5.0;
			verts.Add(new Vec3(r * Math.Cos(ang), -h, r * Math.Sin(ang))); // 6..10
		}

		// Vertices: Bottom
		verts.Add(new Vec3(0, -p, 0)); // 11

		// Faces
		var faces = new List<Face>(20);

		int TOP = 0, BOT = 11, TOP0 = 1, BOT0 = 6;

		// TOP
		for (int k = 0; k < 5; k++)
			faces.Add(new Face(TOP, TOP0 + k, TOP0 + ((k + 1) % 5)));

		// Side
		for (int k = 0; k < 5; k++)
		{
			int t0 = TOP0 + k;
			int t1 = TOP0 + ((k + 1) % 5);
			int b0 = BOT0 + k;
			int b1 = BOT0 + ((k + 1) % 5);

			faces.Add(new Face(t0, t1, b0));
			faces.Add(new Face(t1, b0, b1));
		}

		// Bottom
		for (int k = 0; k < 5; k++)
			faces.Add(new Face(BOT, BOT0 + ((k + 1) % 5), BOT0 + k));

		return new Polyhedron(verts, faces);
	}

	public static Polyhedron RegularDodecahedron(double scale = 1.0)
	{
	    var ico = RegularIcosahedron(1.0);
	
	    // 1) Вершины додекаэдра = нормализованные центры граней икосаэдра
	    var dodeVerts = new List<Vec3>(ico.Faces.Count);
	
	    foreach (var f in ico.Faces)
	    {
	        var a = ico.Vertices[f.Indices[0]];
	        var b = ico.Vertices[f.Indices[1]];
	        var c = ico.Vertices[f.Indices[2]];
	        var center = new Vec3(
				(a.X + b.X + c.X) / 3.0,
				(a.Y + b.Y + c.Y) / 3.0,
				(a.Z + b.Z + c.Z) / 3.0)
				.Normalize();
	        dodeVerts.Add(center);
	    }
	
	    // 2) Грани додекаэдра = по вершине икосаэдра собираем 5 соседних граней и упорядочиваем их по углу вокруг нормали 
	    var facesByVertex = new List<int>[ico.Vertices.Count];
	    for (int i = 0; i < facesByVertex.Length; i++) 
			facesByVertex[i] = new List<int>();
	
	    for (int fi = 0; fi < ico.Faces.Count; fi++)
	    {
	        var f = ico.Faces[fi];
	        foreach (var vi in f.Indices)
				facesByVertex[vi].Add(fi);
	    }
	
	    var dodeFaces = new List<Face>(ico.Vertices.Count); // 12 пентагонов
	
	    for (int vi = 0; vi < ico.Vertices.Count; vi++)
	    {
	        var v = ico.Vertices[vi];
	        var n = v.Normalize(); 
	
	        // построим ортонормированный базис (u,v) на касательной плоскости к сфере в точке n
	        Vec3 tmp = Math.Abs(n.Z) < 0.9 ? new Vec3(0,0,1) : new Vec3(1,0,0);
	        var u = Vec3Math.Cross(tmp, n).Normalize();
	        var w = Vec3Math.Cross(n, u); 
	
	        var adj = facesByVertex[vi];
	        var ordered = adj
	            .Select(faceIndex =>
	            {
	                var p = dodeVerts[faceIndex];      
					
	                double x = Vec3Math.Dot(p, u);
	                double y = Vec3Math.Dot(p, w);
	                double ang = Math.Atan2(y, x);
	                return (faceIndex, ang);
	            })
	            .OrderBy(t => t.ang)
	            .Select(t => t.faceIndex)
	            .ToArray();
			
	        dodeFaces.Add(new Face(ordered));
	    }
	
	    var vertsScaled = dodeVerts.Select(p => p * scale).ToList();
	
	    return new Polyhedron(vertsScaled, dodeFaces);
	}
}