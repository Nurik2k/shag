using Geometry;
using Geometry.dll;
using System.Diagnostics;

TestGeometry testGeometry = new TestGeometry();

float a = 4;
int b = 5;
float h = 6;

testGeometry.Test_Rectangle((int)a, b);
testGeometry.TestSquare((int)a);
testGeometry.TestTriangle(a, h);


Console.WriteLine("Rectangle areas: " + Rectangle_.Rectangle_Area((int)a, b));

Console.WriteLine("Square areas: " + Square.Square_Area((int)a));

Console.WriteLine("Triangle areas: " + Triangle.Triangle_Area(a, h));
