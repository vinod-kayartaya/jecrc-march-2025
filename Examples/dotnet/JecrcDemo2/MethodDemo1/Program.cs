using MethodDemo1.Utils;

namespace MethodDemo1
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, again!");
            Console.Write("What's your name? ");
            var name = Console.ReadLine();
            Greet g1 = new();
            Greet.SayHello();
            Greet.SayHello(name);
        }
    }
}
