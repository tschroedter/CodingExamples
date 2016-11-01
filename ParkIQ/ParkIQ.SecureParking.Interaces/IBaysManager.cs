using System.Collections.Generic;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Vehicles;

namespace ParkIQ.SecureParking.Interaces
{
    public interface IBaysManager
    {
        [NotNull]
        IEnumerable <IBay> Bays { get; }

        int NumberOfBays { get; }
        int NumberOfEmptyBays { get; }
        int NumberOfOccupiedBays { get; }
        bool IsFull { get; }

        [NotNull]
        IEnumerable <IVehicle> Vehicles { get; }

        void AssignBay([NotNull] IVehicle vehicle);
        void ReleaseBay([NotNull] IVehicle vehicle);
        int FindVehicleBayId([NotNull] IVehicle vehicle);
    }
}