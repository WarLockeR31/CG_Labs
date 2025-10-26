using Renderer;
using Timer = System.Windows.Forms.Timer;

namespace Lab6
{
    public partial class Form1 : Form
    {
		private readonly MeshRenderer _renderer = new MeshRenderer
		{
			Projection = ProjectionType.Perspective
		};
		private readonly Timer _timer = new Timer { Interval = 33 };

		public Form1()
		{
			InitializeComponent();
			_timer.Tick += (_, __) => pb.Invalidate();
			_timer.Start();
		}

		private void pb_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear(pb.BackColor);
			_renderer.Render(e.Graphics, pb.ClientRectangle);
		}

		private void btnProjection_Click(object? sender, EventArgs e)
		{
			switch (_renderer.Projection)
			{
				case ProjectionType.Perspective:
					_renderer.Projection = ProjectionType.Axonometric;
					break;
				case ProjectionType.Axonometric:
					_renderer.Projection = ProjectionType.Perspective;
					break;
				default:
					throw new ArgumentOutOfRangeException(); // should never happen
			}
			
			btnProjection.Text = "Projection: " +
								 (_renderer.Projection == ProjectionType.Perspective ? "Perspective " : "Axonometric");
		}

		private void tb_Focal_Scroll(object sender, EventArgs e)
		{
			_renderer.Focal = tb_Focal.Value;
			lbl_Focal.Text = "Focal: " + tb_Focal.Value;
		}
	}
}
