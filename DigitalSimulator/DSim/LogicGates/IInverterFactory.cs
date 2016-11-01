using DSim.Common;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace DSim.LogicGates
{
    public interface IInverterFactory : ITypedFactory
    {
        IInverter Create([NotNull] IWire wireIn,
                         [NotNull] IWire wireOut);

        void Release([NotNull] IInverter inverter);
    }
}