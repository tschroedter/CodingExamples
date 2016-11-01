using System.Collections.Generic;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Fees;
using ParkIQ.SecureParking.Interaces.Vehicles;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Fees
{
    [ProjectComponent(Lifestyle.Transient)]
    public class FeesManager : IFeeManager
    {
        private readonly IFeesForVehicleFactory m_FeesForVehicleFactory;
        private readonly IVehicleFeesFactory m_VehicleFeesFactory;

        public FeesManager([NotNull] IFeesForVehicleFactory feesForVehicleFactory,
                          [NotNull] IVehicleFeesFactory vehicleFeesFactory)
        {
            m_FeesForVehicleFactory = feesForVehicleFactory;
            m_VehicleFeesFactory = vehicleFeesFactory;

            Fees = new Dictionary <IVehicle, IVehicleFees>();
        }

        // todo store vehicle id
        private Dictionary <IVehicle, IVehicleFees> Fees { get; set; }

        public void CreateFees(IVehicle vehicle)
        {
            IEnumerable <IFee> fees = m_FeesForVehicleFactory.Create(vehicle);
            IVehicleFees vehicleFees = m_VehicleFeesFactory.Create();

            vehicleFees.AddFees(fees);

            Fees.Add(vehicle,
                     vehicleFees);
        }

        public IVehicleFees GetFees(IVehicle vehicle)
        {
            if ( !Fees.ContainsKey(vehicle) )
            {
                throw new CarDoesNotHaveAnyFeesException(vehicle);
            }

            return Fees [ vehicle ];
        }

        public void DeleteFees(IVehicle vehicle)
        {
            if ( !Fees.ContainsKey(vehicle) )
            {
                return;
            }

            var vehicleFees = Fees [ vehicle ];
            Fees.Remove(vehicle);

            ReleaseFees(vehicleFees);
        }

        private void ReleaseFees(IVehicleFees vehicleFees)
        {
            m_FeesForVehicleFactory.Release(vehicleFees.Fees); // todo maybe better in vehicleFees
            m_VehicleFeesFactory.Release(vehicleFees);
        }
    }
}