namespace CalculatorLibrary.Service
{
    public class CalculatorService
    {
        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException();
            }
            int f = 1;
            while (number > 1)
            {
                f *= number--;
            }

            return f;
        }
    }
}
