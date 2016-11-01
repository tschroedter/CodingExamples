using GameOfLive.Board.Rules.Conditions;
using Xunit;
using Xunit.Extensions;

namespace GameOfLive.Board.Tests.Rules.Conditions
{
    public sealed class IsLessThanTests
    {
        [Theory]
        [InlineData(1, 0, true)]
        [InlineData(1, 2, false)]
        public void FunctionUnderTest_ExpectedResult_UnderCondition(int threshold,
                                                                    int actual,
                                                                    bool expected)
        {
            // Arrange
            var sut = new IsLessThan
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