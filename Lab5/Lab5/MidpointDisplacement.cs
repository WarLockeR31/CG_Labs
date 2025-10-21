using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab5
{
    public class MidpointDisplacement
    {
        private double[,] heightMap;
        private Random random;
        private int size;
        private double roughness;
        private int seed;

        public double[,] HeightMap => heightMap;
        public int Size => size;

        public MidpointDisplacement(int size, double roughness, int seed = 0)
        {
            if (!IsPowerOfTwo(size - 1))
                throw new ArgumentException("Size must be 2^n + 1");

            this.size = size;
            this.roughness = roughness;
            this.seed = seed;
            this.random = new Random(seed);
            this.heightMap = new double[size, size];
        }

        private bool IsPowerOfTwo(int n)
        {
            return (n & (n - 1)) == 0 && n != 0;
        }

        public void Generate()
        {
            // Инициализация углов для горного массива
            heightMap[0, 0] = random.NextDouble() * 0.3;
            heightMap[0, size - 1] = random.NextDouble() * 0.3;
            heightMap[size - 1, 0] = random.NextDouble() * 0.3;
            heightMap[size - 1, size - 1] = random.NextDouble() * 0.3;

            int step = size - 1;

            while (step > 1)
            {
                DiamondSquareStep(step);
                step /= 2;
            }

            // Усиливаем контраст для более выраженных гор
            EnhanceMountains();
        }

        private void DiamondSquareStep(int step)
        {
            int halfStep = step / 2;

            // Diamond step
            for (int x = halfStep; x < size; x += step)
            {
                for (int y = halfStep; y < size; y += step)
                {
                    DiamondStep(x, y, halfStep);
                }
            }

            // Square step
            for (int x = 0; x < size; x += halfStep)
            {
                for (int y = (x + halfStep) % step; y < size; y += step)
                {
                    SquareStep(x, y, halfStep);
                }
            }
        }

        private void DiamondStep(int x, int y, int halfStep)
        {
            double avg = (
                heightMap[x - halfStep, y - halfStep] +
                heightMap[x - halfStep, y + halfStep] +
                heightMap[x + halfStep, y - halfStep] +
                heightMap[x + halfStep, y + halfStep]
            ) / 4.0;

            heightMap[x, y] = avg + GetRandomDisplacement(halfStep);
            heightMap[x, y] = Math.Max(0, Math.Min(1, heightMap[x, y]));
        }

        private void SquareStep(int x, int y, int halfStep)
        {
            double sum = 0;
            int count = 0;

            if (x - halfStep >= 0)
            {
                sum += heightMap[x - halfStep, y];
                count++;
            }
            if (x + halfStep < size)
            {
                sum += heightMap[x + halfStep, y];
                count++;
            }
            if (y - halfStep >= 0)
            {
                sum += heightMap[x, y - halfStep];
                count++;
            }
            if (y + halfStep < size)
            {
                sum += heightMap[x, y + halfStep];
                count++;
            }

            if (count > 0)
            {
                heightMap[x, y] = sum / count + GetRandomDisplacement(halfStep);
                heightMap[x, y] = Math.Max(0, Math.Min(1, heightMap[x, y]));
            }
        }

        private double GetRandomDisplacement(int range)
        {
            return (random.NextDouble() - 0.5) * 2 * roughness * range / size;
        }

        private void EnhanceMountains()
        {
            // Усиливаем контраст для более выраженных горных пиков
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    // Возводим в квадрат для усиления высоких участков
                    heightMap[x, y] = Math.Pow(heightMap[x, y], 1.5);
                    heightMap[x, y] = Math.Max(0, Math.Min(1, heightMap[x, y]));
                }
            }
        }

        public Bitmap GenerateBitmap(int width, int height, double snowLevel = 0.7)
        {
            Bitmap bitmap = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int mapX = (int)((double)x / width * (size - 1));
                    int mapY = (int)((double)y / height * (size - 1));

                    double heightValue = heightMap[mapX, mapY];
                    Color color = GetMountainColor(heightValue, snowLevel);
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }

        private Color GetMountainColor(double height, double snowLevel)
        {
            // Цветовая схема специально для горного массива
            if (height < 0.3)
            {
                // Долины - темно-зеленый
                int green = (int)(height / 0.3 * 100) + 50;
                return Color.FromArgb(0, Math.Min(150, green), 0);
            }
            else if (height < 0.5)
            {
                // Склоны - коричневый
                int brownIntensity = (int)((height - 0.3) / 0.2 * 100);
                return Color.FromArgb(120 + brownIntensity, 80 + brownIntensity / 2, 40);
            }
            else if (height < snowLevel)
            {
                // Высокогорье - серый камень
                int gray = (int)((height - 0.5) / (snowLevel - 0.5) * 100) + 100;
                return Color.FromArgb(gray, gray, gray);
            }
            else
            {
                // Заснеженные вершины - белый
                int white = (int)((height - snowLevel) / (1.0 - snowLevel) * 100) + 200;
                white = Math.Min(255, white);
                return Color.FromArgb(white, white, white);
            }
        }
    }
}