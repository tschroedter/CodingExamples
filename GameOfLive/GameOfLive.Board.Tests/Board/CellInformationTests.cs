using GameOfLive.Board.Board;
using GameOfLive.Interfaces.Board;
using Xunit;
using XunitShould;

namespace GameOfLive.Board.Tests.Board
{
    public sealed class CellInformationTests
    {
        [Fact]
        public void RowIndex_Roundtrip_Test()
        {
            // Arrange
            CellInformation sut = CreateSut();

            // Act
            // Assert
            sut.RowIndex.ShouldEqual(1);
        }

        [Fact]
        public void ColumnIndex_Roundtrip_Test()
        {
            // Arrange
            CellInformation sut = CreateSut();

            // Act
            // Assert
            sut.ColumnIndex.ShouldEqual(2);
        }

        [Fact]
        public void Status_Roundtrip_Test()
        {
            // Arrange
            CellInformation sut = CreateSut();

            // Act
            // Assert
            sut.Status.ShouldEqual(Cell.Status.Alive);
        }

        private CellInformation CreateSut()
        {
            return new CellInformation
                   {
                       RowIndex = 1,
                       ColumnIndex = 2,
                       Status = Cell.Status.Alive
                   };
        }
    }
}