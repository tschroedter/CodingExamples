using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Evaluation.Geometry.Shapes;
using Evaluation.Interfaces;
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
    internal sealed class ClosestPointsFinderModelTests
    {
        private void SetupSettingsManager(
            [NotNull] ISettingsManager manager)
        {
            manager.Filename = "Test.txt";
            manager.NumberOfClosestPoints = 3;
            manager.QueryPoint = new Point3D(-1,
                                             1.0,
                                             2.0,
                                             3.0,
                                             "Query Point");
            manager.ShiftPoint = new Point3D(-1,
                                             4.0,
                                             5.0,
                                             6.0,
                                             "Shift Point");
        }

        [Theory]
        [AutoNSubstituteData]
        public void ClosestIdsRequestHandler_SendsMessage_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull, Frozen] IClosestPointsFinder finder,
            [NotNull] ClosestPointsFinderModel sut,
            [NotNull] ClosestIdsRequestMessage message)
        {
            // Arrange
            var expected = new[]
                           {
                               1,
                               2,
                               3
                           };

            finder.ClosestIds.Returns(expected);

            // Act
            sut.ClosestIdsRequestHandler(message);

            // Assert
            bus.Received()
               .PublishAsync(Arg.Is <ClosestIdsChangedMessage>(x => expected.SequenceEqual(x.ClosestPointIds)));
        }

        [Theory]
        [AutoNSubstituteData]
        public void ClosestPointsFinderCalculateHandler_CallsRun_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull, Frozen] ISettingsManager manager,
            [NotNull, Frozen] IClosestPointsFinder finder,
            [NotNull] ClosestPointsFinderModel sut,
            [NotNull] ClosestIdsCalculateMessage message)
        {
            // Arrange
            SetupSettingsManager(manager);

            // Act
            sut.ClosestPointsFinderCalculateHandler(message);

            // Assert
            finder.Received().Run(Arg.Is <IApplicationArguments>(x => x.Source == "Test.txt" &&
                                                                      x.NumberOfClosestPoints == 3 &&
                                                                      x.QueryPointCoordinates == "1 2 3" &&
                                                                      x.ShiftPointCoordinates == "4 5 6"));
        }

        [Theory]
        [AutoNSubstituteData]
        public void ClosestPointsFinderCalculateHandler_SendsMessage_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull, Frozen] ISettingsManager manager,
            [NotNull, Frozen] IClosestPointsFinder finder,
            [NotNull] ClosestPointsFinderModel sut,
            [NotNull] ClosestIdsCalculateMessage message)
        {
            // Arrange
            SetupSettingsManager(manager);

            var expected = new[]
                           {
                               1,
                               2,
                               3
                           };

            finder.ClosestIds.Returns(expected);

            // Act
            sut.ClosestPointsFinderCalculateHandler(message);

            // Assert
            bus.Received()
               .PublishAsync(Arg.Is <ClosestIdsChangedMessage>(x => expected.SequenceEqual(x.ClosestPointIds)));
        }

        [Theory]
        [AutoNSubstituteData]
        public void Constructor_SetsClosestIds_WhenCreated(
            [NotNull] ClosestPointsFinderModel sut)
        {
            // Arrange
            // Act
            // Assert
            Assert.NotNull(sut.ClosestIds);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Constructor_SubscribeToClosestIdsCalculateMessage_WhenCreated(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] ClosestPointsFinderModel sut)
        {
            // Arrange
            // Act
            // Assert
            bus.Received().SubscribeAsync(sut.GetType().FullName,
                                          Arg.Any <Action <ClosestIdsCalculateMessage>>());
        }

        [Theory]
        [AutoNSubstituteData]
        public void Constructor_SubscribeToClosestIdsRequestMessage_WhenCreated(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] ClosestPointsFinderModel sut)
        {
            // Arrange
            // Act
            // Assert
            bus.Received().SubscribeAsync(sut.GetType().FullName,
                                          Arg.Any <Action <ClosestIdsRequestMessage>>());
        }
    }
}