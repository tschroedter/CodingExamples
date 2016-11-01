using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;

namespace KataMinesweeper.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class MineFieldTests
    {
        private MineField CreateSut(int numberOfRows,
                                    int numberOfColumns)
        {
            return new MineField(numberOfRows,
                                 numberOfColumns);
        }

        private MineField CreateSutWithMines(int numberOfRows,
                                             int numberOfColumns)
        {
            var mineField = new MineField(numberOfRows,
                                          numberOfColumns);

            mineField.PutMineAt(0,
                                0);
            mineField.PutMineAt(1,
                                1);

            return mineField;
        }

        [Test]
        public void Constructor_CreatesFieldWithColumns_WhenCalled()
        {
            // Arrange
            MineField sut = CreateSut(1,
                                      2);

            // Act
            // Assert
            Assert.AreEqual(2,
                            sut.ColumnsCount);
        }

        [Test]
        public void Constructor_CreatesFieldWithRows_WhenCalled()
        {
            // Arrange
            MineField sut = CreateSut(1,
                                      2);

            // Act
            // Assert
            Assert.AreEqual(1,
                            sut.RowsCount);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        [TestCase(-1, -1)]
        public void Constructor_Throws_ForInvalidParameters(int rows,
                                                            int columns)
        {
            // Arrange
            // Act
            // Assert
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws <ArgumentException>(() => new MineField(rows,
                                                                  columns));
        }

        [Test]
        [TestCase(0, new[]
                     {
                         true,
                         false
                     })]
        [TestCase(1, new[]
                     {
                         false,
                         true
                     })]
        public void GetRowAt_PutsMineIntoField_AtGivenRowAndColumn(int row,
                                                                   bool[] expected)
        {
            // Arrange
            MineField sut = CreateSutWithMines(2,
                                               2);

            // Act
            IEnumerable <bool> actual = sut.GetRowAt(row);

            // Assert
            Assert.True(expected.SequenceEqual(actual));
        }


        [Test]
        [TestCase(-1)]
        [TestCase(3)]
        public void GetRowAt_Throws_ForInvalidParameters(int row)
        {
            // Arrange
            MineField sut = CreateSut(2,
                                      2);

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.GetRowAt(row));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        public void IsMineAt_PutsMineIntoField_AtGivenRowAndColumn(int row,
                                                                   int column)
        {
            // Arrange
            MineField sut = CreateSut(2,
                                      2);
            sut.PutMineAt(row,
                          column);

            // Act
            // Assert
            Assert.True(sut.IsMineAt(row,
                                     column));
        }

        [Test]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        [TestCase(2, 0)]
        [TestCase(0, 2)]
        [TestCase(2, 2)]
        public void IsMineAt_Throws_ForInvalidParameters(int row,
                                                         int column)
        {
            // Arrange
            MineField sut = CreateSut(2,
                                      2);

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.IsMineAt(row,
                                                                 column));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        public void PutMineAt_PutsMineIntoField_AtGivenRowAndColumn(int row,
                                                                    int column)
        {
            // Arrange
            MineField sut = CreateSut(2,
                                      2);

            // Act
            sut.PutMineAt(row,
                          column);

            // Assert
            Assert.True(sut.IsMineAt(row,
                                     column));
        }

        [Test]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        [TestCase(2, 0)]
        [TestCase(0, 2)]
        [TestCase(2, 2)]
        public void PutMineAt_Throws_ForInvalidParameters(int row,
                                                          int column)
        {
            // Arrange
            MineField sut = CreateSut(2,
                                      2);

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.PutMineAt(row,
                                                                  column));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        public void RemoveMineAt_PutsMineIntoField_AtGivenRowAndColumn(int row,
                                                                       int column)
        {
            // Arrange
            MineField sut = CreateSut(2,
                                      2);
            sut.PutMineAt(row,
                          column);

            // Act
            sut.RemoveMineAt(row,
                             column);

            // Assert
            Assert.False(sut.IsMineAt(row,
                                      column));
        }

        [Test]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        [TestCase(2, 0)]
        [TestCase(0, 2)]
        [TestCase(2, 2)]
        public void RemoveMineAt_Throws_ForInvalidParameters(int row,
                                                             int column)
        {
            // Arrange
            MineField sut = CreateSut(2,
                                      2);

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.RemoveMineAt(row,
                                                                     column));
        }

        [Test]
        public void Rows_ReturnsCorrectNumberOfRows_ForField()
        {
            // Arrange
            MineField sut = CreateSut(2,
                                      2);

            // Act
            IEnumerable <IEnumerable <bool>> actual = sut.Rows();

            // Assert
            Assert.AreEqual(2,
                            actual.Count());
        }

        [Test]
        public void Rows_ReturnsFirstRow_ForField()
        {
            // Arrange
            var expected = new[]
                           {
                               true,
                               false
                           };

            MineField sut = CreateSutWithMines(2,
                                               2);

            // Act
            IEnumerable <bool> actual = sut.Rows().First();

            // Assert
            Assert.True(expected.SequenceEqual(actual));
        }

        [Test]
        public void Rows_ReturnsLastRow_ForField()
        {
            // Arrange
            var expected = new[]
                           {
                               false,
                               true
                           };

            MineField sut = CreateSutWithMines(2,
                                               2);

            // Act
            IEnumerable <bool> actual = sut.Rows().Last();

            // Assert
            Assert.True(expected.SequenceEqual(actual));
        }
    }
}