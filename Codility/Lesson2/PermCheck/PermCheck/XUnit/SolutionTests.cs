using Xunit;
using Xunit.Extensions;

namespace PermCheck.XUnit
{
    public class SolutionTests
    {
        [Theory]
        [InlineData(new int[0], 0)]
        [InlineData(new[] { 1 }, 1)]
        [InlineData(new[] { 1, 1 }, 0)]
        [InlineData(new[] { 10 }, 0)]
        [InlineData(new[] { 1, 2 }, 1)]
        [InlineData(new[] { 2, 3 }, 0)]
        [InlineData(new[] { 4, 1, 3, 2 }, 1)]
        [InlineData(new[] {4, 1, 3}, 0)]
        public void Solution_ReturnsValue_WhenCalled(int[] a, int expected)
        {
            // Arrange
            var sut = new MySolution();

            // Act
            var actual = sut.Solution(a);

            // Assert
            Assert.Equal(expected,
                actual);
        }

        [Fact]
        public void Solution_ReturnsValue_ForLargeArray()
        {
            // Arrange
            var a = CreateLargeValidPermutationArray(1000000);
            var sut = new MySolution();

            // Act
            var actual = sut.Solution(a);

            // Assert
            Assert.Equal(1, actual);
        }

        private int[] CreateLargeValidPermutationArray(int size)
        {
            var a = new int[size];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i + 1;
            }

            return a;
        }
    }
}