using DSim.LogicGates.RealTime;
using DSim.Tests.Specflow.Steps.Common;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DSim.Tests.Specflow.Steps
{
    [Binding]
    public class ThenTheProbeProbeOneShouldShowFalseStep : BaseStep
    {
        [Then(@"the probe (.*) should show (.*)")]
        public void ThenTheProbeProbeOneShouldShowFalse(string probeName,
                                                        bool expected)
        {
            IRealTimeProbe probe = GetRealTimeProbeFromContext(probeName);

            SleepWaitAndDo(() => IsExpectedOutputSignal(expected,
                                                        probe),
                           DoNothing);

            bool actual = probe.GetSignal();

            Assert.AreEqual(expected,
                            actual);
        }

        private bool IsExpectedOutputSignal(bool expected,
                                            IRealTimeProbe probe)
        {
            return expected == probe.GetSignal();
        }
    }
}