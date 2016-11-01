using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using KataMinesweeper.Interfaces;
using NUnit.Framework;

namespace KataMinesweeper.Integreation.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class DisplayMineFieldTests
    {
        private readonly string m_NewLine = Environment.NewLine;

        private IMineField CreateEmptyMineField()
        {
            return new MineField(2,
                                 2);
        }

        private MineField CreateMineFieldWithMines()
        {
            var mineField = new MineField(2,
                                          2);

            mineField.PutMineAt(0,
                                0);
            mineField.PutMineAt(1,
                                1);

            return mineField;
        }

        private DisplayMineField CreateSut([NotNull] IMineField mineField)
        {
            return new DisplayMineField(mineField);
        }

        [Test]
        public void ToString_ReturnsMineFieldAsString_ForEmptyMineField()
        {
            // Arrange
            string expected = ".." +
                              m_NewLine +
                              ".." +
                              m_NewLine;
            IMineField mineField = CreateEmptyMineField();
            DisplayMineField sut = CreateSut(mineField);

            // Act
            string actual = sut.ToString();

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }

        [Test]
        public void ToString_ReturnsMineFieldAsString_ForMineFieldWithMines()
        {
            // Arrange
            string expected = "*." +
                              m_NewLine +
                              ".*" +
                              m_NewLine;
            MineField mineField = CreateMineFieldWithMines();
            DisplayMineField sut = CreateSut(mineField);

            // Act
            string actual = sut.ToString();

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }
    }
}