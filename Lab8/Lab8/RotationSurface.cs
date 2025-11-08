using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPrimitives;
using Topology;

namespace Lab8
{
    public static class RotationSurface
    {
        public static Polyhedron Create(IList<Vec3> profile, Axis axis, int segments)
        {
            if (profile == null || profile.Count < 2)
                throw new ArgumentException("Profile must have at least 2 points");
            if (segments < 3)
                throw new ArgumentException("Segments must be at least 3");

            var vertices = new List<Vec3>();
            var faces = new List<Face>();

            // Создаем вершины вращения
            double angleStep = 2 * Math.PI / segments;

            for (int segment = 0; segment <= segments; segment++)
            {
                double angle = segment * angleStep;

                for (int i = 0; i < profile.Count; i++)
                {
                    var point = profile[i];
                    Vec3 rotatedPoint = axis switch
                    {
                        Axis.X => RotateAroundX(point, angle),
                        Axis.Y => RotateAroundY(point, angle),
                        Axis.Z => RotateAroundZ(point, angle),
                        _ => throw new ArgumentException("Invalid axis")
                    };
                    vertices.Add(rotatedPoint);
                }
            }

            // Создаем грани
            int profileCount = profile.Count;

            for (int segment = 0; segment < segments; segment++)
            {
                int currentSegmentStart = segment * profileCount;
                int nextSegmentStart = ((segment + 1) % segments) * profileCount;

                for (int i = 0; i < profileCount - 1; i++)
                {
                    int a = currentSegmentStart + i;
                    int b = currentSegmentStart + i + 1;
                    int c = nextSegmentStart + i + 1;
                    int d = nextSegmentStart + i;

                    // Два треугольника для квадратной грани
                    faces.Add(new Face(a, b, c));
                    faces.Add(new Face(a, c, d));
                }
            }

            return new Polyhedron(vertices, faces);
        }

        private static Vec3 RotateAroundX(Vec3 point, double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Vec3(
                point.X,
                point.Y * cos - point.Z * sin,
                point.Y * sin + point.Z * cos
            );
        }

        private static Vec3 RotateAroundY(Vec3 point, double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Vec3(
                point.X * cos + point.Z * sin,
                point.Y,
                -point.X * sin + point.Z * cos
            );
        }

        private static Vec3 RotateAroundZ(Vec3 point, double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Vec3(
                point.X * cos - point.Y * sin,
                point.X * sin + point.Y * cos,
                point.Z
            );
        }
    }

    public enum Axis { X, Y, Z }
}