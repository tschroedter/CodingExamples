using System.Collections.Generic;
using GameOfLive.Board.Board;
using GameOfLive.Interfaces.Board;
using Xunit;
using XunitShould;

namespace GameOfLive.Board.Tests
{
    public sealed class StringToCellInformationConverterTests
    {
        [Fact]
        public void FunctionUnderTest_ExpectedResult_UnderCondition()
        {
            // Arrange
            IEnumerable <ICellInformation> expected = CreateCellsInformationStillLife();
            string[] text = CreateStillLife();
            var sut = new StringToCellInformationConverter();

            // Act
            IEnumerable <ICellInformation> actual = sut.Convert(text);

            // Assert
            expected.ShouldEqual(actual);
        }

        private string[] CreateStillLife()
        {
            return new[]
                   {
                       "    ",
                       " ** ",
                       " ** ",
                       "    "
                   };
        }

        private IEnumerable <ICellInformation> CreateCellsInformationStillLife()
        {
            var one = new CellInformation
                      {
                          RowIndex = 1,
                          ColumnIndex = 1,
                          NeighboursAlive = 0,
                          Status = Cell.Status.Alive
                      };
            var two = new CellInformation
                      {
                          RowIndex = 1,
                          ColumnIndex = 2,
                          NeighboursAlive = 0,
                          Status = Cell.Status.Alive
                      };

            var three = new CellInformation
                        {
                            RowIndex = 2,
                            ColumnIndex = 1,
                            NeighboursAlive = 0,
                            Status = Cell.Status.Alive
                        };

            var four = new CellInformation
                       {
                           RowIndex = 2,
                           ColumnIndex = 2,
                           NeighboursAlive = 0,
                           Status = Cell.Status.Alive
                       };

            return new[]
                   {
                       one,
                       two,
                       three,
                       four
                   };
        }
    }
}