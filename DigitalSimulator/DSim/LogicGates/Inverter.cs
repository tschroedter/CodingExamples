using DSim.Common;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace DSim.LogicGates
{
    [ProjectComponent(Lifestyle.Transient)]
    public sealed class Inverter : IInverter
    {
        private readonly IWire m_WireIn;
        private readonly IWire m_WireOut;

        public Inverter([NotNull] IWire wireIn,
                        [NotNull] IWire wireOut)
        {
            m_WireIn = wireIn;
            m_WireOut = wireOut;
        }

        public void Calculate(int time)
        {
            m_WireOut.SetSignal(time,
                                !m_WireIn.GetSignal());
        }
    }
}