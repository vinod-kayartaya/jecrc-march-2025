using CalculatorLibrary.Service;

Console.WriteLine("Enter a number: ");
int input = int.Parse(Console.ReadLine());

int fact = CalculatorService.Factorial(input);

Console.WriteLine($"factorial of {input} is {fact}");