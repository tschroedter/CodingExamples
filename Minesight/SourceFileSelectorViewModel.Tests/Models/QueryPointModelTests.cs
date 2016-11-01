using System;
using System.Diagnostics.CodeAnalysis;
using Evaluation.Wpf.Application.Models;
using Evaluation.Wpf.Application.Models.Messages;
using JetBrains.Annotations;
using NSubstitute;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit2;
using Selkie.EasyNetQ;

namespace Evaluation.Wpf.Application.Tests.Models
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class QueryPointModelTests
    {
        private const double Tolerance = 0.0001;

        private void SetXyzValues(
            [NotNull] QueryPointModel model,
            double x,
            double y,
            double z)
        {
            var setMessage = new QueryPointSetMessage
                             {
                                 X = x,
                                 Y = y,
                                 Z = z
                             };

            model.QueryPointSetHandler(setMessage);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Constructor_SubscribeToQueryPointRequestMessage_WhenCreated(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] QueryPointModel sut)
        {
            // Arrange
            // Act
            // Assert
            bus.Received().SubscribeAsync(sut.GetType().FullName,
                                          Arg.Any <Action <QueryPointRequestMessage>>());
        }

        [Theory]
        [AutoNSubstituteData]
        public void Constructor_SubscribeToQueryPointSetMessage_WhenCreated(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] QueryPointModel sut)
        {
            // Arrange
            // Act
            // Assert
            bus.Received().SubscribeAsync(sut.GetType().FullName,
                                          Arg.Any <Action <QueryPointSetMessage>>());
        }

        [Theory]
        [AutoNSubstituteData]
        public void QueryPointRequestHandler_SendsMessage_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] QueryPointModel sut,
            [NotNull] QueryPointRequestMessage message)
        {
            // Arrange
            SetXyzValues(sut,
                         1.0,
                         2.0,
                         3.0);

            // Act
            sut.QueryPointRequestHandler(message);

            // Assert
            bus.Received().PublishAsync(Arg.Is <QueryPointChangedMessage>(x => Math.Abs(x.X - 1.0) < Tolerance &&
                                                                               Math.Abs(x.Y - 2.0) < Tolerance &&
                                                                               Math.Abs(x.Z - 3.0) < Tolerance));
        }

        [Theory]
        [AutoNSubstituteData]
        public void QueryPointSetHandler_SendsMessage_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] QueryPointModel sut,
            [NotNull] QueryPointSetMessage message)
        {
            // Arrange
            // Act
            sut.QueryPointSetHandler(message);

            // Assert
            bus.Received().PublishAsync(Arg.Is <QueryPointChangedMessage>(x => Math.Abs(x.X - message.X) < Tolerance &&
                                                                               Math.Abs(x.Y - message.Y) < Tolerance &&
                                                                               Math.Abs(x.Z - message.Z) < Tolerance));
        }

        [Theory]
        [AutoNSubstituteData]
        public void QueryPointSetHandler_SetsX_ForMessage(
            [NotNull] QueryPointModel sut,
            [NotNull] QueryPointSetMessage message)
        {
            // Arrange
            // Act
            sut.QueryPointSetHandler(message);

            // Assert
            Assert.AreEqual(message.X,
                            sut.X);
        }

        [Theory]
        [AutoNSubstituteData]
        public void QueryPointSetHandler_SetsY_ForMessage(
            [NotNull] QueryPointModel sut,
            [NotNull] QueryPointSetMessage message)
        {
            // Arrange
            // Act
            sut.QueryPointSetHandler(message);

            // Assert
            Assert.AreEqual(message.Y,
                            sut.Y);
        }

        [Theory]
        [AutoNSubstituteData]
        public void QueryPointSetHandler_SetsZ_ForMessage(
            [NotNull] QueryPointModel sut,
            [NotNull] QueryPointSetMessage message)
        {
            // Arrange
            // Act
            sut.QueryPointSetHandler(message);

            // Assert
            Assert.AreEqual(message.Z,
                            sut.Z);
        }
    }
}