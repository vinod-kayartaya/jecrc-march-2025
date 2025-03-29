using CalculatorLibrary.Service;

namespace CalculatorServiceTests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void Factorial_ForNegativeInput_ThrowsException()
        {
            // arrange
            int input = -123;

            Assert.Throws<ArgumentException>(
                () => CalculatorService.Factorial(input), 
                "Was expecting Argumentexception to be thrown; but didn't get one!");


        }

        [Test]
        public void Factorial_ForPositiveNumber_ReturnsFactorial()
        {
            // Arrange
            int input = 5;
            int expected = 120;

            // Act
            int actual = CalculatorService.Factorial(input);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(6, 720)]
        [TestCase(7, 5040)]
        [TestCaseSource(nameof(MoreTestData))]
        [TestCaseSource(nameof(TestDataFromCsv))]
        public void Factorial_ForValidInput_ReturnsFactorial(int input, int expected)
        {
            int actual = CalculatorService.Factorial(input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        public static IEnumerable<TestCaseData> MoreTestData()
        {
            yield return new TestCaseData(3, 6);
            yield return new TestCaseData(4, 24);
            yield return new TestCaseData(8, 40320);
        }

        public static IEnumerable<TestCaseData> TestDataFromCsv()
        {
            var lines = File.ReadAllLines("C:\\Users\\vinod\\OneDrive\\Desktop\\trainings\\testing\\CalculatorSolution\\CalculatorServiceTests\\testdata.csv")
                .Skip(1); // skip the header

            foreach(string line in lines)
            {
                var data = line.Split(",");
                int input = int.Parse(data[0]);
                int expected = int.Parse(data[1]);

                yield return new TestCaseData(input, expected)
                    .SetName($"for {data[0]}, factorial is {data[1]}");
            }
        }

    }
}