using MathPrimitives;
using System.Collections.Generic;
using System.Linq;

namespace Topology
{

    public readonly struct Face
    {
        public readonly int[] Indices;
        public Face(params int[] idx) { Indices = idx; }
    }

    public struct FaceVertexExt
    {
        public int V;
        public int VT;
        public int VN;

        public FaceVertexExt(int v, int vt, int vn)
        {
            V = v;
            VT = vt;
            VN = vn;
        }
    }

    public class FaceExt
    {
        public FaceVertexExt[] Vertices;
        public FaceExt(FaceVertexExt[] verts) => Vertices = verts;
    }

   
    public sealed class Polyhedron
    {
        public List<Vec3> Vertices = new();
        public readonly List<Face> Faces = new();

        public List<Vec2>? TextureCoords = null;
        public List<Vec3>? VertexNormals = null;
        public List<FaceExt>? FacesExt = null;

        public bool HasTexture => FacesExt != null && FacesExt.Count > 0;

        public Polyhedron() { }

        public Polyhedron(IEnumerable<Vec3> vertices, IEnumerable<Face> faces)
        {
            Vertices.AddRange(vertices);
            Faces.AddRange(faces);
        }

        public void GenerateVertexNormals(double creaseAngleDeg = 180.0, bool angleWeighted = true)
        {
            int n = Vertices.Count;
            var sums = new Vec3[n];
            var adj = new List<Vec3>[n];
            for (int i = 0; i < n; i++)
                adj[i] = new List<Vec3>();

            var faceNormals = new Vec3[Faces.Count];

            for (int fi = 0; fi < Faces.Count; fi++)
            {
                var idx = Faces[fi].Indices;
                if (idx.Length < 3) continue;

                var A = Vertices[idx[0]];
                Vec3 nrm = Vec3.Zero;

                for (int k = 1; k + 1 < idx.Length; k++)
                {
                    var B = Vertices[idx[k]];
                    var C = Vertices[idx[k + 1]];
                    nrm += Vec3Math.Cross(B - A, C - A);
                }

                nrm = nrm.Normalize();
                faceNormals[fi] = nrm;

                foreach (var vi in idx)
                    adj[vi].Add(nrm);
            }

            VertexNormals = new List<Vec3>(n);

            for (int vi = 0; vi < n; vi++)
            {
                if (adj[vi].Count == 0)
                {
                    VertexNormals.Add(Vec3.UnitY);
                    continue;
                }

                var avg = adj[vi].Aggregate(Vec3.Zero, (acc, fn) => acc + fn).Normalize();
                VertexNormals.Add(avg);
            }
        }

        public void GenerateSimpleTextureCoords()
        {
            TextureCoords = new List<Vec2>();
            foreach (var v in Vertices)
            {
                double u = (v.X + 1) / 2;
                double w = (v.Z + 1) / 2;
                TextureCoords.Add(new Vec2(u, w));
            }
        }

        public void GenerateTextureCoordsForRegularPolyhedron()
        {
            if (Vertices.Count == 4 || Vertices.Count == 6 || Vertices.Count == 8)
                GenerateSimpleTextureCoords();
            else
                GenerateSimpleTextureCoords();
        }


        public static Polyhedron RegularTetrahedron(double scale = 1.0)
        {
            var v = new List<Vec3>
            {
                new(+1, +1, +1),
                new(-1, -1, +1),
                new(-1, +1, -1),
                new(+1, -1, -1)
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
                new(-1,-1,-1),
                new(+1,-1,-1),
                new(+1,+1,-1),
                new(-1,+1,-1),
                new(-1,-1,+1),
                new(+1,-1,+1),
                new(+1,+1,+1),
                new(-1,+1,+1),
            }.Select(p => p * scale).ToList();

            var faces = new List<Face>
            {
                new(0,1,2,3),
                new(4,5,6,7),
                new(0,4,5,1),
                new(3,7,6,2),
                new(0,3,7,4),
                new(1,5,6,2)
            };

            return new Polyhedron(v, faces);
        }

        public static Polyhedron RegularOctahedron(double scale = 1.0)
        {
            var v = new List<Vec3>
            {
                new(+1,0,0),
                new(-1,0,0),
                new(0,+1,0),
                new(0,-1,0),
                new(0,0,+1),
                new(0,0,-1)
            }.Select(p => p * scale).ToList();

            var faces = new List<Face>
            {
                new(4,0,2),
                new(4,2,1),
                new(4,1,3),
                new(4,3,0),
                new(5,2,0),
                new(5,1,2),
                new(5,3,1),
                new(5,0,3)
            };

            return new Polyhedron(v, faces);
        }

        public static Polyhedron RegularIcosahedron(double radius = 1.0)
        {
            double phi = (1 + Math.Sqrt(5)) * 0.5;
            double r = radius;
            double h = r * 0.5;
            double p = r * (0.5 + 1.0 / phi);

            var verts = new List<Vec3>();

            verts.Add(new Vec3(0, +p, 0));

            for (int k = 0; k < 5; k++)
            {
                double ang = 2 * Math.PI * k / 5;
                verts.Add(new Vec3(r * Math.Cos(ang), +h, r * Math.Sin(ang)));
            }

            for (int k = 0; k < 5; k++)
            {
                double ang = 2 * Math.PI * k / 5 + Math.PI / 5;
                verts.Add(new Vec3(r * Math.Cos(ang), -h, r * Math.Sin(ang)));
            }

            verts.Add(new Vec3(0, -p, 0));

            var faces = new List<Face>();

            int TOP = 0, BOT = 11, T0 = 1, B0 = 6;

            for (int k = 0; k < 5; k++)
                faces.Add(new Face(TOP, T0 + k, T0 + (k + 1) % 5));

            for (int k = 0; k < 5; k++)
            {
                int t0 = T0 + k;
                int t1 = T0 + (k + 1) % 5;
                int b0 = B0 + k;
                int b1 = B0 + (k + 1) % 5;

                faces.Add(new Face(t0, t1, b0));
                faces.Add(new Face(t1, b0, b1));
            }

            for (int k = 0; k < 5; k++)
                faces.Add(new Face(BOT, B0 + (k + 1) % 5, B0 + k));

            return new Polyhedron(verts, faces);
        }

        public static Polyhedron RegularDodecahedron(double scale = 1.0)
        {
            var ico = RegularIcosahedron(1.0);

            var dodeVerts = new List<Vec3>();

            foreach (var f in ico.Faces)
            {
                var a = ico.Vertices[f.Indices[0]];
                var b = ico.Vertices[f.Indices[1]];
                var c = ico.Vertices[f.Indices[2]];

                var center = new Vec3(
                    (a.X + b.X + c.X) / 3,
                    (a.Y + b.Y + c.Y) / 3,
                    (a.Z + b.Z + c.Z) / 3
                ).Normalize();

                dodeVerts.Add(center);
            }

            var facesByVertex = new List<int>[ico.Vertices.Count];
            for (int i = 0; i < facesByVertex.Length; i++)
                facesByVertex[i] = new List<int>();

            for (int fi = 0; fi < ico.Faces.Count; fi++)
                foreach (var vi in ico.Faces[fi].Indices)
                    facesByVertex[vi].Add(fi);

            var dodeFaces = new List<Face>();

            for (int vi = 0; vi < ico.Vertices.Count; vi++)
            {
                var v = ico.Vertices[vi];
                var n = v.Normalize();

                Vec3 tmp = Math.Abs(n.Z) < 0.9 ? new Vec3(0, 0, 1) : new Vec3(1, 0, 0);
                var u = Vec3Math.Cross(tmp, n).Normalize();
                var w = Vec3Math.Cross(n, u);

                var ordered = facesByVertex[vi]
                    .Select(fi =>
                    {
                        var p = dodeVerts[fi];
                        double x = Vec3Math.Dot(p, u);
                        double y = Vec3Math.Dot(p, w);
                        return (fi, Math.Atan2(y, x));
                    })
                    .OrderBy(t => t.Item2)
                    .Select(t => t.Item1)
                    .ToArray();

                dodeFaces.Add(new Face(ordered));
            }

            return new Polyhedron(dodeVerts.Select(v => v * scale), dodeFaces);
        }

        public Vec3 CalculateCenter()
        {
            if (Vertices.Count == 0) return Vec3.Zero;
            Vec3 sum = Vertices.Aggregate(Vec3.Zero, (a, b) => a + b);
            return sum / Vertices.Count;
        }
    }
}
