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
}