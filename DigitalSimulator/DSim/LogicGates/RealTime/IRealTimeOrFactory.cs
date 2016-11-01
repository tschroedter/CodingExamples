using DSim.Common;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace DSim.LogicGates.RealTime
{
    public interface IRealTimeOrFactory : ITypedFactory
    {
        IRealTimeOr Create([NotNull] IWire wireInOne,
                           [NotNull] IWire wireInTwo,
                           [NotNull] IWire wireOut);

        IRealTimeOr Create([NotNull] IAgenda agenda,
                           [NotNull] IWire wireInOne,
                           [NotNull] IWire wireInTwo,
                           [NotNull] IWire wireOut);

        void Release([NotNull] IRealTimeOr inverter);
    }
}