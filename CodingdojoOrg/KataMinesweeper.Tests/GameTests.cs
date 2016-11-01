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
    internal sealed class GameTests : TestFixtureBase <Game>
    {
        protected override void FreezeDependency()
        {
            Fixture.Freeze <IConsole>();
            Fixture.Freeze <IMineFieldManager>();
        }

        [Test]
        public void Initialize_CallsCreateMineField_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();

            // Act
            Sut.Initialize(1,
                           2,
                           3);

            // Assert
            manager.Received().CreateMineField(1,
                                               2,
                                               3);
        }

        [Test]
        public void Initialize_CallsDisplayPlayingField_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();

            // Act
            Sut.Initialize(1,
                           2,
                           3);

            // Assert
            manager.Received().DisplayPlayingField();
        }

        [Test]
        public void IsGameFinished_DisplayMessagePlayerWon_ForHasWon()
        {
            // Arrange
            var console = Fixture.Create <IConsole>();

            // Act
            Sut.IsGameFinished(GameStatus.Player.HasWon);

            // Assert
            console.Received().WriteLine(Arg.Any <string>());
        }

        [Test]
        public void IsGameFinished_DisplayMessagePlayerWon_ForPlayerSelectedMine()
        {
            // Arrange
            var console = Fixture.Create <IConsole>();

            // Act
            Sut.IsGameFinished(GameStatus.Player.SelectedFieldWithMine);

            // Assert
            console.Received().WriteLine(Arg.Any <string>());
        }

        [Test]
        public void IsGameFinished_DisplayMessagePlayerWon_ForPlayerSelectedWithoutMine()
        {
            // Arrange
            var console = Fixture.Create <IConsole>();

            // Act
            Sut.IsGameFinished(GameStatus.Player.SelectedFieldWithoutMine);

            // Assert
            console.DidNotReceive().WriteLine(Arg.Any <string>());
        }

        [Test]
        public void IsGameFinished_ReturnsFalse_ForPlayerSelectedFieldWithoutMine()
        {
            // Arrange
            // Act
            // Assert
            Assert.False(Sut.IsGameFinished(GameStatus.Player.SelectedFieldWithoutMine));
        }

        [Test]
        public void IsGameFinished_ReturnsTrue_ForPlayerHasWon()
        {
            // Arrange
            // Act
            // Assert
            Assert.True(Sut.IsGameFinished(GameStatus.Player.HasWon));
        }

        [Test]
        public void IsGameFinished_ReturnsTrue_ForPlayerSelectedMine()
        {
            // Arrange
            // Act
            // Assert
            Assert.True(Sut.IsGameFinished(GameStatus.Player.SelectedFieldWithMine));
        }

        [Test]
        public void PlayOneRound_CallsIsGameFinished_WhenPlayerWon()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();
            manager.AskUserForRowAndCoumn(Arg.Any <int>(),
                                          Arg.Any <int>()).Returns(new Tuple <int, int>(1,
                                                                                        2));

            // Act
            // Assert
            Assert.True(Sut.PlayOneRound()); // indirect test
        }

        [Test]
        public void PlayOneRound_DisplaysField_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();
            manager.AskUserForRowAndCoumn(Arg.Any <int>(),
                                          Arg.Any <int>()).Returns(new Tuple <int, int>(1,
                                                                                        2));

            // Act
            Sut.PlayOneRound();

            // Assert
            manager.Received().DisplayPlayingField();
        }

        [Test]
        public void PlayOneRound_GetsRowAndColumnFromConsole_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();
            manager.AskUserForRowAndCoumn(Arg.Any <int>(),
                                          Arg.Any <int>()).Returns(new Tuple <int, int>(1,
                                                                                        2));
            manager.RowsCount.Returns(2);
            manager.ColumsCount.Returns(3);

            // Act
            Sut.PlayOneRound();

            // Assert
            manager.Received().AskUserForRowAndCoumn(1,
                                                     2);
        }

        [Test]
        public void PlayOneRound_SelectsField_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();
            manager.AskUserForRowAndCoumn(Arg.Any <int>(),
                                          Arg.Any <int>()).Returns(new Tuple <int, int>(1,
                                                                                        2));

            // Act
            Sut.PlayOneRound();

            // Assert
            manager.Received().UserSelectedField(1,
                                                 2);
        }

        [Test]
        public void Start_CallsPlayOneRound_WhenCalled()
        {
            // Arrange
            var manager = Fixture.Create <IMineFieldManager>();
            manager.AskUserForRowAndCoumn(Arg.Any <int>(),
                                          Arg.Any <int>()).Returns(new Tuple <int, int>(1,
                                                                                        2));

            // Act
            Sut.Start();

            // Assert
            manager.Received().DisplayPlayingField(); // indirect test
        }
    }
}