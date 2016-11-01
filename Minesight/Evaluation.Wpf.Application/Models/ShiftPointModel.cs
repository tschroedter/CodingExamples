using Evaluation.Geometry.Shapes;
using Evaluation.Wpf.Application.Common.Interfaces;
using Evaluation.Wpf.Application.Models.Interfaces;
using Evaluation.Wpf.Application.Models.Messages;
using JetBrains.Annotations;
using Selkie.EasyNetQ;

namespace Evaluation.Wpf.Application.Models
{
    // todo duplicated code ShiftPointModel and QueryPointModel
    public class ShiftPointModel
        : IShiftPointModel
    {
        private readonly ISelkieInMemoryBus m_Bus;
        private readonly ISettingsManager m_Manager;

        public ShiftPointModel(
            [NotNull] ISelkieInMemoryBus bus,
            [NotNull] ISettingsManager manager)
        {
            m_Bus = bus;
            m_Manager = manager;

            bus.SubscribeAsync <ShiftPointRequestMessage>(GetType().FullName,
                                                          ShiftPointRequestHandler);
            bus.SubscribeAsync <ShiftPointSetMessage>(GetType().FullName,
                                                      ShiftPointSetHandler);
        }

        public double X
        {
            get
            {
                return m_Manager.ShiftPoint.X;
            }
        }

        public double Y
        {
            get
            {
                return m_Manager.ShiftPoint.Y;
            }
        }

        public double Z
        {
            get
            {
                return m_Manager.ShiftPoint.Z;
            }
        }

        internal void ShiftPointSetHandler(ShiftPointSetMessage message)
        {
            var shiftPoint = new Point3D(-1,
                                         message.X,
                                         message.Y,
                                         message.Z,
                                         "Shift Point");

            m_Manager.ShiftPoint = shiftPoint;

            SendQueryPointChangedMessage();
        }

        internal void ShiftPointRequestHandler(ShiftPointRequestMessage message)
        {
            SendQueryPointChangedMessage();
        }

        private void SendQueryPointChangedMessage()
        {
            var reply = new ShiftPointChangedMessage
                        {
                            X = X,
                            Y = Y,
                            Z = Z
                        };

            m_Bus.PublishAsync(reply);
        }
    }
}