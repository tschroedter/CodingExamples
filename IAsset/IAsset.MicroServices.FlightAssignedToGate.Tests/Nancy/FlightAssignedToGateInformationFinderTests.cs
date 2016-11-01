using System.Diagnostics.CodeAnalysis;
using IAsset.MicroServices.Common.Tests.Extensions;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.DataAccess;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.Nancy;
using IAsset.MicroServices.FlightAssignedToGate.Nancy;
using JetBrains.Annotations;
using NSubstitute;

namespace IAsset.MicroServices.FlightAssignedToGate.Tests.Nancy
{
    [ExcludeFromCodeCoverage]
    internal sealed class FlightAssignedToGateInformationFinderTests
        : InformationFinderBaseTests
              <IFlightAssignedToGate,
              IFlightAssignedToGate,
              IFlightAssignedToGateRepository,
              IFlightAssignedToGateInformationFinder>
    {
        private static int NextIdForResponse;
        private static int NextIdForEntity;

        protected override IFlightAssignedToGate CreateEntity()
        {
            return new DataAccess.FlightAssignedToGate
                   {
                       Id = NextIdForEntity++,
                       FlightId = 1,
                       GateId = 2
                   };
        }

        protected override IFlightAssignedToGateRepository CreateRepository()
        {
            return Substitute.For <IFlightAssignedToGateRepository>();
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

        protected override IFlightAssignedToGateInformationFinder CreateSut(
            [NotNull] IFlightAssignedToGateRepository repository)
        {
            return new FlightAssignedToGateInformationFinder(repository);
        }
    }
}