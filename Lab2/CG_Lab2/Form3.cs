using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using FastBitmap; // для Select/ForEach

namespace CG_Lab2
{
    public partial class Form3 : SwitchableForm
    {
        private Bitmap _original;
        private Bitmap _preview;

        public Form3()
        {
            InitializeComponent();
            InitUiDefaults();
        }

        private void InitUiDefaults()
        {
            tbHue.Minimum = -180; tbHue.Maximum = 180; tbHue.Value = 0;
            tbSat.Minimum = 0; tbSat.Maximum = 200; tbSat.Value = 100;
            tbVal.Minimum = 0; tbVal.Maximum = 200; tbVal.Value = 100;
            UpdateLabels();
            ToggleUi(false);
        }

        #region Buttons
        private void btnOpen_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Изображения|*.png;*.jpg;*.jpeg;*.bmp;*.gif|Все файлы|*.*"
            };
            if (ofd.ShowDialog(this) != DialogResult.OK) return;

            _original?.Dispose();
            _preview?.Dispose();

            _original = new Bitmap(ofd.FileName);
            _preview = (Bitmap)_original.Clone();
            pb.Image = _preview;

            ToggleUi(true);
            ApplyAndShow();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_preview == null) return;

            using var sfd = new SaveFileDialog
            {
                Filter = "PNG|*.png|JPEG|*.jpg;*.jpeg|BMP|*.bmp",
                FileName = "result.png"
            };
            if (sfd.ShowDialog(this) != DialogResult.OK) return;

            var fmt = ImageFormat.Png;
            var ext = Path.GetExtension(sfd.FileName).ToLowerInvariant();
            if (ext == ".jpg" || ext == ".jpeg") fmt = ImageFormat.Jpeg;
            else if (ext == ".bmp") fmt = ImageFormat.Bmp;

            _preview.Save(sfd.FileName, fmt);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbHue.Value = 0; tbSat.Value = 100; tbVal.Value = 100;
            UpdateLabels();
            ApplyAndShow();
        }
        #endregion

        #region TrackBars
        private void tbHue_Scroll(object sender, EventArgs e) { UpdateLabels(); ApplyAndShow(); }
        private void tbSat_Scroll(object sender, EventArgs e) { UpdateLabels(); ApplyAndShow(); }
        private void tbVal_Scroll(object sender, EventArgs e) { UpdateLabels(); ApplyAndShow(); }
        #endregion

        private void UpdateLabels()
        {
            lblHue.Text = $"Hue: {tbHue.Value}°";
            lblSat.Text = $"Sat: {tbSat.Value}%";
            lblVal.Text = $"Val: {tbVal.Value}%";
        }

        private void ToggleUi(bool on)
        {
            tbHue.Enabled = tbSat.Enabled = tbVal.Enabled = btnSave.Enabled = btnReset.Enabled = on;
        }

        private void ApplyAndShow()
        {
            if (_original == null) return;

            int hueDelta = tbHue.Value;          // -180..+180 градусов
            double sMul = tbSat.Value / 100.0;  // 0..2.0
            double vMul = tbVal.Value / 100.0;  // 0..2.0

            _preview?.Dispose();
            _preview = _original.Select(c =>
            {
                double h, s, v;
                RgbToHsv(c, out h, out s, out v);

                h = (h + hueDelta) % 360.0; if (h < 0) h += 360.0;
                s = Clamp01(s * sMul);
                v = Clamp01(v * vMul);

                return HsvToRgb(h, s, v, c.A);
            });

            pb.Image = _preview;
        }

        #region RGB<->HSV 
        private static void RgbToHsv(Color c, out double h, out double s, out double v)
        {
            double r = c.R / 255.0, g = c.G / 255.0, b = c.B / 255.0;
            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double delta = max - min;

            // Hue
            if (delta == 0) h = 0;
            else if (max == r) h = 60.0 * (((g - b) / delta) % 6.0);
            else if (max == g) h = 60.0 * (((b - r) / delta) + 2.0);
            else h = 60.0 * (((r - g) / delta) + 4.0);
            if (h < 0) h += 360.0;

            // Saturation & Value
            v = max;
            s = max == 0 ? 0 : delta / max;
        }

        private static Color HsvToRgb(double h, double s, double v, byte a = 255)
        {
            double c = v * s;
            double hp = h / 60.0;
            double x = c * (1.0 - Math.Abs(hp % 2.0 - 1.0));

            double r1 = 0, g1 = 0, b1 = 0;
            if (0 <= hp && hp < 1) { r1 = c; g1 = x; b1 = 0; }
            else if (1 <= hp && hp < 2) { r1 = x; g1 = c; b1 = 0; }
            else if (2 <= hp && hp < 3) { r1 = 0; g1 = c; b1 = x; }
            else if (3 <= hp && hp < 4) { r1 = 0; g1 = x; b1 = c; }
            else if (4 <= hp && hp < 5) { r1 = x; g1 = 0; b1 = c; }
            else { r1 = c; g1 = 0; b1 = x; }

            double m = v - c;
            byte R = (byte)Math.Round(Clamp01(r1 + m) * 255.0);
            byte G = (byte)Math.Round(Clamp01(g1 + m) * 255.0);
            byte B = (byte)Math.Round(Clamp01(b1 + m) * 255.0);
            return Color.FromArgb(a, R, G, B);
        }
        #endregion

        private static double Clamp01(double x) => x < 0 ? 0 : (x > 1 ? 1 : x);

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _preview?.Dispose();
            _original?.Dispose();
            base.OnFormClosed(e);
        }

        private void lblHue_Click(object sender, EventArgs e)
        {

        }

        private void lblVal_Click(object sender, EventArgs e)
        {

        }
    }
}
