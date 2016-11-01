using JetBrains.Annotations;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Interaces.Vehicles
{
    public interface IVehicleFactory : ITypedFactory
    {
        T Create <T>(int id,
                     int weightInKilogram) where T : IVehicle;

        void Release([NotNull] IVehicle vehicle);
    }
}