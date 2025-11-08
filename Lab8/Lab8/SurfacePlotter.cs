using System;
using System.Collections.Generic;
using MathPrimitives;
using Topology;

namespace Lab8
{
    public static class SurfacePlotter
    {
        public delegate double Function2D(double x, double y);

        public static Polyhedron Create(Function2D func, double x0, double x1, double y0, double y1, int nx, int ny)
        {
            if (nx < 1 || ny < 1 || x0 >= x1 || y0 >= y1)
                return null;

            var vertices = new List<Vec3>();
            var faces = new List<Face>();

            double dx = (x1 - x0) / nx;
            double dy = (y1 - y0) / ny;

            for (int i = 0; i <= nx; i++)
            {
                for (int j = 0; j <= ny; j++)
                {
                    double x = x0 + i * dx;
                    double y = y0 + j * dy;
                    double z = func(x, y);
                    vertices.Add(new Vec3((float)x, (float)y, (float)z));
                }
            }

            for (int i = 0; i < nx; i++)
            {
                for (int j = 0; j < ny; j++)
                {
                    int a = i * (ny + 1) + j;
                    int b = (i + 1) * (ny + 1) + j;
                    int c = (i + 1) * (ny + 1) + (j + 1);
                    int d = i * (ny + 1) + (j + 1);

                    faces.Add(new Face(a, b, c));
                    faces.Add(new Face(a, c, d));
                }
            }

            return new Polyhedron(vertices, faces);
        }
    }
}