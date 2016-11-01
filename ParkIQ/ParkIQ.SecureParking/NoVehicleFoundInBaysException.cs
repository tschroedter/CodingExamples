using System;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Vehicles;

namespace ParkIQ.SecureParking
{
    public class NoVehicleFoundInBaysException : Exception
    {
        public NoVehicleFoundInBaysException([NotNull] IVehicle vehicle)
            :
                base("There is no bay with the car in the car park!")
        {
            Vehicle = vehicle;
        }

        public IVehicle Vehicle { get; private set; }
    }
}