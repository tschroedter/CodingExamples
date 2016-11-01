using Evaluation.Wpf.Application.Common.Interfaces;
using Evaluation.Wpf.Application.Models.Interfaces;
using Evaluation.Wpf.Application.Models.Messages;
using Evaluation.Wpf.Application.ViewModels.Messages;
using JetBrains.Annotations;
using Selkie.EasyNetQ;

namespace Evaluation.Wpf.Application.Models
{
    public class SourceFileSelectorModel
        : ISourceFileSelectorModel
    {
        private readonly ISelkieInMemoryBus m_Bus;
        private readonly ISettingsManager m_Manager;

        public SourceFileSelectorModel(
            [NotNull] ISelkieInMemoryBus bus,
            [NotNull] ISettingsManager manager)
        {
            m_Bus = bus;
            m_Manager = manager;

            bus.SubscribeAsync <BrowseRequestMessage>(GetType().FullName,
                                                      BrowseRequestHandler);
            bus.SubscribeAsync <FilenameSetMessage>(GetType().FullName,
                                                    FilenameSetHandler);
            bus.SubscribeAsync <FilenameRequestMessage>(GetType().FullName,
                                                        FilenameRequestHandler);
        }

        public string Filename
        {
            get
            {
                return m_Manager.Filename;
            }
        }

        internal void FilenameRequestHandler(FilenameRequestMessage obj)
        {
            SendFilenameChangedMessage();
        }

        internal void FilenameSetHandler(FilenameSetMessage message)
        {
            m_Manager.Filename = message.Filename;

            SendFilenameChangedMessage();
        }

        private void SendFilenameChangedMessage()
        {
            m_Bus.PublishAsync(new FilenameChangedMessage
                               {
                                   Filename = Filename
                               });
        }

        internal void BrowseRequestHandler(BrowseRequestMessage message)
        {
            m_Bus.PublishAsync(new ShowBrowseDialogMessage());
        }
    }
}