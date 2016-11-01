using System.Diagnostics.CodeAnalysis;
using KataMinesweeper.Interfaces;
using NSubstitute;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace KataMinesweeper.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class DisplayPlayingFieldTests : TestFixtureBase <DisplayPlayingField>
    {
        protected override void FreezeDependency()
        {
            Fixture.Freeze <IHintField>();
            Fixture.Freeze <IPlayingField>();
        }

        private void ConfigurePlayingField_IsSelectedReturnsFalse()
        {
            var playingField = Fixture.Create <IPlayingField>();

            playingField.RowsCount.Returns(2);
            playingField.ColumnsCount.Returns(2);
            playingField.IsSelected(Arg.Any <int>(),
                                    Arg.Any <int>())
                        .Returns(false);
        }

        private void ConfigureHintField_GetHintForReturnsZero()
        {
            var hintField = Fixture.Create <IHintField>();

            hintField.GetHintFor(Arg.Any <int>(),
                                 Arg.Any <int>())
                     .Returns(0);
        }

        private void ConfigureHintField_WithTwoMines()
        {
            var hintField = Fixture.Create <IHintField>();

            hintField.GetHintFor(0,
                                 0)
                     .Returns(-1);
            hintField.GetHintFor(0,
                                 1)
                     .Returns(2);
            hintField.GetHintFor(1,
                                 0)
                     .Returns(2);
            hintField.GetHintFor(1,
                                 1)
                     .Returns(-1);
        }

        [Test]
        public void ToString_ReturnsString_ForNoneSelected()
        {
            // Arrange
            ConfigureHintField_GetHintForReturnsZero();
            ConfigurePlayingField_IsSelectedReturnsFalse();

            // Act
            string actual = Sut.ToString();

            // Assert
            Assert.AreEqual("..\r\n..\r\n",
                            actual);
        }

        [Test]
        [TestCase(0, 0, "*.\r\n..\r\n")]
        [TestCase(0, 1, ".2\r\n..\r\n")]
        [TestCase(1, 0, "..\r\n2.\r\n")]
        [TestCase(1, 1, "..\r\n.*\r\n")]
        public void ToString_ReturnsString_ForOneSelected(int row,
                                                          int column,
                                                          string expected)
        {
            // Arrange
            ConfigureHintField_WithTwoMines();
            ConfigurePlayingField_IsSelectedReturnsFalse();

            var playingField = Fixture.Create <IPlayingField>();
            playingField.IsSelected(row,
                                    column)
                        .Returns(true);

            // Act
            string actual = Sut.ToString();

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }
    }
}