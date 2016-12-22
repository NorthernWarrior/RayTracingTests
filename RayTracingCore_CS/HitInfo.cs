using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingCore_CS
{
    public class HitInfo
    {
        public float Distance { get; private set; }
        public ConsoleColor ConsoleColor { get; private set; }

        public HitInfo(float distance, ConsoleColor color)
        {
            Distance = distance;
            ConsoleColor = color;
        }
    }
}
