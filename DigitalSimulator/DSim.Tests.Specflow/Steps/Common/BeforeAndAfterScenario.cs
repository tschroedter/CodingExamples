using Castle.Windsor;
using Castle.Windsor.Installer;
using TechTalk.SpecFlow;

namespace DSim.Tests.Specflow.Steps.Common
{
    [Binding]
    public class BeforeAndAfterScenario
    {
        [BeforeScenario]
        public static void BeforeTestRun()
        {
            var container = new WindsorContainer();
            container.Install(FromAssembly.This());

            ScenarioContext.Current [ "WindsorContainer" ] = container;
        }

        [AfterScenario]
        public static void AfterTestRun()
        {
            var container = ( WindsorContainer ) ScenarioContext.Current [ "WindsorContainer" ];

            container.Dispose();
        }
    }
}