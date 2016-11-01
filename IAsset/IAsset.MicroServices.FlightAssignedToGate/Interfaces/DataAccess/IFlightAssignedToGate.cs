using IAsset.MicroServices.Common.DataAccess;

namespace IAsset.MicroServices.FlightAssignedToGate.Interfaces.DataAccess
{
    public interface IFlightAssignedToGate : IEntity
    {
        int GateId { get; set; }
        int FlightId { get; set; }
    }
}