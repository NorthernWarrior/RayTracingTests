using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracingCore_CS.Math;

namespace RayTracingCore_CS.Objects
{
    public class Plane : Primitive
    {
        public Vector3 Normal;

        public Plane(Vector3 center, Vector3 normal, ConsoleColor color) : base(center, color)
        {
            Normal = normal;
        }

        public override bool RayIntersection(Ray ray, out HitInfo hitInfo)
        {
            hitInfo = null;

            float denom = Vector3.Dot(Normal, ray.Direction);
            if (denom > 1e-6)
            {
                Vector3 p0l0 = Center - ray.Origin;
                hitInfo = new HitInfo(Vector3.Dot(p0l0, Normal) / denom, Color);
                return true;
            }

            return false;
        }
    }
}
