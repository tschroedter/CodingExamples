using System.Linq;
using GameOfLive.Board.Board;
using GameOfLive.Board.Rules.Conditions;
using GameOfLive.Board.Rules.Rules;
using GameOfLive.Interfaces.Board;
using Xunit;
using Xunit.Extensions;
using XunitShould;

namespace GameOfLive.Board.Tests.Rules.Rules
{
    public sealed class NewbornRuleTests
    {
        [Fact]
        public void Initialize_AddsConditions_WhenCalled()
        {
            // Arrange
            CellInformation info = CreateCellInformation();
            NewbornRule sut = CreateSut();

            // Act
            sut.Initialize(info);

            // Assert
            sut.GetConditions().Count().ShouldEqual(1);
        }

        [Fact]
        public void Initialize_AddsMoreThanRule_WhenCalled()
        {
            // Arrange
            CellInformation info = CreateCellInformation();
            NewbornRule sut = CreateSut();

            // Act
            sut.Initialize(info);

            // Assert
            sut.GetConditions().First().ShouldBeInstanceOf <IsEqual>();
        }

        [Fact]
        public void Apply_SetsStatusToDead_WhenCalled()
        {
            // Arrange
            CellInformation info = CreateCellInformation();
            NewbornRule sut = CreateSut();

            // Act
            sut.Apply(info);

            // Assert
            info.Status.ShouldEqual(Cell.Status.Dead);
        }

        [Fact]
        public void Priority_ReturnsInteger_WhenCalled()
        {
            // Arrange
            CellInformation info = CreateCellInformation();
            NewbornRule sut = CreateSut();

            // Act
            sut.Apply(info);

            // Assert
            sut.Priority.ShouldEqual(4);
        }

        [Theory]
        [InlineData(2, false)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        public void IsValid_ReturnsTrueOrFalse_ForGivenNeighbours(int neighbours,
                                                                  bool expected)
        {
            // Arrange
            CellInformation info = CreateCellInformation(neighbours);
            NewbornRule sut = CreateSut();
            sut.Initialize(info);

            // Act
            bool actual = sut.IsValid();

            // Assert
            Assert.Equal(expected,
                         actual);
        }

        private CellInformation CreateCellInformation(int neighbours = 0)
        {
            return new CellInformation
                   {
                       RowIndex = 0,
                       ColumnIndex = 0,
                       Status = Cell.Status.Alive,
                       NeighboursAlive = neighbours
                   };
        }

        private NewbornRule CreateSut()
        {
            var newbornRule = new NewbornRule();

            return newbornRule;
        }
    }
}