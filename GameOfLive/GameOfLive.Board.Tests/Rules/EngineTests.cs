using System.Collections.Generic;
using GameOfLive.Board.Rules;
using GameOfLive.Interfaces.Board;
using GameOfLive.Interfaces.Rules.Rules;
using JetBrains.Annotations;
using NSubstitute;
using Xunit.Extensions;

namespace GameOfLive.Board.Tests.Rules
{
    public sealed class EngineTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void ApplyRules_CallsClearConditions_WhenCalled([NotNull] IRule <ICellInformation> rule,
                                                               [NotNull] ICellInformation cell)
        {
            // Arrange
            var cells = new[]
                        {
                            cell
                        };

            Engine sut = CreateSut(rule);

            // Act
            sut.ApplyRules(cells);

            // Assert
            rule.Received().ClearConditions();
        }

        [Theory]
        [AutoNSubstituteData]
        public void ApplyRules_CallsInitialize_WhenCalled([NotNull] IRule <ICellInformation> rule,
                                                          [NotNull] ICellInformation cell)
        {
            // Arrange
            var cells = new[]
                        {
                            cell
                        };

            Engine sut = CreateSut(rule);

            // Act
            sut.ApplyRules(cells);

            // Assert
            rule.Received().Initialize(cell);
        }

        [Theory]
        [AutoNSubstituteData]
        public void ApplyRules_CallsApply_WhenCalled([NotNull] IRule <ICellInformation> rule,
                                                     [NotNull] ICellInformation cell)
        {
            // Arrange
            var cells = new[]
                        {
                            cell
                        };

            Engine sut = CreateSut(rule);

            // Act
            sut.ApplyRules(cells);

            // Assert
            rule.Received().Apply(cell);
        }

        [Theory]
        [AutoNSubstituteData]
        public void ApplyRules_CallsApplyOnlyOnes_WhenCalled([NotNull] IRule <ICellInformation> ruleOne,
                                                             [NotNull] IRule <ICellInformation> ruleTwo,
                                                             [NotNull] ICellInformation cell)
        {
            // Arrange
            var cells = new[]
                        {
                            cell
                        };

            ruleOne.Priority.Returns(1);
            ruleTwo.Priority.Returns(2);

            var rules = new[]
                        {
                            ruleOne,
                            ruleTwo
                        };

            Engine sut = CreateSut(rules);

            // Act
            sut.ApplyRules(cells);

            // Assert
            ruleOne.Received().Apply(cell);
            ruleTwo.DidNotReceive().Apply(cell);
        }

        private Engine CreateSut(IRule <ICellInformation> rule = null)
        {
            rule = rule ?? Substitute.For <IRule <ICellInformation>>();

            var rules = new[]
                        {
                            rule
                        };

            return CreateSut(rules);
        }

        private Engine CreateSut([NotNull] IEnumerable <IRule <ICellInformation>> rules)
        {
            var repository = Substitute.For <IRuleRepository>();
            repository.Rules.Returns(rules);

            return new Engine(repository);
        }
    }
}