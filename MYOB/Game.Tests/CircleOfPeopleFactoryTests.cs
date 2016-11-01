using Game.Interfaces;
using Xunit;

namespace Game.Tests
{
    public sealed class CircleOfPeopleFactoryTests
    {
        [Fact]
        public void Create_ReturnsInstance_WhenCalled()
        {
            // Arrange
            var sut = new CircleOfPeopleFactory();

            // Act
            ICircleOfPeople actual = sut.Create(3);

            // Assert
            Assert.NotNull(actual);
        }
    }
}