using System;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Vehicles;

namespace ParkIQ.SecureParking
{
    public class CarDidNotPayFeeException : Exception
    {
        public CarDidNotPayFeeException([NotNull] IVehicle vehicle)
            :
                base("Car didn't pay the fee!")
        {
            Vehicle = vehicle;
        }

        public IVehicle Vehicle { get; private set; }
    }
}