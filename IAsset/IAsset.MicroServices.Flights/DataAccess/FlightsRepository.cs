using IAsset.MicroServices.Common.DataAccess;
using IAsset.MicroServices.Flights.Interfaces.DataAccess;
using Selkie.Windsor;

namespace IAsset.MicroServices.Flights.DataAccess
{
    [ProjectComponent(Lifestyle.Singleton)]
    public class FlightsRepository
        : BaseRepository <IFlight>,
          IFlightsRepository
    {
    }
}