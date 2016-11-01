using System;
using ParkIQ.SecureParking.Interaces.Fees;

namespace ParkIQ.SecureParking.Fees
{
    public class FeeAlreadyAddedException : Exception
    {
        public FeeAlreadyAddedException()
            : base("You can't add the same fee twice!")
        {
        }

        public FeeAlreadyAddedException(IFee fee)
        {
            Fee = fee;
        }

        public IFee Fee { get; private set; }
    }
}