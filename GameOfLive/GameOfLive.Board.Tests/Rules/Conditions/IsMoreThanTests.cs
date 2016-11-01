using GameOfLive.Board.Rules.Conditions;
using Xunit;
using Xunit.Extensions;

namespace GameOfLive.Board.Tests.Rules.Conditions
{
    public sealed class IsMoreThanTests
    {
        [Theory]
        [InlineData(1, 0, false)]
        [InlineData(1, 2, true)]
        public void FunctionUnderTest_ExpectedResult_UnderCondition(int threshold,
                                                                    int actual,
                                                                    bool expected)
        {
            // Arrange
            var sut = new IsMoreThan
                      {
                          Threshold = threshold,
                          Actual = actual
                      };

            // Act
            // Assert
            Assert.Equal(expected,
                         sut.IsSatisfied());
        }
    }
}