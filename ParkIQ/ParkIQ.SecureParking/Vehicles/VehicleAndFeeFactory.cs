using System.Collections.Generic;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Fees;
using ParkIQ.SecureParking.Interaces.Vehicles;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Vehicles
{
    [ProjectComponent(Lifestyle.Transient)]
    public class VehicleAndFeeFactory : IVehicleAndFeeFactory
    {
        private int m_NextId = 1;

        public VehicleAndFeeFactory([NotNull] IVehicleFactory vehicleFactory,
                                    [NotNull] IFeesForVehicleFactory feeFactory)
        {
            VehicleFactory = vehicleFactory;
            FeeFactory = feeFactory;
        }

        public IVehicleFactory VehicleFactory { get; set; }
        public IFeesForVehicleFactory FeeFactory { get; set; }

        public T Create <T>(int weightInKilogram) where T : IVehicle
        {
            return ( T ) CreateVehicleWithFees <T>(weightInKilogram);
        }

        public void Release(IVehicle vehicle)
        {
            FeeFactory.Release(vehicle.Fees);
            VehicleFactory.Release(vehicle);
        }

        private IVehicle CreateVehicleWithFees <T>(int weightInKilogram)
            where T : IVehicle
        {
            IVehicle vehicle = VehicleFactory.Create <T>(GetNextId(),
                                                         weightInKilogram);

            IEnumerable <IFee> fees = FeeFactory.Create(vehicle);

            foreach ( IFee fee in fees )
            {
                vehicle.AddFee(fee);
            }

            return vehicle;
        }

        private int GetNextId()
        {
            return m_NextId++;
        }
    }
}