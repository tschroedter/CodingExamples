using DSim.Common;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace DSim.LogicGates.RealTime
{
    [ProjectComponent(Lifestyle.Transient)]
    public class RealTimeOr
        : BaseRealTimeLogicGate,
          IRealTimeOr
    {
        internal const int Delay = 5;
        private readonly IOr m_Or;

        public RealTimeOr([NotNull] IDisposer disposer,
                          [NotNull] IAgenda agenda,
                          [NotNull] IOrFactory factory,
                          [NotNull] IWire wireInOne,
                          [NotNull] IWire wireInTwo,
                          [NotNull] IWire wireOut)
            : base(disposer,
                   agenda,
                   new[]
                   {
                       wireInOne,
                       wireInTwo
                   },
                   new[]
                   {
                       wireOut
                   })
        {
            m_Or = factory.Create(wireInOne,
                                  wireInTwo,
                                  wireOut);
        }

        public override void Run(int time)
        {
            m_Or.Calculate(time); // todo testing
        }

        protected override int GetDelay()
        {
            return Delay;
        }
    }
}