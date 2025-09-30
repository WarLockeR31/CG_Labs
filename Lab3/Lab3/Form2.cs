using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using FastBitmap;

namespace Lab3
{
    public partial class Form2 : SwitchableForm
    {
        private PointF A = new PointF(80, 80);
        private PointF B = new PointF(420, 260);

        private const float HandleR = 5f;
        private int draggedIndex = -1;

        private Color lineColor = Color.Black;
        private bool useWu = false; 
        private int thickness = 3;  

        private Panel bottomPanel;
        private TrackBar trackThickness;
        private Label lblThickness;

        public Form2()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Resize += (s, e) => Invalidate();

            bottomPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 48,
                BackColor = SystemColors.Control
            };

            lblThickness = new Label
            {
                AutoSize = true,
                Text = $"Толщина: {thickness}px",
                Location = new Point(10, 15)
            };

            trackThickness = new TrackBar
            {
                Minimum = 1,
                Maximum = 15,
                TickFrequency = 1,
                SmallChange = 1,
                LargeChange = 2,
                Value = thickness,
                Width = 220,
                Location = new Point(110, 10)
            };
            trackThickness.ValueChanged += (s, e) =>
            {
                thickness = trackThickness.Value;
                lblThickness.Text = $"Толщина: {thickness}px";
                Invalidate();
            };

            bottomPanel.Controls.Add(lblThickness);
            bottomPanel.Controls.Add(trackThickness);
            Controls.Add(bottomPanel);

            this.MouseDown += Form2_MouseDown;
            this.MouseMove += Form2_MouseMove;
            this.MouseUp += (s, e) => draggedIndex = -1;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space)
            {
                useWu = !useWu;
                Invalidate();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (bottomPanel.ClientRectangle.Contains(bottomPanel.PointToClient(MousePosition)))
                return;

            this.Focus(); 

            // ПКМ — только смена цвета (точки не двигаем)
            if (e.Button == MouseButtons.Right)
            {
                using (var dlg = new ColorDialog() { Color = lineColor })
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        lineColor = dlg.Color;
                        Invalidate();
                    }
                }
                return;
            }

            // ЛКМ — работа с точками
            if (e.Button == MouseButtons.Left)
            {
                if (IsNear(e.Location, A)) draggedIndex = 0;
                else if (IsNear(e.Location, B)) draggedIndex = 1;
                else
                {
                    // поставить ближайшую точку в место клика
                    if (Distance(e.Location, A) > Distance(e.Location, B)) B = e.Location;
                    else A = e.Location;
                    draggedIndex = -1;
                    Invalidate();
                }
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            // Тянуть точки только ЛКМ
            if (bottomPanel.ClientRectangle.Contains(bottomPanel.PointToClient(MousePosition)))
                return;

            if (draggedIndex != -1 && e.Button == MouseButtons.Left)
            {
                if (draggedIndex == 0) A = e.Location;
                else B = e.Location;
                Invalidate();
            }
        }

        private bool IsNear(PointF p, PointF v)
        {
            float dx = p.X - v.X, dy = p.Y - v.Y;
            return dx * dx + dy * dy <= HandleR * HandleR;
        }
        private float Distance(PointF p, PointF v)
        {
            float dx = p.X - v.X, dy = p.Y - v.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (ClientSize.Width <= 0 || ClientSize.Height <= 0) return;

            // Высота рабочей области без нижней панели
            int drawWidth = ClientSize.Width;
            int drawHeight = Math.Max(0, ClientSize.Height - bottomPanel.Height);

            using (var bmp = new Bitmap(drawWidth, drawHeight, PixelFormat.Format32bppArgb))
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                if (useWu)
                    DrawLineWu(bmp, A, B, lineColor, thickness);
                else
                    DrawLineBresenham(bmp, Point.Round(A), Point.Round(B), lineColor, thickness);

                // Вставляем рабочее полотно
                e.Graphics.DrawImageUnscaled(bmp, 0, 0);

                // Хэндлы вершин 
                DrawHandle(e.Graphics, A, "A");
                DrawHandle(e.Graphics, B, "B");

                // Подсказки 
                using (var font = new Font("Segoe UI", 9f))
                {
                    var mode = useWu ? "Wu (антиалиасинг)" : "Bresenham (целочисленный)";
                    string info = $"Space — переключить: {mode}\nПКМ — цвет";
                    SizeF size = e.Graphics.MeasureString(info, font);
                    e.Graphics.DrawString(info, font, Brushes.Black, 10, drawHeight - size.Height - 8);
                }
            }
        }


        // Рисование точек
        private void DrawHandle(Graphics g, PointF p, string label)
        {
            if (p.Y > ClientSize.Height - bottomPanel.Height) return;

            using (var pen = new Pen(Color.Black, 1))
            using (var br = new SolidBrush(Color.Orange))
            using (var font = new Font("Segoe UI", 9f))
            {
                g.FillEllipse(br, p.X - HandleR, p.Y - HandleR, 2 * HandleR, 2 * HandleR);
                g.DrawEllipse(pen, p.X - HandleR, p.Y - HandleR, 2 * HandleR, 2 * HandleR);
                if (label == "A")
                    g.DrawString(label, font, Brushes.Black, p.X - 20, p.Y - 14);
                else
                    g.DrawString(label, font, Brushes.Black, p.X + 7, p.Y - 14);
            }
        }

        // Брезенхем (целочисленный)
        private void DrawLineBresenham(Bitmap bmp, Point p0, Point p1, Color c, int thickness = 1)
        {
            int x0 = p0.X, y0 = p0.Y;
            int x1 = p1.X, y1 = p1.Y;

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);

            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;

            bool steep = dy > dx;
            using (var fast = new FastBitmap.FastBitmap(bmp))
            {
                if (!steep)
                {
                    int d = 2 * dy - dx; // d0
                    int y = y0;

                    for (int x = x0; x != x1 + sx; x += sx)
                    {
                        for (int t = -thickness / 2; t <= thickness / 2; t++)
                        {
                            int yy = y + t;
                            if ((uint)x < (uint)bmp.Width && (uint)yy < (uint)bmp.Height)
                                fast[x, yy] = c;
                        }

                        if (d > 0)
                        {
                            y += sy;
                            d += 2 * (dy - dx);
                        }
                        else
                        {
                            d += 2 * dy;
                        }
                    }
                }
                else
                {
                    int d = 2 * dx - dy;
                    int x = x0;

                    for (int y = y0; y != y1 + sy; y += sy)
                    {
                        for (int t = -thickness / 2; t <= thickness / 2; t++)
                        {
                            int xx = x + t;
                            if ((uint)xx < (uint)bmp.Width && (uint)y < (uint)bmp.Height)
                                fast[xx, y] = c;
                        }

                        if (d > 0)
                        {
                            x += sx;
                            d += 2 * (dx - dy);
                        }
                        else
                        {
                            d += 2 * dx;
                        }
                    }
                }
            }
        }

        // Алгоритм Ву
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

        // Альфа-наложение
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
    }
}
