using System.Collections.Generic;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Fees;

namespace ParkIQ.SecureParking.Interaces.Vehicles
{
    public interface IVehicle
    {
        int WeightInKilogram { get; }

        int Id { get; }

        bool IsFeePaid { get; }

        [NotNull]
        IEnumerable <IFee> Fees { get; }

        [NotNull]
        string ShortDescription { get; }

        void PaysFee();

        void AddFee([NotNull] IFee fee);
        bool ContainsFee([NotNull] IFee fee);
    }
}