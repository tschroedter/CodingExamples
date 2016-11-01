using System.Collections.Generic;
using System.Linq;
using GameOfLive.Board.Board;
using GameOfLive.Interfaces.Board;
using Xunit;
using Xunit.Extensions;
using XunitShould;

namespace GameOfLive.Board.Tests.Board
{
    public sealed class CellsTests
    {
        [Theory]
        [InlineData(-1, Cell.Status.Dead)]
        [InlineData(0, Cell.Status.Dead)]
        [InlineData(1, Cell.Status.Dead)]
        public void GetStatus_ReturnsDead_ForNotUsedIndex(int index,
                                                          Cell.Status status)
        {
            // Arrange
            Cells sut = CreateSut();

            // Act
            Cell.Status actual = sut.GetStatus(index);

            // Assert
            actual.ShouldEqual(status);
        }

        [Theory]
        [InlineData(-1, Cell.Status.Alive)]
        [InlineData(0, Cell.Status.Alive)]
        [InlineData(1, Cell.Status.Alive)]
        [InlineData(-11, Cell.Status.Dead)]
        [InlineData(10, Cell.Status.Dead)]
        [InlineData(11, Cell.Status.Dead)]
        public void SetStatus_SetsStatus_ForIndex(int index,
                                                  Cell.Status status)
        {
            // Arrange
            Cells sut = CreateSut();

            // Act
            sut.SetStatus(index,
                          status);

            // Assert
            sut.GetStatus(index).ShouldEqual(status);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void SetStatus_SetsStatusToDead_ForStatusAlive(int index)
        {
            // Arrange
            Cells sut = CreateSut();
            sut.SetStatus(index,
                          Cell.Status.Alive);

            // Act
            sut.SetStatus(index,
                          Cell.Status.Dead);

            // Assert
            sut.GetStatus(index).ShouldEqual(Cell.Status.Dead);
        }

        [Fact]
        public void AreAllDead_ReturnsTrue_ForAllDead()
        {
            // Arrange
            Cells sut = CreateSut();

            // Act
            // Assert
            sut.AreAllDead().ShouldBeTrue();
        }

        [Fact]
        public void AreAllDead_ReturnsFalse_ForOneAlive()
        {
            // Arrange
            Cells sut = CreateSut();

            // Act
            sut.SetStatus(1,
                          Cell.Status.Alive);

            // Assert
            sut.AreAllDead().ShouldBeFalse();
        }

        [Fact]
        public void GetAllAlive_ReturnsEmptyByDefault_WhenCalled()
        {
            // Arrange
            Cells sut = CreateSut();

            // Act
            IEnumerable <int> actual = sut.GetAllAlive();

            // Assert
            actual.ShouldBeEmpty();
        }

        [Fact]
        public void GetAllAlive_ReturnsListOfAliveCells_WhenCalled()
        {
            // Arrange
            var expected = new[]
                           {
                               1,
                               2
                           };

            Cells sut = CreateSut();

            sut.SetStatus(1,
                          Cell.Status.Alive);
            sut.SetStatus(2,
                          Cell.Status.Alive);

            // Act
            IEnumerable <int> actual = sut.GetAllAlive();

            // Assert
            Assert.True(expected.SequenceEqual(actual));
        }

        private Cells CreateSut()
        {
            return new Cells();
        }
    }
}