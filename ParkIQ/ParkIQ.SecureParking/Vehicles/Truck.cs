using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Fees;
using ParkIQ.SecureParking.Interaces.Vehicles;

namespace ParkIQ.SecureParking.Vehicles
{
    public class Truck
        : BaseVehicle,
          ITruck
    {
        public Truck([NotNull] IVehicleFees vehicleFees,
                     int id,
                     int weightInKilogram)
            : base(vehicleFees,
                   id,
                   weightInKilogram)
        {
            ShortDescription = "Truck";
        }
    }
}