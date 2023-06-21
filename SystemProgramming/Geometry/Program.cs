using Geometry.dll;
using System.Diagnostics;

int a = 4;
int b = 5;

Debug.Assert(Rectangle_.Rectangle_Area(a, b) == 20);
Debug.Assert(Square.Square_Area(a) == 16);
Debug.Assert(Triangle.Triangle_Area(a, b) == 10);


Console.WriteLine("Rectangle areas: " + Rectangle_.Rectangle_Area(a, b));

Console.WriteLine("Square areas: " + Square.Square_Area(a));

Console.WriteLine("Triangle areas: " + Triangle.Triangle_Area(a, b));
