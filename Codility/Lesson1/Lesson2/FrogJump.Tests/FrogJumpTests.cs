using NUnit.Framework;

namespace FrogJump.Tests
{
    [TestFixture]
    public sealed class FrogJumpTests
    {
        private FrogJump CreateSut()
        {
            return new FrogJump();
        }

        [Test]
        public void FunctionUnderTest_ExpectedResult_UnderCondition()
        {
            // Arrange
            var sut = CreateSut();

            // Act
            var actual = sut.Solution(10, 85, 30);

            // Assert
            Assert.AreEqual(3,
                actual);
        }
    }
}