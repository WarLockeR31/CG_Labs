using MathPrimitives;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Lab4 : Form
    {
        List<Polygon2D> polygons = new List<Polygon2D>();
        Polygon2D currentPolygon = null;
        Color polygonColor = Color.FromArgb(128, 0, 255, 0);

        const float VertexRadius = 5.0f;

        public Lab4()
        {
            InitializeComponent();
            panel1.Paint += panel1_Paint;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Polygon2D poly in polygons)
            {
                if (poly.Count >= 3)
                {
                    var pts = poly.Select(v => new PointF((float)v.X, (float)v.Y)).ToArray();

                    using (Brush brush = new SolidBrush(polygonColor))
                        g.FillPolygon(brush, pts);

                    using (Pen pen = new Pen(Color.Black, 2))
                        g.DrawPolygon(pen, pts);

                    for (int i = 0; i < pts.Length; i++)
                        DrawVertex(g, Point.Round(pts[i]), Color.Red, i.ToString());
                }
            }
        }

        public void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (CheckPolygonHit(e.Location))
            {
                MessageBox.Show("Hit");
                return;
            }

            if (currentPolygon == null)
            {
                currentPolygon = new Polygon2D();
                polygons.Add(currentPolygon);
            }

            currentPolygon.Add(new Vec2(e.X, e.Y));

            panel1.Invalidate();
        }

        public bool CheckPolygonHit(Point point)
        {
            foreach (Polygon2D polygon in polygons)
            {
                if (polygon.ContainsPoint(new Vec2(point.X, point.Y)))
                    return true;
            }

            return false;
        }


        #region Draw Polygon
        private void DrawVertex(Graphics g, Point p, Color color, string label)
        {
            const float r = VertexRadius;
            using (var b = new SolidBrush(color))
            using (var pen = new Pen(Color.Black, 1))
            using (var font = new Font("Segoe UI", 9f))
            {
                g.FillEllipse(b, p.X - r, p.Y - r, 2 * r, 2 * r);
                g.DrawEllipse(pen, p.X - r, p.Y - r, 2 * r, 2 * r);
                g.DrawString(label, font, Brushes.Black, p.X + 7, p.Y - 14);
            }
        }

        private void RasterizePolygon(Bitmap bmp, Polygon2D polygon, Color fillColor)
        {
            if (polygon == null || polygon.Count < 3)
                return;

            var (min, max) = polygon.BBox();
            int minX = (int)Math.Floor(min.X);
            int maxX = (int)Math.Ceiling(max.X);
            int minY = (int)Math.Floor(min.Y);
            int maxY = (int)Math.Ceiling(max.Y);

            using (var fast = new FastBitmap.FastBitmap(bmp))
            {
                for (int y = minY; y <= maxY; y++)
                {
                    for (int x = minX; x <= maxX; x++)
                    {
                        Vec2 p = new Vec2(x + 0.5, y + 0.5); // центр пикселя

                        if (polygon.ContainsPoint(p))
                        {
                            fast[x, y] = fillColor;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
