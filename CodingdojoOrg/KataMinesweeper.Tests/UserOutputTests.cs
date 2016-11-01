using System.Diagnostics.CodeAnalysis;
using KataMinesweeper.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace KataMinesweeper.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class UserOutputTests
    {
        [SetUp]
        public void Setup()
        {
            m_Console = Substitute.For <IConsole>();
            m_DisplayPlayingFieldFactory = Substitute.For <IDisplayPlayingFieldFactory>();
            m_HintField = Substitute.For <IHintField>();
            m_PlayingField = Substitute.For <IPlayingField>();

            m_DisplayPlayingField = Substitute.For <IDisplayPlayingField>();
            m_DisplayPlayingFieldFactory.Create(Arg.Any <IHintField>(),
                                                Arg.Any <IPlayingField>())
                                        .Returns(m_DisplayPlayingField);
        }

        private IDisplayPlayingFieldFactory m_DisplayPlayingFieldFactory;
        private IHintField m_HintField;
        private IPlayingField m_PlayingField;
        private IConsole m_Console;
        private IDisplayPlayingField m_DisplayPlayingField;

        private IUserOutput CreateSut()
        {
            var sut = new UserOutput(m_Console,
                                     m_DisplayPlayingFieldFactory,
                                     m_HintField,
                                     m_PlayingField);

            return sut;
        }

        [Test]
        public void DisplayPlayingField_CallsConsole_WhenCalled()
        {
            // Arrange
            IUserOutput sut = CreateSut();

            // Act
            sut.DisplayPlayingField();

            // Assert
            m_Console.Received().WriteLine(Arg.Any <string>());
        }

        [Test]
        public void DisplayPlayingField_CallsConsoleForTitle_WhenCalled()
        {
            // Arrange
            IUserOutput sut = CreateSut();

            // Act
            sut.DisplayPlayingField();

            // Assert
            m_Console.Received().WriteLine("Minefield:");
        }

        [Test]
        public void DisplayPlayingField_CallsDisplayPlayingFieldField_WhenCalled()
        {
            // Arrange
            IUserOutput sut = CreateSut();

            // Act
            sut.DisplayPlayingField();

            // Assert
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            m_DisplayPlayingField.Received().ToString();
        }
    }
}