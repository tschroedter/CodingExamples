using System.Diagnostics.CodeAnalysis;
using IAsset.MicroServices.FlightsAssignedToGates.Interfaces.Nancy;

namespace IAsset.MicroServices.FlightsAssignedToGates.Nancy
{
    [ExcludeFromCodeCoverage]
    public class FlightsAssignedToGates : IFlightsAssignedToGates
    {
        public int GateId { get; set; }
        public int[] FlightIds { get; set; }
    }
}