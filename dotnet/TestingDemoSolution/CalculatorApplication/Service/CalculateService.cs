using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Service
{
    public class CalculateService
    {
        public double Number1 { get; set; }
        public double Number2 { get; set; }

        public double Add()
        {
            return Number1 + Number2;
        }

        public double Subtract()
        {
            return Number1 - Number2;
        }

        public double Multiply()
        {
            return Number1 * Number2;
        }

        public double Divide()
        {
            if (Number2 == 0)
                throw new DivideByZeroException("Cannot divide by zero");
            return Number1 / Number2;
        }

        public double Power()
        {
            return Math.Pow(Number1, Number2);
        }

        public double SquareRoot()
        {
            if (Number1 < 0)
                throw new ArgumentException("Cannot calculate square root of a negative number");
            return Math.Sqrt(Number1);
        }

        public int Factorial()
        {
            if (Number1 < 0)
                throw new ArgumentException("Cannot calculate factorial of a negative number");
            if (Number1 > 20)
                throw new ArgumentException("Input too large, may cause overflow");
            
            int input = (int)Number1;
            if (input != Number1)
                throw new ArgumentException("Factorial requires an integer input");

            int factorial = 1;
            for(int i = 1; i <= input; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
