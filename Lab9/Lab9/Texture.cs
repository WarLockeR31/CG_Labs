using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Renderer
{
    public class Texture
    {
        private Color[,] pixels;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Texture(int width, int height)
        {
            Width = width;
            Height = height;
            pixels = new Color[width, height];

            // Создаем простую текстуру по умолчанию
            CreateDefaultTexture();
        }

        public Texture(Bitmap bitmap)
        {
            LoadFromBitmap(bitmap);
        }

        public static Texture Checkerboard(int size = 64, int checkerSize = 8)
        {
            var texture = new Texture(size, size);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    bool isBlack = ((x / checkerSize) + (y / checkerSize)) % 2 == 0;
                    texture.pixels[x, y] = isBlack ? Color.Black : Color.White;
                }
            }

            return texture;
        }

        public static Texture Gradient(int size = 64)
        {
            var texture = new Texture(size, size);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    int r = (x * 255) / size;
                    int g = (y * 255) / size;
                    int b = 128;
                    texture.pixels[x, y] = Color.FromArgb(r, g, b);
                }
            }

            return texture;
        }

        private void CreateDefaultTexture()
        {
            // Простая текстура по умолчанию - шахматная доска
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    bool isDark = ((x / 8) + (y / 8)) % 2 == 0;
                    pixels[x, y] = isDark ? Color.DarkBlue : Color.LightBlue;
                }
            }
        }

        private void LoadFromBitmap(Bitmap bitmap)
        {
            Width = bitmap.Width;
            Height = bitmap.Height;
            pixels = new Color[Width, Height];

            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, Width, Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            var bytes = new byte[bitmapData.Stride * Height];
            Marshal.Copy(bitmapData.Scan0, bytes, 0, bytes.Length);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int offset = y * bitmapData.Stride + x * 4;
                    int b = bytes[offset];
                    int g = bytes[offset + 1];
                    int r = bytes[offset + 2];
                    int a = bytes[offset + 3];

                    pixels[x, y] = Color.FromArgb(a, r, g, b);
                }
            }

            bitmap.UnlockBits(bitmapData);
        }

        public Color Sample(double u, double v)
        {
            // Повторяем текстуру (wrap mode)
            u = u - Math.Floor(u);
            v = v - Math.Floor(v);

            int x = (int)(u * (Width - 1));
            int y = (int)(v * (Height - 1));

            x = Math.Clamp(x, 0, Width - 1);
            y = Math.Clamp(y, 0, Height - 1);

            return pixels[x, y];
        }

        public Color SampleBilinear(double u, double v)
        {
            u = u - Math.Floor(u);
            v = v - Math.Floor(v);

            double x = u * (Width - 1);
            double y = v * (Height - 1);

            int x1 = (int)Math.Floor(x);
            int y1 = (int)Math.Floor(y);
            int x2 = (x1 + 1) % Width;
            int y2 = (y1 + 1) % Height;

            double tx = x - x1;
            double ty = y - y1;

            // Билинейная интерполяция
            Color c11 = pixels[x1, y1];
            Color c21 = pixels[x2, y1];
            Color c12 = pixels[x1, y2];
            Color c22 = pixels[x2, y2];

            Color top = InterpolateColor(c11, c21, tx);
            Color bottom = InterpolateColor(c12, c22, tx);

            return InterpolateColor(top, bottom, ty);
        }

        private Color InterpolateColor(Color a, Color b, double t)
        {
            t = Math.Clamp(t, 0, 1);
            int r = (int)(a.R + (b.R - a.R) * t);
            int g = (int)(a.G + (b.G - a.G) * t);
            int bl = (int)(a.B + (b.B - a.B) * t);

            return Color.FromArgb(r, g, bl);
        }
    }
}