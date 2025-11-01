using System;
using System.Numerics; // INumber, IFloatingPoint

namespace MathPrimitives
{
    public readonly struct Vec3(double x, double y, double z)
	{
        public double X { get; } = x;
		public double Y { get; } = y;
		public double Z { get; } = z;

		public override int GetHashCode() => HashCode.Combine(X, Y, Z);

        public void Deconstruct(out double x, out double y, out double z) { x = X; y = Y; z = Z;
		}

        // Constants
        public static Vec3 Zero  => new(0, 0, 0);
        public static Vec3 One   => new(1, 1, 1);
        public static Vec3 UnitX => new(1, 0, 0);
        public static Vec3 UnitY => new(0, 1, 0);
		public static Vec3 UnitZ => new(0, 0, 1);

        // Vec operations
        public static Vec3 operator +(in Vec3 a, in Vec3 b)    => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vec3 operator -(in Vec3 a, in Vec3 b)    => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vec3 operator -(in Vec3 v)               => new(-v.X, -v.Y, -v.Z);

        // Scalar operations
        public static Vec3 operator *(in Vec3 v, double s)             => new(v.X * s, v.Y * s, v.Z * s);
        public static Vec3 operator *(double s, in Vec3 v)             => new(v.X * s, v.Y * s, v.Z * s);
        public static Vec3 operator /(in Vec3 v, double s)             => new(v.X / s, v.Y / s, v.Z / s);

        // Equality
        public static bool operator ==(in Vec3 a, in Vec3 b) =>
            a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        public static bool operator !=(in Vec3 a, in Vec3 b) => !(a == b);

        public override bool Equals(object? obj) =>
            obj is Vec3 o && this == o;

        

        // Удобные "with"-методы (иммутабельный стиль)
        public Vec3 WithX(double x) => new(x, Y, Z);
        public Vec3 WithY(double y) => new(X, y, Z);
		public Vec3 WithZ(double z) => new(X, Y, z);

        public override string ToString() => $"({X}, {Y}, {Z})";
    }

    // Отдельная "математика" для Vec3
    public static class Vec3Math
    {
        public static double Dot(in Vec3 a, in Vec3 b)
            => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        public static Vec3 Cross(in Vec3 a, in Vec3 b)
            => new Vec3(a.Y*b.Z - a.Z*b.Y, a.Z*b.X - a.X*b.Z, a.X*b.Y - a.Y*b.X);

        public static double LengthSquared(in Vec3 v)
            => Dot(v, v);

        public static double DistanceSquared(this in Vec3 a, in Vec3 b)
        {
            var dx = a.X - b.X;
            var dy = a.Y - b.Y;
			var dz = a.Z - b.Z;
            return dx * dx + dy * dy + dz * dz;
        }

        public static Vec3 Lerp(in Vec3 a, in Vec3 b, double t)
        {
            // a + t*(b - a)
            return new Vec3(
				a.X + t * (b.X - a.X),
				a.Y + t * (b.Y - a.Y),
				a.Z + t * (b.Z - a.Z));
        }

        // Approximately equal with given epsilon
        public static bool Approximately(this in Vec3 a, in Vec3 b, double eps)
        {
            var dx = a.X - b.X;
            var dy = a.Y - b.Y;
			var dz = a.Z - b.Z;
            dx = dx >= 0 ? dx : -dx;
            dy = dy >= 0 ? dy : -dy;
			dz = dz >= 0 ? dz : -dz;
            return (dx <= eps) && (dy <= eps) && (dz <= eps);
        }

        public static double Length(this in Vec3 v)
            => Math.Sqrt(LengthSquared(v));

        public static double Distance(this in Vec3 a, in Vec3 b)
            => Math.Sqrt(DistanceSquared(a, b));

        public static Vec3 Normalize(this in Vec3 v, double epsilon = default)
        {
            if (epsilon == default) epsilon = double.CreateChecked(1e-12);
            var len2 = LengthSquared(v);
            if (len2 <= epsilon * epsilon) return Vec3.Zero;
            var invLen = 1 / Math.Sqrt(len2);
            return new Vec3(v.X * invLen, v.Y * invLen, v.Z * invLen);
        }

        // Project a onto b
        public static Vec3 Project(in Vec3 a, in Vec3 b, double epsilon = default)
        {
            var denom = Dot(b, b);
            if (epsilon == default) epsilon = double.CreateChecked(1e-12);
            if (denom <= epsilon) return Vec3.Zero;
            var k = Dot(a, b) / denom;
            return new Vec3(b.X * k, b.Y * k, b.Z * k);
        }

        // Reflect v relative to n
        public static Vec3 Reflect(in Vec3 v, in Vec3 n)
        {
            var nn = Dot(n, n);
            if (nn == 0) return v;
            var k = Dot(v, n) / nn;
            return new Vec3(
				v.X - (n.X * (k + k)),
				v.Y - (n.Y * (k + k)),
				v.Z - (n.Z * (k + k)));
        }

        // Clamp vector magnitude to maxLen
        public static Vec3 ClampMagnitude(in Vec3 v, double maxLen)
        {
            var len2 = LengthSquared(v);
            var max2 = maxLen * maxLen;
            if (len2 <= max2) return v;
            var scale = maxLen / Math.Sqrt(len2);
            return new Vec3(v.X * scale, v.Y * scale, v.Z * scale);
        }
    }
}
