using System;
using System.Diagnostics.CodeAnalysis;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Fees;
using ParkIQ.SecureParking.Interaces.Fees;

namespace ParkIQ.SecureParking.Tests.Vehicles
{
    [ExcludeFromCodeCoverage]
    public sealed class TestIFeeFactory : IFeeFactory
    {
        public T Create <T>() where T : IFee
        {
            if ( typeof ( T ) == typeof ( IStandardCarFee ) )
            {
                IFee fee = new StandardCarFee();

                return ( T ) fee;
            }

            if ( typeof ( T ) == typeof ( ILuxuryCarFee ) )
            {
                IFee fee = new LuxuryCarFee(new StandardCarFee());

                return ( T ) fee;
            }

            if ( typeof ( T ) == typeof ( IMotorbikeFee ) )
            {
                IFee fee = new MotorbikeFee();

                return ( T ) fee;
            }

            if ( typeof ( T ) == typeof ( ITruckFee ) )
            {
                IFee fee = new TruckFee();

                return ( T ) fee;
            }

            if ( typeof ( T ) == typeof ( IWeightFee ) )
            {
                IFee fee = new WeightFee();

                return ( T ) fee;
            }

            if ( typeof ( T ) == typeof ( IVehicleFee ) )
            {
                IFee fee = new VehicleFee();

                return ( T ) fee;
            }

            throw new ArgumentException("Unknown vehicle type '{0}'!".Inject(typeof ( T )));
        }

        public void Release(IFee fee)
        {
        }
    }
}