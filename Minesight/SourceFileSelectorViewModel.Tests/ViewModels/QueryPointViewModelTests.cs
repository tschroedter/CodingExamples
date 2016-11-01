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
    internal sealed class QueryPointViewModelTests
    {
        [SetUp]
        public void Setup()
        {
            m_Bus = Substitute.For <ISelkieInMemoryBus>();
            m_Manager = Substitute.For <ICommandManager>();
            m_Model = Substitute.For <IQueryPointModel>();
            m_Sut = new QueryPointViewModel(m_Bus,
                                            m_Manager,
                                            m_Model);
        }

        private const double Tolerance = 0.0001;

        private ISelkieInMemoryBus m_Bus;
        private ICommandManager m_Manager;
        private IQueryPointModel m_Model;
        private QueryPointViewModel m_Sut;

        [Test]
        public void BrowseCommand_ReturnsInstance_WhenCalled()
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
            Assert.True(m_Sut.CanExecuteBrowseCommand());
        }

        [Test]
        public void Constructor_SendsQueryPointRequestMessage_WhenCreated()
        {
            // Arrange
            // Act
            // Assert
            m_Bus.Received().PublishAsync(Arg.Any <QueryPointRequestMessage>());
        }

        [Test]
        public void Constructor_SubscribeToQueryPointChangedMessage_WhenCreated()
        {
            // Arrange
            // Act
            // Assert
            m_Bus.Received().SubscribeAsync(m_Sut.GetType().FullName,
                                            Arg.Any <Action <QueryPointChangedMessage>>());
        }

        [Test]
        public void QueryPointChangedHandler_SetsX_ForMessage()
        {
            // Arrange
            var message = new QueryPointChangedMessage
                          {
                              X = 1.0,
                              Y = 2.0,
                              Z = 3.0
                          };

            // Act
            m_Sut.QueryPointChangedHandler(message);

            // Assert
            Assert.AreEqual(1.0,
                            m_Sut.X);
        }

        [Test]
        public void QueryPointChangedHandler_SetsY_ForMessage()
        {
            // Arrange
            var message = new QueryPointChangedMessage
                          {
                              X = 1.0,
                              Y = 2.0,
                              Z = 3.0
                          };

            // Act
            m_Sut.QueryPointChangedHandler(message);

            // Assert
            Assert.AreEqual(2.0,
                            m_Sut.Y);
        }

        [Test]
        public void QueryPointChangedHandler_SetsZ_ForMessage()
        {
            // Arrange
            var message = new QueryPointChangedMessage
                          {
                              X = 1.0,
                              Y = 2.0,
                              Z = 3.0
                          };

            // Act
            m_Sut.QueryPointChangedHandler(message);

            // Assert
            Assert.AreEqual(3.0,
                            m_Sut.Z);
        }

        [Test]
        public void QueryPointChangedMessage_DoesNotifyPropertyChangedForPropertyX_ForMessage()
        {
            // Arrange
            var test = new TestNotifyPropertyChanged(m_Sut,
                                                     "X");

            var message = new QueryPointChangedMessage();

            // Act
            m_Sut.QueryPointChangedHandler(message);

            // Assert
            Assert.True(test.IsExpectedNotified);
        }

        [Test]
        public void QueryPointChangedMessage_DoesNotifyPropertyChangedForPropertYX_ForMessage()
        {
            // Arrange
            var test = new TestNotifyPropertyChanged(m_Sut,
                                                     "Y");

            var message = new QueryPointChangedMessage();

            // Act
            m_Sut.QueryPointChangedHandler(message);

            // Assert
            Assert.True(test.IsExpectedNotified);
        }

        [Test]
        public void QueryPointChangedMessage_DoesNotifyPropertyChangedForPropertyZ_ForMessage()
        {
            // Arrange
            var test = new TestNotifyPropertyChanged(m_Sut,
                                                     "Z");

            var message = new QueryPointChangedMessage();

            // Act
            m_Sut.QueryPointChangedHandler(message);

            // Assert
            Assert.True(test.IsExpectedNotified);
        }

        [Test]
        public void SendBrowseRequestMessage_SendsMessage_WhenCalled()
        {
            // Arrange
            m_Sut.X = 1.0;
            m_Sut.Y = 2.0;
            m_Sut.Z = 3.0;

            // Act
            m_Sut.SendQueryPointSetMessage();

            // Assert
            m_Bus.Received().PublishAsync(Arg.Is <QueryPointSetMessage>(x => Math.Abs(x.X - 1.0) < Tolerance &&
                                                                             Math.Abs(x.Y - 2.0) < Tolerance &&
                                                                             Math.Abs(x.Z - 3.0) < Tolerance));
        }
    }
}