using MathPrimitives;
using Renderer;
using Topology;
using Topology.IO;
using Timer = System.Windows.Forms.Timer;

namespace Lab7
{
    public partial class Form1 : Form
    {
        private readonly MeshRenderer _renderer = new MeshRenderer
        {
            Projection = ProjectionType.Perspective
        };
        private readonly Timer _timer = new Timer { Interval = 33 };
		private string? _currentPath;

        public Form1()
        {
            InitializeComponent();
            _timer.Tick += (_, __) => pb.Invalidate();
            _timer.Start();

            this.KeyPreview = true;

            this.KeyDown += Form1_KeyDown;

            cmbAxis.SelectedIndex = 0;

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

        private static bool isRotating = false;
        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            Action<Mat4> func = e.Control ? _renderer.ApplyModelTransformLocal : _renderer.ApplyModelTransformWorld;

            if (e.KeyCode == Keys.R)
            {
                if (isRotating)
                    _timer.Tick -= TimerRotate;
                else
                    _timer.Tick += TimerRotate;
                isRotating = !isRotating;
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                func(Mat4.RotationY(+0.05));
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                func(Mat4.RotationY(-0.05));
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                func(Mat4.RotationX(+0.05));
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                func(Mat4.RotationX(-0.05));
                e.Handled = true;
            }
        }

        private void TimerRotate(object? sender, EventArgs e)
        {
            _renderer.ApplyModelTransformWorld(Mat4.RotationY(-0.05));
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
            ResetModelButtons();
            btn_Octa.Enabled = false;
			btn_modelSave.Enabled = true;
		}

        private void btn_Hexa_Click(object sender, EventArgs e)
        {
            _renderer.Model = Polyhedron.RegularHexahedron(MeshRenderer.StandardScale);
            ResetModelButtons();
            btn_Hexa.Enabled = false;
			btn_modelSave.Enabled = true;
        }

        private void btn_Tetra_Click(object sender, EventArgs e)
        {
            _renderer.Model = Polyhedron.RegularTetrahedron(MeshRenderer.StandardScale);
            ResetModelButtons();
            btn_Tetra.Enabled = false;
			btn_modelSave.Enabled = true;
        }

        private void btn_Ico_Click(object sender, EventArgs e)
        {
            _renderer.Model = Polyhedron.RegularIcosahedron(MeshRenderer.StandardScale);
            ResetModelButtons();
            btn_Ico.Enabled = false;
			btn_modelSave.Enabled = true;
        }

        private void btn_Dode_Click(object sender, EventArgs e)
        {
            _renderer.Model = Polyhedron.RegularDodecahedron(MeshRenderer.StandardScale);
            ResetModelButtons();
            btn_Dode.Enabled = false;
			btn_modelSave.Enabled = true;
        }

        private void ResetModelButtons()
        {
            btn_Tetra.Enabled = true;
            btn_Hexa.Enabled = true;
            btn_Octa.Enabled = true;
            btn_Ico.Enabled = true;
            btn_Dode.Enabled = true;
        }

        #endregion

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            _renderer.ResetView();
        }

        private void BtnTranslate_Click(object? sender, EventArgs e)
        {
            if (_renderer.Model == null) return;

            var tx = (double)numTX.Value;
            var ty = (double)numTY.Value;
            var tz = (double)numTZ.Value;

            var translation = Mat4.Translation(tx, ty, tz);
            _renderer.ApplyModelTransformWorld(translation);
        }

        private void BtnRotate_Click(object? sender, EventArgs e)
        {
            if (_renderer.Model == null) return;

            var rx = (double)numRX.Value * Math.PI / 180.0;
            var ry = (double)numRY.Value * Math.PI / 180.0;
            var rz = (double)numRZ.Value * Math.PI / 180.0;

            var rotation = Mat4.RotationX(rx) * Mat4.RotationY(ry) * Mat4.RotationZ(rz);
            _renderer.ApplyModelTransformWorld(rotation);
        }

        private void BtnScale_Click(object? sender, EventArgs e)
        {
            if (_renderer.Model == null) return;

            var sx = (double)numSX.Value;
            var sy = (double)numSY.Value;
            var sz = (double)numSZ.Value;

            // ��������� ����� �������������
            var center = CalculateMeshCenter();

            var scaling = Mat4.ScaleAtOrigin(sx, sy, sz, center);
            _renderer.ApplyModelTransformWorld(scaling);
        }

        private void BtnReflectXY_Click(object? sender, EventArgs e)
        {
            if (_renderer.Model == null) return;

            var reflection = Mat4.ReflectionXY();
            _renderer.ApplyModelTransformWorld(reflection);
        }

        private void BtnReflectXZ_Click(object? sender, EventArgs e)
        {
            if (_renderer.Model == null) return;

            var reflection = Mat4.ReflectionXZ();
            _renderer.ApplyModelTransformWorld(reflection);
        }

        private void BtnReflectYZ_Click(object? sender, EventArgs e)
        {
            if (_renderer.Model == null) return;

            var reflection = Mat4.ReflectionYZ();
            _renderer.ApplyModelTransformWorld(reflection);
        }

        // ��������������� ����� ��� ���������� ������ �������������
        private Vec3 CalculateMeshCenter()
        {
            if (_renderer.Model == null || _renderer.Model.Vertices.Count == 0)
                return Vec3.Zero;

            var sum = _renderer.Model.Vertices.Aggregate(Vec3.Zero, (acc, v) => acc + v);
            return sum * (1.0 / _renderer.Model.Vertices.Count);
        }


        private void BtnRotateParallelAxis_Click(object? sender, EventArgs e)
        {
            if (_renderer.Model == null) return;

            var center = CalculateMeshCenter();
            var angle = (double)numParallelAngle.Value * Math.PI / 180.0;
            var axis = cmbAxis.SelectedItem?.ToString();

            Mat4 rotation;
            switch (axis)
            {
                case "X":
                    rotation = Mat4.RotationAroundAxisX(center, angle);
                    break;
                case "Y":
                    rotation = Mat4.RotationAroundAxisY(center, angle);
                    break;
                case "Z":
                    rotation = Mat4.RotationAroundAxisZ(center, angle);
                    break;
                default:
                    MessageBox.Show("�������� ��� ��������");
                    return;
            }

            _renderer.ApplyModelTransformWorld(rotation);
        }

        private void BtnRotateArbitraryAxis_Click(object? sender, EventArgs e)
        {
            if (_renderer.Model == null) return;

            var point1 = new Vec3(
                (double)numAxisX1.Value,
                (double)numAxisY1.Value,
                (double)numAxisZ1.Value
            );

            var point2 = new Vec3(
                (double)numAxisX2.Value,
                (double)numAxisY2.Value,
                (double)numAxisZ2.Value
            );

            var angle = (double)numArbitraryAngle.Value * Math.PI / 180.0;

            if (Vec3Math.Distance(point1, point2) < 1e-10)
            {
                MessageBox.Show("����� �� ������ ���������");
                return;
            }

            var rotation = Mat4.RotationAroundArbitraryAxis(point1, point2, angle);
            _renderer.ApplyModelTransformWorld(rotation);
        }

		private void btn_lab6_Click(object sender, EventArgs e)
		{
			ResetLabGroupBoxes();
			gb_lab6.Visible = true;
			btn_lab6.Enabled = false;
		}

		private void btn_lab7_Click(object sender, EventArgs e)
		{
			ResetLabGroupBoxes();
			gb_lab7.Visible = true;
			btn_lab7.Enabled = false;
		}

		private void ResetLabGroupBoxes()
		{
			gb_lab6.Visible = false;
			gb_lab7.Visible = false;
			
			btn_lab6.Enabled = true;
			btn_lab7.Enabled = true;
		}
		
		
		#region Model Load/Save
		
		private void btn_modelLoad_Click(object sender, EventArgs e)
		{
			ResetModelButtons();
			btn_modelSave.Enabled = true;
			
			using var ofd = new OpenFileDialog
			{
				Title = "Open model (.obj)",
				Filter = "Wavefront OBJ (*.obj)|*.obj|All files (*.*)|*.*",
				CheckFileExists = true,
				Multiselect = false
			};

			if (ofd.ShowDialog(this) != DialogResult.OK)
				return;

			try
			{
				var mesh = ObjIO.Load(ofd.FileName);
				_renderer.Model = mesh;
				_currentPath = ofd.FileName;

				MessageBox.Show(
					this,
					$"Model loaded.\nVertices: {_renderer.Model.Vertices.Count}\nFaces: {_renderer.Model.Faces.Count}",
					"Loading complete",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					this,
					$"File was not loaded.\n{ex.GetType().Name}: {ex.Message}",
					"Loading error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void btn_modelSave_Click(object sender, EventArgs e)
		{
			if (_renderer.Model is null)
			{
				MessageBox.Show(
					this,
					"There is no model to save..",
					"Saving",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			var curModelTransform = _renderer.CurModelTransform();
			var untrasformedModel = _renderer.Model;
			var transformedModel = new Polyhedron(curModelTransform.ToList(), untrasformedModel.Faces);

			using var sfd = new SaveFileDialog
			{
				Title = "Save model (.obj)",
				Filter = "Wavefront OBJ (*.obj)|*.obj|All files (*.*)|*.*",
				FileName = Path.GetFileName(_currentPath ?? "mesh.obj"),
				AddExtension = true,
				DefaultExt = "obj",
				OverwritePrompt = true
			};

			if (sfd.ShowDialog(this) != DialogResult.OK)
				return;

			try
			{
				ObjIO.Save(transformedModel, sfd.FileName);
				_currentPath = sfd.FileName;

				MessageBox.Show(
					this,
					"File saved successfully.",
					"Saving",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					this,
					$"File was not saved.\n{ex.GetType().Name}: {ex.Message}",
					"Saving error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
		
		#endregion
	}
}
