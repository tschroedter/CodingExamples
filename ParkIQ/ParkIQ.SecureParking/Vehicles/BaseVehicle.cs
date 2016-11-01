using System.Collections.Generic;
using JetBrains.Annotations;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Interaces.Fees;
using ParkIQ.SecureParking.Interaces.Vehicles;

namespace ParkIQ.SecureParking.Vehicles
{
    public abstract class BaseVehicle : IVehicle
    {
        protected BaseVehicle([NotNull] IVehicleFees vehicleFees,
                              int id,
                              int weightInKilogram)
        {
            VehicleFees = vehicleFees;
            Id = id;
            WeightInKilogram = weightInKilogram;
            ShortDescription = string.Empty;
        }

        private IVehicleFees VehicleFees { get; set; }

        public string ShortDescription { get; protected set; }

        public int WeightInKilogram { get; private set; }

        public int Id { get; private set; }

        public bool IsFeePaid
        {
            get
            {
                return VehicleFees.IsFeePaid;
            }
        }

        public IEnumerable <IFee> Fees
        {
            get
            {
                return VehicleFees.Fees;
            }
        }

        public void PaysFee()
        {
            VehicleFees.FeeIsPaid();
        }

        public void AddFee(IFee fee)
        {
            VehicleFees.AddFee(fee);
        }

        public bool ContainsFee(IFee fee)
        {
            return VehicleFees.ContainsFee(fee);
        }

        public override string ToString()
        {
            return "Id: {0} ShortDescription: {1} Fees: {2} IsFeePaid: {3}".Inject(Id,
                                                                                   ShortDescription,
                                                                                   VehicleFees.Calulate(),
                                                                                   IsFeePaid);
        }
    }
}