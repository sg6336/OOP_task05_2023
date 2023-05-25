using LibraryCalculator;
using NUnit.Framework;

namespace TestCalculator
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void TestSimpleExpression()
        {
            string expression = "9+1*3";
            string expected = "12";
            string result = Calculator.Calculate(expression);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestDivisionByZero()
        {
            string expression = "7/0";
            string expected = "Exception. Divide by zero.";
            string result = Calculator.Calculate(expression);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestExpressionWithBrackets()
        {
            string expression = "3+4*(1+2)";
            string expected = "15";
            string result = Calculator.Calculate(expression);
            Assert.AreEqual(expected, result);
        }
    }
}