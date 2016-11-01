using DSim.Common;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace DSim.LogicGates.RealTime
{
    [ProjectComponent(Lifestyle.Transient)]
    public sealed class RealTimeInverter
        : BaseRealTimeLogicGate,
          IRealTimeInverter
    {
        internal static int Delay = 4;

        private readonly IInverter m_Inverter;

        public RealTimeInverter([NotNull] IDisposer disposer,
                                [NotNull] IAgenda agenda,
                                [NotNull] IInverterFactory factory,
                                [NotNull] IWire wireIn,
                                [NotNull] IWire wireOut)
            : base(disposer,
                   agenda,
                   new[]
                   {
                       wireIn
                   },
                   new[]
                   {
                       wireOut
                   })
        {
            m_Inverter = factory.Create(wireIn,
                                        wireOut);
        }

        public override void Run(int time)
        {
            m_Inverter.Calculate(time); // todo testing
        }

        protected override int GetDelay()
        {
            return 4;
        }
    }
}