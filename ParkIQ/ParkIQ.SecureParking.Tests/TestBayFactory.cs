using System.Diagnostics.CodeAnalysis;
using ParkIQ.SecureParking.Interaces;

namespace ParkIQ.SecureParking.Tests
{
    [ExcludeFromCodeCoverage]
    internal sealed class TestBayFactory : IBayFactory
    {
        public IBay Create(int id)
        {
            return new Bay(id);
        }

        public void Release(IBay bay)
        {
        }
    }
}