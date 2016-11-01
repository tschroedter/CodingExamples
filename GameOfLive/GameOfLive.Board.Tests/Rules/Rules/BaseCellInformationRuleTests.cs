using System.Linq;
using GameOfLive.Board.Board;
using GameOfLive.Board.Rules.Rules;
using GameOfLive.Interfaces.Board;
using GameOfLive.Interfaces.Rules.Conditions;
using NSubstitute;
using Xunit;
using XunitShould;

namespace GameOfLive.Board.Tests.Rules.Rules
{
    public sealed class BaseCellInformationRuleTests
    {
        [Fact]
        public void Conditions_ReturnsEmpty_ByDefault()
        {
            // Arrange
            // Act
            TestRule sut = CreateSut();

            // Assert
            sut.GetConditions().Count().ShouldEqual(0);
        }

        [Fact]
        public void Initialize_AddsConditions_WhenCalled()
        {
            // Arrange
            CellInformation info = CreateCellInformation();
            TestRule sut = CreateSut();

            // Act
            sut.Initialize(info);

            // Assert
            sut.GetConditions().Count().ShouldEqual(2);
        }

        [Fact]
        public void ClearConditions_ClearsCondintions_WhenCalled()
        {
            // Arrange
            CellInformation info = CreateCellInformation();
            TestRule sut = CreateSut();
            sut.Initialize(info);

            // Act
            sut.ClearConditions();

            // Assert
            sut.GetConditions().Count().ShouldEqual(0);
        }

        [Fact]
        public void Initialize_CallsInitialize_WhenCalled()
        {
            // Arrange
            CellInformation info = CreateCellInformation();
            TestRule sut = CreateSut();

            // Act
            sut.Initialize(info);

            // Assert
            sut.WasCalledInitialize.ShouldBeTrue();
        }

        [Fact]
        public void Apply_CallsApply_WhenCalled()
        {
            // Arrange
            CellInformation info = CreateCellInformation();
            TestRule sut = CreateSut();

            // Act
            sut.Apply(info);

            // Assert
            sut.WasCalledApply.ShouldBeTrue();
        }

        [Fact]
        public void Priority_ReturnsInteger_WhenCalled()
        {
            // Arrange
            CellInformation info = CreateCellInformation();
            TestRule sut = CreateSut();

            // Act
            sut.Apply(info);

            // Assert
            sut.Priority.ShouldEqual(1);
        }

        private CellInformation CreateCellInformation()
        {
            return new CellInformation
                   {
                       RowIndex = 0,
                       ColumnIndex = 0,
                       Status = Cell.Status.Alive
                   };
        }

        private TestRule CreateSut()
        {
            var testRule = new TestRule();

            return testRule;
        }

        private sealed class TestRule : BaseCellInformationRule
        {
            public bool WasCalledInitialize { get; private set; }

            public bool WasCalledApply { get; private set; }

            public override void Initialize(ICellInformation info)
            {
                Conditions.Add(Substitute.For <ICondition>());
                Conditions.Add(Substitute.For <ICondition>());

                WasCalledInitialize = true;
            }

            public override ICellInformation Apply(ICellInformation info)
            {
                WasCalledApply = true;

                return info;
            }

            public override int GetPriority()
            {
                return 1;
            }
        }
    }
}