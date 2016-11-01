using System;
using System.Diagnostics.CodeAnalysis;
using Evaluation.Wpf.Application.Common.Interfaces;
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
    internal sealed class NumberOfPointsModelTests
    {
        private void SetNumberOfPoints(
            [NotNull] NumberOfPointsModel model,
            int numberOfPoints)
        {
            var message = new NumberOfPointsSetMessage
                          {
                              NumberOfPoints = numberOfPoints
                          };

            model.NumberOfPointsSetHandler(message);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Constructor_SetsDefaultValueForNumberOfPoints_WhenCreated(
            [NotNull, Frozen] ISettingsManager manager,
            [NotNull] NumberOfPointsModel sut)
        {
            // Arrange
            manager.NumberOfClosestPoints = 1;

            // Act
            // Assert
            Assert.AreEqual(1,
                            sut.NumberOfPoints);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Constructor_SubscribeToNumberOfPointsRequestMessage_WhenCreated(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] NumberOfPointsModel sut)
        {
            // Arrange
            // Act
            // Assert
            bus.Received().SubscribeAsync(sut.GetType().FullName,
                                          Arg.Any <Action <NumberOfPointsRequestMessage>>());
        }

        [Theory]
        [AutoNSubstituteData]
        public void Constructor_SubscribeToNumberOfPointsSetMessage_WhenCreated(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] NumberOfPointsModel sut)
        {
            // Arrange
            // Act
            // Assert
            bus.Received().SubscribeAsync(sut.GetType().FullName,
                                          Arg.Any <Action <NumberOfPointsSetMessage>>());
        }

        [Theory]
        [AutoNSubstituteData]
        public void NumberOfPointsRequestHandler_SendsMessage_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] NumberOfPointsModel sut)
        {
            // Arrange
            SetNumberOfPoints(sut,
                              1);

            var message = new NumberOfPointsRequestMessage();

            // Act
            sut.NumberOfPointsRequestHandler(message);

            // Assert
            bus.Received().PublishAsync(Arg.Is <NumberOfPointsChangedMessage>(x => x.NumberOfPoints == 1));
        }

        [Theory]
        [AutoNSubstituteData]
        public void NumberOfPointsSetHandler_SendsMessage_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] NumberOfPointsModel sut,
            [NotNull] NumberOfPointsSetMessage message)
        {
            // Arrange
            // Act
            sut.NumberOfPointsSetHandler(message);

            // Assert
            bus.Received()
               .PublishAsync(Arg.Is <NumberOfPointsChangedMessage>(x => x.NumberOfPoints == message.NumberOfPoints));
        }

        [Theory]
        [AutoNSubstituteData]
        public void NumberOfPointsSetHandler_SetsNumberOfPoints_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] NumberOfPointsModel sut,
            [NotNull] NumberOfPointsSetMessage message)
        {
            // Arrange
            // Act
            sut.NumberOfPointsSetHandler(message);

            // Assert
            Assert.AreEqual(message.NumberOfPoints,
                            sut.NumberOfPoints);
        }
    }
}