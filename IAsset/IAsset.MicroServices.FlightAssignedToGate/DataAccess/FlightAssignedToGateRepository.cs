using IAsset.MicroServices.Common.DataAccess;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.DataAccess;
using Selkie.Windsor;

namespace IAsset.MicroServices.FlightAssignedToGate.DataAccess
{
    [ProjectComponent(Lifestyle.Singleton)]
    public class FlightAssignedToGateRepository
        : BaseRepository <IFlightAssignedToGate>,
          IFlightAssignedToGateRepository
    {
    }
}