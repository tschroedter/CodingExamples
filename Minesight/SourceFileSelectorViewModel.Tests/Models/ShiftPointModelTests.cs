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
    internal sealed class ShiftPointModelTests
    {
        private const double Tolerance = 0.0001;

        private void SetXyzValues(
            [NotNull] ShiftPointModel model,
            double x,
            double y,
            double z)
        {
            var setMessage = new ShiftPointSetMessage
                             {
                                 X = x,
                                 Y = y,
                                 Z = z
                             };

            model.ShiftPointSetHandler(setMessage);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Constructor_SubscribeToShiftPointRequestMessage_WhenCreated(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] ShiftPointModel sut)
        {
            // Arrange
            // Act
            // Assert
            bus.Received().SubscribeAsync(sut.GetType().FullName,
                                          Arg.Any <Action <ShiftPointRequestMessage>>());
        }

        [Theory]
        [AutoNSubstituteData]
        public void Constructor_SubscribeToShiftPointSetMessage_WhenCreated(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] ShiftPointModel sut)
        {
            // Arrange
            // Act
            // Assert
            bus.Received().SubscribeAsync(sut.GetType().FullName,
                                          Arg.Any <Action <ShiftPointSetMessage>>());
        }

        [Theory]
        [AutoNSubstituteData]
        public void ShiftPointRequestHandler_SendsMessage_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] ShiftPointModel sut,
            [NotNull] ShiftPointRequestMessage message)
        {
            // Arrange
            SetXyzValues(sut,
                         1.0,
                         2.0,
                         3.0);

            // Act
            sut.ShiftPointRequestHandler(message);

            // Assert
            bus.Received().PublishAsync(Arg.Is <ShiftPointChangedMessage>(x => Math.Abs(x.X - 1.0) < Tolerance &&
                                                                               Math.Abs(x.Y - 2.0) < Tolerance &&
                                                                               Math.Abs(x.Z - 3.0) < Tolerance));
        }

        [Theory]
        [AutoNSubstituteData]
        public void ShiftPointSetHandler_SendsMessage_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] ShiftPointModel sut,
            [NotNull] ShiftPointSetMessage message)
        {
            // Arrange
            // Act
            sut.ShiftPointSetHandler(message);

            // Assert
            bus.Received().PublishAsync(Arg.Is <ShiftPointChangedMessage>(x => Math.Abs(x.X - message.X) < Tolerance &&
                                                                               Math.Abs(x.Y - message.Y) < Tolerance &&
                                                                               Math.Abs(x.Z - message.Z) < Tolerance));
        }

        [Theory]
        [AutoNSubstituteData]
        public void ShiftPointSetHandler_SetsX_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] ShiftPointModel sut,
            [NotNull] ShiftPointSetMessage message)
        {
            // Arrange
            // Act
            sut.ShiftPointSetHandler(message);

            // Assert
            Assert.AreEqual(message.X,
                            sut.X);
        }

        [Theory]
        [AutoNSubstituteData]
        public void ShiftPointSetHandler_SetsY_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] ShiftPointModel sut,
            [NotNull] ShiftPointSetMessage message)
        {
            // Arrange
            // Act
            sut.ShiftPointSetHandler(message);

            // Assert
            Assert.AreEqual(message.Y,
                            sut.Y);
        }

        [Theory]
        [AutoNSubstituteData]
        public void ShiftPointSetHandler_SetsZ_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] ShiftPointModel sut,
            [NotNull] ShiftPointSetMessage message)
        {
            // Arrange
            // Act
            sut.ShiftPointSetHandler(message);

            // Assert
            Assert.AreEqual(message.Z,
                            sut.Z);
        }
    }
}