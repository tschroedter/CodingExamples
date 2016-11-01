using System;
using System.Diagnostics.CodeAnalysis;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using IAsset.MicroServices.FlightAssignedToGate.DataAccess;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.DataAccess;
using IAsset.MicroServices.Flights.DataAccess;
using IAsset.MicroServices.Flights.Interfaces.DataAccess;
using IAsset.MicroServices.Gates.DataAccess;
using IAsset.MicroServices.Gates.Interfaces.DataAccess;
using Nancy.Bootstrappers.Windsor;
using Selkie.Windsor;

namespace SelfHosting
{
    [ExcludeFromCodeCoverage]
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            base.ConfigureApplicationContainer(container);

            // Add the Array Resolver, so we can take dependencies on T[]
            // while only registering T.
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));

            container.Install(FromAssembly.Containing(typeof( Installer )));
            container.Install(FromAssembly.Containing(typeof( IAsset.MicroServices.Gates.Installer )));
            container.Install(FromAssembly.Containing(typeof( IAsset.MicroServices.Flights.Installer )));
            container.Install(FromAssembly.Containing(typeof( IAsset.MicroServices.FlightAssignedToGate.Installer )));
            container.Install(FromAssembly.Containing(typeof( IAsset.MicroServices.FlightsAssignedToGates.Installer )));

            PopulateRepositories(container);
        }

        private static void PopulateRepositories(IWindsorContainer container)
        {
            PopulateRepositoryFlightsRepository(container);
            PopulateRepositoryGates(container);
            PopulateRepositoryFlightAssignedToGate(container);
        }

        private static void PopulateRepositoryFlightAssignedToGate(IWindsorContainer container)
        {
            var repository = container.Resolve <IFlightAssignedToGateRepository>();

            var one = new FlightAssignedToGate
                      {
                          GateId = 1,
                          FlightId = 11,
                          Id = 1
                      };

            repository.Save(one);

            var two = new FlightAssignedToGate
                      {
                          GateId = 1,
                          FlightId = 12,
                          Id = 2
                      };

            repository.Save(two);

            var three = new FlightAssignedToGate
                        {
                            GateId = 2,
                            FlightId = 21,
                            Id = 3
                        };

            repository.Save(three);

            container.Release(repository);
        }

        private static void PopulateRepositoryFlightsRepository(IWindsorContainer container)
        {
            var repository = container.Resolve <IFlightsRepository>();

            var one = new Flight
                      {
                          Arrival = DateTime.Parse("01/01/2001 9:00"),
                          Departure = DateTime.Parse("01/01/2001 9:30"),
                          Id = 11
                      };

            repository.Save(one);

            var two = new Flight
                      {
                          Arrival = DateTime.Parse("01/01/2001 9:30"),
                          Departure = DateTime.Parse("01/01/2001 10:00"),
                          Id = 12
                      };

            repository.Save(two);

            var three = new Flight
                        {
                            Arrival = DateTime.Parse("01/01/2001 9:00"),
                            Departure = DateTime.Parse("01/01/2001 9:30"),
                            Id = 21
                        };

            repository.Save(three);

            container.Release(repository);
        }

        private static void PopulateRepositoryGates(IWindsorContainer container)
        {
            var repository = container.Resolve <IGatesRepository>();

            var one = new Gate
                      {
                          Id = 1,
                          Description = "Gate 1"
                      };

            repository.Save(one);

            var two = new Gate
                      {
                          Id = 2,
                          Description = "Gate 2"
                      };

            repository.Save(two);

            var three = new Gate
                        {
                            Id = 3,
                            Description = "Gate 3"
                        };

            repository.Save(three);

            container.Release(repository);
        }
    }
}