using Nancy;

namespace IAsset.MicroServices.FlightsAssignedToGates.Interfaces.Nancy
{
    public interface IFlightsAssignedToGatesRequestHandler
    {
        Response FlightsAssignedToGate(int id);
        Response List();
    }
}