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
    internal sealed class ShiftPointViewModelTests
    {
        [SetUp]
        public void Setup()
        {
            m_Bus = Substitute.For <ISelkieInMemoryBus>();
            m_Manager = Substitute.For <ICommandManager>();
            m_Model = Substitute.For <IShiftPointModel>();
            m_Sut = new ShiftPointViewModel(m_Bus,
                                            m_Manager,
                                            m_Model);
        }

        private const double Tolerance = 0.0001;

        private ISelkieInMemoryBus m_Bus;
        private ICommandManager m_Manager;
        private IShiftPointModel m_Model;
        private ShiftPointViewModel m_Sut;

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
        public void Constructor_SendsShiftPointRequestMessage_WhenCreated()
        {
            // Arrange
            // Act
            // Assert
            m_Bus.Received().PublishAsync(Arg.Any <ShiftPointRequestMessage>());
        }

        [Test]
        public void Constructor_SubscribeToShiftPointChangedMessage_WhenCreated()
        {
            // Arrange
            // Act
            // Assert
            m_Bus.Received().SubscribeAsync(m_Sut.GetType().FullName,
                                            Arg.Any <Action <ShiftPointChangedMessage>>());
        }

        [Test]
        public void SendBrowseRequestMessage_SendsMessage_WhenCalled()
        {
            // Arrange
            m_Sut.X = 1.0;
            m_Sut.Y = 2.0;
            m_Sut.Z = 3.0;

            // Act
            m_Sut.SendShiftPointSetMessage();

            // Assert
            m_Bus.Received().PublishAsync(Arg.Is <ShiftPointSetMessage>(x => Math.Abs(x.X - 1.0) < Tolerance &&
                                                                             Math.Abs(x.Y - 2.0) < Tolerance &&
                                                                             Math.Abs(x.Z - 3.0) < Tolerance));
        }

        [Test]
        public void ShiftPointChangedHandler_SetsX_ForMessage()
        {
            // Arrange
            var message = new ShiftPointChangedMessage
                          {
                              X = 1.0,
                              Y = 2.0,
                              Z = 3.0
                          };

            // Act
            m_Sut.ShiftPointChangedHandler(message);

            // Assert
            Assert.AreEqual(1.0,
                            m_Sut.X);
        }

        [Test]
        public void ShiftPointChangedHandler_SetsY_ForMessage()
        {
            // Arrange
            var message = new ShiftPointChangedMessage
                          {
                              X = 1.0,
                              Y = 2.0,
                              Z = 3.0
                          };

            // Act
            m_Sut.ShiftPointChangedHandler(message);

            // Assert
            Assert.AreEqual(2.0,
                            m_Sut.Y);
        }

        [Test]
        public void ShiftPointChangedHandler_SetsZ_ForMessage()
        {
            // Arrange
            var message = new ShiftPointChangedMessage
                          {
                              X = 1.0,
                              Y = 2.0,
                              Z = 3.0
                          };

            // Act
            m_Sut.ShiftPointChangedHandler(message);

            // Assert
            Assert.AreEqual(3.0,
                            m_Sut.Z);
        }

        [Test]
        public void ShiftPointChangedMessage_DoesNotifyPropertyChangedForPropertyX_ForMessage()
        {
            // Arrange
            var test = new TestNotifyPropertyChanged(m_Sut,
                                                     "X");

            var message = new ShiftPointChangedMessage();

            // Act
            m_Sut.ShiftPointChangedHandler(message);

            // Assert
            Assert.True(test.IsExpectedNotified);
        }

        [Test]
        public void ShiftPointChangedMessage_DoesNotifyPropertyChangedForPropertYX_ForMessage()
        {
            // Arrange
            var test = new TestNotifyPropertyChanged(m_Sut,
                                                     "Y");

            var message = new ShiftPointChangedMessage();

            // Act
            m_Sut.ShiftPointChangedHandler(message);

            // Assert
            Assert.True(test.IsExpectedNotified);
        }

        [Test]
        public void ShiftPointChangedMessage_DoesNotifyPropertyChangedForPropertyZ_ForMessage()
        {
            // Arrange
            var test = new TestNotifyPropertyChanged(m_Sut,
                                                     "Z");

            var message = new ShiftPointChangedMessage();

            // Act
            m_Sut.ShiftPointChangedHandler(message);

            // Assert
            Assert.True(test.IsExpectedNotified);
        }
    }
}