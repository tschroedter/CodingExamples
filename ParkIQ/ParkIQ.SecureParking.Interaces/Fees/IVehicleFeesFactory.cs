using JetBrains.Annotations;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Interaces.Fees
{
    public interface IVehicleFeesFactory : ITypedFactory
    {
        IVehicleFees Create();
        void Release([NotNull] IVehicleFees vehicleFees);
    }
}