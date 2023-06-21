using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.dll
{
    public class Triangle
    {

        public static double Triangle_Area(float a, float h)
        {
            double result;
            result = (0.5 * a) * h;
            return result;
        }
    }
}
