using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]
    public class GildedRoseTests
    {
        [Test]
        public void Add_ShouldReturnTwo_GivenOneAndOne()
        {
            //arrange
            int x = 1;
            int y = 1;
            Calculator calc = new Calculator();

            //act
            int result = calc.Add(x, y);

            //assert
            result.Should().Be(2, "because 1 + 1 is 2.");
        }

        [Test]
        public void Add_ShouldBeCalledOnce()
        {
            //arrange
            int x = 2;
            int y = 2;
            Mock<ICalculator> mockCalc = new Mock<ICalculator>();
            const int expectedResult = 4;
            mockCalc.Setup(calc => calc.Add(x, y)).Returns(expectedResult);

            //act
            int actualResult = mockCalc.Object.Add(x, y);

            //assert
            mockCalc.Verify(calc => calc.Add(x, y), Times.Once);
            actualResult.Should().Be(expectedResult, "because 2 + 2 is 4.");
        }
    }

    public interface ICalculator
    {
        int Add(int x, int y);
    }

    public class Calculator : ICalculator
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}
