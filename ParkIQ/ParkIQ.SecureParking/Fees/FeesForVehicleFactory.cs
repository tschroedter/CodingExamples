using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Interaces.Fees;
using ParkIQ.SecureParking.Interaces.Vehicles;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Fees
{
    [ProjectComponent(Lifestyle.Transient)]
    public class FeesForVehicleFactory : IFeesForVehicleFactory
    {
        private readonly IFeeFactory m_FeeFactory;

        public FeesForVehicleFactory([NotNull] IFeeFactory feeFactory)
        {
            m_FeeFactory = feeFactory;
        }

        public IEnumerable <IFee> Create(IVehicle vehicle)
        {
            var fees = new List <IFee>();

            AddCommonFees(fees,
                          vehicle);

            // todo move into table or use AOP
            if ( vehicle is IStandardCar )
            {
                var fee = m_FeeFactory.Create <IStandardCarFee>();
                fees.Add(fee);
            }
            else if ( vehicle is ILuxuryCar )
            {
                var fee = m_FeeFactory.Create <ILuxuryCarFee>();
                fees.Add(fee);
            }
            else if ( vehicle is IMotorbike )
            {
                var fee = m_FeeFactory.Create <IMotorbikeFee>();
                fees.Add(fee);
            }
            else if ( vehicle is ITruck )
            {
                var fee = m_FeeFactory.Create <ITruckFee>();
                fees.Add(fee);
            }
            else
            {
                throw new ArgumentException("Can't create vehicle for type '{0}'!".Inject(vehicle.GetType()));
            }

            return fees;
        }

        public void Release(IEnumerable <IFee> fees)
        {
            foreach ( IFee fee in fees )
            {
                m_FeeFactory.Release(fee);
            }
        }

        private void AddCommonFees([NotNull] List <IFee> fees,
                                   [NotNull] IVehicle vehicle)
        {
            AddWeightFeeIfRequired(fees,
                                   vehicle);

            var vehicleFee = m_FeeFactory.Create <IVehicleFee>();
            fees.Add(vehicleFee);
        }

        private void AddWeightFeeIfRequired([NotNull] List <IFee> fees,
                                            [NotNull] IVehicle vehicle)
        {
            if ( vehicle.WeightInKilogram > 100 )
            {
                var weightFee = m_FeeFactory.Create <IWeightFee>();

                fees.Add(weightFee);
            }
        }
    }
}