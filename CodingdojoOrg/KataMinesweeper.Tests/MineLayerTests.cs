using System.Diagnostics.CodeAnalysis;
using KataMinesweeper.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace KataMinesweeper.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class MineLayerTests
    {
        private MineLayer CreateSut(IRandom random,
                                    IMineField mineField)
        {
            return new MineLayer(random,
                                 mineField);
        }

        [Test]
        public void PutMinesAtRandomLocation_PutsMinesIntoMineField_WhenCalled()
        {
            // Arrange
            var random = Substitute.For <IRandom>();
            var mineField = Substitute.For <IMineField>();
            MineLayer sut = CreateSut(random,
                                      mineField);

            random.Next(Arg.Any <int>(),
                        Arg.Any <int>()).Returns(0,
                                                 0,
                                                 1,
                                                 1
                );

            // Act
            sut.PutMinesAtRandomLocation(2);

            // Assert
            mineField.Received().PutMineAt(0,
                                           0);
            mineField.Received().PutMineAt(1,
                                           1);
        }
    }
}