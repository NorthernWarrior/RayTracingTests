using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracingCore_CS.Math;

namespace RayTracingCore_CS.Objects
{
    public class Circle : Plane
    {
        public float Radius;
        public float RadiusSQR { get { return Radius * Radius; } }

        public Circle(Vector3 center, Vector3 normal, float radius, ConsoleColor color) : base(center, normal, color)
        {
            Radius = radius;
        }

        public override bool RayIntersection(Ray ray, out HitInfo hitInfo)
        {
            if (!base.RayIntersection(ray, out hitInfo))
                return false;

            Vector3 intersectionPoint = ray.Origin + ray.Direction * hitInfo.Distance;
            Vector3 directionFromIntersection = intersectionPoint - Center;
            float d2 = Vector3.Dot(directionFromIntersection, directionFromIntersection);

            return (d2 <= RadiusSQR);
        }
    }
}
