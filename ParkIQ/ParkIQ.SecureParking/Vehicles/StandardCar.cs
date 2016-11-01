using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Fees;
using ParkIQ.SecureParking.Interaces.Vehicles;

namespace ParkIQ.SecureParking.Vehicles
{
    public class StandardCar
        : BaseVehicle,
          IStandardCar
    {
        public StandardCar([NotNull] IVehicleFees vehicleFees,
                           int id,
                           int weightInKilogram)
            : base(vehicleFees,
                   id,
                   weightInKilogram)
        {
            ShortDescription = "StandardCar";
        }
    }
}