using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FastBitmap; 
using MathPrimitives; 

namespace Lab5
{
    public partial class Form1a : SwitchableForm
    {
        private LSystemDefinition _def;
        private string _lastExpanded = "";
		private bool isTree;
        private int seed;

        public Form1a()
        {
            InitializeComponent();

            Resize += (s, e) =>
			{
				if (_def != null && _lastExpanded != null)
				{
					if (isTree) 
						RenderTree();
					else
						Render();	
				} 
			};
        }

        private void OnRenderClick(object sender, EventArgs e) => Render();
		private void OnRenderTreeClick(object sender, EventArgs e) => RenderTree();

        private void OnOpenClick(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Text files|*.txt;*.lsys;*.cfg|All files|*.*",
                Title = "Выберите файл описания L‑системы"
            };
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    var text = File.ReadAllText(ofd.FileName);
                    _def = LSystemDefinition.Parse(text);
                    _lastExpanded = null;
                    Render();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ошибка чтения: " + ex.Message, "L‑system", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Render()
        {
            if (_def == null) return;
			isTree = false;

            // Параметры
            var iterations = (int)_numIter.Value;
            var stepPx = 1f;
            var jitter = (double)_numJitter.Value; // ± в градусах
            var rnd = new Random(seed);

            // 1) Развёртка
            _lastExpanded = LSystemEngine.Expand(_def.Axiom, _def.Rules, iterations, rnd);

            // 2) Трассировка «черепашкой» в единичных шагах
            var segments = LSystemEngine.Trace(_lastExpanded, 1.0, _def.TurnAngleDeg, _def.InitialDirDeg, jitter, rnd);

            if (segments.Count == 0)
            {
                _canvas.Image = new Bitmap(_canvas.Width, _canvas.Height);
                return;
            }
			
			int maxDepth = 0;
			foreach (var s in segments)
				if (s.Depth > maxDepth) maxDepth = s.Depth;

            // 3) Получим все точки (для масштабирования)
            var allPts = new List<Vec2>(segments.Count * 2);
            foreach (var s in segments) { allPts.Add(s.A); allPts.Add(s.B); }

            // 4) Масштабирование под PictureBox
            FitScaler.FitToTarget(allPts, _canvas.ClientSize, out var toScreen, out var bounds);

            // 5) Рисование в Bitmap с помощью FastBitmap
            var bmp = new Bitmap(Math.Max(1, _canvas.Width), Math.Max(1, _canvas.Height));
            using (var g = Graphics.FromImage(bmp)) g.Clear(Color.White);

            using (var fb = new FastBitmap.FastBitmap(bmp))
            {
                var col = Color.Black;
                foreach (var s in segments)
                {
                    if (!s.Draw) continue;
                    var p0 = toScreen(s.A);
                    var p1 = toScreen(s.B);
                    FastDraw.DrawLine(fb, p0.X, p0.Y, p1.X, p1.Y, col);
                }
            }

            _canvas.Image = bmp;
        }

        private void _btnRandomizeSeed_Click(object sender, EventArgs e)
        {
            seed = Environment.TickCount;
        }

		private void RenderTree()
		{
			if (_def == null) return;
			isTree = true;
			
			// Параметры
			var iterations = (int)_numIter.Value;
			var stepPx = 1f;
			var jitter = (double)_numJitter.Value; // ± в градусах
			var rnd = new Random(seed);

			// 1) Развёртка
			_lastExpanded = LSystemEngine.Expand(_def.Axiom, _def.Rules, iterations, rnd);

			// 2) Трассировка «черепашкой» в единичных шагах
			var segments = LSystemEngine.Trace(
				_lastExpanded, 
				1.0, 
				_def.TurnAngleDeg, 
				_def.InitialDirDeg, 
				jitter, 
				rnd,
				treeMode: true
			);
			
			if (segments.Count == 0)
			{
				_canvas.Image = new Bitmap(_canvas.Width, _canvas.Height);
				return;
			}
			
			int maxDepth = 0;
			foreach (var s in segments)
				if (s.Depth > maxDepth) maxDepth = s.Depth;

			// 3) Получим все точки (для масштабирования)
			var allPts = new List<Vec2>(segments.Count * 2);
			foreach (var s in segments) { allPts.Add(s.A); allPts.Add(s.B); }

			// 4) Масштабирование под PictureBox
			FitScaler.FitToTarget(allPts, _canvas.ClientSize, out var toScreen, out var bounds);

			// 5) Рисование в Bitmap с помощью FastBitmap
			var bmp = new Bitmap(Math.Max(1, _canvas.Width), Math.Max(1, _canvas.Height));
			using (var g = Graphics.FromImage(bmp)) g.Clear(Color.White);

			using (var fb = new FastBitmap.FastBitmap(bmp))
			{
				int baseThickness = 10; // напр., 8–14
				Color brown = Color.FromArgb(139, 69, 19);   // SaddleBrown
				Color green = Color.FromArgb(34, 139, 34);   // ForestGreen

				foreach (var s in segments)
				{
					if (!s.Draw) continue;
					var p0 = toScreen(s.A);
					var p1 = toScreen(s.B);

					// Нормированная глубина [0..1]: 0 — ствол, 1 — тонкие ветви
					double t = (maxDepth > 0) ? (double)s.Depth / maxDepth : 0.0;

					// Толщина: экспоненциальное сужение
					int thickness = Math.Max(1, (int)Math.Round((Math.Pow(1-t, 3)) * baseThickness));

					// Цвет между коричневым и зелёным
					var col = LerpColor(brown, green, t);

					FastDraw.DrawLineThick(fb, p0.X, p0.Y, p1.X, p1.Y, thickness, col);
				}
			}

			_canvas.Image = bmp;
		}
		
		static Color LerpColor(Color a, Color b, double t)
		{
			if (t < 0) t = 0; if (t > 1) t = 1;
			int r = (int)Math.Round(a.R + (b.R - a.R) * t);
			int g = (int)Math.Round(a.G + (b.G - a.G) * t);
			int bch = (int)Math.Round(a.B + (b.B - a.B) * t);
			return Color.FromArgb(r, g, bch);
		}
    }


    internal sealed class LSystemDefinition
    {
        public string Axiom { get; private set; }
        public double TurnAngleDeg { get; private set; }
        public double InitialDirDeg { get; private set; }
        public Dictionary<char, StochasticRule> Rules { get; private set; }

        private LSystemDefinition(string axiom, double angle, double initial, Dictionary<char, StochasticRule> rules)
        {
            Axiom = axiom; TurnAngleDeg = angle; InitialDirDeg = initial; Rules = rules;
        }

        public static LSystemDefinition Parse(string text)
        {
            var lines = text
                .Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None)
                .Select(l => l.Trim())
                .Where(l => l.Length > 0 && !l.StartsWith("#"))
                .ToList();

            string axiom = lines[0];
            var angle = double.Parse(lines[1], NumberStyles.Float, CultureInfo.InvariantCulture);
            var initial = double.Parse(lines[2], NumberStyles.Float, CultureInfo.InvariantCulture);
                

            var rules = new Dictionary<char, StochasticRule>();
            for (int i = 3; i < lines.Count; i++)
            {
                var ln = lines[i];
                var arrowIdx = ln.IndexOf("->", StringComparison.Ordinal); 
                char left = ln.Substring(0, arrowIdx).Trim()[0];
                string right = ln.Substring(arrowIdx + 2).Trim();

                // "w:expr | w:expr | expr | expr"
                var alts = right.Split('|').Select(s => s.Trim()).Where(s => s.Length > 0).ToList();
                var sr = new StochasticRule();
                foreach (var alt in alts)
                {
                    double w = 1.0;
                    string expr = alt;
                    var colon = alt.IndexOf(':');
                    if (colon > 0 && double.TryParse(alt.Substring(0, colon).Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var ww))
                    {
                        w = ww;
                        expr = alt.Substring(colon + 1).Trim();
                    }
                    sr.Add(expr, w);
                }
                rules[left] = sr;
            }

            return new LSystemDefinition(axiom, angle, initial, rules);
        }
    }

    internal sealed class StochasticRule
    {
        private readonly List<(double w, string expr)> _alts = new();
        private double _sum;

        public void Add(string expr, double weight)
        {
            _alts.Add((Math.Max(0, weight), expr ?? string.Empty));
            _sum = _alts.Sum(a => a.w);
        }

        public string Expand(Random rng)
        {
            if (_alts.Count == 0) return string.Empty;
            if (_alts.Count == 1) return _alts[0].expr;

            if (_sum <= 0) 
            {
                int idx = rng.Next(_alts.Count);
                return _alts[idx].expr;
            }

            var r = rng.NextDouble() * _sum;
            double acc = 0;
            foreach (var (w, expr) in _alts)
            {
                acc += w; if (r <= acc) return expr;
            }
            return _alts[^1].expr;
        }
    }

    internal static class LSystemEngine
    {
        public static string Expand(string axiom, Dictionary<char, StochasticRule> rules, int iterations, Random rng)
        {
            string cur = axiom ?? string.Empty;
            for (int it = 0; it < iterations; it++)
            {
                // Быстрая оценка длины
                var est = cur.Length * 2;
                var sb = new System.Text.StringBuilder(est);
                foreach (var ch in cur)
                {
                    if (rules != null && rules.TryGetValue(ch, out var rule)) sb.Append(rule.Expand(rng));
                    else sb.Append(ch);
                }
                cur = sb.ToString();
                // Простейший предохранитель
                if (cur.Length > 5_000_000) break;
            }
            return cur;
        }

        public readonly struct Segment
        {
            public readonly Vec2 A, B;
			public readonly bool Draw;
			public readonly int Depth;

			public Segment(in Vec2 a, in Vec2 b, bool draw, int depth)
			{
				A = a; 
				B = b; 
				Draw = draw;
				Depth = depth;
			}
        }

        public static List<Segment> Trace(string sequence, 
										  double stepLen, 
										  double angleDeg, 
										  double initialDirDeg, 
										  double jitterDeg, 
										  Random rng,
										  bool treeMode = false)
        {
            var segs = new List<Segment>(Math.Max(16, sequence?.Length ?? 0));
            if (string.IsNullOrEmpty(sequence)) return segs;

            var pos = new Vec2(0, 0);
            double dir = initialDirDeg; // градусы CCW от оси X
            var stack = new Stack<(Vec2 pos, double dir)>();

            foreach (char ch in sequence)
            {
                switch (ch)
                {
					case 'H':
					case 'F':
					{
						var depth = stack.Count;
						double stepHere = treeMode ? stepLen * Math.Pow(0.9f, depth) : stepLen;

						var rad = Deg2Rad(dir);
						var delta = new Vec2(Math.Cos(rad) * stepHere, Math.Sin(rad) * stepHere);
						var next = new Vec2(pos.X + delta.X, pos.Y + delta.Y);

						segs.Add(new Segment(pos, next, draw: true, depth: depth));
						pos = next;
						break;
					}
                    case '+':
                        dir += angleDeg + (jitterDeg > 0 ? RandSymmetric(rng, jitterDeg) : 0);
                        break;
                    case '-':
                        dir -= angleDeg + (jitterDeg > 0 ? RandSymmetric(rng, jitterDeg) : 0);
                        break;
                    case '|':
                        dir += 180.0; // разворот
                        break;
                    case '[':
                        stack.Push((pos, dir));
                        break;
                    case ']':
                        if (stack.Count > 0) { var s = stack.Pop(); pos = s.pos; dir = s.dir; }
                        break;
                    default:
                        break;
                }
            }
            return segs;
        }

        private static double Deg2Rad(double deg) => Math.PI * deg / 180.0;
        private static double RandSymmetric(Random rng, double maxAbs) => (rng.NextDouble() * 2 - 1) * maxAbs;
    }

    internal static class FitScaler
    {
        public static void FitToTarget(IReadOnlyList<Vec2> pts, Size target,
            out Func<Vec2, Point> toScreen, out RectangleF bounds)
        {
            if (pts == null || pts.Count == 0)
            {
                toScreen = v => Point.Empty; bounds = RectangleF.Empty; return;
            }

            double minX = pts[0].X, maxX = pts[0].X;
            double minY = pts[0].Y, maxY = pts[0].Y;
            for (int i = 1; i < pts.Count; i++)
            {
                var p = pts[i];
                if (p.X < minX) minX = p.X; if (p.X > maxX) maxX = p.X;
                if (p.Y < minY) minY = p.Y; if (p.Y > maxY) maxY = p.Y;
            }

            double w = Math.Max(1e-9, maxX - minX);
            double h = Math.Max(1e-9, maxY - minY);

            int W = Math.Max(1, target.Width);
            int H = Math.Max(1, target.Height);
            double scale = Math.Min((W) / w, (H) / h);
            if (double.IsInfinity(scale) || double.IsNaN(scale) || scale <= 0) scale = 1.0;

            // Флип по Y для экранных координат
            double maxYd = maxY;
            toScreen = (Vec2 v) =>
            {
                int x = (int)Math.Round((v.X - minX) * scale);
                int y = (int)Math.Round((maxYd - v.Y) * scale);
                if (x < 0) x = 0; if (y < 0) y = 0; if (x >= W) x = W - 1; if (y >= H) y = H - 1;
                return new Point(x, y);
            };

            bounds = new RectangleF((float)minX, (float)minY, (float)w, (float)h);
        }
    }

    internal static class FastDraw
    {
        public static void DrawLine(FastBitmap.FastBitmap fb, int x0, int y0, int x1, int y1, Color color)
        {
            int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
            int dy = -Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
            int err = dx + dy, e2;
            int x = x0, y = y0;
            while (true)
            {
                if ((uint)x < (uint)fb.Width && (uint)y < (uint)fb.Height)
                    fb[x, y] = color;
                if (x == x1 && y == y1) break;
                e2 = 2 * err;
                if (e2 >= dy) { err += dy; x += sx; }
                if (e2 <= dx) { err += dx; y += sy; }
            }
        }
		
		public static void DrawLineThick(FastBitmap.FastBitmap fb, int x0, int y0, int x1, int y1, int thickness, Color color)
		{
			if (thickness <= 1) { DrawLine(fb, x0, y0, x1, y1, color); return; }
			int r = Math.Max(1, thickness / 2);

			int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
			int dy = -Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
			int err = dx + dy, e2;
			int x = x0, y = y0;

			while (true)
			{
				FillDisc(fb, x, y, r, color);
				if (x == x1 && y == y1) break;
				e2 = 2 * err;
				if (e2 >= dy) { err += dy; x += sx; }
				if (e2 <= dx) { err += dx; y += sy; }
			}
		}

		private static void FillDisc(FastBitmap.FastBitmap fb, int cx, int cy, int r, Color color)
		{
			int r2 = r * r;
			for (int dy = -r; dy <= r; dy++)
			{
				int yy = cy + dy;
				if ((uint)yy >= (uint)fb.Height) continue;
				
				int dxlim = (int)Math.Floor(Math.Sqrt(r2 - dy * dy));
				for (int dx = -dxlim; dx <= dxlim; dx++)
				{
					int xx = cx + dx;
					if ((uint)xx >= (uint)fb.Width) continue;
					fb[xx, yy] = color;
				}
			}
		}
    }
}
