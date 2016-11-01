using DSim.Common;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace DSim.LogicGates.RealTime
{
    public interface IRealTimeProbeFactory : ITypedFactory
    {
        IRealTimeProbe Create([NotNull] IWire wire);

        IRealTimeProbe Create([NotNull] IAgenda agenda,
                              [NotNull] IWire wire);

        void Release([NotNull] IRealTimeProbe probe);
    }
}