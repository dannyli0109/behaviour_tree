using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behavior_tree
{
    public class Matrix3
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

        public Matrix3()
        {
            m1 = 1; m4 = 0; m7 = 0;
            m2 = 0; m5 = 1; m8 = 0;
            m3 = 0; m6 = 0; m9 = 1;
        }

        public Matrix3(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9)
        {
            this.m1 = m1; this.m4 = m4; this.m7 = m7;
            this.m2 = m2; this.m5 = m5; this.m8 = m8;
            this.m3 = m3; this.m6 = m6; this.m9 = m9;
        }

        public Vector3 this[int i]
        {
            get
            {
                if (i == 0) return new Vector3(m1, m2, m3);
                if (i == 1) return new Vector3(m4, m5, m6);
                if (i == 2) return new Vector3(m7, m8, m9);
                return null;
            }

            set
            {
                if (i == 0)
                {
                    m1 = value.x;
                    m2 = value.y;
                    m3 = value.z;
                }
                if (i == 1)
                {
                    m4 = value.x;
                    m5 = value.y;
                    m6 = value.z;
                }
                if (i == 2)
                {
                    m7 = value.x;
                    m8 = value.y;
                    m9 = value.z;
                }
            }
        }

        public float this[int i, int j]
        {
            get
            {
                return this[i][j];
            }

            set
            {
                if (i == 0)
                {
                    if (j == 0) m1 = value;
                    if (j == 1) m2 = value;
                    if (j == 2) m3 = value;
                }
                if (i == 1)
                {
                    if (j == 0) m4 = value;
                    if (j == 1) m5 = value;
                    if (j == 2) m6 = value;
                }
                if (i == 2)
                {
                    if (j == 0) m7 = value;
                    if (j == 1) m8 = value;
                    if (j == 2) m9 = value;
                }
            }
        }

        public static Matrix3 operator *(Matrix3 a, Matrix3 b)
        {
            return new Matrix3(
                a.m1 * b.m1 + a.m4 * b.m2 + a.m7 * b.m3,
                a.m2 * b.m1 + a.m5 * b.m2 + a.m8 * b.m3,
                a.m3 * b.m1 + a.m6 * b.m2 + a.m9 * b.m3,

                a.m1 * b.m4 + a.m4 * b.m5 + a.m7 * b.m6,
                a.m2 * b.m4 + a.m5 * b.m5 + a.m8 * b.m6,
                a.m3 * b.m4 + a.m6 * b.m5 + a.m9 * b.m6,

                a.m1 * b.m7 + a.m4 * b.m8 + a.m7 * b.m9,
                a.m2 * b.m7 + a.m5 * b.m8 + a.m8 * b.m9,
                a.m3 * b.m7 + a.m6 * b.m8 + a.m9 * b.m9
            );
        }

        public static Matrix3 operator *(Matrix3 a, float s)
        {
            return new Matrix3(
                a.m1 * s,
                a.m2 * s,
                a.m3 * s,

                a.m4 * s,
                a.m5 * s,
                a.m6 * s,

                a.m7 * s,
                a.m8 * s,
                a.m9 * s
            );
        }

        public static Vector3 operator *(Matrix3 m, Vector3 b)
        {
            return new Vector3(
                m.m1 * b.x + m.m4 * b.y + m.m7 * b.z,
                m.m2 * b.x + m.m5 * b.y + m.m8 * b.z,
                m.m3 * b.x + m.m6 * b.y + m.m9 * b.z
             );
        }

        public static Vector3 operator *(Vector3 b, Matrix3 m)
        {
            return m * b;
        }

        public static Matrix3 operator +(Matrix3 a, Matrix3 b)
        {
            return new Matrix3(
                a.m1 + b.m1,
                a.m2 + b.m2,
                a.m3 + b.m3,

                a.m4 + b.m4,
                a.m5 + b.m5,
                a.m6 + b.m6,

                a.m7 + b.m7,
                a.m8 + b.m8,
                a.m9 + b.m9
            );
        }


        public void Set(Matrix3 m)
        {
            m1 = m.m1; m2 = m.m2; m3 = m.m3;
            m4 = m.m4; m5 = m.m5; m6 = m.m6;
            m7 = m.m7; m8 = m.m8; m9 = m.m9;
        }

        public float Determinant()
        {
            return (
                this[0, 0] * this[1, 1] * this[2, 2] +
                this[0, 1] * this[1, 2] * this[2, 0] +
                this[0, 2] * this[1, 0] * this[2, 1] -
                this[0, 0] * this[1, 2] * this[2, 1] -
                this[0, 1] * this[1, 0] * this[2, 2] -
                this[0, 2] * this[1, 1] * this[2, 0]
            );
        }

        public void Inverse()
        {
            float invDet = 1 / Determinant();
            Vector3 a = this[0];
            Vector3 b = this[1];
            Vector3 c = this[2];

            Vector3 r0 = b.Cross(c);
            Vector3 r1 = c.Cross(a);
            Vector3 r2 = a.Cross(b);

            Matrix3 m = new Matrix3(
                r0.x * invDet, r1.x * invDet, r2.x * invDet,
                r0.y * invDet, r1.y * invDet, r2.y * invDet,
                r0.z * invDet, r1.z * invDet, r2.z * invDet
            );

            Set(m);
        }

        public Matrix3 GetInverse()
        {
            float invDet = 1 / Determinant();
            Vector3 a = this[0];
            Vector3 b = this[1];
            Vector3 c = this[2];

            Vector3 r0 = b.Cross(c);
            Vector3 r1 = c.Cross(a);
            Vector3 r2 = a.Cross(b);

            Matrix3 m = new Matrix3(
                r0.x * invDet, r1.x * invDet, r2.x * invDet,
                r0.y * invDet, r1.y * invDet, r2.y * invDet,
                r0.z * invDet, r1.z * invDet, r2.z * invDet
            );

            return m;
        }

        public void SetRotateX(float radians)
        {
            float s = (float)Math.Sin(radians);
            float c = (float)Math.Cos(radians);
            Matrix3 m = new Matrix3(
                1, 0, 0,
                0, c, s,
                0, -s, c
            );
            Set(m);
        }

        public void SetRotateY(float radians)
        {
            float s = (float)Math.Sin(radians);
            float c = (float)Math.Cos(radians);
            Matrix3 m = new Matrix3(
                c, 0, -s,
                0, 1, 0,
                s, 0, c
            );
            Set(m);
        }

        public void SetRotateZ(float radians)
        {
            float s = (float)Math.Sin(radians);
            float c = (float)Math.Cos(radians);
            Matrix3 m = new Matrix3(
                c, s, 0,
                -s, c, 0,
                0, 0, 1
            );
            Set(m);
        }

        // rotate around an arbitrary axis
        public void SetRotation(float radians, Vector3 a)
        {
            float s = (float)Math.Sin(radians);
            float c = (float)Math.Cos(radians);

            Matrix3 i = new Matrix3();
            i *= c;
            Matrix3 outer = a.Outer(a);
            outer *= (1 - c);
            Matrix3 cross = new Matrix3(
                0, a.z, -a.y,
                -a.z, 0, a.x,
                a.y, -a.x, 0
            );
            cross *= s;
            Set(i + outer + cross);
        }

        public void SetPosition(float x, float y)
        {
            m1 = 1;
            m2 = 0;
            m3 = 0;
            m4 = 0;
            m5 = 1;
            m6 = 0;
            m7 = x;
            m8 = y;
            m9 = 1;
        }

        public void Translate(float x, float y)
        {
            m7 += x;
            m8 += y;
        }

        public void SetScale(float sx, float sy, float sz)
        {
            Matrix3 scale = new Matrix3(
                sx, 0, 0,
                0, sy, 0,
                0, 0, sz
            );
            Set(scale);
        }
    }
}
