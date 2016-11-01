using DSim.Common;
using DSim.Tests.Specflow.Steps.Common;
using TechTalk.SpecFlow;

namespace DSim.Tests.Specflow.Steps
{
    [Binding]
    public class WhenAgendaAgendaOneIsProcessedStep : BaseStep
    {
        [When(@"Agenda (.*) is processed")]
        public void WhenAgendaAgendaOneIsProcessed(string name)
        {
            IAgenda agenda = GetAgendaFromContext(name);
            agenda.Run();
        }
    }
}