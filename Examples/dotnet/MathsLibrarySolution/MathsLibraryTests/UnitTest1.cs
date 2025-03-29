using MathsLibrary;

namespace MathsLibraryTests
{
    [TestFixture]
    public class Tests
    {
        private MathUtil util;

        [SetUp]
        public void Init()
        {
            util = new();
        }

        [Test(Description ="5th fibonacci element")]
        public void Fibonacci_ForValidInput_ReturnsFiboNumber()
        {
            // arrange
            int input = 5;
            int expected = 3;

            // act
            int actual = util.Fibonacci(input);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, 0, TestName ="First fibonacci number")]
        [TestCase(2, 1, TestName = "Second fibonacci number")]
        [TestCase(3, 1, TestName = "Third fibonacci number")]
        [TestCase(4, 2)]
        [TestCaseSource(nameof(FibonacciTestInputs))]
        public void Fibonacci_ForValidInputs_ReturnsFiboNumbers(int input, int expected)
        {
            // act
            int actual = util.Fibonacci(input);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        // function to act as a source testcase data
        public static IEnumerable<TestCaseData> FibonacciTestInputs()
        {
            yield return new TestCaseData(6, 5).SetName("6th fibonacci element");
            yield return new TestCaseData(7, 8).SetName("7th fibonacci element");
            yield return new TestCaseData(8, 13).SetName("8th fibonacci element");
            yield return new TestCaseData(9, 21).SetName("9th fibonacci element");

            var filename = "C:\\Users\\vinod\\OneDrive\\Documents\\sandbox\\Batch1\\MathsLibrarySolution\\MathsLibraryTests\\fibo-inputs.csv";
            var lines = File.ReadAllLines(filename).Skip(1);
            foreach(var line in lines)
            {
                var fields = line.Split(",");
                int input;
                int expected;
                try
                {
                     input = int.Parse(fields[0].Trim());
                     expected = int.Parse(fields[1].Trim());
                }
                catch (Exception)
                {
                    // just continue with the next line
                    continue;
                }
                yield return new TestCaseData(input, expected)
                        .SetName($"fibonacci element for {input}");
            }

        }

        
    }
}