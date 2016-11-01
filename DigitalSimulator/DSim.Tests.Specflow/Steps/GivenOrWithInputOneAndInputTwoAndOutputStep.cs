using DSim.Common;
using DSim.LogicGates.RealTime;
using DSim.Tests.Specflow.Steps.Common;
using JetBrains.Annotations;
using TechTalk.SpecFlow;

namespace DSim.Tests.Specflow.Steps
{
    [Binding]
    public class GivenOrWithInputOneAndInputTwoAndOutputStep : BaseStep
    {
        [Given(@"Or (.*) using agenda (.*) with input one (.*) and input two (.*) and output (.*)")]
        public void GivenOrUsingAgendaWithInputOneAndInputTwoAndOutput([NotNull] string orName,
                                                                       [NotNull] string agendaName,
                                                                       [NotNull] string wireInputOneName,
                                                                       [NotNull] string wireInputTwoName,
                                                                       [NotNull] string wireOutputName)
        {
            IAgenda agenda = GetAgendaFromContext(agendaName);
            IWire inputOne = GetWireFromContext(wireInputOneName);
            IWire inputTwo = GetWireFromContext(wireInputTwoName);
            IWire output = GetWireFromContext(wireOutputName);

            IRealTimeOr or = CreateRealTimeOr(agenda,
                                              inputOne,
                                              inputTwo,
                                              output);

            ScenarioContext.Current [ orName ] = or;
        }
    }
}