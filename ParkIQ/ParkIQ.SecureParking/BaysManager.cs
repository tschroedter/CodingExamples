using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces;
using ParkIQ.SecureParking.Interaces.Vehicles;
using Selkie.Windsor;

namespace ParkIQ.SecureParking
{
    [ProjectComponent(Lifestyle.Transient)]
    public class BaysManager
        : IBaysManager,
          IDisposable
    {
        private readonly IBay[] m_Bays;
        private readonly IBayFactory m_Factory;

        public BaysManager([NotNull] IBayFactory factory,
                           int numberOfBays)
        {
            m_Factory = factory;
            m_Bays = new IBay[numberOfBays];

            for ( var i = 0 ; i < m_Bays.Length ; i++ )
            {
                m_Bays [ i ] = factory.Create(i);
            }
        }

        public IEnumerable <IBay> Bays
        {
            get
            {
                return m_Bays;
            }
        }

        public int NumberOfBays
        {
            get
            {
                return m_Bays.Length;
            }
        }

        public int NumberOfEmptyBays
        {
            get
            {
                return m_Bays.Count(x => x.IsEmpty);
            }
        }

        public int NumberOfOccupiedBays
        {
            get
            {
                return NumberOfBays - NumberOfEmptyBays;
            }
        }

        public bool IsFull
        {
            get
            {
                return NumberOfBays == NumberOfOccupiedBays;
            }
        }

        public IEnumerable <IVehicle> Vehicles
        {
            get
            {
                return m_Bays.Select(x => x.Vehicle).Where(x => x != null);
            }
        }

        public void AssignBay(IVehicle vehicle)
        {
            IBay emptyBay = m_Bays.FirstOrDefault(x => x.IsEmpty);

            if ( emptyBay == null )
            {
                throw new NoEmptyBayException(vehicle);
            }

            emptyBay.Vehicle = vehicle;
        }

        public void ReleaseBay(IVehicle vehicle)
        {
            IBay assignedBay = m_Bays.FirstOrDefault(x => x.Vehicle == vehicle);

            if ( assignedBay == null )
            {
                throw new NoVehicleFoundInBaysException(vehicle);
            }

            assignedBay.Vehicle = null;
        }

        public int FindVehicleBayId(IVehicle vehicle)
        {
            IBay assignedBay = m_Bays.FirstOrDefault(x => x.Vehicle == vehicle);

            if ( assignedBay == null )
            {
                throw new NoVehicleFoundInBaysException(vehicle);
            }

            return assignedBay.Id;
        }

        public void Dispose()
        {
            foreach ( IBay bay in m_Bays )
            {
                m_Factory.Release(bay);
            }
        }
    }
}