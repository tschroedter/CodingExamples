using System.Diagnostics.CodeAnalysis;
using IAsset.MicroServices.Common.Tests.Extensions;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.DataAccess;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.Nancy;
using IAsset.MicroServices.FlightAssignedToGate.Nancy;
using NSubstitute;
using NUnit.Framework;

namespace IAsset.MicroServices.FlightAssignedToGate.Tests.Nancy
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class FlightAssignedToGateRequestHandlerTests
        : RequestHandlerBaseTests
              <IFlightAssignedToGate,
              IFlightAssignedToGateInformationFinder,
              IFlightAssignedToGateRequestHandler>
    {
        private static int NextIdForResponse;

        protected override IFlightAssignedToGateInformationFinder CreateFinder()
        {
            return Substitute.For <IFlightAssignedToGateInformationFinder>();
        }

        protected override IFlightAssignedToGateRequestHandler CreateSut(
            IFlightAssignedToGateInformationFinder finder)
        {
            return new FlightAssignedToGateRequestHandler(finder);
        }

        protected override IFlightAssignedToGate CreateResponse()
        {
            return new DataAccess.FlightAssignedToGate
                   {
                       Id = NextIdForResponse++,
                       FlightId = 1,
                       GateId = 2
                   };
        }
    }
}