using System.Diagnostics.CodeAnalysis;
using IAsset.MicroServices.Common.Tests.Extensions;
using IAsset.MicroServices.Flights.DataAccess;
using IAsset.MicroServices.Flights.Interfaces.DataAccess;
using IAsset.MicroServices.Flights.Interfaces.Nancy;
using IAsset.MicroServices.Flights.Nancy;
using NSubstitute;
using NUnit.Framework;

namespace IAsset.MicroServices.Flights.Tests.Nancy
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class FlightsRequestHandlerTests
        : RequestHandlerBaseTests
              <IFlight,
              IFlightsInformationFinder,
              IFlightsRequestHandler>
    {
        private static int NextIdForResponse;

        protected override IFlightsInformationFinder CreateFinder()
        {
            return Substitute.For <IFlightsInformationFinder>();
        }

        protected override IFlightsRequestHandler CreateSut(
            IFlightsInformationFinder finder)
        {
            return new FlightsRequestHandler(finder);
        }

        protected override IFlight CreateResponse()
        {
            return new Flight
                   {
                       Id = NextIdForResponse++
                   };
        }
    }
}