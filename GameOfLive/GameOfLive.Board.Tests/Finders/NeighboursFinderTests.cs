using System.Collections.Generic;
using GameOfLive.Board.Board;
using GameOfLive.Board.Finders;
using GameOfLive.Interfaces.Board;
using Xunit;
using Xunit.Extensions;
using XunitShould;

namespace GameOfLive.Board.Tests.Finders
{
    public sealed class NeighboursFinderTests
    {
        [Fact]
        public void FindAlive_ReturnsEmpty_ForAllDead()
        {
            // Arrange
            Dictionary <int, ICells> rows = CreateEmptyRows();
            NeighboursFinder sut = CreateSut();

            // Act
            int actual = sut.NumberOfAliveNeighbours(rows,
                                                     0,
                                                     0);

            // Assert
            actual.ShouldEqual(0);
        }

        [Theory] // NUnit combinatorial would be create here
        [InlineData(-1, 0)]
        [InlineData(1, 0)]
        [InlineData(0, -1)]
        [InlineData(0, 1)]
        [InlineData(-1, -1)]
        [InlineData(1, 1)]
        [InlineData(-1, 1)]
        [InlineData(1, -1)]
        public void FindAlive_ReturnsOne_ForOnlyOneIsAlive(int row,
                                                           int column)
        {
            // Arrange
            Dictionary <int, ICells> rows = CreateEmptyRows();
            var cells = new Cells();
            cells.SetStatus(column,
                            Cell.Status.Alive);
            rows.Add(row,
                     cells);

            NeighboursFinder sut = CreateSut();

            // Act
            int actual = sut.NumberOfAliveNeighbours(rows,
                                                     0,
                                                     0);

            // Assert
            actual.ShouldEqual(1);
        }

        [Fact]
        public void FindAlive_ReturnsTwo_ForTwoAreAlive()
        {
            // Arrange
            Dictionary <int, ICells> rows = CreateEmptyRows();
            var cells = new Cells();
            cells.SetStatus(0,
                            Cell.Status.Alive);
            cells.SetStatus(-1,
                            Cell.Status.Alive);
            rows.Add(-1,
                     cells);

            NeighboursFinder sut = CreateSut();

            // Act
            int actual = sut.NumberOfAliveNeighbours(rows,
                                                     0,
                                                     0);

            // Assert
            actual.ShouldEqual(2);
        }

        private Dictionary <int, ICells> CreateEmptyRows()
        {
            return new Dictionary <int, ICells>();
        }

        private NeighboursFinder CreateSut()
        {
            return new NeighboursFinder();
        }
    }
}