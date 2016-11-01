using System;
using Xunit;

namespace Importer.Tests
{
    public sealed class SilenceTests
    {
        private const float Tolerance = 0.001f;

        [Fact]
        public void Constructor_SetsCutTime_WhenCalled()
        {
            // Arrange
            var sut = new Silence(1.0f,
                                  2.0f,
                                  3.0f);

            // Act
            // Assert
            Assert.True(Math.Abs(1.1f - sut.CutTime) < Tolerance);
        }

        [Fact]
        public void Constructor_SetsStart_WhenCalled()
        {
            // Arrange
            var sut = new Silence(1.0f,
                                  2.0f,
                                  3.0f);

            // Act
            // Assert
            Assert.True(Math.Abs(1.0f - sut.Start) < Tolerance);
        }

        [Fact]
        public void Constructor_SetsEnd_WhenCalled()
        {
            // Arrange
            var sut = new Silence(1.0f,
                                  2.0f,
                                  3.0f);

            // Act
            // Assert
            Assert.True(Math.Abs(2.0f - sut.End) < Tolerance);
        }

        [Fact]
        public void Constructor_SetsDuration_WhenCalled()
        {
            // Arrange
            var sut = new Silence(1.0f,
                                  2.0f,
                                  3.0f);

            // Act
            // Assert
            Assert.True(Math.Abs(3.0f - sut.Duration) < Tolerance);
        }
    }
}