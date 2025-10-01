using MathPrimitives;
using System.Windows.Forms;

namespace Lab4
{
    enum ActionMode
    {
        None,
        CreatePolygon,
    }

    enum SubSelection
    {
        None,
        Vertex,
        Edge,
    }

    public partial class Lab4 : Form
    {
        ActionMode curAction = ActionMode.None;

        Bitmap curBitmap;

        List<Polygon2D> polygons = new List<Polygon2D>();
        Color polygonColor = Color.FromArgb(128, 0, 255, 0);
        Color selectedPolygonColor = Color.FromArgb(128, 0, 0, 255);
        Color vertexColor = Color.Yellow;
        Color selectedVertexColor = Color.Red;

        Polygon2D currentPolygon = null;
        int currentVertex = -1;
        SubSelection currentSubSelection = SubSelection.None;

        const float VertexRadius = 5.0f;

        bool isDragging = false;

        public Lab4()
        {
            InitializeComponent();
        }

        private void pb_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            curBitmap = new Bitmap(pb.Width, pb.Height);

            foreach (Polygon2D poly in polygons)
            {
                if (poly.Count >= 3)
                {
                    var pts = poly.Select(v => new PointF((float)v.X, (float)v.Y)).ToArray();

                    /*using (Brush brush = new SolidBrush(polygonColor))
                        g.FillPolygon(brush, pts);*/

                    bool isSelected = poly == currentPolygon;

                    Color fillColor = isSelected ? selectedPolygonColor : polygonColor;
                    RasterizePolygon(curBitmap, poly, fillColor);
                    

                    for (int i = 0; i < pts.Length; i++)
                    {
                        bool isSelectedVerted = isSelected && currentVertex == i;
                        Color vColor = isSelectedVerted ? selectedVertexColor : vertexColor;
                        DrawVertex(g, Point.Round(pts[i]), vColor, i.ToString());
                    }
                }
            }

            pb.Image = curBitmap;
        }

        public void pb_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public bool CheckPolygonHit(Point point, out Polygon2D? hitted)
        {
            foreach (Polygon2D polygon in polygons)
            {
                if (polygon.ContainsPoint(new Vec2(point.X, point.Y)))
                {
                    hitted = polygon;
                    return true;
                }

            }

            hitted = null;
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

        private void btnCreatePolygon_Click(object sender, EventArgs e)
        {
            if (curAction != ActionMode.CreatePolygon)
            {
                curAction = ActionMode.CreatePolygon;
                btnCreatePolygon.Text = "Finish Polygon";
                ResetSelection();
            }
            else
            {
                curAction = ActionMode.None;
                btnCreatePolygon.Text = "Create Polygon";
                ResetSelection();
            }
            btnCreatePolygon.Refresh();
        }

        private void ResetSelection()
        {
            currentPolygon = null;
            currentVertex = -1;
        }

        private void pb_MouseDown(object sender, MouseEventArgs e)
        {
            Vec2 location = new Vec2(e.X, e.Y);
            foreach (Polygon2D poly in polygons)
            {
                for (int i = 0; i < poly.Count; i++)
                {
                    Vec2 v = poly[i];
                    if (v.DistanceSquared(location) <= VertexRadius * VertexRadius)
                    {
                        currentPolygon = poly;
                        currentVertex = i;
                        isDragging = true;
                        return;
                    }
                }
            }

            if (CheckPolygonHit(e.Location, out Polygon2D? polygon))
            {
                currentPolygon = polygon;
                currentVertex = polygon.Count - 1;
                return;
            }

            if (curAction != ActionMode.CreatePolygon)
                return;

            if (currentPolygon == null)
            {
                currentPolygon = new Polygon2D();
                polygons.Add(currentPolygon);
            }

            currentPolygon.InsertAfter(currentVertex, new Vec2(e.X, e.Y));
            currentVertex++;

            pb.Invalidate();
        }

        private void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                currentPolygon[currentVertex] = new Vec2(e.X, e.Y);
                Invalidate();
            }
        }

        private void pb_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
            }
        }

        private void btn_DeleteSelectedPolygon_Click(object sender, EventArgs e)
        {
            if (currentPolygon == null)
            {
                MessageBox.Show("Выберите полигон");
                return;
            }
            polygons.Remove(currentPolygon);
        }

        private void btn_DeleteSelectedVertex_Click(object sender, EventArgs e)
        {
            if (currentPolygon == null || currentVertex == -1)
            {
                MessageBox.Show("Выберите вершину");
                return;
            }

            currentPolygon.RemoveAt(currentVertex);
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            ResetSelection();
            polygons.Clear();
        }
    }
}
