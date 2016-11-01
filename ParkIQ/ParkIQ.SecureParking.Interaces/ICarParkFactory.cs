using JetBrains.Annotations;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Interaces
{
    public interface ICarParkFactory : ITypedFactory
    {
        ICarPark Create([NotNull] string name,
                        int numberOfBays);

        void Release([NotNull] ICarPark carPark);
    }
}