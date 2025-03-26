namespace InterfaceDemo
{
    class Triangle:IShape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public string ShapeName { get { return "Triangle"; } }

        public void PrintArea()
        {
            var area = 0.5 * Base * Height;
            Console.WriteLine($"area of triangle with base={Base} and height={Height} is {area}");
        }
    }
}
