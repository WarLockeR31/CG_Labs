using FastBitmap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Lab2
{
    public partial class Form2 : SwitchableForm
    {
        private Bitmap _src, _rImg, _gImg, _bImg;

        public Form2()
        {
            InitializeComponent();
            ToggleUi(false);
        }

        private void ToggleUi(bool on)
        {
            btnSave.Enabled = on;
            pbR.Enabled = pbG.Enabled = pbB.Enabled = on;
            hR.Enabled = hG.Enabled = hB.Enabled = on;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Изображения|*.png;*.jpg;*.jpeg;*.bmp;*.gif|Все файлы|*.*"
            };
            if (ofd.ShowDialog(this) != DialogResult.OK) return;

            DisposeAll();

            _src = new Bitmap(ofd.FileName);
            pbSrc.Image = _src;

            MakeChannelsAndHists();
            ToggleUi(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_rImg == null) return;
            using var fbd = new FolderBrowserDialog { Description = "Куда сохранить каналы (PNG)" };
            if (fbd.ShowDialog(this) != DialogResult.OK) return;

            _rImg.Save(Path.Combine(fbd.SelectedPath, "R.png"), ImageFormat.Png);
            _gImg.Save(Path.Combine(fbd.SelectedPath, "G.png"), ImageFormat.Png);
            _bImg.Save(Path.Combine(fbd.SelectedPath, "B.png"), ImageFormat.Png);
        }

        private void MakeChannelsAndHists()
        {
            int[] hr = new int[256], hg = new int[256], hb = new int[256];

            // цветные маски каналов: (R,0,0), (0,G,0), (0,0,B)
            _rImg = _src.Select(c => { hr[c.R]++; return Color.FromArgb(c.A, c.R, 0, 0); });
            _gImg = _src.Select(c => { hg[c.G]++; return Color.FromArgb(c.A, 0, c.G, 0); });
            _bImg = _src.Select(c => { hb[c.B]++; return Color.FromArgb(c.A, 0, 0, c.B); });

            pbR.Image = _rImg; pbG.Image = _gImg; pbB.Image = _bImg;

            hR.Image = DrawHist(hr, Pens.Red, "R");
            hG.Image = DrawHist(hg, Pens.Green, "G");
            hB.Image = DrawHist(hb, Pens.Blue, "B");
        }

        private static Bitmap DrawHist(int[] hist, Pen pen, string title)
        {
            int w = 256, h = 120, pad = 18;
            var bmp = new Bitmap(w, h, PixelFormat.Format24bppRgb);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            int max = Math.Max(1, hist.Max());
            using var axis = new Pen(Color.Gray, 1);
            g.DrawLine(axis, pad, h - pad, w - 4, h - pad);
            g.DrawLine(axis, pad, 4, pad, h - pad);

            for (int x = 0; x < 256; x++)
            {
                int barH = (int)Math.Round((h - 2 * pad) * (hist[x] / (double)max));
                if (barH > 0)
                    g.DrawLine(pen, pad + x, (h - pad) - barH, pad + x, h - pad);
            }

            g.DrawString(title, SystemFonts.DefaultFont, Brushes.Black, w - 20, 2);
            return bmp;
        }

        private void DisposeAll()
        {
            pbSrc.Image = pbR.Image = pbG.Image = pbB.Image = null;
            hR.Image = hG.Image = hB.Image = null;

            _src?.Dispose(); _src = null;
            _rImg?.Dispose(); _rImg = null;
            _gImg?.Dispose(); _gImg = null;
            _bImg?.Dispose(); _bImg = null;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            DisposeAll();
            base.OnFormClosed(e);
        }

        private void pbG_Click(object sender, EventArgs e)
        {

        }

        private void pbB_Click(object sender, EventArgs e)
        {

        }
    }
}
