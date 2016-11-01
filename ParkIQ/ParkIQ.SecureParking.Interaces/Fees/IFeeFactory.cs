using JetBrains.Annotations;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Interaces.Fees
{
    public interface IFeeFactory : ITypedFactory
    {
        T Create <T>() where T : IFee;
        void Release([NotNull] IFee fee);
    }
}