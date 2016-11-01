using System;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Vehicles;

namespace ParkIQ.SecureParking
{
    public class NoEmptyBayException : Exception
    {
        public NoEmptyBayException([NotNull] IVehicle vehicle)
            : base("There is no empty bay!")
        {
            Vehicle = vehicle;
        }

        public IVehicle Vehicle { get; private set; }
    }
}