using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FastBitmap;

namespace Lab3
{
    public partial class Form1b : SwitchableForm
    {
        private Bitmap _src;
        private Bitmap _pattern;

        public Form1b()
        {
            InitializeComponent();

            if (btnOpen != null)
                btnOpen.Click += btnOpen_Click;
            if (btnPattern != null)
                btnPattern.Click += btnPattern_Click;
            if (pictureBox1 != null)
                pictureBox1.MouseDown += pictureBox1_MouseDown;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "Images|*.png;*.jpg;*.bmp" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _src?.Dispose();
                    _src = new Bitmap(ofd.FileName);
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = (Bitmap)_src.Clone();
                }
            }
        }

        private void btnPattern_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "Images|*.png;*.jpg;*.bmp" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _pattern?.Dispose();
                    _pattern = new Bitmap(ofd.FileName);
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_src == null || _pattern == null) return;
            if (!TryTranslateToImagePoint(pictureBox1, e.Location, _src.Size, out var seed))
                return;

            using (var fb = new FastBitmap.FastBitmap(_src))
            {
                var target = fb[seed.X % _src.Width, seed.Y % _src.Height];
                FloodFillPattern(fb, seed.X, seed.Y, target);
            }

            pictureBox1.Image?.Dispose();
            pictureBox1.Image = (Bitmap)_src.Clone();
        }

        /// <summary>
        /// Итеративная заливка сериями пикселей паттерном
        /// </summary>
        private void FloodFillPattern(FastBitmap.FastBitmap fb, int x, int y, Color target)
        {
            int w = fb.Width, h = fb.Height;
            int pw = _pattern.Width, ph = _pattern.Height;

            bool[,] visited = new bool[w, h];
            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(x, y));

            while (stack.Count > 0)
            {
                var p = stack.Pop();
                int px = p.X, py = p.Y;
                if (px < 0 || px >= w || py < 0 || py >= h) continue;
                if (visited[px, py]) continue;
                if (fb[px, py] != target) continue;

                // найти левую границу
                int left = px;
                while (left > 0 && fb[left - 1, py] == target && !visited[left - 1, py])
                    left--;

                // найти правую границу
                int right = px;
                while (right < w - 1 && fb[right + 1, py] == target && !visited[right + 1, py])
                    right++;

                // закрасить серию
                for (int i = left; i <= right; i++)
                {
                    fb[i, py] = _pattern.GetPixel(i % pw, py % ph);
                    visited[i, py] = true;

                    // добавить верх/низ
                    if (py > 0 && fb[i, py - 1] == target && !visited[i, py - 1])
                        stack.Push(new Point(i, py - 1));
                    if (py < h - 1 && fb[i, py + 1] == target && !visited[i, py + 1])
                        stack.Push(new Point(i, py + 1));
                }
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
    }
}
