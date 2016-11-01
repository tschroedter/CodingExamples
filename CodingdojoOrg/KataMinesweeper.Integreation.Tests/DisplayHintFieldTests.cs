using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using KataMinesweeper.Interfaces;
using NUnit.Framework;

namespace KataMinesweeper.Integreation.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class DisplayHintFieldTests : IntegrationTestBase
    {
        private readonly string m_MineFieldWithTwoMines =
            "*...\r\n" +
            "....\r\n" +
            ".*..\r\n" +
            "....";

        private readonly string m_HintFieldWithTwoMines =
            "*100\r\n" +
            "2210\r\n" +
            "1*10\r\n" +
            "1110\r\n";

        private IMineField CreateMineField([NotNull] string text)
        {
            var converter = new StringToMineFieldConverter();

            IMineField minefield = converter.ToMineField(text);

            return minefield;
        }

        private DisplayHintField CreateSut(IMineField mineField)
        {
            var factory = Container.Resolve <IHintFieldFactory>();
            IHintField hintField = factory.Create(mineField);
            var displayHintField = new DisplayHintField(hintField);

            return displayHintField;
        }

        [Test]
        public void ToString_ReturnsString_ForMineField()
        {
            // Arrange
            IMineField mineField = CreateMineField(m_MineFieldWithTwoMines);
            DisplayHintField sut = CreateSut(mineField);

            // Act
            string actual = sut.ToString();

            // Assert
            Assert.AreEqual(m_HintFieldWithTwoMines,
                            actual);
        }
    }
}