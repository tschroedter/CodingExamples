using System.Diagnostics.CodeAnalysis;
using KataMinesweeper.Interfaces;
using NUnit.Framework;
using Should;

namespace KataMinesweeper.Tests
{
    [ExcludeFromCodeCoverage]
    internal sealed class StringToMineFieldConverterTests
    {
        private readonly string m_MineFieldWithTwoMines = "*.\r\n" +
                                                          ".*";

        [Test]
        public void FunctionUnderTest_ExpectedResult_UnderCondition()
        {
            // Arrange
            StringToMineFieldConverter sut = CreateSut();

            // Act
            IMineField actual = sut.ToMineField(m_MineFieldWithTwoMines);

            // Assert
            actual.IsMineAt(0,
                            0).ShouldBeTrue("[0,0] Here should be a Mine");
            actual.IsMineAt(0,
                            1).ShouldBeFalse("[0,1] Here should not be a Mine");
            actual.IsMineAt(1,
                            0).ShouldBeFalse("[1,0] Here should not be a Mine");
            actual.IsMineAt(1,
                            1).ShouldBeTrue("[1,1] Here should be a Mine");
        }

        private StringToMineFieldConverter CreateSut()
        {
            return new StringToMineFieldConverter();
        }
    }
}