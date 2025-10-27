namespace MathPrimitives;

public readonly struct Vec4
{
	public readonly double X, Y, Z, W;
	public Vec4(double x, double y, double z, double w) { X=x; Y=y; Z=z; W=w; }
}


public readonly struct Mat4
{
	// Row-major 4x4
	public readonly double M11, M12, M13, M14;
	public readonly double M21, M22, M23, M24;
	public readonly double M31, M32, M33, M34;
	public readonly double M41, M42, M43, M44;

	public Mat4(
		double m11, double m12, double m13, double m14,
		double m21, double m22, double m23, double m24,
		double m31, double m32, double m33, double m34,
		double m41, double m42, double m43, double m44)
	{
		M11 = m11; M12 = m12; M13 = m13; M14 = m14;
		M21 = m21; M22 = m22; M23 = m23; M24 = m24;
		M31 = m31; M32 = m32; M33 = m33; M34 = m34;
		M41 = m41; M42 = m42; M43 = m43; M44 = m44;
	}


	public static Mat4 Identity => new(
		1, 0, 0, 0, 
		0, 1, 0, 0, 
		0, 0, 1, 0, 
		0, 0, 0, 1);


	public static Mat4 operator *(in Mat4 a, in Mat4 b)
	{
		return new Mat4(
			a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41,
			a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42,
			a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43,
			a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44,


			a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41,
			a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42,
			a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43,
			a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44,


			a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41,
			a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42,
			a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43,
			a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44,


			a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41,
			a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42,
			a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43,
			a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44
		);
	}
	
	public Vec4 TransformPointToVec4(in Vec3 v)
	{
		var x = v.X * M11 + v.Y * M12 + v.Z * M13 + 1.0 * M14;
		var y = v.X * M21 + v.Y * M22 + v.Z * M23 + 1.0 * M24;
		var z = v.X * M31 + v.Y * M32 + v.Z * M33 + 1.0 * M34;
		var w = v.X * M41 + v.Y * M42 + v.Z * M43 + 1.0 * M44;
		
		return new Vec4(x, y, z, w);
	}


	public Vec3 TransformPoint(in Vec3 v)
	{
		var x = v.X * M11 + v.Y * M12 + v.Z * M13 + 1.0 * M14;
		var y = v.X * M21 + v.Y * M22 + v.Z * M23 + 1.0 * M24;
		var z = v.X * M31 + v.Y * M32 + v.Z * M33 + 1.0 * M34;
		var w = v.X * M41 + v.Y * M42 + v.Z * M43 + 1.0 * M44;
		if (Math.Abs(w) > 1e-12)
		{
			x /= w;
			y /= w;
			z /= w;
		}

		return new Vec3(x, y, z);
	}

	#region Basic transformations
	
	public static Mat4 Translation(double dx, double dy, double dz)
		=> new(
			1, 0, 0,dx, 
			0, 1, 0,dy, 
			0, 0, 1,dz, 
			0, 0, 0, 1);
	
	public static Mat4 Scale(double sx, double sy, double sz)
		=> new(
			sx, 0, 0, 0, 
			 0,sy, 0, 0,
			 0, 0,sz, 0, 
			 0, 0, 0, 1);
	
	#endregion

	#region Rotation
	
	public static Mat4 RotationX(double radians)
	{
		double c = Math.Cos(radians), s = Math.Sin(radians);
		return new(
			1, 0, 0, 0, 
			0, c,-s, 0, 
			0, s, c, 0, 
			0, 0, 0, 1);
	}
	public static Mat4 RotationY(double radians)
	{
		double c = Math.Cos(radians), s = Math.Sin(radians);
		return new(
			 c, 0, s, 0, 
			 0, 1, 0, 0, 
			-s, 0, c, 0, 
			 0, 0, 0, 1);
	}
	public static Mat4 RotationZ(double radians)
	{
		double c = Math.Cos(radians), s = Math.Sin(radians);
		return new(
			c,-s, 0, 0, 
			s, c, 0, 0, 
			0, 0, 1, 0, 
			0, 0, 0, 1);
	}
	
	#endregion
	
	#region Render Related
	
	public static Mat4 PerspectiveFovY(double fovYdeg, double aspect, double zn, double zf)
	{
		double f = 1.0 / Math.Tan(0.5 * fovYdeg * Math.PI / 180.0);
		
		return new Mat4(
			f/aspect, 0, 0, 0,
			0, f, 0, 0,
			0, 0, (zf+zn)/(zn - zf), (2*zf*zn)/(zn - zf),
			0, 0, -1, 0
		);
	}
	
	public static Mat4 IsometricRotation()
	{
		const double deg = Math.PI / 180.0;
		var rx = RotationX(35.26438968 * deg);
		var ry = RotationY(45 * deg);
		return rx * ry; // сначала X, потом Y
	}


	public static Mat4 Orthographic(double left, double right, double bottom, double top, double zn, double zf)
	{
		return new Mat4(
			2/(right-left), 0, 0, -(right+left)/(right-left),
			0, 2/(top-bottom), 0, -(top+bottom)/(top-bottom),
			0, 0, 2/(zn - zf), (zf+zn)/(zn - zf),
			0, 0, 0, 1
		);
	}

	#endregion
}