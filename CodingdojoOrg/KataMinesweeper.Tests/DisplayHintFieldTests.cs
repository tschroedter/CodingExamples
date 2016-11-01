using System.Diagnostics.CodeAnalysis;
using KataMinesweeper.Interfaces;
using NSubstitute;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace KataMinesweeper.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class DisplayHintFieldTests : TestFixtureBase <DisplayHintField>
    {
        protected override void FreezeDependency()
        {
            Fixture.Freeze <IHintField>();
        }

        [Test]
        public void ToString_ReturnsString_ForMineField()
        {
            // Arrange
            var hintField = Fixture.Create <IHintField>();
            hintField.RowsCount.Returns(2);
            hintField.ColumnCount.Returns(2);
            hintField.GetHintFor(Arg.Any <int>(),
                                 Arg.Any <int>()).Returns(0);

            // Act
            string actual = Sut.ToString();

            // Assert
            Assert.AreEqual("00\r\n00\r\n",
                            actual);
        }
    }
}