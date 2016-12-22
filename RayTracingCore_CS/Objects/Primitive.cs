using RayTracingCore_CS.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingCore_CS.Objects
{
    public abstract class Primitive
    {
        public Vector3 Center;
        public ConsoleColor Color;

        public Primitive(Vector3 center, ConsoleColor color)
        {
            Center = center;
            Color = color;
        }

        public void Move(float x, float y, float z)
        {
            Center.X += x;
            Center.Y += y;
            Center.Z += z;
        }

        public abstract bool RayIntersection(Ray ray, out HitInfo hitInfo);
    }
}
