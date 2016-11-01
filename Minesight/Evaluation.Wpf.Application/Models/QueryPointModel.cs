using Evaluation.Geometry.Shapes;
using Evaluation.Wpf.Application.Common.Interfaces;
using Evaluation.Wpf.Application.Models.Interfaces;
using Evaluation.Wpf.Application.Models.Messages;
using JetBrains.Annotations;
using Selkie.EasyNetQ;

namespace Evaluation.Wpf.Application.Models
{
    public class QueryPointModel
        : IQueryPointModel
    {
        private readonly ISelkieInMemoryBus m_Bus;
        private readonly ISettingsManager m_Manager;

        public QueryPointModel(
            [NotNull] ISelkieInMemoryBus bus,
            [NotNull] ISettingsManager manager)
        {
            m_Bus = bus;
            m_Manager = manager;

            bus.SubscribeAsync <QueryPointRequestMessage>(GetType().FullName,
                                                          QueryPointRequestHandler);
            bus.SubscribeAsync <QueryPointSetMessage>(GetType().FullName,
                                                      QueryPointSetHandler);
        }

        public double X
        {
            get
            {
                return m_Manager.QueryPoint.X;
            }
        }

        public double Y
        {
            get
            {
                return m_Manager.QueryPoint.Y;
            }
        }

        public double Z
        {
            get
            {
                return m_Manager.QueryPoint.Z;
            }
        }

        internal void QueryPointSetHandler(QueryPointSetMessage message)
        {
            var queryPoint = new Point3D(-1,
                                         message.X,
                                         message.Y,
                                         message.Z,
                                         "Query Point");

            m_Manager.QueryPoint = queryPoint;

            SendQueryPointChangedMessage();
        }

        internal void QueryPointRequestHandler(QueryPointRequestMessage message)
        {
            SendQueryPointChangedMessage();
        }

        private void SendQueryPointChangedMessage()
        {
            var reply = new QueryPointChangedMessage
                        {
                            X = X,
                            Y = Y,
                            Z = Z
                        };

            m_Bus.PublishAsync(reply);
        }
    }
}