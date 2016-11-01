using DSim.Common;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace DSim.LogicGates
{
    [ProjectComponent(Lifestyle.Transient)]
    public class Or : IOr
    {
        private readonly IWire m_WireInOne;
        private readonly IWire m_WireInTwo;
        private readonly IWire m_WireOut;

        public Or([NotNull] IWire wireInOne,
                  [NotNull] IWire wireInTwo,
                  [NotNull] IWire wireOut)
        {
            m_WireInOne = wireInOne;
            m_WireInTwo = wireInTwo;
            m_WireOut = wireOut;
        }

        public void Calculate(int time)
        {
            bool value = m_WireInOne.GetSignal() ||
                         m_WireInTwo.GetSignal();

            m_WireOut.SetSignal(time,
                                value);
        }
    }
}