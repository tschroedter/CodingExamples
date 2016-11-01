using System.Diagnostics.CodeAnalysis;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.DataAccess;

namespace IAsset.MicroServices.FlightAssignedToGate.DataAccess
{
    [ExcludeFromCodeCoverage]
    public class FlightAssignedToGate : IFlightAssignedToGate
    {
        public int GateId { get; set; }
        public int FlightId { get; set; }
        public int Id { get; set; }
    }
}