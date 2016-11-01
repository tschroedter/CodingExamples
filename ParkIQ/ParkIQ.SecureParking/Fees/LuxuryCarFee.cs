using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Fees;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Fees
{
    [ProjectComponent(Lifestyle.Transient)]
    public class LuxuryCarFee : ILuxuryCarFee
    {
        private const int ThreeDollars = 3;

        private readonly IStandardCarFee m_StandardCar;

        public LuxuryCarFee([NotNull] IStandardCarFee standardCarFee)
        {
            m_StandardCar = standardCarFee;
        }

        public int Calculate()
        {
            return m_StandardCar.Calculate() + ThreeDollars;
        }
    }
}