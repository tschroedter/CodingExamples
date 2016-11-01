using System;
using System.Diagnostics.CodeAnalysis;
using Evaluation.Wpf.Application.Common.Interfaces;
using Evaluation.Wpf.Application.Models;
using Evaluation.Wpf.Application.Models.Messages;
using Evaluation.Wpf.Application.ViewModels.Messages;
using JetBrains.Annotations;
using NSubstitute;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit2;
using Selkie.EasyNetQ;

namespace Evaluation.Wpf.Application.Tests.Models
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class SourceFileSelectorModelTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void BrowseRequestHandler_SendsMessage_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] SourceFileSelectorModel sut,
            [NotNull] BrowseRequestMessage message)
        {
            // Arrange
            // Act
            sut.BrowseRequestHandler(message);

            // Assert
            bus.Received().PublishAsync(Arg.Any <ShowBrowseDialogMessage>());
        }

        [Theory]
        [AutoNSubstituteData]
        public void Constructor_SubscribeTFilenameRequestMessage_WhenCreated(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] SourceFileSelectorModel sut)
        {
            // Arrange
            // Act
            // Assert
            bus.Received().SubscribeAsync(sut.GetType().FullName,
                                          Arg.Any <Action <FilenameRequestMessage>>());
        }

        [Theory]
        [AutoNSubstituteData]
        public void Constructor_SubscribeToBrowseRequestMessage_WhenCreated(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] SourceFileSelectorModel sut)
        {
            // Arrange
            // Act
            // Assert
            bus.Received().SubscribeAsync(sut.GetType().FullName,
                                          Arg.Any <Action <BrowseRequestMessage>>());
        }

        [Theory]
        [AutoNSubstituteData]
        public void Constructor_SubscribeToFilenameSetMessage_WhenCreated(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] SourceFileSelectorModel sut)
        {
            // Arrange
            // Act
            // Assert
            bus.Received().SubscribeAsync(sut.GetType().FullName,
                                          Arg.Any <Action <FilenameSetMessage>>());
        }

        [Theory]
        [AutoNSubstituteData]
        public void FilenameRequestHandler_SendsMessage_ForMessage(
            [NotNull, Frozen] ISettingsManager manager,
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] SourceFileSelectorModel sut,
            [NotNull] FilenameRequestMessage message)
        {
            // Arrange
            manager.Filename = "Test.txt";

            // Act
            sut.FilenameRequestHandler(message);

            // Assert
            bus.Received()
               .PublishAsync(Arg.Is <FilenameChangedMessage>(x => x.Filename == "Test.txt"));
        }

        [Theory]
        [AutoNSubstituteData]
        public void FilenameSetHandler_SendsMessage_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] SourceFileSelectorModel sut,
            [NotNull] FilenameSetMessage message)
        {
            // Arrange
            // Act
            sut.FilenameSetHandler(message);

            // Assert
            bus.Received().PublishAsync(Arg.Is <FilenameChangedMessage>(x => x.Filename == message.Filename));
        }

        [Theory]
        [AutoNSubstituteData]
        public void FilenameSetHandler_SetsFilename_ForMessage(
            [NotNull, Frozen] ISelkieInMemoryBus bus,
            [NotNull] SourceFileSelectorModel sut,
            [NotNull] FilenameSetMessage message)
        {
            // Arrange
            // Act
            sut.FilenameSetHandler(message);

            // Assert
            Assert.AreEqual(message.Filename,
                            sut.Filename);
        }
    }
}