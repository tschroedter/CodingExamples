using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;

namespace KataMinesweeper.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class FieldTests
    {
        private Field <bool> CreateSut(int numberOfRows,
                                       int numberOfColumns)
        {
            var sut = new Field <bool>(numberOfRows,
                                       numberOfColumns);

            return sut;
        }

        [Test]
        public void ColumnsCount_ReturnsColumnsCount_ForField()
        {
            // Arrange
            Field <bool> sut = CreateSut(2,
                                         3);

            // Act
            // Assert
            Assert.AreEqual(2,
                            sut.RowsCount);
        }

        [Test]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        public void Constructor_Throws_ForInvalidParameters(int row,
                                                            int column)
        {
            // Arrange
            // Act
            // Assert
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws <ArgumentException>(() => new Field <bool>(row,
                                                                     column));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(3)]
        public void GetRowAt_Throws_ForInvalidParameters(int row)
        {
            // Arrange
            Field <bool> sut = CreateSut(2,
                                         2);

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.GetRowAt(row));
        }

        [Test]
        [TestCase(0, 0, true)]
        [TestCase(0, 1, true)]
        [TestCase(1, 0, true)]
        [TestCase(1, 1, true)]
        public void Indexer_ReturnsValue_ForRowAndColumn(int row,
                                                         int column,
                                                         bool expected)
        {
            // Arrange
            Field <bool> sut = CreateSut(2,
                                         2);

            // Act
            sut [ row,
                  column ] = expected;

            bool actual = sut [ row,
                                column ];

            // Assert
            Assert.AreEqual(expected,
                            actual);
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
            Field <bool> sut = CreateSut(2,
                                         2);

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.CheckIndexes(row,
                                                                     column));
        }

        [Test]
        public void Rows_ReturnsCorrectNumberOfRows_ForField()
        {
            // Arrange
            Field <bool> sut = CreateSut(2,
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

            Field <bool> sut = CreateSut(2,
                                         2);

            sut [ 0,
                  0 ] = true;

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

            Field <bool> sut = CreateSut(2,
                                         2);

            sut [ 1,
                  1 ] = true;

            // Act
            IEnumerable <bool> actual = sut.Rows().Last();

            // Assert
            Assert.True(expected.SequenceEqual(actual));
        }

        [Test]
        public void RowsCount_ReturnsRowCount_ForField()
        {
            // Arrange
            Field <bool> sut = CreateSut(2,
                                         3);

            // Act
            // Assert
            Assert.AreEqual(3,
                            sut.ColumnsCount);
        }
    }
}