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
    }
}
