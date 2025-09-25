using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace CG_Lab2
{
    public partial class Form1 : SwitchableForm
    {
        private Bitmap originalImage;
        private Bitmap processedImage;
        private Bitmap ntscImage;
        private Bitmap srgbImage;

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
                    ntscImage = null;
                    srgbImage = null;
                    pbNTSC.Image = null;
                    pbSRGB.Image = null;
                    pbResult.Image = null;
                    pbHistogramNTSC.Image = null;
                    pbHistogramSRGB.Image = null;
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;


            ntscImage = new Bitmap(originalImage.Width, originalImage.Height);
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color c = originalImage.GetPixel(x, y);
                    int gray = (int)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    ntscImage.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pbNTSC.Image = ntscImage;

            Bitmap ntscHistogram = CreateHistogram(ntscImage);
            pbHistogramNTSC.Image = ntscHistogram;

            srgbImage = new Bitmap(originalImage.Width, originalImage.Height);
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color c = originalImage.GetPixel(x, y);
                    int gray = (int)(0.21 * c.R + 0.72 * c.G + 0.07 * c.B);
                    srgbImage.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pbSRGB.Image = srgbImage;

            Bitmap srgbHistogram = CreateHistogram(srgbImage);
            pbHistogramSRGB.Image = srgbHistogram;

            Bitmap diffImage = new Bitmap(originalImage.Width, originalImage.Height);
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color ntscPixel = ntscImage.GetPixel(x, y);
                    Color srgbPixel = srgbImage.GetPixel(x, y);

                    int diff = Math.Abs(ntscPixel.R - srgbPixel.R);
                    diff = Math.Min(255, Math.Max(0, diff));

                    diffImage.SetPixel(x, y, Color.FromArgb(diff, diff, diff));
                }
            }

            pbResult.Image = diffImage;
            processedImage = diffImage;
        }
        private Bitmap CreateHistogram(Bitmap image)
        {
            int[] histogram = new int[256];

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    histogram[pixel.R]++;
                }
            }

            int maxFrequency = histogram.Max();

            int histWidth = 256;
            int histHeight = 200;
            Bitmap histBitmap = new Bitmap(histWidth, histHeight);
            using (Graphics g = Graphics.FromImage(histBitmap))
            {
                g.Clear(Color.White);
                Pen pen = new Pen(Color.Black);
                for (int i = 0; i < 256; i++)
                {
                    float height = (float)histogram[i] / maxFrequency * histHeight;
                    g.DrawLine(pen, i, histHeight, i, histHeight - height);
                }

                Font font = new Font("Arial", 8);
                g.DrawString("0", font, Brushes.Black, 0, histHeight - 15);
                g.DrawString("255", font, Brushes.Black, histWidth - 25, histHeight - 15);
            }

            return histBitmap;
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
            pbHistogramNTSC.Image = null;
            pbHistogramSRGB.Image = null;
            processedImage = null;
            ntscImage = null;
            srgbImage = null;
        }
    }
}