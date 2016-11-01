using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Extensions;

namespace Game.Tests
{
    public sealed class CircleAsBitArrayTests
    {
        [Theory]
        [InlineData(1, 2, new[]
                          {
                              false,
                              true,
                              true,
                              true
                          })]
        [InlineData(2, 3, new[]
                          {
                              false,
                              true,
                              true,
                              true
                          })]
        [InlineData(3, 1, new[]
                          {
                              false,
                              true,
                              true,
                              true
                          })]
        [InlineData(1, 3, new[]
                          {
                              false,
                              false,
                              false,
                              true
                          })]
        [InlineData(2, 1, new[]
                          {
                              false,
                              true,
                              false,
                              false
                          })]
        [InlineData(3, 2, new[]
                          {
                              false,
                              false,
                              true,
                              false
                          })]
        public void NextPersonId_ReturnsNextPersonId_WhenCalled(
            int personId,
            int expected,
            bool[] array)
        {
            // Arrange
            CircleAsBitArray sut = CreateSut();

            // Act
            int actual = sut.NextPersonId(array,
                                          personId);

            // Assert
            Assert.Equal(expected,
                         actual);
        }

        [Theory]
        [InlineData(1, 1, 1, new[]
                             {
                                 false,
                                 true,
                                 true,
                                 true
                             })]
        [InlineData(1, 2, 2, new[]
                             {
                                 false,
                                 true,
                                 true,
                                 true
                             })]
        [InlineData(1, 3, 3, new[]
                             {
                                 false,
                                 true,
                                 true,
                                 true
                             })]
        [InlineData(1, 3, 1, new[]
                             {
                                 false,
                                 true,
                                 false,
                                 true
                             })]
        [InlineData(3, 3, 3, new[]
                             {
                                 false,
                                 true,
                                 false,
                                 true
                             })]
        public void NextPersonIdForCountTo_ReturnsNextPersonId_WhenCalled(
            int personId,
            int countTo,
            int expected,
            bool[] array)
        {
            // Arrange
            CircleAsBitArray sut = CreateSut();

            // Act
            int actual = sut.NextPersonIdForCountTo(array,
                                                    personId,
                                                    countTo);

            // Assert
            Assert.Equal(expected,
                         actual);
        }

        [Theory]
        [InlineData(3, 1, new[]
                          {
                              1,
                              2,
                              3
                          })]
        [InlineData(3, 2, new[]
                          {
                              2,
                              1,
                              3
                          })]
        [InlineData(3, 3, new[]
                          {
                              3,
                              1,
                              2
                          })]
        [InlineData(3, 4, new[]
                          {
                              1,
                              3,
                              2
                          })]
        public void Run_ReturnsPersonIds_WhenCalled(
            int numberOfPeople,
            int countTo,
            int[] expected)
        {
            // Arrange
            CircleAsBitArray sut = CreateSut();

            // Act
            IEnumerable <int> actual = sut.Run(numberOfPeople,
                                               countTo);

            // Assert
            TestHelper.AssertArray(expected,
                                   actual);
        }

        [Fact]
        public void Constructor_SetsMaxLoopCount_WhenCalled()
        {
            // Arrange
            CircleAsBitArray sut = CreateSut();

            // Act
            // Assert
            Assert.Equal(10000000,
                         sut.MaxLoopCount);
        }

        [Fact]
        public void NextPersonId_Throws_ForToManyLoops()
        {
            // Arrange
            bool[] bitArray = Enumerable.Repeat(false,
                                                10).ToArray();
            CircleAsBitArray sut = CreateSut();
            sut.SetMaxLoopCount(2);

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.NextPersonId(bitArray,
                                                                     1));
        }

        [Fact]
        public void NextPersonIdForCountTo_Throws_ForToManyLoops()
        {
            // Arrange
            bool[] bitArray = Enumerable.Repeat(false,
                                                10).ToArray();
            CircleAsBitArray sut = CreateSut();
            sut.SetMaxLoopCount(2);

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.NextPersonIdForCountTo(bitArray,
                                                                               1,
                                                                               10));
        }

        private CircleAsBitArray CreateSut()
        {
            return new CircleAsBitArray();
        }
    }
}