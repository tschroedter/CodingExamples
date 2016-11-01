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
    internal sealed class UserInputTests
    {
        [SetUp]
        public void Setup()
        {
            m_Console = Substitute.For <IConsole>();
        }

        private IConsole m_Console;

        [Test]
        public void AskUserForRowAndCoumn_ReturnsRowAndColumn_ForValidRowAndColum()
        {
            // Arrange
            var sut = new UserInput(m_Console);

            m_Console.ReadLine().Returns("1,2");

            // Act
            Tuple <int, int> rowAndColumn = sut.AskUserForRowAndCoumn(2,
                                                                      3);

            // Assert
            Assert.AreEqual(1,
                            rowAndColumn.Item1,
                            "Row");
            Assert.AreEqual(2,
                            rowAndColumn.Item2,
                            "Column");
        }

        [Test]
        [TestCase("0,0", 0, 0)]
        [TestCase("1,2", 1, 2)]
        [TestCase("2,0", 2, 0)]
        [TestCase("0,2", 0, 2)]
        [TestCase("2,2", 2, 2)]
        [TestCase("3,2", -1, 2)]
        [TestCase("2,3", 2, -1)]
        [TestCase("3,3", -1, -1)]
        [TestCase("a,1", -1, 1)]
        [TestCase("1,a", 1, -1)]
        [TestCase("-1,-1", -1, -1)]
        public void ExtractRowAndColumn_ReturnsInvalid_ForInput([NotNull] string input,
                                                                int expectedRow,
                                                                int expectedColumn)
        {
            // Arrange
            var sut = new UserInput(m_Console);

            // Act
            Tuple <int, int> rowAndColumn = sut.ExtractRowAndColumn(input,
                                                                    2,
                                                                    2);

            // Assert
            Assert.AreEqual(expectedRow,
                            rowAndColumn.Item1,
                            "Row");

            Assert.AreEqual(expectedColumn,
                            rowAndColumn.Item2,
                            "Column");
        }
    }
}