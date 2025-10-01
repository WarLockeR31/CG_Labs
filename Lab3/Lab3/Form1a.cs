using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FastBitmap;

namespace Lab3
{
    public partial class Form1a : SwitchableForm
    {
        private Bitmap _src;
        private int Tol => trbTolerance?.Value ?? 20;
        private Color _fillColor = Color.Red; // цвет заливки (можно поменять)

        public Form1a()
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

            using (var fast = new FastBitmap.FastBitmap(_src))
            {
                var target = fast[seed.X, seed.Y];
                if (!Similar(target, target, Tol)) return;

                FloodFillScanline(fast, seed.X, seed.Y, target, _fillColor, Tol);
            }

            pictureBox1.Image?.Dispose();
            pictureBox1.Image = (Bitmap)_src.Clone();
        }

        /// <summary>
        /// Рекурсивная заливка сериями пикселов (scanline flood fill).
        /// </summary>
        private void FloodFillScanline(FastBitmap.FastBitmap fb, int x, int y, Color target, Color replacement, int tol)
        {
            int w = fb.Width, h = fb.Height;
            if (x < 0 || x >= w || y < 0 || y >= h) return;
            if (!Similar(fb[x, y], target, tol)) return;

            // найти левую границу серии
            int left = x;
            while (left - 1 >= 0 && Similar(fb[left - 1, y], target, tol))
                left--;

            // найти правую границу серии
            int right = x;
            while (right + 1 < w && Similar(fb[right + 1, y], target, tol))
                right++;

            // закрасить серию
            for (int i = left; i <= right; i++)
                fb[i, y] = replacement;

            // проверяем строки сверху и снизу
            for (int i = left; i <= right; i++)
            {
                if (y - 1 >= 0 && Similar(fb[i, y - 1], target, tol))
                    FloodFillScanline(fb, i, y - 1, target, replacement, tol);

                if (y + 1 < h && Similar(fb[i, y + 1], target, tol))
                    FloodFillScanline(fb, i, y + 1, target, replacement, tol);
            }
        }

        private static bool Similar(Color c, Color refC, int tol) =>
            Math.Abs(c.R - refC.R) <= tol &&
            Math.Abs(c.G - refC.G) <= tol &&
            Math.Abs(c.B - refC.B) <= tol;

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

            if (p.X < offsetX || p.X >= offsetX + drawWidth || p.Y < offsetY || p.Y >= drawHeight + offsetY)
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
