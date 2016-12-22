using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingCore_CS.Math
{
    public class Vector3
    {
        public static Vector3 Left = new Vector3(-1, 0, 0);
        public static Vector3 Right = new Vector3(1, 0, 0);
        public static Vector3 Up = new Vector3(0, 1, 0);
        public static Vector3 Down = new Vector3(0, -1, 0);
        public static Vector3 Forward = new Vector3(0, 0, 1);
        public static Vector3 Back = new Vector3(0, 0, -1);

        public float X;

        public float Y;
        public float Z;

        public Vector3() { }
        public Vector3(float value) { X = value; Y = value; Z = value; }
        public Vector3(float x, float y = 0, float z = 0) { X = x; Y = y; Z = z; }


        public Vector3 Cross(Vector3 other)
        {
            return new Vector3(Y * other.Z - Z * other.Y
                , Z * other.X - X * other.Z
                , X * other.Y - Y * other.X);
        }
        public static Vector3 Cross(Vector3 vectorA, Vector3 vectorB)
        {
            return vectorA.Cross(vectorB);
        }

        public float Dot(Vector3 other)
        {
            return (X * other.X + Y * other.Y + Z * other.Z);
        }
        public static float Dot(Vector3 vectorA, Vector3 vectorB)
        {
            return vectorA.Dot(vectorB);
        }



        public static Vector3 operator+(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector3 operator-(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vector3 operator*(Vector3 vector, float value)
        {
            return new Vector3(vector.X * value, vector.Y * value, vector.Z * value);
        }
    }
}
