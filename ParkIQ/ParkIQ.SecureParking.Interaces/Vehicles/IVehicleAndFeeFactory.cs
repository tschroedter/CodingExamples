using JetBrains.Annotations;

namespace ParkIQ.SecureParking.Interaces.Vehicles
{
    public interface IVehicleAndFeeFactory
    {
        T Create <T>(int weightInKilogram) where T : IVehicle;
        void Release([NotNull] IVehicle vehicle);
    }
}