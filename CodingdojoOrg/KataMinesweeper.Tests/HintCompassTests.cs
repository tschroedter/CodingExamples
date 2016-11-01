using System.Diagnostics.CodeAnalysis;
using KataMinesweeper.Interfaces;
using NUnit.Framework;

namespace KataMinesweeper.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class HintCompassTests
    {
        private HintCompass CreateSut(IMineField mineField)
        {
            var compass = new HintCompass(mineField);

            return compass;
        }

        private IMineField CreateMineFieldWithTwoMines()
        {
            var mineField = new MineField(2,
                                          2);

            mineField.PutMineAt(0,
                                0);
            mineField.PutMineAt(1,
                                1);

            return mineField;
        }

        private IMineField CreateMineFieldWithOneMineInCentre()
        {
            var mineField = new MineField(3,
                                          3);

            mineField.PutMineAt(1,
                                1);

            return mineField;
        }

        private IMineField CreateMineFieldWith3x3AndMinesAroundCentre()
        {
            var mineField = new MineField(3,
                                          3);

            mineField.PutMineAt(0,
                                0);
            mineField.PutMineAt(0,
                                1);
            mineField.PutMineAt(0,
                                2);
            mineField.PutMineAt(1,
                                0);
            mineField.PutMineAt(1,
                                2);
            mineField.PutMineAt(2,
                                0);
            mineField.PutMineAt(2,
                                1);
            mineField.PutMineAt(2,
                                2);

            return mineField;
        }

        [Test]
        [TestCase(0, 0, HintCompass.Mine)]
        [TestCase(0, 1, 2)]
        [TestCase(1, 0, 2)]
        [TestCase(1, 1, HintCompass.Mine)]
        public void GetMineCountFor_ReturnsMineCount_For2x2AndTwoMines(int row,
                                                                       int column,
                                                                       int expected)
        {
            // Arrange
            IMineField mineField = CreateMineFieldWithTwoMines();
            HintCompass sut = CreateSut(mineField);

            // Act
            int actual = sut.GetMineCountFor(row,
                                             column);

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }

        [Test]
        [TestCase(0, 0, HintCompass.Mine)]
        [TestCase(0, 1, HintCompass.Mine)]
        [TestCase(0, 2, HintCompass.Mine)]
        [TestCase(1, 0, HintCompass.Mine)]
        [TestCase(1, 1, 8)]
        [TestCase(1, 2, HintCompass.Mine)]
        [TestCase(2, 0, HintCompass.Mine)]
        [TestCase(2, 1, HintCompass.Mine)]
        [TestCase(2, 2, HintCompass.Mine)]
        public void GetMineCountFor_ReturnsMineCount_For3x3AndMinesAroundCentre(int row,
                                                                                int column,
                                                                                int expected)
        {
            // Arrange
            IMineField mineField = CreateMineFieldWith3x3AndMinesAroundCentre();
            HintCompass sut = CreateSut(mineField);

            // Act
            int actual = sut.GetMineCountFor(row,
                                             column);

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }

        [Test]
        [TestCase(0, 0, 1)]
        [TestCase(0, 1, 1)]
        [TestCase(0, 2, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, HintCompass.Mine)]
        [TestCase(1, 2, 1)]
        [TestCase(2, 0, 1)]
        [TestCase(2, 1, 1)]
        [TestCase(2, 2, 1)]
        public void GetMineCountFor_ReturnsMineCount_For3x3AndOneMineInCentre(int row,
                                                                              int column,
                                                                              int expected)
        {
            // Arrange
            IMineField mineField = CreateMineFieldWithOneMineInCentre();
            HintCompass sut = CreateSut(mineField);

            // Act
            int actual = sut.GetMineCountFor(row,
                                             column);

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }
    }
}