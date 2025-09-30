using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using FastBitmap;

namespace Lab3
{
    public partial class Form1c : SwitchableForm
    {
        private Bitmap _src;
        private Bitmap _current;

        struct NeighborMap
        {
            private static readonly int[] DX = { 1, 1, 0, -1, -1, -1, 0, 1 };
            private static readonly int[] DY = { 0, -1, -1, -1, 0, 1, 1, 1 };

            private int lastMovement = 6;

            public int LastMovement => lastMovement;

            public int[] GetRightDir()
            {
                int[] res = new int[2];
                res[0] = -DY[lastMovement];
                res[1] = DX[lastMovement];
                return res;
            }

            public int[] GetRightDir(int move)
            {
                int[] res = new int[2];
                res[0] = -DY[move];
                res[1] = DX[move];
                return res;
            }

            public NeighborMap()
            {
            }

            public int RotateDirection()
            {
                lastMovement = NextDirection(lastMovement);
                return lastMovement;
            }

            public int NextDirection(int move)
            {
                return (move + 1) % 8;
            }

            public int PrevDirection(int move)
            {
                if (move == 0)
                    return 7;

                return (move - 1) % 8;
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

                    _current = (Bitmap)_src.Clone();
                    pictureBox1.Image = _current;
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_current == null) return;
            if (!TryTranslateToImagePoint(pictureBox1, e.Location, _current.Size, out var seed))
                return;

            Color innerColor;
            using (var fb = new FastBitmap.FastBitmap(_current))
                innerColor = fb[seed.X, seed.Y];

            Point? startingPoint = GetFirstBorderPoint(_current, innerColor, seed);
            if (startingPoint == null)
            {
                MessageBox.Show("Ошибка");
                return;
            }

            Color borderColor;
            using (var fb = new FastBitmap.FastBitmap(_current))
                borderColor = fb[startingPoint.Value.X, startingPoint.Value.Y];

            var borderPoints = BuildContour(_current, startingPoint.Value, innerColor, borderColor);
            if (borderPoints.Count == 0)
            {
                MessageBox.Show("Ошибка");
                return;
            }

            DrawContour(_current, borderPoints, Color.Red);
            pictureBox1.Image = _current;
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
            var all = new List<Point> { };
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

                        if (nm.LastMovement % 2 == 0)
                        {
                            var innerDir = nm.GetRightDir();
                            var innerPoint = new Point(cand.X + innerDir[0], cand.Y + innerDir[1]);
                            if ((uint)cand.X < w && (uint)cand.Y < h &&
                                !visited[cand.X, cand.Y] &&
                                fast[innerPoint.X, innerPoint.Y] == innerColor &&
                                fast[cand.X, cand.Y] == borderColor)
                            {
                                curPoint = cand;
                                visited[cand.X, cand.Y] = true;
                                all.Add(innerPoint);
                                found = true;
                                break;
                            }
                            nm.RotateDirection();
                        }
                        else
                        {
                            var innerDir1 = nm.GetRightDir(nm.NextDirection(nm.LastMovement));
                            var innerPoint1 = new Point(cand.X + innerDir1[0], cand.Y + innerDir1[1]);
                            var isInner1 = fast[innerPoint1.X, innerPoint1.Y] == innerColor;

                            var innerDir2 = nm.GetRightDir(nm.PrevDirection(nm.LastMovement));
                            var innerPoint2 = new Point(cand.X + innerDir2[0], cand.Y + innerDir2[1]);
                            var isInner2 = fast[innerPoint2.X, innerPoint2.Y] == innerColor;

                            if ((uint)cand.X < w && (uint)cand.Y < h &&
                                !visited[cand.X, cand.Y] &&
                                (isInner1 || isInner2) &&
                                fast[cand.X, cand.Y] == borderColor)
                            {
                                curPoint = cand;
                                visited[cand.X, cand.Y] = true;
                                if (isInner1) all.Add(innerPoint1);
                                if (isInner2) all.Add(innerPoint2);
                                found = true;
                                break;
                            }
                            nm.RotateDirection();
                        }


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

        private void btnClear_Click(object sender, EventArgs e)
        {
            _current = (Bitmap)_src.Clone();
            pictureBox1.Image = _current;
        }
    }
}
