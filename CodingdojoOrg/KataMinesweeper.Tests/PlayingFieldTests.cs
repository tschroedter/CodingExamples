using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using KataMinesweeper.Interfaces;
using NUnit.Framework;

namespace KataMinesweeper.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class PlayingFieldTests
    {
        private readonly string m_MineFieldWithDifferentRowColumnCount =
            "*.\r\n" +
            ".*\r\n" +
            ".*";

        private readonly string m_SmallMineFieldWithTwoMines =
            "*.\r\n" +
            ".*";

        private readonly string m_MineFieldWithTwoMines =
            "*...\r\n" +
            "....\r\n" +
            ".*..\r\n" +
            "....";

        private PlayingField CreateSut(IMineField mineField)
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

        [Test]
        public void ColumnsCount_ReturnsCount_ForMineField()
        {
            // Arrange
            IMineField mineField = CreateMineField(m_MineFieldWithDifferentRowColumnCount);
            PlayingField sut = CreateSut(mineField);

            // Act
            // Assert
            Assert.AreEqual(2,
                            sut.ColumnsCount);
        }

        [Test]
        public void CreateMineField_SetStatus_WhenCalled()
        {
            // Arrange
            IMineField mineField = CreateMineField(m_MineFieldWithTwoMines);
            PlayingField sut = CreateSut(mineField);

            // Act
            // Assert
            Assert.AreEqual(GameStatus.Player.SelectedFieldWithoutMine,
                            sut.Status);
        }

        [Test]
        public void HasPlayerWon_ReturnsFalse_ForNoneSelected()
        {
            // Arrange
            IMineField mineField = CreateMineField(m_SmallMineFieldWithTwoMines);
            PlayingField sut = CreateSut(mineField);

            // Act
            bool actual = sut.HasPlayerWon();

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void HasPlayerWon_ReturnsFalse_ForOnlyOneSelected()
        {
            // Arrange
            IMineField mineField = CreateMineField(m_SmallMineFieldWithTwoMines);
            PlayingField sut = CreateSut(mineField);
            sut.SelectField(0,
                            0);

            // Act
            bool actual = sut.HasPlayerWon();

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void HasPlayerWon_ReturnsTrue_ForAllSelected()
        {
            // Arrange
            IMineField mineField = CreateMineField(m_SmallMineFieldWithTwoMines);
            PlayingField sut = CreateSut(mineField);
            sut.SelectField(0,
                            1);
            sut.SelectField(1,
                            0);

            // Act
            bool actual = sut.HasPlayerWon();

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void RowsCount_ReturnsCount_ForMineField()
        {
            // Arrange
            IMineField mineField = CreateMineField(m_MineFieldWithDifferentRowColumnCount);
            PlayingField sut = CreateSut(mineField);

            // Act
            // Assert
            Assert.AreEqual(3,
                            sut.RowsCount);
        }

        [Test]
        public void SelectedField_DoesNotUpdateStatusByDefault_WhenCalled()
        {
            // Arrange
            IMineField mineField = CreateMineField(m_MineFieldWithTwoMines);
            PlayingField sut = CreateSut(mineField);

            // Act
            sut.SelectField(1,
                            2);

            // Assert
            Assert.AreEqual(GameStatus.Player.SelectedFieldWithoutMine,
                            sut.Status);
        }

        [Test]
        [TestCase(0, 0, true)]
        [TestCase(1, 1, true)]
        [TestCase(2, 2, true)]
        [TestCase(3, 3, true)]
        public void SelectField_MarksFieldAsSelected_ForRowAndColumn(int row,
                                                                     int column,
                                                                     bool expected)
        {
            // Arrange
            IMineField mineField = CreateMineField(m_MineFieldWithTwoMines);
            PlayingField sut = CreateSut(mineField);

            // Act
            sut.SelectField(row,
                            column);

            // Assert
            Assert.AreEqual(expected,
                            sut.IsSelected(row,
                                           column));
        }

        [Test]
        public void UserSelectedField_SetsStatusToSelectedFieldWithMine_WhenSelectedFieldWithMine()
        {
            // Arrange
            IMineField mineField = CreateMineField(m_SmallMineFieldWithTwoMines);
            PlayingField sut = CreateSut(mineField);

            // Act
            sut.SelectField(1,
                            1);

            // Assert
            Assert.AreEqual(GameStatus.Player.SelectedFieldWithMine,
                            sut.Status);
        }

        [Test]
        public void UserSelectedField_UpdatesStatus_WhenPlayerHasWon()
        {
            // Arrange
            IMineField mineField = CreateMineField(m_SmallMineFieldWithTwoMines);
            PlayingField sut = CreateSut(mineField);
            sut.SelectField(0,
                            1);

            // Act
            sut.SelectField(1,
                            0);

            // Assert
            Assert.AreEqual(GameStatus.Player.HasWon,
                            sut.Status);
        }
    }
}