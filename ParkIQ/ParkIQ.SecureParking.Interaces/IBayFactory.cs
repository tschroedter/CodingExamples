using JetBrains.Annotations;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Interaces
{
    public interface IBayFactory : ITypedFactory
    {
        IBay Create(int id);
        void Release([NotNull] IBay bay);
    }
}