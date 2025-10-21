using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form3 : SwitchableForm
    {
        private List<Point> controlPoints = new List<Point>();
        private Point selectedPoint = Point.Empty;
        private bool isDragging = false;
        private const int pointRadius = 6;
        private Pen curvePen = new Pen(Color.Blue, 2f);
        private Pen controlLinePen = new Pen(Color.Gray, 1f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
        private Pen tangentPen = new Pen(Color.Red, 1f);
        private Brush pointBrush = Brushes.Red;
        private Brush selectedPointBrush = Brushes.Gold;

        public Form3()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += Form3_Paint;
            this.MouseDown += Form3_MouseDown;
            this.MouseMove += Form3_MouseMove;
            this.MouseUp += Form3_MouseUp;
            this.KeyDown += Form3_KeyDown;
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Рисуем контрольные линии
            if (controlPoints.Count >= 2)
            {
                g.DrawLines(controlLinePen, controlPoints.ToArray());
            }

            // Рисуем кривые Безье
            if (controlPoints.Count >= 4)
            {
                for (int i = 0; i <= controlPoints.Count - 4; i += 3)
                {
                    DrawBezierSegment(g, controlPoints[i], controlPoints[i + 1],
                                    controlPoints[i + 2], controlPoints[i + 3]);
                }
            }

            // Рисуем контрольные точки
            for (int i = 0; i < controlPoints.Count; i++)
            {
                Brush brush = (controlPoints[i] == selectedPoint) ? selectedPointBrush : pointBrush;
                g.FillEllipse(brush, controlPoints[i].X - pointRadius,
                            controlPoints[i].Y - pointRadius,
                            pointRadius * 2, pointRadius * 2);

                // Подписываем точки
                g.DrawString(i.ToString(), this.Font, Brushes.Black,
                           controlPoints[i].X + pointRadius + 2,
                           controlPoints[i].Y - pointRadius);
            }
        }

        private void DrawBezierSegment(Graphics g, Point p0, Point p1, Point p2, Point p3)
        {
            // Рисуем касательные
            g.DrawLine(tangentPen, p0, p1);
            g.DrawLine(tangentPen, p2, p3);

            // Рисуем сегмент кривой Безье
            List<Point> curvePoints = new List<Point>();
            for (double t = 0; t <= 1; t += 0.01)
            {
                Point point = CalculateBezierPoint(t, p0, p1, p2, p3);
                curvePoints.Add(point);
            }

            if (curvePoints.Count >= 2)
            {
                g.DrawLines(curvePen, curvePoints.ToArray());
            }
        }

        private Point CalculateBezierPoint(double t, Point p0, Point p1, Point p2, Point p3)
        {
            double u = 1 - t;
            double u2 = u * u;
            double u3 = u2 * u;
            double t2 = t * t;
            double t3 = t2 * t;

            double x = u3 * p0.X + 3 * u2 * t * p1.X + 3 * u * t2 * p2.X + t3 * p3.X;
            double y = u3 * p0.Y + 3 * u2 * t * p1.Y + 3 * u * t2 * p2.Y + t3 * p3.Y;

            return new Point((int)Math.Round(x), (int)Math.Round(y));
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Проверяем, кликнули ли на существующую точку
                Point clickedPoint = FindPointAt(e.Location);
                if (clickedPoint != Point.Empty)
                {
                    selectedPoint = clickedPoint;
                    isDragging = true;
                }
                else
                {
                    // Добавляем новую точку
                    controlPoints.Add(e.Location);
                    selectedPoint = e.Location;
                    isDragging = true;
                }
                this.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Удаляем точку
                Point pointToRemove = FindPointAt(e.Location);
                if (pointToRemove != Point.Empty)
                {
                    controlPoints.Remove(pointToRemove);
                    selectedPoint = Point.Empty;
                    this.Invalidate();
                }
            }
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && selectedPoint != Point.Empty)
            {
                // Перемещаем выбранную точку
                int index = controlPoints.IndexOf(selectedPoint);
                if (index != -1)
                {
                    controlPoints[index] = e.Location;
                    selectedPoint = e.Location;
                    this.Invalidate();
                }
            }
        }

        private void Form3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && selectedPoint != Point.Empty)
            {
                controlPoints.Remove(selectedPoint);
                selectedPoint = Point.Empty;
                this.Invalidate();
            }
        }

        private Point FindPointAt(Point location)
        {
            foreach (Point point in controlPoints)
            {
                if (Math.Abs(point.X - location.X) <= pointRadius &&
                    Math.Abs(point.Y - location.Y) <= pointRadius)
                {
                    return point;
                }
            }
            return Point.Empty;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            controlPoints.Clear();
            selectedPoint = Point.Empty;
            this.Invalidate();
        }
    }
}