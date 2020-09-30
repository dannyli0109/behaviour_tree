using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behavior_tree
{
    public class Vector3
    {
        public float x, y, z;

        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float this[int i]
        {
            get
            {
                if (i == 0) return x;
                if (i == 1) return y;
                if (i == 2) return z;
                return float.NaN;
            }

            set
            {
                if (i == 0) x = value;
                if (i == 1) y = value;
                if (i == 2) z = value;
            }
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs.x + rhs.x,
                lhs.y + rhs.y,
                lhs.z + rhs.z
            );
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs.x - rhs.x,
                lhs.y - rhs.y,
                lhs.z - rhs.z
            );
        }

        public static Vector3 operator *(Vector3 v1, Vector3 v2)
        {
            return new Vector3(
                v1.x * v2.x,
                v1.y * v2.y,
                v1.z * v2.z
            );
        }

        public static Vector3 operator *(Vector3 v, float s)
        {
            return new Vector3(
                v.x * s,
                v.y * s,
                v.z * s
            );
        }

        public static Vector3 operator *(float s, Vector3 v)
        {
            return v * s;
        }

        public static Vector3 operator /(Vector3 v, float s)
        {
            s = 1 / s;
            return new Vector3(
                v.x * s,
                v.y * s,
                v.z * s
            );
        }

        public float MagnitudeSquared()
        {
            return x * x + y * y + z * z;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(MagnitudeSquared());
        }

        public void Normalize()
        {
            float mag = Magnitude();
            x /= mag;
            y /= mag;
            z /= mag;
        }

        public Vector3 GetNormalize()
        {
            float mag = Magnitude();
            return new Vector3(
                x / mag,
                y / mag,
                z / mag
            );
        }

        public float Dot(Vector3 v)
        {
            return x * v.x + y * v.y + z * v.z;
        }

        public Vector3 Cross(Vector3 v)
        {
            return new Vector3(
                y * v.z - z * v.y,
                z * v.x - x * v.z,
                x * v.y - y * v.x
            );
        }

        public Matrix3 Outer(Vector3 v)
        {
            return new Matrix3(
                x * v.x,
                y * v.x,
                z * v.x,

                x * v.y,
                y * v.y,
                z * v.y,

                x * v.z,
                y * v.z,
                z * v.z
            );
        }

        public Vector3 Projection(Vector3 b)
        {
            return Dot(b) / b.MagnitudeSquared() * b;
        }

        public Vector3 Rejection(Vector3 b)
        {
            return this - Projection(b);
        }
    }
}
