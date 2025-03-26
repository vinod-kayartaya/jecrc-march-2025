
using System.Data;

namespace InterfaceDemo
{
    class Circle:IShape
    {
        public double Radius { get; set; }
        public string ShapeName { get { return "Circle"; } }

        public void PrintArea()
        {
            var area = Math.PI * Radius * Radius;
            Console.WriteLine($"area of circle with radius {Radius} is {area}");
        }
    }
}
