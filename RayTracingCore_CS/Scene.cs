using RayTracingCore_CS.Math;
using RayTracingCore_CS.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingCore_CS
{
    public class Scene
    {
        private List<Primitive> _primitives = new List<Primitive>();

        public void AddObject(Primitive primitive)
        {
            _primitives.Add(primitive);
        }

        public bool GetRayIntersection(Ray ray, out HitInfo hitInfo)
        {
            hitInfo = null;
            HitInfo tmp;
            for (int i = 0; i < _primitives.Count; ++i)
            {
                if (!_primitives[i].RayIntersection(ray, out tmp))
                    continue;

                if (hitInfo == null || hitInfo.Distance > tmp.Distance)
                    hitInfo = tmp;
            }
            return (hitInfo != null);
        }
    }
}
