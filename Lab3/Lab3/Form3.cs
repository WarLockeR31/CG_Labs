using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FastBitmap;

namespace Lab3
{
    public partial class Form3 : SwitchableForm
    {
        private const float VertexRadius = 5f;

        private Point A = new Point(120, 90);
        private Point B = new Point(420, 180);
        private Point C = new Point(220, 360);

        private Color colorA = Color.Red;
        private Color colorB = Color.Lime;
        private Color colorC = Color.Blue;

        private int     draggedIndex = -1;
        private bool    useHsv = false;

        public Form3()
        {
            InitializeComponent();
            
            this.DoubleBuffered     = true;
            this.Resize += (s, e)   => Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (ClientSize.Width <= 0 || ClientSize.Height <= 0)
                return;

            using (var bitmap = new Bitmap(ClientSize.Width, ClientSize.Height, PixelFormat.Format32bppArgb))
            using (var g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);

                RasterizeTriangle(bitmap, A, B, C, colorA, colorB, colorC);

                e.Graphics.DrawImageUnscaled(bitmap, 0, 0);

                DrawVertex(e.Graphics, A, colorA, "A");
                DrawVertex(e.Graphics, B, colorB, "B");
                DrawVertex(e.Graphics, C, colorC, "C");
            }
        }

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

        private void RasterizeTriangle(Bitmap bmp, PointF A, PointF B, PointF C,
                                       Color ca, Color cb, Color cc)
        {
            float area2 = Cross(A, B, C);
            if (Math.Abs(area2) < 1e-6f)
                return; 

            // Bounding box
            int minX = (int)Math.Floor(Math.Min(A.X, Math.Min(B.X, C.X)));
            int maxX = (int)Math.Ceiling(Math.Max(A.X, Math.Max(B.X, C.X)));
            int minY = (int)Math.Floor(Math.Min(A.Y, Math.Min(B.Y, C.Y)));
            int maxY = (int)Math.Ceiling(Math.Max(A.Y, Math.Max(B.Y, C.Y)));

            using (var fast = new FastBitmap.FastBitmap(bmp))
            {
                for (int y = minY; y <= maxY; y++)
                {
                    float py = y;

                    for (int x = minX; x <= maxX; x++)
                    {
                        float px = x ;
                        var P = new PointF(px, py);

                        // Барицентрические координаты
                        float wa = Cross(P, B, C) / area2;
                        float wb = Cross(P, C, A) / area2;
                        float wc = 1f - wa - wb; 

                        if (wa >= 0 && wb >= 0 && wc >= 0)
                        {
                            if (useHsv) // HSV
                            {
                                var ha = RgbToHsv(ca);
                                var hb = RgbToHsv(cb);
                                var hc = RgbToHsv(cc);

                                double hx = wa * Math.Cos(ha.H * Math.PI / 180) +
                                            wb * Math.Cos(hb.H * Math.PI / 180) +
                                            wc * Math.Cos(hc.H * Math.PI / 180);
                                double hy = wa * Math.Sin(ha.H * Math.PI / 180) +
                                            wb * Math.Sin(hb.H * Math.PI / 180) +
                                            wc * Math.Sin(hc.H * Math.PI / 180);
                                double H = Math.Atan2(hy, hx) * 180 / Math.PI;
                                if (H < 0) H += 360;

                                double S = wa * ha.S + wb * hb.S + wc * hc.S;
                                double V = wa * ha.V + wb * hb.V + wc * hc.V;

                                var mixed = HsvToRgb(new HSV { H = H, S = S, V = V });
                                fast[x, y] = mixed;
                            }
                            else // RGB
                            {
                                byte r = (byte)Clamp(wa * ca.R + wb * cb.R + wc * cc.R, 0, 255);
                                byte g = (byte)Clamp(wa * ca.G + wb * cb.G + wc * cc.G, 0, 255);
                                byte b = (byte)Clamp(wa * ca.B + wb * cb.B + wc * cc.B, 0, 255);

                                fast[x, y] = Color.FromArgb(255, r, g, b);
                            }
                        }
                    }
                }
            }
        }

        private static float Cross(in PointF A, in PointF B, in PointF C)
            => (B.X - A.X) * (C.Y - A.Y) - (B.Y - A.Y) * (C.X - A.X);

        private static float Clamp(double v, double lo, double hi)
            => (float)(v < lo ? lo : (v > hi ? hi : v));


        #region Color Settings
        private void BtnColor1_Click(object sender, EventArgs e)
        {
            using (var dlg = new ColorDialog())
            {
                dlg.Color = colorA; 
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    colorA = dlg.Color;
                    Invalidate(); 
                }
            }
        }

        private void BtnColor2_Click(object sender, EventArgs e)
        {
            using (var dlg = new ColorDialog())
            {
                dlg.Color = colorB;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    colorB = dlg.Color;
                    Invalidate();
                }
            }
        }

        private void BtnColor3_Click(object sender, EventArgs e)
        {
            using (var dlg = new ColorDialog())
            {
                dlg.Color = colorC;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    colorC = dlg.Color;
                    Invalidate();
                }
            }
        }

        private void BtnSwitchColorScheme_Click(object sender, EventArgs e)
        {
            useHsv = !useHsv;
            labelColorScheme.Text = useHsv ? "HSV" : "RGB";
            Invalidate();
        }
        #endregion

        #region Vertex Drag
        private bool IsNear(PointF p, PointF v)
        {
            float dx = p.X - v.X;
            float dy = p.Y - v.Y;
            return dx * dx + dy * dy <= VertexRadius * VertexRadius;
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsNear(e.Location, A)) draggedIndex = 0;
            else if (IsNear(e.Location, B)) draggedIndex = 1;
            else if (IsNear(e.Location, C)) draggedIndex = 2;
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (/*e.Button == MouseButtons.Left && */draggedIndex != -1)
            {
                switch (draggedIndex)
                {
                    case 0: A = e.Location; break;
                    case 1: B = e.Location; break;
                    case 2: C = e.Location; break;
                }
                Invalidate();
            }
        }

        private void Form3_MouseUp(object sender, MouseEventArgs e)
        {
            draggedIndex = -1;
        }
        #endregion

        #region RGB<->HSV 
        private struct HSV
        {
            public double H;
            public double S;
            public double V;
        }

        private HSV RgbToHsv(Color c)
        {
            double r = c.R / 255.0;
            double g = c.G / 255.0;
            double b = c.B / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double h = 0, s, v = max;

            double delta = max - min;
            s = (max == 0) ? 0 : delta / max;

            if (delta != 0)
            {
                if (max == r) h = 60 * (((g - b) / delta) % 6);
                else if (max == g) h = 60 * (((b - r) / delta) + 2);
                else h = 60 * (((r - g) / delta) + 4);
            }

            if (h < 0) h += 360;
            return new HSV { H = h, S = s, V = v };
        }

        private Color HsvToRgb(HSV hsv)
        {
            double h = hsv.H, s = hsv.S, v = hsv.V;
            double c = v * s;
            double x = c * (1 - Math.Abs((h / 60) % 2 - 1));
            double m = v - c;

            double r = 0, g = 0, b = 0;
            if (h < 60) { r = c; g = x; b = 0; }
            else if (h < 120) { r = x; g = c; b = 0; }
            else if (h < 180) { r = 0; g = c; b = x; }
            else if (h < 240) { r = 0; g = x; b = c; }
            else if (h < 300) { r = x; g = 0; b = c; }
            else { r = c; g = 0; b = x; }

            return Color.FromArgb(
                255,
                (int)Math.Round((r + m) * 255),
                (int)Math.Round((g + m) * 255),
                (int)Math.Round((b + m) * 255)
            );
        }
        #endregion
    }
}