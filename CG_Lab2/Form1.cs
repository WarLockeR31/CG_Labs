using System;
using System.Drawing;
using System.Windows.Forms;

namespace CG_Lab2
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private Bitmap processedImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    originalImage = new Bitmap(ofd.FileName);
                    pbOriginal.Image = originalImage;
                    processedImage = null;
                    pbNTSC.Image = null;
                    pbSRGB.Image = null;
                    pbResult.Image = null;

                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            processedImage = new Bitmap(originalImage.Width, originalImage.Height);
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color c = originalImage.GetPixel(x, y);
                    int gray = (int)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    processedImage.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pbNTSC.Image = processedImage;

            processedImage = new Bitmap(originalImage.Width, originalImage.Height);
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color c = originalImage.GetPixel(x, y);
                    int gray = (int)(0.21 * c.R + 0.72 * c.G + 0.07 * c.B);
                    processedImage.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pbSRGB.Image = processedImage;

            Bitmap diffImage = new Bitmap(originalImage.Width, originalImage.Height);
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color c = originalImage.GetPixel(x, y);
                    int diff = (int)(0.21 * c.R + 0.72 * c.G + 0.07 * c.B) - (int)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B); ;

                    diff = Math.Abs(diff);

                    diff = Math.Min(255, Math.Max(0, diff));

                    diffImage.SetPixel(x, y, Color.FromArgb(diff, diff, diff));
                }
            }

            pbResult.Image = diffImage;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (processedImage == null) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    processedImage.Save(sfd.FileName);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            pbOriginal.Image = originalImage;
            pbResult.Image = null;
            pbSRGB.Image = null;
            pbNTSC.Image = null;
            processedImage = null;
        }
    }
}
