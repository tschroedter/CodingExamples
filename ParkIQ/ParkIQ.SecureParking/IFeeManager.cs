using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Fees;
using ParkIQ.SecureParking.Interaces.Vehicles;

namespace ParkIQ.SecureParking
{
    public interface IFeeManager
    {
        void CreateFees([NotNull] IVehicle vehicle);
        IVehicleFees GetFees([NotNull] IVehicle vehicle);
        void DeleteFees([NotNull] IVehicle vehicle);
    }
}