using Evaluation.Wpf.Application.Common.Interfaces;
using Evaluation.Wpf.Application.Models.Interfaces;
using Evaluation.Wpf.Application.Models.Messages;
using JetBrains.Annotations;
using Selkie.EasyNetQ;

namespace Evaluation.Wpf.Application.Models
{
    public class NumberOfPointsModel
        : INumberOfPointsModel
    {
        private readonly ISelkieInMemoryBus m_Bus;
        private readonly ISettingsManager m_Manager;

        public NumberOfPointsModel(
            [NotNull] ISelkieInMemoryBus bus,
            [NotNull] ISettingsManager manager)
        {
            m_Bus = bus;
            m_Manager = manager;

            bus.SubscribeAsync <NumberOfPointsSetMessage>(GetType().FullName,
                                                          NumberOfPointsSetHandler);
            bus.SubscribeAsync <NumberOfPointsRequestMessage>(GetType().FullName,
                                                              NumberOfPointsRequestHandler);
        }

        public int NumberOfPoints
        {
            get
            {
                return m_Manager.NumberOfClosestPoints;
            }
        }

        internal void NumberOfPointsRequestHandler(NumberOfPointsRequestMessage message)
        {
            SendNumberOfPointsChangedMessage();
        }

        internal void NumberOfPointsSetHandler(NumberOfPointsSetMessage message)
        {
            m_Manager.NumberOfClosestPoints = message.NumberOfPoints;

            SendNumberOfPointsChangedMessage();
        }

        private void SendNumberOfPointsChangedMessage()
        {
            m_Bus.PublishAsync(new NumberOfPointsChangedMessage
                               {
                                   NumberOfPoints = NumberOfPoints
                               });
        }
    }
}