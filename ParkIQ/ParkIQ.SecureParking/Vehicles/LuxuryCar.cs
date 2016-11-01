using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Fees;
using ParkIQ.SecureParking.Interaces.Vehicles;

namespace ParkIQ.SecureParking.Vehicles
{
    public class LuxuryCar
        : BaseVehicle,
          ILuxuryCar
    {
        public LuxuryCar([NotNull] IVehicleFees vehicleFees,
                         int id,
                         int weightInKilogram)
            : base(vehicleFees,
                   id,
                   weightInKilogram)
        {
            ShortDescription = "LuxuryCar";
        }
    }
}