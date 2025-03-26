using InterfaceDemo;

Circle c1 = new() { Radius = 12.34 };
Circle c2 = new() { Radius = 22.12 };
Triangle t1 = new() { Base = 1.2, Height = 2.3 };

// c1 refers to an object of Circle and IShape
// c2 refers to an object of Circle and IShape
// t1 refers to an object of Triangle and IShape

ProcessShape(c1);
ProcessShape(c2);
ProcessShape(t1);


static void ProcessShape(IShape shape)
{
    Console.WriteLine($"Got an object of {shape.ShapeName}");
    shape.PrintArea();
    Console.WriteLine();
}