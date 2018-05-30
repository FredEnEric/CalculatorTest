using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    public class OperationTests
    {
        [Test]
        [TestCase(1, "+", 1)]
        [TestCase(-1, "+", -1)]
        [TestCase(1.2, "+", 1.3)]

        [TestCase(1, "-", 1)]
        [TestCase(-1, "-", -1)]
        [TestCase(1.2, "-", 1.3)]

        [TestCase(2, "*", 2)]
        [TestCase(-2, "*", -2)]
        [TestCase(2.4, "*", 1.3)]

        [TestCase(2, "/", 2)]
        [TestCase(-2, "/", -2)]
        [TestCase(2.4, "+", 1.3)]
        public void ParseShouldFindLeftAndRightNumber(double leftNumber, string operand, double rightNumber)
        {
            //Arrange
            var operation = new Operation();
            //Act
            operation.Parse($"{leftNumber}{operand}{rightNumber}");
            //Assert
            Assert.That(operation.LeftNumber, Is.EqualTo(leftNumber));
            Assert.That(operation.RightNumber, Is.EqualTo(rightNumber));
        }

        [Test]
        public void SolveShouldThrowErrorIfUsedBeforeParse()
        {
            //Arrange
            var operation = new Operation();
            //Act
            //Assert
            Assert.Throws<System.Exception>(() => operation.Solve());
        }

        [Test]
        [TestCase("1+1", 2)]
        [TestCase("2-0.5", 1.5)]
        [TestCase("-4*3", -12)]
        [TestCase("6.9/4", 1.725)]
        public void SolveShouldReturnDouble(string equation, double expectedResult)
        {
            //Arrange
            var operation = new Operation();
            operation.Parse(equation);
            //Act
            var result = operation.Solve();
            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
