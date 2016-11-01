using DSim.Common;
using DSim.Tests.Specflow.Steps.Common;
using JetBrains.Annotations;
using TechTalk.SpecFlow;

namespace DSim.Tests.Specflow.Steps
{
    [Binding]
    public class WhenTheSignalOnTheWireIsStep : BaseStep
    {
        [When(@"the signal on the wire (.*) is (.*) at time (.*)")]
        public void WhenTheSignalOnTheWireIs([NotNull] string wireName,
                                             bool value,
                                             int time)
        {
            IWire wire = GetWireFromContext(wireName);

            wire.SetSignal(time,
                           value);
        }
    }
}