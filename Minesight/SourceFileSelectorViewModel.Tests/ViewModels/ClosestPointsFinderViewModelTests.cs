using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Evaluation.Wpf.Application.Common.Interfaces;
using Evaluation.Wpf.Application.Models.Interfaces;
using Evaluation.Wpf.Application.Models.Messages;
using Evaluation.Wpf.Application.ViewModels;
using Evaluation.Wpf.Application.ViewModels.Interfaces;
using NSubstitute;
using NUnit.Framework;
using Selkie.EasyNetQ;

namespace Evaluation.Wpf.Application.Tests.ViewModels
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class ClosestPointsFinderViewModelTests
    {
        [SetUp]
        public void Setup()
        {
            m_SettingsManager = Substitute.For <ISettingsManager>();
            m_Bus = Substitute.For <ISelkieInMemoryBus>();
            m_Manager = Substitute.For <ICommandManager>();
            m_Model = Substitute.For <IClosestPointsFinderModel>();
            m_Sut = new ClosestPointsFinderViewModel(m_Bus,
                                                     m_Manager,
                                                     m_SettingsManager,
                                                     m_Model);
        }

        private ISelkieInMemoryBus m_Bus;
        private ICommandManager m_Manager;
        private IClosestPointsFinderModel m_Model;
        private ClosestPointsFinderViewModel m_Sut;
        private ISettingsManager m_SettingsManager;

        [Test]
        public void CalculateCommand_ReturnsInstance_WhenCalled()
        {
            // Arrange
            // Act
            // Assert
            Assert.NotNull(m_Sut.CalculateCommand);
        }

        [Test]
        public void CanExecuteCalculateCommand_ReturnsTrue_WhenCalled()
        {
            // Arrange
            // Act
            // Assert
            Assert.True(m_Sut.CanExecuteCalculateCommand());
        }

        [Test]
        public void ClosestIdsChangeHandler_DoesNotifyPropertyChangedForPropertyX_ForMessage()
        {
            // Arrange
            var test = new TestNotifyPropertyChanged(m_Sut,
                                                     "ClosestPointIds");

            var message = new ClosestIdsChangedMessage
                          {
                              ClosestPointIds = new int[0]
                          };

            // Act
            m_Sut.ClosestIdsChangeHandler(message);

            // Assert
            Assert.True(test.IsExpectedNotified);
        }

        [Test]
        public void ClosestIdsChangeHandler_SetsClosestIds_ForMessage()
        {
            // Arrange
            var expected = new[]
                           {
                               1,
                               2,
                               3
                           };

            var message = new ClosestIdsChangedMessage
                          {
                              ClosestPointIds = expected
                          };

            // Act
            m_Sut.ClosestIdsChangeHandler(message);

            // Assert
            Assert.True(expected.SequenceEqual(m_Sut.ClosestPointIds));
        }

        [Test]
        public void Constructor_SendsNumberOfPointsRequestMessage_WhenCreated()
        {
            // Arrange
            // Act
            // Assert
            m_Bus.Received().PublishAsync(Arg.Any <ClosestIdsRequestMessage>());
        }

        [Test]
        public void Constructor_SubscribeToNumberOfPointsChangedMessage_WhenCreated()
        {
            // Arrange
            // Act
            // Assert
            m_Bus.Received().SubscribeAsync(m_Sut.GetType().FullName,
                                            Arg.Any <Action <ClosestIdsChangedMessage>>());
        }

        [Test]
        public void SendQueryPointSetMessage_SendsMessage_WhenCalled()
        {
            // Arrange
            // Act
            m_Sut.SendClosestIdsCalculateMessage();

            // Assert
            m_Bus.Received().PublishAsync(Arg.Any <ClosestIdsCalculateMessage>());
        }
    }
}