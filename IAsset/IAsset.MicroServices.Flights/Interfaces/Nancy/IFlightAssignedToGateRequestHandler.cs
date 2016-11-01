using IAsset.MicroServices.Common.Nancy;
using IAsset.MicroServices.Flights.Interfaces.DataAccess;

namespace IAsset.MicroServices.Flights.Interfaces.Nancy
{
    public interface IFlightsRequestHandler : IRequestHandler <IFlight>
    {
    }
}