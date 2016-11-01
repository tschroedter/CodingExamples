using System.Collections.Generic;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Vehicles;

namespace ParkIQ.SecureParking.Interaces
{
    public interface ICarPark
    {
        string Name { get; }
        IEnumerable <IBay> Bays { get; }
        IEnumerable <IVehicle> Vehicles { get; }
        int NumberOfBays { get; }
        int NumberOfOccupiedBays { get; }
        bool IsFull { get; }
        void Enter([NotNull] IVehicle vehicle);
        void Exit([NotNull] IVehicle vehicle);
    }
}