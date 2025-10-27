using MathPrimitives;
using Renderer;
using Topology;
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
			
			this.KeyPreview = true;
			
			this.KeyDown += Form1_KeyDown;
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
			
			btn_Projection.Text = "Projection: " +
								 (_renderer.Projection == ProjectionType.Perspective ? "Perspective " : "Axonometric");
		}

		private void tb_FOV_Scroll(object sender, EventArgs e)
		{
			_renderer.FOV = tb_FOV.Value;
			lbl_FOV.Text = "FOV: " + tb_FOV.Value;
		}
		
		
		private void Form1_KeyDown(object? sender, KeyEventArgs e)
		{
			Action<Mat4> func = e.Control ? _renderer.ApplyModelTransformLocal : _renderer.ApplyModelTransformWorld;

			if (e.KeyCode == Keys.Left)
			{
				func(Mat4.RotationY(+0.05));
				pb.Invalidate();
				e.Handled = true;
			}
			if (e.KeyCode == Keys.Right)
			{
				func(Mat4.RotationY(-0.05));
				pb.Invalidate();
				e.Handled = true;
			}
			if (e.KeyCode == Keys.Up)
			{
				func(Mat4.RotationX(+0.05));
				pb.Invalidate();
				e.Handled = true;
			}
			if (e.KeyCode == Keys.Down)
			{
				func(Mat4.RotationX(-0.05));
				pb.Invalidate();
				e.Handled = true;
			}
		}

		private void tb_Distance_Scroll(object sender, EventArgs e)
		{
			_renderer.Distance = tb_Distance.Value;
			lbl_Distance.Text = "Distance: " + tb_Distance.Value;
		}

		#region Model Buttons

		private void btn_Octa_Click(object sender, EventArgs e)
		{
			_renderer.Model = Polyhedron.RegularOctahedron(MeshRenderer.StandardScale);
			EnableButtons();
			btn_Octa.Enabled = false;
		}

		private void btn_Hexa_Click(object sender, EventArgs e)
		{
			_renderer.Model = Polyhedron.RegularHexahedron(MeshRenderer.StandardScale);
			EnableButtons();
			btn_Hexa.Enabled = false;
		}

		private void btn_Tetra_Click(object sender, EventArgs e)
		{
			_renderer.Model = Polyhedron.RegularTetrahedron(MeshRenderer.StandardScale);
			EnableButtons();
			btn_Tetra.Enabled = false;
		}
		
		private void btn_Ico_Click(object sender, EventArgs e)
		{
			_renderer.Model = Polyhedron.RegularIcosahedron(MeshRenderer.StandardScale);
			EnableButtons();
			btn_Ico.Enabled = false;
		}

		private void btn_Dode_Click(object sender, EventArgs e)
		{
			_renderer.Model = Polyhedron.RegularDodecahedron(MeshRenderer.StandardScale);
			EnableButtons();
			btn_Dode.Enabled = false;
		}

		private void EnableButtons()
		{
			btn_Tetra.Enabled	= true;
			btn_Hexa.Enabled	= true;
			btn_Octa.Enabled	= true;
			btn_Ico.Enabled		= true;
			btn_Dode.Enabled	= true;
		}

		#endregion

		private void btn_Reset_Click(object sender, EventArgs e)
		{
			_renderer.ResetView();
		}
	}
}
