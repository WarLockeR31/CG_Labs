using MathPrimitives;
using Renderer;
using Topology;
using Topology.IO;
using Timer = System.Windows.Forms.Timer;

namespace Lab9
{
    public partial class Form1 : Form
    {
        private Polyhedron currentPolyhedron;
        private readonly MeshRenderer _renderer = new MeshRenderer
        {
            Projection = ProjectionType.Perspective
        };
        private readonly Timer _timer = new Timer { Interval = 33 };
        private string? _currentPath;

        public Form1()
        {
            InitializeComponent();

            cmbFunction.Items.AddRange(new string[]
            {
                    "z = x² + y²",
                    "z = x² - y²",
                    "z = sin(x)·cos(y)",
                    "z = sin(√(x²+y²))",
                    "z = e^(-x² - y²)",
                    "z = 0 (плоскость)"
            });
            cmbFunction.SelectedIndex = 0;
            _timer.Tick += (_, __) => pb.Invalidate();
            _timer.Start();

            this.KeyPreview = true;

            this.KeyDown += Form1_KeyDown;

            cmbAxis.SelectedIndex = 0;


            tb_camYaw.Value = (int)_renderer.YawDegrees;
            lbl_camYaw.Text = "Yaw: " + (int)_renderer.YawDegrees;

            tb_camPitch.Value = (int)_renderer.PitchDegrees;
            lbl_camPitch.Text = "Pitch: " + (int)_renderer.PitchDegrees;
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

        #region Keyboard
        //---------------------------------------------------- KEYBOARD ----------------------------------------------------
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
        #endregion

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

        private void btn_lab8_Click(object sender, EventArgs e)
        {
            ResetLabGroupBoxes();
            gb_lab8.Visible = true;
            btn_lab8.Enabled = false;
        }

        private void ResetLabGroupBoxes()
        {
            gb_lab6.Visible = false;
            gb_lab7.Visible = false;
            gb_lab8.Visible = false;

            btn_lab6.Enabled = true;
            btn_lab7.Enabled = true;
            btn_lab8.Enabled = true;
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

        private void btn_Surface_Click(object sender, EventArgs e)
        {
            SurfacePlotter.Function2D func = cmbFunction.SelectedIndex switch
            {
                0 => (x, y) => x * x + y * y,                          // параболоид
                1 => (x, y) => x * x - y * y,                          // седло
                2 => (x, y) => Math.Sin(x) * Math.Cos(y),              // волна
                3 => (x, y) => Math.Sin(Math.Sqrt(x * x + y * y + 1e-6)), // круговая волна
                4 => (x, y) => Math.Exp(-x * x - y * y),               // гаусс
                _ => (x, y) => 0.0                                     // плоскость
            };

            double x0 = (double)numX0.Value;
            double x1 = (double)numX1.Value;
            double y0 = (double)numY0.Value;
            double y1 = (double)numY1.Value;
            int nx = (int)numNX.Value;
            int ny = (int)numNY.Value;

            var poly = SurfacePlotter.Create(func, x0, x1, y0, y1, nx, ny);
            if (poly != null)
            {
                _renderer.Model = poly;
                btn_modelSave.Enabled = true;
                pb.Invalidate();
            }
        }

        // Обработчики для фигуры вращения:
        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            dgvProfile.Rows.Add(0, 0, 0);
        }

        private void btnClearPoints_Click(object sender, EventArgs e)
        {
            dgvProfile.Rows.Clear();
        }

        private void btnAddSample_Click(object sender, EventArgs e)
        {
            // Пример профиля для тора (круг в плоскости XY)
            dgvProfile.Rows.Clear();

            // Создаем круг из 8 точек
            int points = 8;
            double radius = 1.0;
            double centerX = 3.0; // Смещение от центра для тора

            for (int i = 0; i < points; i++)
            {
                double angle = 2 * Math.PI * i / points;
                double x = centerX + radius * Math.Cos(angle);
                double y = radius * Math.Sin(angle);
                double z = 0;
                dgvProfile.Rows.Add(Math.Round(x, 2), Math.Round(y, 2), Math.Round(z, 2));
            }
        }

        private void btnBuildRotation_Click(object sender, EventArgs e)
        {
            if (dgvProfile.Rows.Count < 2)
            {
                MessageBox.Show("Добавьте хотя бы 2 точки профиля");
                return;
            }

            try
            {
                // Считываем точки профиля
                var profile = new List<Vec3>();
                foreach (DataGridViewRow row in dgvProfile.Rows)
                {
                    if (row.IsNewRow) continue;

                    double x = Convert.ToDouble(row.Cells[0].Value ?? 0);
                    double y = Convert.ToDouble(row.Cells[1].Value ?? 0);
                    double z = Convert.ToDouble(row.Cells[2].Value ?? 0);
                    profile.Add(new Vec3(x, y, z));
                }

                // Получаем параметры
                var axis = cmbRotationAxis.SelectedItem?.ToString() switch
                {
                    "X" => Axis.X,
                    "Y" => Axis.Y,
                    "Z" => Axis.Z,
                    _ => Axis.Y
                };

                int segments = (int)numSegments.Value;

                // Строим фигуру вращения
                var poly = RotationSurface.Create(profile, axis, segments);
                if (poly != null)
                {
                    _renderer.Model = poly;
                    btn_modelSave.Enabled = true;
                    pb.Invalidate();

                    MessageBox.Show($"Фигура вращения построена!\nВершин: {poly.Vertices.Count}\nГраней: {poly.Faces.Count}",
                                  "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка построения: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_camPitch_Scroll(object sender, EventArgs e)
        {
            _renderer.PitchDegrees = tb_camPitch.Value;
            lbl_camPitch.Text = "Pitch: " + tb_camPitch.Value;
        }

        private void tb_camYaw_Scroll(object sender, EventArgs e)
        {
            _renderer.YawDegrees = tb_camYaw.Value;
            lbl_camYaw.Text = "Yaw: " + tb_camYaw.Value;
        }

        private void btn_cullBackfaces_Click(object sender, EventArgs e)
        {
            _renderer.CullBackFaces = !_renderer.CullBackFaces;
            btn_cullBackfaces.Text = "Backface Culling: " + (_renderer.CullBackFaces ? "On" : "Off");
        }

        private void btn_normalsDisplay_Click(object sender, EventArgs e)
        {
            _renderer.ShowFaceNormals = !_renderer.ShowFaceNormals;
            btn_normalsDisplay.Text = "Face Normals: " + (_renderer.ShowFaceNormals ? "On" : "Off");
        }

        private void btn_renderMode_Click(object sender, EventArgs e)
        {
            switch (_renderer.RenderMode)
            {
                case Renderer.RenderMode.Wireframe:
                    _renderer.RenderMode = Renderer.RenderMode.Gouraud;
                    break;

                case Renderer.RenderMode.Gouraud:
                    _renderer.RenderMode = Renderer.RenderMode.ZBuffer;
                    break;

                case Renderer.RenderMode.ZBuffer:
                default:
                    _renderer.RenderMode = Renderer.RenderMode.Wireframe;
                    break;
            }

            btn_renderMode.Text = "Render Mode: " + _renderer.RenderMode;
            pb.Invalidate();
        }
    }
}
