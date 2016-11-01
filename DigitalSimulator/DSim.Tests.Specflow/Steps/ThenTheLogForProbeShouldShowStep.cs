using System;
using DSim.LogicGates.RealTime;
using DSim.Tests.Specflow.Steps.Common;
using JetBrains.Annotations;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DSim.Tests.Specflow.Steps
{
    [Binding]
    public class ThenTheLogForProbeShouldShowStep : BaseStep
    {
        [Then(@"the log for probe (.*) should show (.*)")]
        public void ThenTheLogForProbeShouldShow([NotNull] string probeName,
                                                 [NotNull] string expected)
        {
            IRealTimeProbe probe = GetRealTimeProbeFromContext(probeName);

            SleepWaitAndDo(() => IsExpectedOutputSignal(expected,
                                                        probe),
                           DoNothing);

            string actual = probe.GetLog();

            Assert.AreEqual(expected,
                            actual);
        }

        private bool IsExpectedOutputSignal(string expected,
                                            IRealTimeProbe probe)
        {
            return string.Compare(expected,
                                  probe.GetLog(),
                                  StringComparison.InvariantCulture) == 0;
        }
    }
}