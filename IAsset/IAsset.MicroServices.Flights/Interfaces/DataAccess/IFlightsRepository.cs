using IAsset.MicroServices.Common.DataAccess;

namespace IAsset.MicroServices.Flights.Interfaces.DataAccess
{
    public interface IFlightsRepository
        : IRepository <IFlight>
    {
    }
}