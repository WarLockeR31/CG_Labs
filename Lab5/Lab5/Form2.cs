using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form2 : SwitchableForm
    {
        private MidpointDisplacement generator;
        private List<Bitmap> stepBitmaps = new List<Bitmap>();

        public Form2()
        {
            InitializeComponent();
            InitializeEvents();
            GenerateTerrain();
        }

        private void InitializeEvents()
        {
            roughnessTrackBar.Scroll += (s, e) => UpdateLabels();
            snowLevelTrackBar.Scroll += (s, e) => UpdateLabels();
            sizeTrackBar.Scroll += (s, e) => UpdateLabels();

            generateButton.Click += (s, e) => GenerateTerrain();

            UpdateLabels();
        }

        private void UpdateLabels()
        {
            roughnessLabel.Text = $"Шероховатость: {roughnessTrackBar.Value / 100.0:F2}";
            snowLevelLabel.Text = $"Уровень снега: {snowLevelTrackBar.Value / 100.0:F2}";

            int size = (int)Math.Pow(2, sizeTrackBar.Value) + 1;
            sizeLabel.Text = $"Размер: {size}x{size}";
        }

        private void GenerateTerrain()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                generateButton.Enabled = false;

                int size = (int)Math.Pow(2, sizeTrackBar.Value) + 1;
                double roughness = roughnessTrackBar.Value / 100.0;
                int seed = (int)seedNumeric.Value;
                double snowLevel = snowLevelTrackBar.Value / 100.0;

                generator = new MidpointDisplacement(size, roughness, seed);
                generator.Generate();

                Bitmap bitmap = generator.GenerateBitmap(500, 400, snowLevel);

                stepBitmaps.Clear();
                stepBitmaps.Add(bitmap);
                ShowStep(0);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                generateButton.Enabled = true;
            }
        }

        private void ShowStep(int stepIndex)
        {
            if (stepIndex >= 0 && stepIndex < stepBitmaps.Count)
                pictureBox.Image = stepBitmaps[stepIndex];
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (var bitmap in stepBitmaps)
                bitmap?.Dispose();
            stepBitmaps.Clear();
            base.OnFormClosing(e);
        }
    }
}