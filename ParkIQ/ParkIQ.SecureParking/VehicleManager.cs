using Selkie.Windsor;

namespace ParkIQ.SecureParking
{
    [ProjectComponent(Lifestyle.Transient)]
    public class VehicleManager : IVehicleManager
    {
        // todo
    }

    public interface IVehicleManager
    {
    }
}