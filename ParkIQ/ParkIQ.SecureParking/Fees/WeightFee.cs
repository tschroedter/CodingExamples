using ParkIQ.SecureParking.Interaces.Fees;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Fees
{
    [ProjectComponent(Lifestyle.Transient)]
    public class WeightFee : IWeightFee
    {
        private const int ThreeDollars = 3;

        public int Calculate()
        {
            return ThreeDollars;
        }
    }
}