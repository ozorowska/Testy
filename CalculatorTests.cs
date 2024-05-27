using NUnit.Framework;

namespace TestProjectAO
{
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_TwoPositiveNumbers_ReturnsSum()
        {
            var result = _calculator.Add(1, 2);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            var result = _calculator.Subtract(5, 3);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            var result = _calculator.Multiply(2, 3);
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Divide_ByNonZeroNumber_ReturnsQuotient()
        {
            var result = _calculator.Divide(6, 3);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(1, 0));
        }

    }
}
