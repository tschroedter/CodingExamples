using System.Collections.Generic;
using System.Linq;
using Evaluation.Common;
using Evaluation.Interfaces;
using Evaluation.Wpf.Application.Common.Interfaces;
using Evaluation.Wpf.Application.Models.Interfaces;
using Evaluation.Wpf.Application.Models.Messages;
using JetBrains.Annotations;
using Selkie.EasyNetQ;

namespace Evaluation.Wpf.Application.Models
{
    public class ClosestPointsFinderModel
        : IClosestPointsFinderModel
    {
        private readonly ISelkieInMemoryBus m_Bus;
        private readonly IClosestPointsFinder m_Finder;
        private readonly ISettingsManager m_Manager;

        public ClosestPointsFinderModel(
            [NotNull] ISelkieInMemoryBus bus,
            [NotNull] ISettingsManager manager,
            [NotNull] IClosestPointsFinder finder)
        {
            m_Bus = bus;
            m_Manager = manager;
            m_Finder = finder;

            bus.SubscribeAsync <ClosestIdsRequestMessage>(GetType().FullName,
                                                          ClosestIdsRequestHandler);
            bus.SubscribeAsync <ClosestIdsCalculateMessage>(GetType().FullName,
                                                            ClosestPointsFinderCalculateHandler);
        }

        public IEnumerable <int> ClosestIds
        {
            get
            {
                return m_Finder.ClosestIds;
            }
        }

        internal void ClosestIdsRequestHandler(ClosestIdsRequestMessage message)
        {
            SendClosestIdsChangedMessage();
        }

        internal void ClosestPointsFinderCalculateHandler(ClosestIdsCalculateMessage message)
        {
            // todo avoid converting to string, use a different class to configure (the app was original developed as a console application)
            string queryPointCoordinates = "{0} {1} {2}".Inject(m_Manager.QueryPoint.X,
                                                                m_Manager.QueryPoint.Y,
                                                                m_Manager.QueryPoint.Z);

            string shiftPointCoordinates = "{0} {1} {2}".Inject(m_Manager.ShiftPoint.X,
                                                                m_Manager.ShiftPoint.Y,
                                                                m_Manager.ShiftPoint.Z);

            var arguments = new ApplicationArguments
                            {
                                Source = m_Manager.Filename, // todo Source should be named Filename
                                NumberOfClosestPoints = m_Manager.NumberOfClosestPoints,
                                QueryPointCoordinates = queryPointCoordinates,
                                ShiftPointCoordinates = shiftPointCoordinates
                            };

            m_Finder.Run(arguments);

            SendClosestIdsChangedMessage();
        }

        private void SendClosestIdsChangedMessage()
        {
            var message = new ClosestIdsChangedMessage
                          {
                              ClosestPointIds = ClosestIds.ToArray()
                          };

            m_Bus.PublishAsync(message);
        }
    }
}