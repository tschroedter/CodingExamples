using System.Collections.Generic;
using System.Linq;
using GameOfLive.Board.Board;
using GameOfLive.Board.Finders;
using GameOfLive.Interfaces.Board;
using GameOfLive.Interfaces.Finders;
using NSubstitute;
using Xunit;
using Xunit.Extensions;
using XunitShould;

namespace GameOfLive.Board.Tests.Board
{
    public sealed class UnlimitedBoardTests
    {
        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        public void GetStatus_ReturnsStatusDeadAsDefault_ForRowAndColumn(int row,
                                                                         int coloumn)
        {
            // Arrange
            UnlimitedBoard sut = CreateSut();

            // Act
            Cell.Status actual = sut.GetStatus(row,
                                               coloumn);

            // Assert
            actual.ShouldEqual(Cell.Status.Dead);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        public void SetStatus_SetsStatusToAlive_ForRowAndColumn(int row,
                                                                int coloumn)
        {
            // Arrange
            UnlimitedBoard sut = CreateSut();

            // Act
            sut.SetStatus(row,
                          coloumn,
                          Cell.Status.Alive);

            // Assert
            sut.GetStatus(row,
                          coloumn).ShouldEqual(Cell.Status.Alive);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        public void SetStatus_SetsStatusToDead_ForRowAndColumn(int row,
                                                               int coloumn)
        {
            // Arrange
            UnlimitedBoard sut = CreateSut();
            sut.SetStatus(row,
                          coloumn,
                          Cell.Status.Alive);

            // Act
            sut.SetStatus(row,
                          coloumn,
                          Cell.Status.Dead);

            // Assert
            sut.GetStatus(row,
                          coloumn).ShouldEqual(Cell.Status.Dead);
        }

        [Fact]
        public void SetStatus_SetsStatusToDead_ForRowWithOtherAlive()
        {
            // Arrange
            UnlimitedBoard sut = CreateSut();
            sut.SetStatus(0,
                          0,
                          Cell.Status.Alive);
            sut.SetStatus(0,
                          1,
                          Cell.Status.Alive);

            // Act
            sut.SetStatus(0,
                          1,
                          Cell.Status.Dead);

            // Assert
            sut.GetStatus(0,
                          0).ShouldEqual(Cell.Status.Alive);
            sut.GetStatus(0,
                          1).ShouldEqual(Cell.Status.Dead);
        }

        [Fact]
        public void SetStatus_SetsStatusToDead_ForAlreadyDead()
        {
            // Arrange
            UnlimitedBoard sut = CreateSut();

            // Act
            sut.SetStatus(1,
                          1,
                          Cell.Status.Dead);

            // Assert
            sut.GetStatus(1,
                          1).ShouldEqual(Cell.Status.Dead);
        }

        [Fact]
        public void LivingCells_ReturnsAllAlive_WhenCalled()
        {
            // Arrange
            var expected = new CellInformation[0];
            var finder = Substitute.For <ILivingCellFinder>();
            finder.Find(Arg.Any <Dictionary <int, ICells>>()).Returns(expected);

            UnlimitedBoard sut = CreateSut();

            // Act
            IEnumerable <ICellInformation> actual = sut.LivingCells();

            // Assert
            expected.ShouldEqual(actual);
        }

        [Fact]
        public void Update_UpdatesStatus_WhenCalled()
        {
            // Arrange
            ICellInformation[] expected = CreateCellsInformation().ToArray();
            UnlimitedBoard sut = CreateSut();

            // Act
            sut.Update(expected);

            // Assert
            expected.ShouldEqual(sut.LivingCells());
        }

        private IEnumerable <ICellInformation> CreateCellsInformation()
        {
            var one = new CellInformation
                      {
                          RowIndex = -10,
                          ColumnIndex = -10,
                          NeighboursAlive = 0,
                          Status = Cell.Status.Alive
                      };
            var two = new CellInformation
                      {
                          RowIndex = 10,
                          ColumnIndex = 10,
                          NeighboursAlive = 0,
                          Status = Cell.Status.Alive
                      };

            var three = new CellInformation
                        {
                            RowIndex = 0,
                            ColumnIndex = 0,
                            NeighboursAlive = 0,
                            Status = Cell.Status.Alive
                        };

            return new[]
                   {
                       one,
                       two,
                       three
                   };
        }

        private UnlimitedBoard CreateSut(ILivingCellFinder livingCellFinder = null,
                                         INeighboursFinder neighboursFinder = null)
        {
            if ( livingCellFinder == null )
            {
                livingCellFinder = new LivingCellFinder(neighboursFinder ?? new NeighboursFinder());
            }

            return new UnlimitedBoard(livingCellFinder);
        }
    }
}