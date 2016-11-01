using DSim.Common;
using DSim.LogicGates.RealTime;
using DSim.Tests.Specflow.Steps.Common;
using JetBrains.Annotations;
using TechTalk.SpecFlow;

namespace DSim.Tests.Specflow.Steps
{
    [Binding]
    public class GivenInverterUsingAgendaWithInputAndIOutputStep : BaseStep
    {
        [Given(@"Inverter (.*) using agenda (.*) with input (.*) and output (.*)")]
        public void GivenInverterUsingAgendaWithInputAndIOutput([NotNull] string inverterName,
                                                                [NotNull] string agendaName,
                                                                [NotNull] string wireInputName,
                                                                [NotNull] string wireOutputName)
        {
            IAgenda agenda = GetAgendaFromContext(agendaName);
            IWire input = GetWireFromContext(wireInputName);
            IWire output = GetWireFromContext(wireOutputName);

            IRealTimeInverter inverter = CreateRealTimeInverter(agenda,
                                                                input,
                                                                output);

            ScenarioContext.Current [ inverterName ] = inverter;
        }
    }
}