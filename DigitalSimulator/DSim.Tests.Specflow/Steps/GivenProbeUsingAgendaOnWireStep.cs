using DSim.Common;
using DSim.LogicGates.RealTime;
using DSim.Tests.Specflow.Steps.Common;
using JetBrains.Annotations;
using TechTalk.SpecFlow;

namespace DSim.Tests.Specflow.Steps
{
    [Binding]
    public class GivenProbeUsingAgendaOnWireStep : BaseStep
    {
        [Given(@"Probe (.*) using agenda (.*) on wire (.*)")]
        public void GivenProbeOnWire([NotNull] string probeName,
                                     [NotNull] string agendaName,
                                     [NotNull] string wireName)
        {
            IAgenda agenda = GetAgendaFromContext(agendaName);
            IWire wire = GetWireFromContext(wireName);

            IRealTimeProbe probe = CreateRealTimeProbe(agenda,
                                                       wire);

            ScenarioContext.Current [ probeName ] = probe;
        }
    }
}