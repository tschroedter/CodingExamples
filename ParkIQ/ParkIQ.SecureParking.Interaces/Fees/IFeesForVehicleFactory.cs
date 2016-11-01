using System.Collections.Generic;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Vehicles;

namespace ParkIQ.SecureParking.Interaces.Fees
{
    public interface IFeesForVehicleFactory
    {
        IEnumerable <IFee> Create([NotNull] IVehicle vehicle);
        void Release([NotNull] IEnumerable <IFee> fees);
    }
}