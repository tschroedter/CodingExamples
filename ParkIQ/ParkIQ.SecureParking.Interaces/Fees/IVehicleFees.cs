using System.Collections.Generic;

namespace ParkIQ.SecureParking.Interaces.Fees
{
    public interface IVehicleFees
    {
        bool IsFeePaid { get; }
        IEnumerable <IFee> Fees { get; }
        void AddFee(IFee fee);
        void RemoveFee(IFee fee);
        bool ContainsFee(IFee fee);
        void FeeIsPaid();
        int Calulate();
        void AddFees(IEnumerable <IFee> fees);
    }
}