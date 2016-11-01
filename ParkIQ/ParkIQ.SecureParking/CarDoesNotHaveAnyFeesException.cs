using System;
using JetBrains.Annotations;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Interaces.Vehicles;

namespace ParkIQ.SecureParking
{
    public class CarDoesNotHaveAnyFeesException : Exception
    {
        public readonly IVehicle Vehicle;

        public CarDoesNotHaveAnyFeesException([NotNull] IVehicle vehicle)
            : base("Car with Id '{0}'doesn't have any fees assigned!".Inject(vehicle.Id))
        {
            Vehicle = vehicle;
        }
    }
}