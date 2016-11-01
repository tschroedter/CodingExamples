using DSim.Common;
using DSim.Tests.Specflow.Steps.Common;
using JetBrains.Annotations;
using TechTalk.SpecFlow;

namespace DSim.Tests.Specflow.Steps
{
    [Binding]
    public class GivenWireStep : BaseStep
    {
        [Given(@"Wire (.*)")]
        public void GivenWire([NotNull] string wireName)
        {
            IWire inverter = CreateWire(wireName);

            ScenarioContext.Current [ wireName ] = inverter;
        }
    }
}