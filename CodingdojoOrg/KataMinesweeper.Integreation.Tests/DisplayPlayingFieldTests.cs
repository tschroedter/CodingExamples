using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using KataMinesweeper.Interfaces;
using NUnit.Framework;

namespace KataMinesweeper.Integreation.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class DisplayPlayingFieldTests
    {
        private readonly string m_SmallMineFieldWithTwoMines =
            "*.\r\n" +
            ".*";

        private PlayingField CreatePlayingField(IMineField mineField)
        {
            var field = new PlayingField(mineField);

            return field;
        }

        private IMineField CreateMineField([NotNull] string text)
        {
            var converter = new StringToMineFieldConverter();

            IMineField minefield = converter.ToMineField(text);

            return minefield;
        }

        private IHintField CreateHintField([NotNull] IMineField mineField)
        {
            var factory = new HintCompassFactory();
            var hintField = new HintField(factory,
                                          mineField);

            return hintField;
        }

        private DisplayPlayingField CreateSut([NotNull] IHintField hintField,
                                              [NotNull] IPlayingField playingField)
        {
            var sut = new DisplayPlayingField(hintField,
                                              playingField);

            return sut;
        }

        [Test]
        public void ToString_ReturnsString_ForNoneSelected()
        {
            // Arrange
            IMineField mineField = CreateMineField(m_SmallMineFieldWithTwoMines);
            IHintField hintField = CreateHintField(mineField);
            PlayingField playingField = CreatePlayingField(mineField);
            DisplayPlayingField sut = CreateSut(hintField,
                                                playingField);

            // Act
            string actual = sut.ToString();

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
            IMineField mineField = CreateMineField(m_SmallMineFieldWithTwoMines);
            IHintField hintField = CreateHintField(mineField);
            PlayingField playingField = CreatePlayingField(mineField);
            DisplayPlayingField sut = CreateSut(hintField,
                                                playingField);
            playingField.SelectField(row,
                                     column);

            // Act
            string actual = sut.ToString();

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }
    }

    internal sealed class HintCompassFactory : IHintCompassFactory
    {
        public IHintCompass Create(IMineField mineField)
        {
            return new HintCompass(mineField);
        }

        public void Release(IHintCompass hintCompass)
        {
        }
    }
}