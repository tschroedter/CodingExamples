using System.Diagnostics.CodeAnalysis;
using IAsset.MicroServices.Common.Tests.Extensions;
using IAsset.MicroServices.Flights.DataAccess;
using IAsset.MicroServices.Flights.Interfaces.DataAccess;
using IAsset.MicroServices.Flights.Interfaces.Nancy;
using IAsset.MicroServices.Flights.Nancy;
using JetBrains.Annotations;
using NSubstitute;

namespace IAsset.MicroServices.Flights.Tests.Nancy
{
    [ExcludeFromCodeCoverage]
    internal sealed class FlightsInformationFinderTests
        : InformationFinderBaseTests
              <IFlight,
              IFlight,
              IFlightsRepository,
              IFlightsInformationFinder>
    {
        private static int NextIdForResponse;
        private static int NextIdForEntity;

        protected override IFlight CreateEntity()
        {
            return new Flight
                   {
                       Id = NextIdForEntity++
                   };
        }

        protected override IFlightsRepository CreateRepository()
        {
            return Substitute.For <IFlightsRepository>();
        }

        protected override IFlight CreateResponse()
        {
            return new Flight
                   {
                       Id = NextIdForResponse++
                   };
        }

        protected override IFlightsInformationFinder CreateSut(
            [NotNull] IFlightsRepository repository)
        {
            return new FlightsInformationFinder(repository);
        }
    }
}