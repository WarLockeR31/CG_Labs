namespace MathPrimitives
{
    struct Affine2D
    {
        public float a, b, c, d;   // линейная часть: [ a b ; c d ]
        public float tx, ty;       // сдвиг

        public Affine2D(float a, float b, float c, float d, float tx, float ty)
        {
            this.a = a; this.b = b;
            this.c = c; this.d = d;
            this.tx = tx; this.ty = ty;
        }

        public static Affine2D TranslationMatrix(int dx, int dy)
        {
            return new Affine2D(1, 0, 0, 1, dx, dy);  
        }

        // Применить к точке (x, y)
        public (float x, float y) Transform(float x, float y)
        {
            float nx = a * x + b * y + tx;
            float ny = c * x + d * y + ty;
            return (nx, ny);
        }

        public Vec2 Transform(Vec2 v)
        {
            double nx = a * v.X + b * v.Y + tx;
            double ny = c * v.X + d * v.Y + ty;
            return new Vec2(nx, ny);
        }

        // Комбинирование: this затем other
        public Affine2D Combine(Affine2D other)
        {
            return new Affine2D
            {
                a = other.a * a + other.b * c,
                b = other.a * b + other.b * d,
                c = other.c * a + other.d * c,
                d = other.c * b + other.d * d,
                tx = other.a * tx + other.b * ty + other.tx,
                ty = other.c * tx + other.d * ty + other.ty
            };
        }

        public static Affine2D RotationMatrix(double angleDegrees, double cx = 0, double cy = 0)
        {
            double angle = angleDegrees * Math.PI / 180.0;
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            // Матрица поворота вокруг (0,0)
            Affine2D R = new Affine2D(cos, -sin, sin, cos, 0, 0);

            // Если указан центр поворота (cx, cy)
            if (cx != 0 || cy != 0)
            {
                // T(-cx, -cy) * R * T(cx, cy)
                Affine2D T1 = TranslationMatrix((int)-cx, (int)-cy);
                Affine2D T2 = TranslationMatrix((int)cx, (int)cy);
                R = T1.Combine(R).Combine(T2);
            }

            return R;
        }

        public static Affine2D ScaleMatrix(double sx, double sy, double cx = 0, double cy = 0)
        {
            Affine2D S = new Affine2D((float)sx, 0, 0, (float)sy, 0, 0);

            if (cx != 0 || cy != 0)
            {
                // T(-cx, -cy) * S * T(cx, cy)
                Affine2D T1 = TranslationMatrix((int)-cx, (int)-cy);
                Affine2D T2 = TranslationMatrix((int)cx, (int)cy);
                S = T1.Combine(S).Combine(T2);
            }

            return S;
        }

    }
}
