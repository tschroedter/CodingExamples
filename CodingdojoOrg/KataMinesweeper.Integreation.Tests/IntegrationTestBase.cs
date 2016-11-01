using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;

namespace KataMinesweeper.Integreation.Tests
{
    public class IntegrationTestBase
    {
        protected WindsorContainer Container { get; private set; }

        [SetUp]
        public void Setup()
        {
            Container = new WindsorContainer();

            var installers = new IWindsorInstaller[]
                             {
                                 new Selkie.Windsor.Installer(),
                                 new Interfaces.Installer(),
                                 new Installer()
                             };

            Container.Install(installers);
        }

        [TearDown]
        public void Teardown()
        {
            Container.Dispose();
        }
    }
}