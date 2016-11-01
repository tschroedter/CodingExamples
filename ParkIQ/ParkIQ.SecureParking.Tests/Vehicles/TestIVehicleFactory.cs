using System;
using System.Diagnostics.CodeAnalysis;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Fees;
using ParkIQ.SecureParking.Interaces.Vehicles;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking.Tests.Vehicles
{
    [ExcludeFromCodeCoverage]
    public sealed class TestIVehicleFactory : IVehicleFactory
    {
        public T Create <T>(int id,
                            int weightInKilogram) where T : IVehicle
        {
            if ( typeof ( T ) == typeof ( IStandardCar ) )
            {
                IVehicle car = new StandardCar(new VehicleFees(new FeeCalculator()),
                                               id,
                                               weightInKilogram);
                return ( T ) car;
            }
            if ( typeof ( T ) == typeof ( ILuxuryCar ) )
            {
                IVehicle car = new LuxuryCar(new VehicleFees(new FeeCalculator()),
                                             id,
                                             weightInKilogram);
                return ( T ) car;
            }
            if ( typeof ( T ) == typeof ( IMotorbike ) )
            {
                IVehicle car = new Motorbike(new VehicleFees(new FeeCalculator()),
                                             id,
                                             weightInKilogram);
                return ( T ) car;
            }
            if ( typeof ( T ) == typeof ( ITruck ) )
            {
                IVehicle car = new Truck(new VehicleFees(new FeeCalculator()),
                                         id,
                                         weightInKilogram);
                return ( T ) car;
            }

            throw new ArgumentException("Unknown vehicle type '{0}'!".Inject(typeof ( T )));
        }

        public void Release(IVehicle vehicle)
        {
        }
    }
}