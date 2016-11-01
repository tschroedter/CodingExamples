using System;
using System.Diagnostics.CodeAnalysis;
using KataMinesweeper.Interfaces;
using NSubstitute;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace KataMinesweeper.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class DisplayMineFieldTests : TestFixtureBase <DisplayMineField>
    {
        private readonly string m_NewLine = Environment.NewLine;

        protected override void FreezeDependency()
        {
            Fixture.Freeze <IMineField>();
        }

        private static bool[][] CreateRows()
        {
            return new[]
                   {
                       new[]
                       {
                           true,
                           false
                       },
                       new[]
                       {
                           false,
                           true
                       }
                   };
        }

        [Test]
        public void ToString_ReturnsMineFieldAsString_ForEmptyMineField()
        {
            // Arrange
            var mineField = Fixture.Create <IMineField>();
            mineField.Rows().Returns(CreateRows());

            string expected = "*." +
                              m_NewLine +
                              ".*" +
                              m_NewLine;

            // Act
            string actual = Sut.ToString();

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }
    }
}