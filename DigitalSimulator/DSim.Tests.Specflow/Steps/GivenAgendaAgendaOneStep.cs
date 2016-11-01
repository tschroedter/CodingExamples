using DSim.Common;
using DSim.Tests.Specflow.Steps.Common;
using TechTalk.SpecFlow;

namespace DSim.Tests.Specflow.Steps
{
    [Binding]
    public class GivenAgendaAgendaOneStep : BaseStep
    {
        [Given(@"Agenda (.*)")]
        public void GivenAgendaAgendaOne(string name)
        {
            IAgenda inverter = CreateAgenda(name);

            ScenarioContext.Current [ name ] = inverter;
        }
    }
}