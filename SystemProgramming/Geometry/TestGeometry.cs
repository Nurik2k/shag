using Geometry.dll;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class TestGeometry
    {
        public void TestTriangle(float a, float h)
        {
            Debug.Assert(Triangle.Triangle_Area(a, h) == 12);
        }
        public void TestSquare(int a)
        {
            Debug.Assert(Square.Square_Area(a) == 16);
        }
        public void Test_Rectangle(int a, int h)
        {
            Debug.Assert(Rectangle_.Rectangle_Area(a, h) == 20);
        }
    }
}
