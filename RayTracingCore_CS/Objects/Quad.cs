using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracingCore_CS.Math;

namespace RayTracingCore_CS.Objects
{
    public class Quad : Plane
    {
        public float Radius;

        public Quad(Vector3 position, Vector3 normal, float radius, ConsoleColor color) : base(position, normal, color)
        {
            Radius = radius;
        }

        public override bool RayIntersection(Ray ray, out HitInfo hitInfo)
        {
            if (!base.RayIntersection(ray, out hitInfo))
                return false;

            var left = Vector3.Cross(Normal, Vector3.Up);
            var right = new Vector3() - left;
            var up = Vector3.Cross(left, Normal);
            var down = new Vector3() - up;

            Vector3 S1 = Center + ((left + up) * Radius);
            Vector3 S2 = Center + ((right + up) * Radius);
            Vector3 S3 = Center + ((left + down) * Radius);
            //Vector3 S4 = Center + ((right + down) * Radius);

            Vector3 dS21 = S2 - S1;
            Vector3 dS31 = S3 - S1;

            Vector3 intersectionPoint = ray.Origin + ray.Direction * hitInfo.Distance;
            Vector3 dMS1 = intersectionPoint - S1;
            float u = dMS1.Dot(dS21);
            float v = dMS1.Dot(dS31);

            return (u >= 0.0f && u <= dS21.Dot(dS21) 
                    && v >= 0.0f && v <= dS31.Dot(dS31));
        }
    }
}
