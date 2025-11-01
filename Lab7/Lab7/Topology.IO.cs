using System;
using System.Globalization;
using System.Text;
using MathPrimitives;

namespace Topology.IO
{
    public static class ObjIO
    {
        private static readonly CultureInfo CI = CultureInfo.InvariantCulture;

        // -------- Save --------

        public static void Save(Polyhedron mesh, string path)
        {
            using var w = new StreamWriter(path, false, new UTF8Encoding(false));
            Save(mesh, w);
        }

        public static void Save(Polyhedron mesh, Stream stream, bool leaveOpen = false)
        {
            using var w = new StreamWriter(stream, new UTF8Encoding(false), bufferSize: 1024, leaveOpen);
            Save(mesh, w);
        }

        private static void Save(Polyhedron mesh, TextWriter w)
        {
            w.WriteLine("# OBJ generated for Polyhedron");
            w.WriteLine($"# vertices: {mesh.Vertices.Count}, faces: {mesh.Faces.Count}");

            // v lines
            foreach (var v in mesh.Vertices)
            {
                w.Write("v ");
                w.Write(v.X.ToString("R", CI)); w.Write(' ');
                w.Write(v.Y.ToString("R", CI)); w.Write(' ');
                w.WriteLine(v.Z.ToString("R", CI));
            }

            // f lines
            foreach (var f in mesh.Faces)
            {
                var idx = f.Indices;
                if (idx is null || idx.Length < 3) continue;

                w.Write("f");
                for (int i = 0; i < idx.Length; i++)
                {
                    // 1-based indexing
                    w.Write(' ');
                    w.Write(idx[i] + 1);
                }
                w.WriteLine();
            }

            w.Flush();
        }

        // -------- Load --------

        public static Polyhedron Load(string path)
        {
            using var r = new StreamReader(path, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
            return Load(r);
        }

        public static Polyhedron Load(Stream stream, bool leaveOpen = false)
        {
            using var r = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, bufferSize: 1024, leaveOpen);
            return Load(r);
        }

        private static Polyhedron Load(TextReader r)
        {
            var vertices = new List<Vec3>();
            var faces = new List<Face>();

            string? line;
            while ((line = r.ReadLine()) is not null)
            {
                // strip comments
                int hash = line.IndexOf('#');
                if (hash >= 0) line = line[..hash];

                line = line.Trim();
                if (line.Length == 0) continue;

                // split by any whitespace
                var parts = line.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;

                switch (parts[0])
                {
                    case "v":
                        // v x y z
                        if (parts.Length < 4)
                            throw new FormatException($"Invalid vertex line: '{line}'");

                        double x = double.Parse(parts[1], CI);
                        double y = double.Parse(parts[2], CI);
                        double z = double.Parse(parts[3], CI);
                        vertices.Add(new Vec3(x, y, z));
                        break;

                    case "f":
                        // f a b c [d ...], tokens may be like "3", "3/2/1", "3//1", "-1"
                        if (parts.Length < 4)
                            throw new FormatException($"Invalid face line (need >=3 verts): '{line}'");

                        var idx = new int[parts.Length - 1];
                        for (int i = 1; i < parts.Length; i++)
                        {
                            idx[i - 1] = ParseObjVertexIndex(parts[i], vertices.Count);
                            if ((uint)idx[i - 1] >= (uint)vertices.Count)
                                throw new IndexOutOfRangeException(
                                    $"Face vertex index resolves out of range: {parts[i]} -> {idx[i - 1]} (verts={vertices.Count})");
                        }
                        faces.Add(new Face(idx));
                        break;

                    // Ignore everything else
                    default:
                        break;
                }
            }

            return new Polyhedron(vertices, faces);
        }

        /// <summary>
        /// Parses the vertex index from an OBJ face token:
        ///   "v", "v/vt", "v//vn", or "v/vt/vn".
        /// Supports negative indices (relative to end of vertex list).
        /// Returns ZERO-based index.
        /// </summary>
        private static int ParseObjVertexIndex(string token, int vertexCount)
        {
            // token like "3", "3/2", "3//1", "-1", "-5/7/9"
            string vStr = token;
            int slash = token.IndexOf('/');
            if (slash >= 0)
                vStr = token[..slash];

            if (string.IsNullOrEmpty(vStr))
                throw new FormatException($"Invalid face token: '{token}'");

            int raw = int.Parse(vStr, CI);

            if (raw > 0) return raw - 1;              // 1-based -> 0-based
            if (raw < 0) return vertexCount + raw;     // -1 is last defined vertex
            throw new FormatException("OBJ vertex index cannot be 0.");
        }
    }
}
