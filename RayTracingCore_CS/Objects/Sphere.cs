using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracingCore_CS.Math;

namespace RayTracingCore_CS.Objects
{
    public class Sphere : Primitive
    {
        public float Radius;
        public float Diameter { get { return Radius * Radius; } }

        public Sphere(Vector3 position, float radius, ConsoleColor color) : base(position, color)
        {
            Radius = radius;
        }

        public override bool RayIntersection(Ray ray, out HitInfo hitInfo)
        {
            hitInfo = null;

            float t0, t1;

            Vector3 L = Center - ray.Origin;
            float tca = L.Dot(ray.Direction);
            if (tca < 0)
                return false;
            float d2 = L.Dot(L) - tca * tca;
            if (d2 > Diameter)
                return false;
            float thc = (float)System.Math.Sqrt(Diameter - d2);
            t0 = tca - thc;
            t1 = tca + thc;

            if (t0 > t1)
            {
                var tmp = t0;
                t0 = t1;
                t1 = tmp;
            }

            if (t0 < 0)
            {
                // Uncomment this if you want backface culling...
                //return false;
                t0 = t1;
                if (t0 < 0)
                    return false;
            }

            hitInfo = new HitInfo(t0, Color);

            return true;
        }
    }
}
