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
    public sealed class SurvivorRuleTests
    {
        [Fact]
        public void Initialize_AddsConditions_WhenCalled()
        {
            // Arrange
            CellInformation info = CreateCellInformation();
            SurvivorRule sut = CreateSut();

            // Act
            sut.Initialize(info);

            // Assert
            sut.GetConditions().Count().ShouldEqual(2);
        }

        [Fact]
        public void Initialize_AddsMoreThanRule_WhenCalled()
        {
            // Arrange
            CellInformation info = CreateCellInformation();
            SurvivorRule sut = CreateSut();

            // Act
            sut.Initialize(info);

            // Assert
            sut.GetConditions().First().ShouldBeInstanceOf <IsMoreThan>();
        }

        [Fact]
        public void Initialize_AddsLessThanRule_WhenCalled()
        {
            // Arrange
            CellInformation info = CreateCellInformation();
            SurvivorRule sut = CreateSut();

            // Act
            sut.Initialize(info);

            // Assert
            sut.GetConditions().Last().ShouldBeInstanceOf <IsLessThan>();
        }

        [Fact]
        public void Apply_SetsStatusToDead_WhenCalled()
        {
            // Arrange
            CellInformation info = CreateCellInformation();
            SurvivorRule sut = CreateSut();

            // Act
            sut.Apply(info);

            // Assert
            info.Status.ShouldEqual(Cell.Status.Alive);
        }

        [Fact]
        public void Priority_ReturnsInteger_WhenCalled()
        {
            // Arrange
            CellInformation info = CreateCellInformation();
            SurvivorRule sut = CreateSut();

            // Act
            sut.Apply(info);

            // Assert
            sut.Priority.ShouldEqual(3);
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        public void IsValid_ReturnsTrueOrFalse_ForGivenNeighbours(int neighbours,
                                                                  bool expected)
        {
            // Arrange
            CellInformation info = CreateCellInformation(neighbours);
            SurvivorRule sut = CreateSut();
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

        private SurvivorRule CreateSut()
        {
            var survivorRule = new SurvivorRule();

            return survivorRule;
        }
    }
}