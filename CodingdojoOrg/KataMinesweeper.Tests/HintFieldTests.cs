using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using KataMinesweeper.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace KataMinesweeper.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class HintFieldTests
    {
        private readonly string m_MineFieldWithTwoMines =
            "*...\r\n" +
            "....\r\n" +
            ".*..\r\n" +
            "....";

        private IMineField CreateMineField([NotNull] string text)
        {
            var converter = new StringToMineFieldConverter();

            IMineField minefield = converter.ToMineField(text);

            return minefield;
        }

        private HintField CreateSut(IMineField mineField)
        {
            var hintCompass = new HintCompass(mineField); // todo replace with Substitute?
            var factory = Substitute.For <IHintCompassFactory>();
            factory.Create(Arg.Any <IMineField>())
                   .Returns(hintCompass);

            var hintField = new HintField(factory,
                                          mineField);

            return hintField;
        }

        [Test]
        public void ColumnsCount_ReturnsColumnsCount_ForHintField()
        {
            // Arrange
            IMineField field = CreateMineField(m_MineFieldWithTwoMines);
            HintField sut = CreateSut(field);

            // Act
            // Assert
            Assert.AreEqual(4,
                            sut.RowsCount);
        }

        [Test]
        [TestCase(0, 0, -1)]
        [TestCase(0, 1, 1)]
        [TestCase(0, 2, 0)]
        [TestCase(0, 3, 0)]
        [TestCase(1, 0, 2)]
        [TestCase(1, 1, 2)]
        [TestCase(1, 2, 1)]
        [TestCase(1, 3, 0)]
        [TestCase(2, 0, 1)]
        [TestCase(2, 1, -1)]
        [TestCase(2, 2, 1)]
        [TestCase(2, 3, 0)]
        [TestCase(3, 0, 1)]
        [TestCase(3, 1, 1)]
        [TestCase(3, 2, 1)]
        [TestCase(3, 3, 0)]
        public void GetHintFor_ReturnsHintNumber_ForRowAndColumn(int row,
                                                                 int column,
                                                                 int expected)
        {
            // Arrange
            IMineField mineField = CreateMineField(m_MineFieldWithTwoMines);
            HintField sut = CreateSut(mineField);

            // Act
            int actual = sut.GetHintFor(row,
                                        column);

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }

        [Test]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        [TestCase(4, 0)]
        [TestCase(0, 4)]
        [TestCase(4, 4)]
        public void GetHintFor_Throws_ForInvalidRowAndColumn(int row,
                                                             int column)
        {
            // Arrange
            IMineField mineField = CreateMineField(m_MineFieldWithTwoMines);
            HintField sut = CreateSut(mineField);

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.GetHintFor(row,
                                                                   column));
        }

        [Test]
        public void RowsCount_ReturnsRowsCount_ForHintField()
        {
            // Arrange
            IMineField field = CreateMineField(m_MineFieldWithTwoMines);
            HintField sut = CreateSut(field);

            // Act
            // Assert
            Assert.AreEqual(4,
                            sut.RowsCount);
        }
    }
}