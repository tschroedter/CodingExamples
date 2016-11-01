using System;
using System.Diagnostics.CodeAnalysis;
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
    internal sealed class NumberOfPointsViewModelTests
    {
        [SetUp]
        public void Setup()
        {
            m_Bus = Substitute.For <ISelkieInMemoryBus>();
            m_Manager = Substitute.For <ICommandManager>();
            m_Model = Substitute.For <INumberOfPointsModel>();
            m_Sut = new NumberOfPointsViewModel(m_Bus,
                                                m_Manager,
                                                m_Model);
        }

        private ISelkieInMemoryBus m_Bus;
        private ICommandManager m_Manager;
        private INumberOfPointsModel m_Model;
        private NumberOfPointsViewModel m_Sut;

        [Test]
        public void ApplyCommand_ReturnsInstance_WhenCalled()
        {
            // Arrange
            // Act
            // Assert
            Assert.NotNull(m_Sut.ApplyCommand);
        }

        [Test]
        public void CanExecuteApplyCommand_ReturnsTrue_WhenCalled()
        {
            // Arrange
            // Act
            // Assert
            Assert.True(m_Sut.CanExecuteApplyCommand());
        }

        [Test]
        public void Constructor_SendsNumberOfPointsRequestMessage_WhenCreated()
        {
            // Arrange
            // Act
            // Assert
            m_Bus.Received().PublishAsync(Arg.Any <NumberOfPointsRequestMessage>());
        }

        [Test]
        public void Constructor_SetsDefaultValueForNumberOfPoints_WhenCreated()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(1,
                            m_Sut.NumberOfPoints);
        }

        [Test]
        public void Constructor_SubscribeToNumberOfPointsChangedMessage_WhenCreated()
        {
            // Arrange
            // Act
            // Assert
            m_Bus.Received().SubscribeAsync(m_Sut.GetType().FullName,
                                            Arg.Any <Action <NumberOfPointsChangedMessage>>());
        }

        [Test]
        public void NumberOfPointsChangedHandler_SetsNumberOfPoints_ForMessage()
        {
            // Arrange
            var message = new NumberOfPointsChangedMessage
                          {
                              NumberOfPoints = 123
                          };

            // Act
            m_Sut.NumberOfPointsChangedHandler(message);

            // Assert
            Assert.AreEqual(123,
                            m_Sut.NumberOfPoints);
        }

        [Test]
        public void SendNumberOfPointsSetMessage_SendsMessage_WhenCalled()
        {
            // Arrange
            // Act
            m_Sut.SendNumberOfPointsSetMessage();

            // Assert
            m_Bus.Received().PublishAsync(Arg.Is <NumberOfPointsSetMessage>(x => x.NumberOfPoints == 1));
        }

        [Test]
        public void ShiftPointChangedMessage_DoesNotifyPropertyChangedForPropertyX_ForMessage()
        {
            // Arrange
            var test = new TestNotifyPropertyChanged(m_Sut,
                                                     "NumberOfPoints");

            var message = new NumberOfPointsChangedMessage
                          {
                              NumberOfPoints = 123
                          };

            // Act
            m_Sut.NumberOfPointsChangedHandler(message);

            // Assert
            Assert.True(test.IsExpectedNotified);
        }
    }
}