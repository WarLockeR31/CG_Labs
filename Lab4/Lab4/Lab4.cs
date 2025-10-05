using MathPrimitives;
using System.Windows.Forms;

namespace Lab4
{
    enum ActionMode
    {
        None,
        CreatePolygon,
        CheckPoint,
    }

    enum SubSelection
    {
        None,
        Vertex,
        Edge,
    }

    public partial class Lab4 : Form
    {
        Bitmap curBitmap;
        ActionMode curAction = ActionMode.None;
        List<Polygon2D> polygons = new List<Polygon2D>();
        bool isDragging = false;
        private bool isSelectingCenter = false;

        // Colors and styles
        Color polygonColor = Color.FromArgb(255, 0, 255, 0);
        Color selectedPolygonColor = Color.FromArgb(255, 0, 0, 255);
        Color vertexColor = Color.Yellow;
        Color selectedVertexColor = Color.Red;
        Color edgeColor = Color.Black;
        Color selectedEdgeColor = Color.Lime;
        int edgeThickness = 3;
        int selectedEdgeThickness = 7;

        // Current selection
        Polygon2D currentPolygon = null;
        int currentVertex = -1;
        SubSelection currentSubSelectionType = SubSelection.None;

        Polygon2D currentAltPolygon = null;
        int currentAltVertex = -1;
        SubSelection currentAltSubSelectionType = SubSelection.None;

        // Consts
        const float VertexRadius = 5.0f;



        public Lab4()
        {
            InitializeComponent();
            UpdateCounters();
        }

        private void pb_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            curBitmap = new Bitmap(pb.Width, pb.Height);

            foreach (Polygon2D poly in polygons)
            {
                var pts = poly.Select(v => new PointF((float)v.X, (float)v.Y)).ToArray();
                bool isSelected = poly == currentPolygon || poly == currentAltPolygon;

                if (poly.Count >= 3)
                {
                    Color fillColor = isSelected ? selectedPolygonColor : polygonColor;
                    RasterizePolygon(curBitmap, poly, fillColor);
                }

                for (int i = 0; i < pts.Length; i++)
                {
                    bool isSelectedEdge = IsEdgeSelected(poly, i);
                    int j = (i + 1) % pts.Length;
                    if (isSelectedEdge)
                    {
                        DrawLineWu(curBitmap, pts[i], pts[j], selectedEdgeColor, selectedEdgeThickness);
                    }
                    DrawLineWu(curBitmap, pts[i], pts[j], edgeColor, edgeThickness);
                }

                for (int i = 0; i < pts.Length; i++)
                {
                    bool isSelectedVerted = IsVertexSelected(poly, i);
                    Color vColor = isSelectedVerted ? selectedVertexColor : vertexColor;
                    DrawVertex(g, Point.Round(pts[i]), vColor, i.ToString());
                }
            }

            e.Graphics.DrawImageUnscaled(curBitmap, 0, 0);
        }

        #region Selection
        public bool IsEdgeSelected(Polygon2D polygon, int i)
        {
            if (polygon != null && polygon != currentPolygon)
                return false;
            return currentVertex == i && currentSubSelectionType == SubSelection.Edge
                || currentAltVertex == i && currentAltSubSelectionType == SubSelection.Edge;
        }

        public bool IsVertexSelected(Polygon2D polygon, int i)
        {
            if (polygon != null && polygon != currentPolygon)
                return false;
            return currentVertex == i && currentSubSelectionType == SubSelection.Vertex
                || currentAltVertex == i && currentAltSubSelectionType == SubSelection.Vertex;
        }

        private void ResetSelection()
        {
            UpdateSelection(true, null, -1, SubSelection.None);
            UpdateSelection(false, null, -1, SubSelection.None);

            pb.Invalidate();
        }

        private void UpdateSelection(bool mainSelection, Polygon2D? polygon, int vertexIndex, SubSelection subSelection)
        {
            if (mainSelection)
            {
                currentPolygon = polygon;
                currentVertex = vertexIndex;
                currentSubSelectionType = subSelection;
            }
            else
            {
                currentAltPolygon = polygon;
                currentAltVertex = vertexIndex;
                currentAltSubSelectionType = subSelection;
            }
        }
        #endregion

        #region Hit Detection
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

        public bool CheckVertexHit(Vec2 point, Polygon2D polygon, out int vertexIndex)
        {
            if (polygon == null)
            {
                vertexIndex = -1;
                return false;
            }

            for (int i = 0; i < polygon.Count; i++)
            {
                Vec2 v = polygon[i];
                if (v.DistanceSquared(point) <= VertexRadius * VertexRadius)
                {
                    vertexIndex = i;
                    return true;
                }
            }

            vertexIndex = -1;
            return false;
        }

        public bool CheckEdgeHit(Vec2 point, Polygon2D polygon, out int edgeIndex)
        {
            if (polygon == null)
            {
                edgeIndex = -1;
                return false;
            }

            for (int i = 0; i < polygon.Count; i++)
            {
                int j = (i + 1) % polygon.Count;
                if (LineContainsPoint(point, polygon[i], polygon[j], edgeThickness))
                {
                    edgeIndex = i;
                    return true;
                }
            }

            edgeIndex = -1;
            return false;
        }

        private bool LineContainsPoint(Vec2 pt, Vec2 p1, Vec2 p2, float thickness)
        {
            // Вектор AB
            double vx = p2.X - p1.X;
            double vy = p2.Y - p1.Y;

            // Вектор AP
            double wx = pt.X - p1.X;
            double wy = pt.Y - p1.Y;

            double denom = vx * vx + vy * vy;
            if (denom == 0)
            {
                // p1 и p2 совпадают — это точка, а не отрезок
                double distSq = wx * wx + wy * wy;
                return distSq <= (thickness * thickness) / 4f;
            }

            double t = (wx * vx + wy * vy) / denom;

            Vec2 closest;
            if (t < 0f)
            {
                closest = p1;
            }
            else if (t > 1f)
            {
                closest = p2;
            }
            else
            {
                closest = new Vec2(p1.X + t * vx, p1.Y + t * vy);
            }

            double dx = pt.X - closest.X;
            double dy = pt.Y - closest.Y;
            double distSqToLine = dx * dx + dy * dy;

            double half = thickness / 2f;
            return distSqToLine <= half * half;
        }
        #endregion

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

        #region Wu
        private void DrawLineWu(Bitmap bmp, PointF p0, PointF p1, Color c, int thickness = 1)
        {
            float ipart(float x) => (float)Math.Floor(x);
            float fpart(float x) => x - (float)Math.Floor(x);
            float rfpart(float x) => 1f - fpart(x);

            if (p1.X < p0.X) { var t = p0; p0 = p1; p1 = t; }

            float x0 = p0.X, y0 = p0.Y;
            float x1 = p1.X, y1 = p1.Y;

            float dx = x1 - x0;
            float dy = y1 - y0;

            bool steep = Math.Abs(dy) > Math.Abs(dx);
            if (steep)
            {
                (x0, y0) = (y0, x0);
                (x1, y1) = (y1, x1);
                dx = x1 - x0;
                dy = y1 - y0;
            }
            if (x0 > x1)
            {
                // swap points so that x0 < x1
                (x0, x1) = (x1, x0);
                (y0, y1) = (y1, y0);
            }

            if (Math.Abs(dx) < 1e-6f) dx = 1e-6f;
            float gradient = dy / dx;

            using (var fast = new FastBitmap.FastBitmap(bmp))
            {
                void plot(int x, int y, float a)
                {
                    for (int t = -thickness / 2; t <= thickness / 2; t++)
                    {
                        if (steep) SetPixelBlend(fast, y + t, x, c, a);
                        else SetPixelBlend(fast, x, y + t, c, a);
                    }
                }

                float xend = (float)Math.Round(x0);
                float yend = y0 + gradient * (xend - x0);
                float xgap = rfpart(x0 + 0.5f);
                int xpxl1 = (int)xend;
                int ypxl1 = (int)ipart(yend);
                plot(xpxl1, ypxl1, rfpart(yend) * xgap);
                plot(xpxl1, ypxl1 + 1, fpart(yend) * xgap);
                float intery = yend + gradient;

                xend = (float)Math.Round(x1);
                yend = y1 + gradient * (xend - x1);
                xgap = fpart(x1 + 0.5f);
                int xpxl2 = (int)xend;
                int ypxl2 = (int)ipart(yend);

                for (int x = xpxl1 + 1; x <= xpxl2 - 1; x++)
                {
                    int iy = (int)ipart(intery);
                    plot(x, iy, rfpart(intery));
                    plot(x, iy + 1, fpart(intery));
                    intery += gradient;
                }

                plot(xpxl2, ypxl2, rfpart(yend) * xgap);
                plot(xpxl2, ypxl2 + 1, fpart(yend) * xgap);
            }
        }

        private void SetPixelBlend(FastBitmap.FastBitmap fast, int x, int y, Color c, float alpha)
        {
            if ((uint)x >= (uint)fast.Width || (uint)y >= (uint)fast.Height) return;
            if (alpha <= 0f) return;
            if (alpha > 1f) alpha = 1f;

            var dst = fast[x, y];
            float ar = alpha * (c.A / 255f);
            float inv = 1f - ar;

            byte r = (byte)Math.Round(c.R * ar + dst.R * inv);
            byte g = (byte)Math.Round(c.G * ar + dst.G * inv);
            byte b = (byte)Math.Round(c.B * ar + dst.B * inv);

            fast[x, y] = Color.FromArgb(255, r, g, b);
        }
        #endregion

        #region Mouse Events
        private void pb_MouseDown(object sender, MouseEventArgs e)
        {
            Vec2 location = new Vec2(e.X, e.Y);
            
            if (isSelectingCenter)
            {
                numeric_cx.Value = e.X;
                numeric_cy.Value = e.Y;

                isSelectingCenter = false;
                pb.Cursor = Cursors.Default;

                MessageBox.Show($"Точка выбрана: ({e.X}, {e.Y})",
                    "Центр выбран", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            foreach (Polygon2D poly in polygons)
            {
                if (CheckVertexHit(location, poly, out int vertexIndex))
                {
                    UpdateSelection(e.Button == MouseButtons.Left, poly, vertexIndex, SubSelection.Vertex);
                    isDragging = true;
                    pb.Invalidate();
                    return;
                }

            }

            foreach (Polygon2D poly in polygons)
            {
                if (CheckEdgeHit(location, poly, out int edgeIndex))
                {
                    UpdateSelection(e.Button == MouseButtons.Left, poly, edgeIndex, SubSelection.Edge);
                    pb.Invalidate();
                    return;
                }
            }

            if (CheckPolygonHit(e.Location, out Polygon2D? polygon))
            {
                UpdateSelection(e.Button == MouseButtons.Left, polygon, polygon.Count - 1, SubSelection.None);
                pb.Invalidate();
                if (curAction == ActionMode.CheckPoint)
                {
                    MessageBox.Show(this, "Точка внутри полигона");
                }
                return;
            }

            if (curAction == ActionMode.CheckPoint)
            {
                MessageBox.Show(this, "Точка вне всех полигонов");
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

            UpdateCounters();

            pb.Invalidate();
        }

        private void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                currentPolygon[currentVertex] = new Vec2(e.X, e.Y);
                pb.Invalidate();
            }
        }

        private void pb_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
            }
        }
        #endregion

        #region UI Buttons
        private void btnCreatePolygon_Click(object sender, EventArgs e)
        {
            if (curAction != ActionMode.CreatePolygon)
            {
                if (!TrySwitchState(ActionMode.CreatePolygon))
                    return;
                btnCreatePolygon.Text = "Закончить создание полигона";
                ResetSelection();
            }
            else
            {
                curAction = ActionMode.None;
                btnCreatePolygon.Text = "Создать/изменить полигон";
                ResetSelection();
            }
            btnCreatePolygon.Refresh();
        }

        private void btn_CheckPoint_Click(object sender, EventArgs e)
        {
            if (curAction != ActionMode.CheckPoint)
            {
                if (!TrySwitchState(ActionMode.CheckPoint))
                    return;
                btn_CheckPoint.Text = "Закончить проверку";
                ResetSelection();
            }
            else
            {
                curAction = ActionMode.None;
                btn_CheckPoint.Text = "Принадлежность точки";
                ResetSelection();
            }
            btn_CheckPoint.Refresh();
        }

        private void btn_DeleteSelectedPolygon_Click(object sender, EventArgs e)
        {
            if (currentPolygon == null)
            {
                MessageBox.Show(this, "Выберите полигон");
                return;
            }
            polygons.Remove(currentPolygon);
            pb.Invalidate();
        }

        private void btn_DeleteSelectedVertex_Click(object sender, EventArgs e)
        {
            if (currentPolygon == null || currentVertex == -1)
            {
                MessageBox.Show(this, "Выберите вершину");
                return;
            }

            currentPolygon.RemoveAt(currentVertex);

            if (currentPolygon.Count == 0)
                polygons.Remove(currentPolygon);

            UpdateCounters();
            pb.Invalidate();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            ResetSelection();
            polygons.Clear();

            UpdateCounters();
            pb.Invalidate();
        }

        private void UpdateCounters()
        {
            lbl_PolyCount.Text = $"Polygons: {polygons.Count}";
            lbl_VertCount.Text = $"Vertices: {polygons.Sum(p => p.Count)}";
        }
        #endregion

        private bool TrySwitchState(ActionMode newState)
        {
            if (curAction != ActionMode.None)
            {
                MessageBox.Show(this, "Завершите текущее действие");
                return false;
            }

            curAction = newState;
            return true;
        }

        private void btn_Shift_Click(object sender, EventArgs e)
        {
            if (currentPolygon == null && currentAltPolygon == null)
            {
                MessageBox.Show(this, "Выберите хотя бы один полигон");
                return;
            }

            Affine2D TranslationMatrix = Affine2D.TranslationMatrix((int)numeric_dx.Value, (int)numeric_dy.Value);

            if (currentPolygon != null)
            {
                for (int i = 0; i < currentPolygon.Count; i++)
                {
                    currentPolygon[i] = TranslationMatrix.Transform(currentPolygon[i]);
                }
            }

            if (currentAltPolygon != null)
            {
                for (int i = 0; i < currentAltPolygon.Count; i++)
                {
                    currentAltPolygon[i] = TranslationMatrix.Transform(currentAltPolygon[i]);
                }
            }

            pb.Invalidate();
        }

        private void btn_RotatePoint_Click(object sender, EventArgs e)
        {
            if (currentPolygon == null && currentAltPolygon == null)
            {
                MessageBox.Show(this, "Выберите хотя бы один полигон");
                return;
            }

            double angle = (double)numeric_angle.Value;
            double cx = (double)numeric_cx.Value;
            double cy = (double)numeric_cy.Value;

            Affine2D R = Affine2D.RotationMatrix(angle, cx, cy);

            if (currentPolygon != null)
            {
                for (int i = 0; i < currentPolygon.Count; i++)
                    currentPolygon[i] = R.Transform(currentPolygon[i]);
            }

            if (currentAltPolygon != null)
            {
                for (int i = 0; i < currentAltPolygon.Count; i++)
                    currentAltPolygon[i] = R.Transform(currentAltPolygon[i]);
            }

            pb.Invalidate();
        }

        private void btn_RotateCenter_Click(object sender, EventArgs e)
        {
            if (currentPolygon == null && currentAltPolygon == null)
            {
                MessageBox.Show(this, "Выберите хотя бы один полигон");
                return;
            }

            double angle = (double)numeric_angle.Value;

            if (currentPolygon != null)
            {
                var (cx, cy) = GetPolygonCenter(currentPolygon);
                Affine2D R = Affine2D.RotationMatrix(angle, cx, cy);

                for (int i = 0; i < currentPolygon.Count; i++)
                    currentPolygon[i] = R.Transform(currentPolygon[i]);
            }

            if (currentAltPolygon != null)
            {
                var (cx, cy) = GetPolygonCenter(currentAltPolygon);
                Affine2D R = Affine2D.RotationMatrix(angle, cx, cy);

                for (int i = 0; i < currentAltPolygon.Count; i++)
                    currentAltPolygon[i] = R.Transform(currentAltPolygon[i]);
            }

            pb.Invalidate();
        }

        private void btn_ScalePoint_Click(object sender, EventArgs e)
        {
            if (currentPolygon == null && currentAltPolygon == null)
            {
                MessageBox.Show(this, "Выберите хотя бы один полигон");
                return;
            }

            double sx = (double)numeric_sx.Value;
            double sy = (double)numeric_sy.Value;
            double cx = (double)numeric_cx.Value;
            double cy = (double)numeric_cy.Value;

            Affine2D S = Affine2D.ScaleMatrix(sx, sy, cx, cy);

            if (currentPolygon != null)
            {
                for (int i = 0; i < currentPolygon.Count; i++)
                    currentPolygon[i] = S.Transform(currentPolygon[i]);
            }

            if (currentAltPolygon != null)
            {
                for (int i = 0; i < currentAltPolygon.Count; i++)
                    currentAltPolygon[i] = S.Transform(currentAltPolygon[i]);
            }

            pb.Invalidate();
        }

        private void btn_ScaleCenter_Click(object sender, EventArgs e)
        {
            if (currentPolygon == null && currentAltPolygon == null)
            {
                MessageBox.Show(this, "Выберите хотя бы один полигон");
                return;
            }

            double sx = (double)numeric_sx.Value;
            double sy = (double)numeric_sy.Value;

            if (currentPolygon != null)
            {
                var (cx, cy) = GetPolygonCenter(currentPolygon);
                Affine2D S = Affine2D.ScaleMatrix(sx, sy, cx, cy);

                for (int i = 0; i < currentPolygon.Count; i++)
                    currentPolygon[i] = S.Transform(currentPolygon[i]);
            }

            if (currentAltPolygon != null)
            {
                var (cx, cy) = GetPolygonCenter(currentAltPolygon);
                Affine2D S = Affine2D.ScaleMatrix(sx, sy, cx, cy);

                for (int i = 0; i < currentAltPolygon.Count; i++)
                    currentAltPolygon[i] = S.Transform(currentAltPolygon[i]);
            }

            pb.Invalidate();
        }


        private (double cx, double cy) GetPolygonCenter(Polygon2D poly)
        {
            if (poly == null || poly.Count == 0)
                return (0, 0);

            double sx = 0, sy = 0;
            foreach (var v in poly)
            {
                sx += v.X;
                sy += v.Y;
            }
            return (sx / poly.Count, sy / poly.Count);
        }

        private void btn_SelectCenter_Click(object sender, EventArgs e)
        {
            isSelectingCenter = true;
            pb.Cursor = Cursors.Cross;
            MessageBox.Show("Кликните на холсте, чтобы выбрать точку (cx, cy)",
                "Выбор точки", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
