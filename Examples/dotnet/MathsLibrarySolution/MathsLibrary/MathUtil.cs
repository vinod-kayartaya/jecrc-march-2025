namespace MathsLibrary
{
    public class MathUtil
    {
        public int Fibonacci(int num)
        {
            if (num < 1)
            {
                throw new ArgumentException("Invalid argument; input must be >=1");
            }

            int a, b, c=0;
            a = -1;
            b = 1;
            for(int i=0; i<num; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
        }
    }
}
