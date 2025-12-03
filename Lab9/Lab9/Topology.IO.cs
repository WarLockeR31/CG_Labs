using MathPrimitives;
using System.Globalization;
using Topology;   

namespace Topology.IO
{
    public static class ObjIO
    {
        private static readonly CultureInfo CI = CultureInfo.InvariantCulture;

        public static Polyhedron Load(string path)
        {
            using var r = new StreamReader(path);
            return Load(r);
        }

        private static Polyhedron Load(TextReader r)
        {
            var vertices = new List<Vec3>();
            var texcoords = new List<Vec2>();
            var normals = new List<Vec3>();

            var facesExt = new List<FaceExt>();   // новый формат (v/vt/vn)
            var facesOld = new List<Face>();      // старый формат (v)

            string? line;
            while ((line = r.ReadLine()) != null)
            {
                int hash = line.IndexOf('#');
                if (hash >= 0) line = line[..hash];
                line = line.Trim();
                if (line.Length == 0) continue;

                var parts = line.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;

                switch (parts[0])
                {
                    case "v":
                        vertices.Add(new Vec3(
                            double.Parse(parts[1], CI),
                            double.Parse(parts[2], CI),
                            double.Parse(parts[3], CI)
                        ));
                        break;

                    case "vt":
                        texcoords.Add(new Vec2(
                            double.Parse(parts[1], CI),
                            double.Parse(parts[2], CI)
                        ));
                        break;

                    case "vn":
                        normals.Add(new Vec3(
                            double.Parse(parts[1], CI),
                            double.Parse(parts[2], CI),
                            double.Parse(parts[3], CI)
                        ).Normalize());
                        break;

                    case "f":
                        {
                            bool hasVT = false;
                            bool hasVN = false;

                            var triplets = new List<FaceVertexExt>();
                            var oldFace = new List<int>();

                            for (int i = 1; i < parts.Length; i++)
                            {
                                var comp = parts[i].Split('/');

                                int v = ParseIndex(comp, 0, vertices.Count);
                                int vt = ParseIndex(comp, 1, texcoords.Count, allowMissing: true);
                                int vn = ParseIndex(comp, 2, normals.Count, allowMissing: true);

                                if (vt >= 0) hasVT = true;
                                if (vn >= 0) hasVN = true;

                                triplets.Add(new FaceVertexExt(v, vt, vn));
                                oldFace.Add(v);
                            }

                            if (hasVT || hasVN)
                                facesExt.Add(new FaceExt(triplets.ToArray()));
                            else
                                facesOld.Add(new Face(oldFace.ToArray()));

                            break;
                        }
                }
            }

            var poly = new Polyhedron
            {
                Vertices = vertices
            };

            if (texcoords.Count > 0)
                poly.TextureCoords = texcoords;

            if (normals.Count > 0)
                poly.VertexNormals = normals;

            if (facesExt.Count > 0)
                poly.FacesExt = facesExt;

            if (facesOld.Count > 0)
                poly.Faces.AddRange(facesOld);

            if (poly.VertexNormals == null)
                poly.GenerateVertexNormals();


            if (poly.FacesExt != null && poly.FacesExt.Count > 0)
            {
                poly.Faces.Clear();

                foreach (var fe in poly.FacesExt)
                {
                    var indices = fe.Vertices.Select(v => v.V).ToArray();
                    poly.Faces.Add(new Face(indices));
                }
            }


            return poly;
        }

        private static int ParseIndex(string[] arr, int idx, int count, bool allowMissing = false)
        {
            if (idx >= arr.Length)
                return allowMissing ? -1 : 0;

            if (string.IsNullOrWhiteSpace(arr[idx]))
                return allowMissing ? -1 : 0;

            int val = int.Parse(arr[idx], CI);

            if (val > 0) return val - 1;
            if (val < 0) return count + val;

            return 0;
        }

        public static void Save(Polyhedron poly, string path)
        {
            using var w = new StreamWriter(path);

            w.WriteLine("# Exported by MeshRenderer");
            w.WriteLine("# vertices: " + poly.Vertices.Count);

            foreach (var v in poly.Vertices)
                w.WriteLine($"v {v.X} {v.Y} {v.Z}");

            if (poly.TextureCoords != null)
            {
                foreach (var t in poly.TextureCoords)
                    w.WriteLine($"vt {t.X} {t.Y}");
            }

            if (poly.VertexNormals != null)
            {
                foreach (var n in poly.VertexNormals)
                    w.WriteLine($"vn {n.X} {n.Y} {n.Z}");
            }

            if (poly.FacesExt != null && poly.FacesExt.Count > 0)
            {
                foreach (var f in poly.FacesExt)
                {
                    w.Write("f");

                    foreach (var fv in f.Vertices)
                    {
                        int v = fv.V + 1;   
                        int vt = fv.VT >= 0 ? fv.VT + 1 : 0;
                        int vn = fv.VN >= 0 ? fv.VN + 1 : 0;

                        if (vt > 0 && vn > 0)
                            w.Write($" {v}/{vt}/{vn}");
                        else if (vt > 0)
                            w.Write($" {v}/{vt}");
                        else if (vn > 0)
                            w.Write($" {v}//{vn}");
                        else
                            w.Write($" {v}");
                    }

                    w.WriteLine();
                }
            }
            else
            {
                foreach (var f in poly.Faces)
                {
                    w.Write("f");
                    foreach (var vi in f.Indices)
                    {
                        int v = vi + 1;
                        w.Write($" {v}");
                    }
                    w.WriteLine();
                }
            }
        }

    }
}
