using System;
using System.Diagnostics.CodeAnalysis;
using Evaluation.Wpf.Application.Models.Interfaces;
using Evaluation.Wpf.Application.Models.Messages;
using Evaluation.Wpf.Application.ViewModels;
using Evaluation.Wpf.Application.ViewModels.Interfaces;
using Evaluation.Wpf.Application.ViewModels.Messages;
using NSubstitute;
using NUnit.Framework;
using Selkie.EasyNetQ;

namespace Evaluation.Wpf.Application.Tests.ViewModels
{
    // todo AutoNSubstituteDataAttribute for all tests
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class SourceFileSelectorViewModelTests
    {
        [SetUp]
        public void Setup()
        {
            m_Bus = Substitute.For <ISelkieInMemoryBus>();
            m_Manager = Substitute.For <ICommandManager>();
            m_Model = Substitute.For <ISourceFileSelectorModel>();
            m_Sut = new SourceFileSelectorViewModel(m_Bus,
                                                    m_Manager,
                                                    m_Model);
        }

        private ISelkieInMemoryBus m_Bus;
        private ICommandManager m_Manager;
        private ISourceFileSelectorModel m_Model;
        private SourceFileSelectorViewModel m_Sut;

        [Test]
        public void BrowseCommand_ReturnsInstance_WhenCalled()
        {
            // Arrange
            // Act
            // Assert
            Assert.NotNull(m_Sut.BrowseCommand);
        }

        [Test]
        public void CanExecuteApplyCommand_ReturnsTrue_WhenCalled()
        {
            // Arrange
            // Act
            // Assert
            Assert.True(m_Sut.CanExecuteBrowseCommand());
        }

        [Test]
        public void Constructor_SendsFilenameRequestMessage_WhenCreated()
        {
            // Arrange
            // Act
            // Assert
            m_Bus.Received().PublishAsync(Arg.Any <FilenameRequestMessage>());
        }

        [Test]
        public void Constructor_SubscribeToFilenameChangedMessage_WhenCreated()
        {
            // Arrange
            // Act
            // Assert
            m_Bus.Received().SubscribeAsync(m_Sut.GetType().FullName,
                                            Arg.Any <Action <FilenameChangedMessage>>());
        }

        [Test]
        public void Constructor_SubscribeToShowBrowseDialogMessage_WhenCreated()
        {
            // Arrange
            // Act
            // Assert
            m_Bus.Received().SubscribeAsync(m_Sut.GetType().FullName,
                                            Arg.Any <Action <ShowBrowseDialogMessage>>());
        }

        [Test]
        public void Filename_ReturnsDefaultValue_AfterCreation()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual("Please select a source file...",
                            m_Sut.Filename);
        }

        [Test]
        public void FilenameChangedHandler_DoesNotifyPropertyChanged_ForMessage()
        {
            // Arrange
            var test = new TestNotifyPropertyChanged(m_Sut,
                                                     "Filename");

            var message = new FilenameChangedMessage();

            // Act
            m_Sut.FilenameChangedHandler(message);

            // Assert
            Assert.True(test.IsExpectedNotified);
        }

        [Test]
        public void FilenameChangedHandler_SetsFilename_ForMessage()
        {
            // Arrange
            var message = new FilenameChangedMessage
                          {
                              Filename = "Test.txt"
                          };

            // Act
            m_Sut.FilenameChangedHandler(message);

            // Assert
            Assert.AreEqual("Test.txt",
                            m_Sut.Filename);
        }

        [Test]
        public void SendBrowseRequestMessage_SendsMessage_WhenCalled()
        {
            // Arrange
            // Act
            m_Sut.SendBrowseRequestMessage();

            // Assert
            m_Bus.Received().PublishAsync(Arg.Any <BrowseRequestMessage>());
        }

        [Test]
        public void Update_CallsInvalidateRequerySuggested_WhenCalled()
        {
            // Arrange
            // Act
            m_Sut.Update();

            // Assert
            m_Manager.Received().InvalidateRequerySuggested();
        }

        [Test]
        public void Update_DoesNotifyPropertyChanged_ForFilename()
        {
            // Arrange
            var test = new TestNotifyPropertyChanged(m_Sut,
                                                     "Filename");

            // Act
            m_Sut.Update();

            // Assert
            Assert.True(test.IsExpectedNotified);
        }
    }
}