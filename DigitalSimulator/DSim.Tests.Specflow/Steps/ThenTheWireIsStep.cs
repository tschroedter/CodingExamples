using DSim.Common;
using DSim.Tests.Specflow.Steps.Common;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DSim.Tests.Specflow.Steps
{
    [Binding]
    public class ThenTheWireIsStep : BaseStep
    {
        [Then(@"the wire (.*) is (.*)")]
        public void ThenTheWireOrOutputIsTrue(string wireName,
                                              bool expected)
        {
            IWire wire = GetWireFromContext(wireName);

            SleepWaitAndDo(() => IsExpectedOutputSignal(expected,
                                                        wire),
                           DoNothing);

            bool actual = wire.GetSignal();

            Assert.AreEqual(expected,
                            actual);
        }

        private bool IsExpectedOutputSignal(bool expected,
                                            IWire wire)
        {
            return expected == wire.GetSignal();
        }
    }
}