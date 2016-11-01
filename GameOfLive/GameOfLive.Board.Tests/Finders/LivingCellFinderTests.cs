using System.Collections.Generic;
using System.Linq;
using GameOfLive.Board.Board;
using GameOfLive.Board.Finders;
using GameOfLive.Interfaces.Board;
using Xunit;
using XunitShould;

namespace GameOfLive.Board.Tests.Finders
{
    public sealed class LivingCellFinderTests
    {
        [Fact]
        public void Find_ReturnsAliveCells_ForRowsNotEmpty()
        {
            // Arrange
            IEnumerable <ICellInformation> expected = CreateExpectedCellInfos();
            Dictionary <int, ICells> rows = CreateNotEmptyRows();
            LivingCellFinder sut = CreateSut();

            // Act
            IEnumerable <ICellInformation> actual = sut.Find(rows);

            // Assert
            Assert.True(expected.SequenceEqual(actual));
        }

        [Fact]
        public void Find_ReturnsEmpty_ForAllRowsEmpty()
        {
            // Arrange
            Dictionary <int, ICells> rows = CreateEmptyRows();
            LivingCellFinder sut = CreateSut();

            // Act
            IEnumerable <ICellInformation> actual = sut.Find(rows);

            // Assert
            actual.Count().ShouldEqual(0);
        }

        [Fact]
        public void Find_ReturnsEmpty_ForDictionaryEmpty()
        {
            // Arrange
            Dictionary <int, ICells> rows = CreateEmpty();
            LivingCellFinder sut = CreateSut();

            // Act
            IEnumerable <ICellInformation> actual = sut.Find(rows);

            // Assert
            actual.Count().ShouldEqual(0);
        }

        private LivingCellFinder CreateSut()
        {
            return new LivingCellFinder(new NeighboursFinder());
        }

        private Dictionary <int, ICells> CreateEmptyRows()
        {
            var rows = new Dictionary <int, ICells>();

            var one = new Cells();
            var two = new Cells();

            rows.Add(1,
                     one);
            rows.Add(2,
                     two);

            return rows;
        }

        private Dictionary <int, ICells> CreateEmpty()
        {
            var rows = new Dictionary <int, ICells>();

            return rows;
        }

        private Dictionary <int, ICells> CreateNotEmptyRows()
        {
            var rows = new Dictionary <int, ICells>();

            var one = new Cells();
            one.SetStatus(0,
                          Cell.Status.Alive);
            one.SetStatus(1,
                          Cell.Status.Alive);

            var two = new Cells();
            two.SetStatus(0,
                          Cell.Status.Alive);

            rows.Add(0,
                     one);
            rows.Add(1,
                     two);

            return rows;
        }

        private IEnumerable <CellInformation> CreateExpectedCellInfos()
        {
            var list = new List <CellInformation>();

            var zeroZero = new CellInformation
                           {
                               RowIndex = 0,
                               ColumnIndex = 0,
                               Status = Cell.Status.Alive,
                               NeighboursAlive = 2
                           };

            list.Add(zeroZero);

            var zeroOne = new CellInformation
                          {
                              RowIndex = 0,
                              ColumnIndex = 1,
                              Status = Cell.Status.Alive,
                              NeighboursAlive = 2
                          };

            list.Add(zeroOne);

            var oneZero = new CellInformation
                          {
                              RowIndex = 1,
                              ColumnIndex = 0,
                              Status = Cell.Status.Alive,
                              NeighboursAlive = 2
                          };

            list.Add(oneZero);

            return list;
        }
    }
}