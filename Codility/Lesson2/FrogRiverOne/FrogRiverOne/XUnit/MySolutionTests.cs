using Xunit;
using Xunit.Extensions;

namespace FrogRiverOne.XUnit
{
    public sealed class MySolutionTests
    {
        [Theory]
        [InlineData(new[] { 1, 1 }, 1, 0)]
        [InlineData(new[] { 2, 1 }, 1, 1)]
        [InlineData(new[] { 1, 2 }, 1, 0)]
        [InlineData(new[] { 1, 2 }, 2, 1)]
        [InlineData(new[] { 1, 3, 1, 4, 2, 3, 5, 4 }, 5, 6)]
        public void FunctionUnderTest_ExpectedResult_UnderCondition(
            int[] a,
            int x,
            int expected)
        {
            // Arrange
            var sut = new MySolution();

            // Act
            var actual = sut.Solution(x, a);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}