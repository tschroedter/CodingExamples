using DSim.Common;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace DSim.LogicGates.RealTime
{
    [ProjectComponent(Lifestyle.Transient)]
    public class RealTimeProbe
        : BaseRealTimeLogicGate,
          IRealTimeProbe
    {
        internal static int Delay = 0;
        private readonly IProbe m_Probe;

        public RealTimeProbe([NotNull] IDisposer disposer,
                             [NotNull] IAgenda agenda,
                             [NotNull] IWire wire,
                             [NotNull] IProbeFactory factory)
            : base(disposer,
                   agenda,
                   new[]
                   {
                       wire
                   },
                   new[]
                   {
                       wire
                   })
        {
            m_Probe = factory.Create(wire);
        }

        public bool GetSignal()
        {
            return m_Probe.GetSignal();
        }

        public string GetLog()
        {
            return m_Probe.GetLog();
        }

        public override void Run(int time)
        {
            m_Probe.Calculate(time); // todo testing
        }

        protected override int GetDelay()
        {
            return Delay;
        }
    }
}