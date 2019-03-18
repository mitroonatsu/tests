using System;
using Xunit;
using UnitTestExample;

namespace DemoTests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(4,3,7)]
        [InlineData(4.5,6,10.5)]
        [InlineData(-1.5,-5,-6.5)]
        [InlineData(double.MaxValue, 10, double.MaxValue)]
        [InlineData(double.MaxValue, double.MaxValue, double.PositiveInfinity)]
        [InlineData(double.MinValue, double.MinValue, double.NegativeInfinity)]
        public void Add_ShouldCalculate_ReturnEqual(double x, double y, double expected)
        {
            //Arrange
            //var expected = 5;
            //Act
            var actual = Calculator.Add(x, y);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8,4,2)]
        [InlineData(8,0,double.PositiveInfinity)]
        [InlineData(0,2,0)]
        [InlineData(0,0,double.NaN)]
        public void Divide_ShouldDivide_ReturnEqual(double x, double y, double expected)
        {
            //Arrange
            //var expected = 2;
            //Act
            var actual = Calculator.Divide(x,y);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
