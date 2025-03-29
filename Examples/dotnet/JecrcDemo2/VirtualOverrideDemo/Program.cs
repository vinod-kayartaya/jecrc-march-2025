abstract class A
{
    public abstract void greet();

    public virtual void Hello()
    {
        Console.WriteLine("From A.hello()");
    }
}

class B : A
{
    public override void greet()
    {
        Console.WriteLine("greetings!");
    }

    public override void Hello()
    {
        Console.WriteLine("From B.hello()");
    }
}

class Program
{
    static void Main()
    {
        B b1 = new();
        b1.Hello();
    }
}