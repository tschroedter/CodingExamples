using ParkIQ.SecureParking.Interaces.Fees;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Fees
{
    [ProjectComponent(Lifestyle.Transient)]
    public class TruckFee : ITruckFee
    {
        private const int TenDollars = 10;

        public int Calculate()
        {
            return TenDollars;
        }
    }
}