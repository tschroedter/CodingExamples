using System.Diagnostics.CodeAnalysis;
using Castle.Windsor;
using Castle.Windsor.Installer;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.DataAccess;
using Nancy.Bootstrappers.Windsor;
using Selkie.Windsor.Installers;

namespace IAsset.MicroServices.FlightsAssignedToGates.Integration.Tests.Nancy
{
    [ExcludeFromCodeCoverage]
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(IWindsorContainer existingContainer)
        {
            base.ConfigureApplicationContainer(existingContainer);

            var loggerInstaller = new LoggerInstaller();
            loggerInstaller.Install(existingContainer,
                                    null);

            var loaderInstaller = new ProjectComponentLoaderInstaller();
            loaderInstaller.Install(existingContainer,
                                    null);

            existingContainer.Install(FromAssembly.Containing(typeof( Selkie.Windsor.Installer )));
            existingContainer.Install(FromAssembly.Containing(typeof( FlightAssignedToGate.Installer )));
            existingContainer.Install(FromAssembly.Containing(typeof( Installer )));

            PopulateRepositoryFlightAssignedToGate(existingContainer);

            // todo expose repository for testing
        }

        private static void PopulateRepositoryFlightAssignedToGate(IWindsorContainer container)
        {
            var repository = container.Resolve <IFlightAssignedToGateRepository>();

            var one = new FlightAssignedToGate.DataAccess.FlightAssignedToGate
                      {
                          GateId = 1,
                          FlightId = 11,
                          Id = 1
                      };

            repository.Save(one);

            var two = new FlightAssignedToGate.DataAccess.FlightAssignedToGate
                      {
                          GateId = 1,
                          FlightId = 12,
                          Id = 2
                      };

            repository.Save(two);

            var three = new FlightAssignedToGate.DataAccess.FlightAssignedToGate
                        {
                            GateId = 2,
                            FlightId = 21,
                            Id = 3
                        };

            repository.Save(three);

            container.Release(repository);
        }
    }
}