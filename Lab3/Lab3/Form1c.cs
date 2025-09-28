using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using FastBitmap;

namespace Lab3
{
    public partial class Form1c : SwitchableForm
    {
        private Bitmap _src;

        struct NeighborMap
        {
            private static readonly int[] DX = { 1,  1,  0,  -1, -1, -1,  0,  1 };
            private static readonly int[] DY = { 0, -1, -1,  -1,  0,  1,  1,  1 };

            private int lastMovement = 6;

            public int LastMovement => lastMovement;

            public int[] GetRightDir()
            {
                int[] res = new int[2];
                res[0] = -DY[lastMovement];
                res[1] = DX[lastMovement];
                return res;
            }

            public NeighborMap()
            {
            }

            public int RotateDirection()
            {
                if (lastMovement == 0)
                    lastMovement = 7;
                else
                    lastMovement = (lastMovement - 1) % 8;
                return lastMovement;
            }

            public Point GetNextPoint(Point p)
            {
                int dx = DX[lastMovement];
                int dy = DY[lastMovement];

                return new Point(p.X + dx, p.Y + dy);
            }
        }

        public Form1c()
        {
            InitializeComponent();

            if (pictureBox1 != null)
                pictureBox1.MouseDown += pictureBox1_MouseDown;

            if (btnOpen != null)
                btnOpen.Click += btnOpen_Click;
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

            Color innerColor;
            using (var fb = new FastBitmap.FastBitmap(_src))
                innerColor = fb[seed.X, seed.Y];

            Point? startingPoint = GetFirstBorderPoint(_src, innerColor, seed);
            if (startingPoint == null)
            {
                MessageBox.Show("Ошибка");
                return;
            }

            Color borderColor;
            using (var fb = new FastBitmap.FastBitmap(_src))
                borderColor = fb[startingPoint.Value.X, startingPoint.Value.Y];

            var borderPoints = BuildContour(_src, startingPoint.Value, innerColor, borderColor);
            if (borderPoints.Count == 0)
            {
                MessageBox.Show("Ошибка");
                return;
            }

            Bitmap b = (Bitmap)_src.Clone();

            DrawContour(b, borderPoints, Color.Red); 

            pictureBox1.Image?.Dispose();
            pictureBox1.Image = b;
        }

        private Point? GetFirstBorderPoint(Bitmap bmp, Color innerColor, Point startPoint)
        {
            Queue<Point> q = new Queue<Point>();
            int curX = startPoint.X;
            int curY = startPoint.Y;

            q.Enqueue(new Point(curX + 1, curY));

            while (q.Count > 0)
            {
                Point curPoint = q.Dequeue();

                if ((uint)curPoint.X == bmp.Width) 
                    continue;

                if (bmp.GetPixel(curPoint.X, curPoint.Y) != innerColor)
                {
                    return curPoint;
                }

                q.Enqueue(new Point(curPoint.X + 1, curPoint.Y));
            }

            return null;
        }

        private List<Point> BuildContour(Bitmap bmp, Point seedOnBorder, Color innerColor, Color borderColor)
        {
            int w = bmp.Width, h = bmp.Height;
            var all = new List<Point> { seedOnBorder };
            var nm = new NeighborMap();
            var curPoint = seedOnBorder;
            var visited = new bool[w, h];

            using (var fast = new FastBitmap.FastBitmap(bmp))
            {
                int safety = w * h * 4; 
                while (safety-- > 0)
                {
                    bool found = false;
                    for (int i = 0; i < 8; i++)
                    {
                        var cand = nm.GetNextPoint(curPoint);
                        var innerDir = nm.GetRightDir();
                        var innerPoint = new Point(cand.X + innerDir[0], cand.Y + innerDir[1]);
                        if ((uint)cand.X < w && (uint)cand.Y < h &&
                            !visited[cand.X, cand.Y] &&
                            fast[innerPoint.X, innerPoint.Y] == innerColor &&   
                            fast[cand.X, cand.Y] == borderColor)
                        {
                            curPoint = cand;
                            visited[cand.X, cand.Y] = true;
                            all.Add(curPoint);
                            found = true;
                            break;
                        }
                        nm.RotateDirection();
                    }
                    if (!found) break;                // контур оборвался / цвет неверный
                    if (curPoint == seedOnBorder) break; // вернулись к старту — готово
                }
            }

            return all;
        }
        
        private static void DrawContour(Bitmap bmp, IEnumerable<Point> borderPoints, Color outline)
        {
            using var fb = new FastBitmap.FastBitmap(bmp);
            foreach (var p in borderPoints)
                if ((uint)p.X < bmp.Width && (uint)p.Y < bmp.Height)
                    fb[p.X, p.Y] = outline;
        }

        private static bool TryTranslateToImagePoint(PictureBox pb, Point p, Size imgSize, out Point imgPt)
        {
            var pbSize = pb.ClientSize;
            if (imgSize.Width <= 0 || imgSize.Height <= 0 ||
                pbSize.Width <= 0 || pbSize.Height <= 0)
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

            if (p.X < offsetX || p.X >= offsetX + drawWidth ||
                p.Y < offsetY || p.Y >= offsetY + drawHeight)
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
