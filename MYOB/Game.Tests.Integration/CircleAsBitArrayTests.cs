using System.Linq;
using Xunit;
using Xunit.Extensions;

namespace Game.Tests.Integration
{
    public sealed class CircleAsBitArrayTests
    {
        [Theory]
        [InlineData(1, 10, 1)]
        [InlineData(10, 10, 8)]
        [InlineData(100, 10, 26)]
        [InlineData(1000, 10, 63)]
        [InlineData(10000, 10, 9143)]
        [InlineData(100000, 10, 77328)]
        [InlineData(1000000, 10, 630538)]
        public void Run_ReturnsPersonIds_WhenCalled(
            int numberOfPeople,
            int countTo,
            int expectedWinner)
        {
            // Arrange
            CircleAsBitArray sut = CreateSut();

            // Act
            int actual = sut.Run(numberOfPeople,
                                 countTo).Last();

            // Assert
            Assert.Equal(expectedWinner,
                         actual);
        }

        private CircleAsBitArray CreateSut()
        {
            return new CircleAsBitArray();
        }
    }
}