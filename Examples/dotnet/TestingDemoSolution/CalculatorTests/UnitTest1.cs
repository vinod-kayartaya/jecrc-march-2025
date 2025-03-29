using CalculatorApplication.Service;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private CalculateService _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new CalculateService();
        }

        [Test]
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            // Arrange
            _calculator.Number1 = 5;
            _calculator.Number2 = 3;

            // Act
            double result = _calculator.Add();

            // Assert
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void Add_NegativeNumbers_ReturnsCorrectSum()
        {
            _calculator.Number1 = -5;
            _calculator.Number2 = -3;
            Assert.That(_calculator.Add(), Is.EqualTo(-8));
        }

        [Test]
        public void Subtract_PositiveNumbers_ReturnsCorrectDifference()
        {
            _calculator.Number1 = 10;
            _calculator.Number2 = 3;
            Assert.That(_calculator.Subtract(), Is.EqualTo(7));
        }

        [Test]
        public void Subtract_WithNegativeResult_ReturnsNegativeNumber()
        {
            _calculator.Number1 = 3;
            _calculator.Number2 = 10;
            Assert.That(_calculator.Subtract(), Is.EqualTo(-7));
        }

        [Test]
        public void Multiply_TwoPositiveNumbers_ReturnsCorrectProduct()
        {
            _calculator.Number1 = 4;
            _calculator.Number2 = 5;
            Assert.That(_calculator.Multiply(), Is.EqualTo(20));
        }

        [Test]
        public void Multiply_WithZero_ReturnsZero()
        {
            _calculator.Number1 = 5;
            _calculator.Number2 = 0;
            Assert.That(_calculator.Multiply(), Is.EqualTo(0));
        }

        [Test]
        public void Divide_TwoPositiveNumbers_ReturnsCorrectQuotient()
        {
            _calculator.Number1 = 10;
            _calculator.Number2 = 2;
            Assert.That(_calculator.Divide(), Is.EqualTo(5));
        }

        [Test]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            _calculator.Number1 = 10;
            _calculator.Number2 = 0;
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide());
        }

        [Test]
        public void Power_PositiveBaseAndExponent_ReturnsCorrectResult()
        {
            _calculator.Number1 = 2;
            _calculator.Number2 = 3;
            Assert.That(_calculator.Power(), Is.EqualTo(8));
        }

        [Test]
        public void Power_ZeroExponent_ReturnsOne()
        {
            _calculator.Number1 = 5;
            _calculator.Number2 = 0;
            Assert.That(_calculator.Power(), Is.EqualTo(1));
        }

        [Test]
        public void SquareRoot_PositiveNumber_ReturnsCorrectResult()
        {
            _calculator.Number1 = 16;
            Assert.That(_calculator.SquareRoot(), Is.EqualTo(4));
        }

        [Test]
        public void SquareRoot_Zero_ReturnsZero()
        {
            _calculator.Number1 = 0;
            Assert.That(_calculator.SquareRoot(), Is.EqualTo(0));
        }

        [Test]
        public void SquareRoot_NegativeNumber_ThrowsArgumentException()
        {
            _calculator.Number1 = -4;
            Assert.Throws<ArgumentException>(() => _calculator.SquareRoot());
        }

        [Test]
        public void Factorial_PositiveInteger_ReturnsCorrectResult()
        {
            _calculator.Number1 = 5;
            Assert.That(_calculator.Factorial(), Is.EqualTo(120));
        }

        [Test]
        public void Factorial_Zero_ReturnsOne()
        {
            _calculator.Number1 = 0;
            Assert.That(_calculator.Factorial(), Is.EqualTo(1));
        }

        [Test]
        public void Factorial_NegativeNumber_ThrowsArgumentException()
        {
            _calculator.Number1 = -5;
            Assert.Throws<ArgumentException>(() => _calculator.Factorial());
        }

        [Test]
        public void Factorial_NonInteger_ThrowsArgumentException()
        {
            _calculator.Number1 = 5.5;
            Assert.Throws<ArgumentException>(() => _calculator.Factorial());
        }

        [Test]
        public void Factorial_TooLarge_ThrowsArgumentException()
        {
            _calculator.Number1 = 21;
            Assert.Throws<ArgumentException>(() => _calculator.Factorial());
        }
    }
}