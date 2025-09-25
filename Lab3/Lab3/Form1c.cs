using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FastBitmap; 

namespace Lab3
{
    public partial class Form1c : SwitchableForm
    {
        private Bitmap _src;
        private List<Point> _contour;
        private int Tol => trbTolerance?.Value ?? 20;

        // 8: E, SE, S, SW, W, NW, N, NE
        private static readonly int[] DX = { 1, 1, 0, -1, -1, -1, 0, 1 };
        private static readonly int[] DY = { 0, 1, 1, 1, 0, -1, -1, -1 };

        public Form1c()
        {
            InitializeComponent();

            if (pictureBox1 != null)
                pictureBox1.MouseDown += pictureBox1_MouseDown;
            if (btnOpen != null)
                btnOpen.Click += btnOpen_Click;
            if (trbTolerance != null)
            {
                trbTolerance.Minimum = 0;
                trbTolerance.Maximum = 128;
                trbTolerance.Value = 20;
                trbTolerance.ValueChanged += (s, e) => lblTol.Text = $"Толерантность: {Tol}";
                lblTol.Text = $"Толерантность: {Tol}";
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog
            {
                Title = "Открыть изображение",
                Filter = "Изображения|*.png;*.jpg;*.jpeg;*.bmp"
            })
            {
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    _src?.Dispose();
                    using (var tmp = (Bitmap)Image.FromFile(ofd.FileName))
                    {
                        _src = new Bitmap(tmp.Width, tmp.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        using (var g = Graphics.FromImage(_src))
                            g.DrawImageUnscaled(tmp, 0, 0);
                    }
                    _contour = null;
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = (Bitmap)_src.Clone();
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_src == null) return;
            if (!TryTranslateToImagePoint(pictureBox1, e.Location, _src.Size, out var seed))
                return;

            Color seedColor;
            using (var fast = new FastBitmap.FastBitmap(_src))
            {
                seedColor = fast[seed.X, seed.Y];
            }

            bool[,] inRegion;
            var start = FindBoundaryStartFromSeed(_src, seed, seedColor, Tol, out inRegion);
            if (start == null)
            {
                MessageBox.Show("Не удалось найти границу (возможно, объект слишком мал или разорван).");
                return;
            }

            _contour = TraceContourMoore(inRegion, start.Value);

            DrawContourOverlay();
        }

        private static Point? FindBoundaryStartFromSeed(Bitmap bmp, Point seed, Color seedColor, int tol, out bool[,] inRegion)
        {
            int w = bmp.Width, h = bmp.Height;
            inRegion = new bool[w, h];
            var visited = new bool[w, h];
            var q = new Queue<Point>();

            using (var fast = new FastBitmap.FastBitmap(bmp))
            {
                bool Similar(Color c) =>
                    Math.Abs(c.R - seedColor.R) <= tol &&
                    Math.Abs(c.G - seedColor.G) <= tol &&
                    Math.Abs(c.B - seedColor.B) <= tol;

                bool InBounds(int x, int y) => (uint)x < w && (uint)y < h;

                if (!Similar(fast[seed.X, seed.Y])) return null;

                q.Enqueue(seed);
                visited[seed.X, seed.Y] = true;
                inRegion[seed.X, seed.Y] = true;

                Point? boundaryStart = null;

                int[] qdx = { 1, -1, 0, 0 };
                int[] qdy = { 0, 0, 1, -1 };

                while (q.Count > 0)
                {
                    var p = q.Dequeue();

                    bool isBoundary = false;
                    for (int k = 0; k < 8 && !isBoundary; k++)
                    {
                        int nx = p.X + DX[k], ny = p.Y + DY[k];
                        if (!InBounds(nx, ny) || !SimilarSafe(fast, InBounds, nx, ny, Similar))
                            isBoundary = true;
                    }
                    if (isBoundary && boundaryStart == null)
                        boundaryStart = p;

                    for (int k = 0; k < 4; k++)
                    {
                        int nx = p.X + qdx[k], ny = p.Y + qdy[k];
                        if (!InBounds(nx, ny) || visited[nx, ny]) continue;
                        visited[nx, ny] = true;

                        if (Similar(fast[nx, ny]))
                        {
                            inRegion[nx, ny] = true;
                            q.Enqueue(new Point(nx, ny));
                        }
                    }
                }

                return boundaryStart;
            }

            static bool SimilarSafe(FastBitmap.FastBitmap fb, Func<int, int, bool> inb, int x, int y, Func<Color, bool> sim)
                => inb(x, y) && sim(fb[x, y]);
        }

        private List<Point> TraceContourMoore(bool[,] inRegion, Point start, int maxSteps = 2_000_000)
        {
            int w = inRegion.GetLength(0);
            int h = inRegion.GetLength(1);

            bool InBounds(int x, int y) => (uint)x < w && (uint)y < h;
            bool IsIn(int x, int y) => InBounds(x, y) && inRegion[x, y];

            var contour = new List<Point>();
            if (!IsIn(start.X, start.Y)) return contour;

            var curr = start;
            int backtrackDir = 4; 
            int startBacktrackDir = backtrackDir;
            contour.Add(curr);

            int steps = 0;
            do
            {
                int startIdx = (backtrackDir + 1) % 8;
                bool found = false;

                for (int k = 0; k < 8; k++)
                {
                    int i = (startIdx + k) % 8;
                    int nx = curr.X + DX[i];
                    int ny = curr.Y + DY[i];

                    if (IsIn(nx, ny))
                    {
                        var next = new Point(nx, ny);
                        if (contour[^1] != next)
                            contour.Add(next);

                        backtrackDir = (i + 4) % 8; 
                        curr = next;
                        found = true;
                        break;
                    }
                }

                if (!found) break;
                if (++steps > maxSteps) break;

            } while (!(curr == start && backtrackDir == startBacktrackDir));

            return contour;
        }

        private void DrawContourOverlay()
        {
            if (_src == null || _contour == null || _contour.Count < 2) return;

            using (var overlay = (Bitmap)_src.Clone())
            using (var g = Graphics.FromImage(overlay))
            using (var pen = new Pen(Color.Red, 1f))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

                for (int i = 1; i < _contour.Count; i++)
                    g.DrawLine(pen, _contour[i - 1], _contour[i]);

                if (_contour[0] != _contour[^1])
                    g.DrawLine(pen, _contour[^1], _contour[0]);

                pictureBox1.Image?.Dispose();
                pictureBox1.Image = (Bitmap)overlay.Clone();
            }
        }

        private static bool TryTranslateToImagePoint(PictureBox pb, Point p, Size imgSize, out Point imgPt)
        {
            var pbSize = pb.ClientSize;
            if (imgSize.Width <= 0 || imgSize.Height <= 0 || pbSize.Width <= 0 || pbSize.Height <= 0)
            {
                imgPt = Point.Empty;
                return false;
            }

            double imageAspect = (double)imgSize.Width / imgSize.Height;
            double boxAspect = (double)pbSize.Width / pbSize.Height;

            int drawWidth, drawHeight, offsetX, offsetY;

            if (boxAspect > imageAspect)
            {
                drawHeight = pbSize.Height;
                drawWidth = (int)Math.Round(drawHeight * imageAspect);
                offsetX = (pbSize.Width - drawWidth) / 2;
                offsetY = 0;
            }
            else
            {
                drawWidth = pbSize.Width;
                drawHeight = (int)Math.Round(drawWidth / imageAspect);
                offsetX = 0;
                offsetY = (pbSize.Height - drawHeight) / 2;
            }

            if (p.X < offsetX || p.X >= offsetX + drawWidth || p.Y < offsetY || p.Y >= offsetY + drawHeight)
            {
                imgPt = Point.Empty;
                return false;
            }

            double scaleX = (double)imgSize.Width / drawWidth;
            double scaleY = (double)imgSize.Height / drawHeight;

            int ix = (int)Math.Floor((p.X - offsetX) * scaleX);
            int iy = (int)Math.Floor((p.Y - offsetY) * scaleY);

            ix = Math.Max(0, Math.Min(imgSize.Width - 1, ix));
            iy = Math.Max(0, Math.Min(imgSize.Height - 1, iy));

            imgPt = new Point(ix, iy);
            return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
