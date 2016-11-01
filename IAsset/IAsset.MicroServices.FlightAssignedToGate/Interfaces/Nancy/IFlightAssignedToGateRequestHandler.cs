using IAsset.MicroServices.Common.Nancy;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.DataAccess;
using Nancy;

namespace IAsset.MicroServices.FlightAssignedToGate.Interfaces.Nancy
{
    public interface IFlightAssignedToGateRequestHandler : IRequestHandler <IFlightAssignedToGate>
    {
        Response FlightsAssignedToGate(int id);
    }
}