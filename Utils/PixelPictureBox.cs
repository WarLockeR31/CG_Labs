using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lab3   
{
    public class PixelPictureBox : PictureBox
    {
        public PixelPictureBox() => SizeMode = PictureBoxSizeMode.Zoom;

        public InterpolationMode InterpolationMode { get; set; } =
            InterpolationMode.NearestNeighbor;

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            base.OnPaint(e);
        }
    }
}