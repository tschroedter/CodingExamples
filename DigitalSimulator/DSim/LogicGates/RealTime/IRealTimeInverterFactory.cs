using DSim.Common;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace DSim.LogicGates.RealTime
{
    public interface IRealTimeInverterFactory : ITypedFactory
    {
        IRealTimeInverter Create([NotNull] IWire wireIn,
                                 [NotNull] IWire wireOut);

        IRealTimeInverter Create([NotNull] IAgenda agenda,
                                 [NotNull] IWire wireIn,
                                 [NotNull] IWire wireOut);

        void Release([NotNull] IRealTimeInverter inverter);
    }
}