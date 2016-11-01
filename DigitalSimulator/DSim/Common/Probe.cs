using System.Text;
using JetBrains.Annotations;
using Selkie.Windsor;
using Selkie.Windsor.Extensions;

namespace DSim.Common
{
    [ProjectComponent(Lifestyle.Transient)]
    public class Probe : IProbe
    {
        private readonly StringBuilder m_Builder = new StringBuilder();
        private readonly IWire m_Wire;

        public Probe([NotNull] IWire wire)
        {
            m_Wire = wire;
        }

        public bool GetSignal()
        {
            return m_Wire.GetSignal();
        }

        public void Calculate(int time) // todo rename
        {
            string value = m_Wire.GetSignal()
                               ? "1"
                               : "0";

            m_Builder.Append("[{0},{1}]".Inject(time,
                                                value));
        }

        public string GetLog()
        {
            return m_Builder.ToString();
        }
    }
}