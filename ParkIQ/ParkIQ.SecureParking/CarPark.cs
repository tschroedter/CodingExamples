using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Interaces;
using ParkIQ.SecureParking.Interaces.Vehicles;
using Selkie.Windsor;

namespace ParkIQ.SecureParking
{
    [ProjectComponent(Lifestyle.Transient)]
    public class CarPark
        : ICarPark,
          IDisposable
    {
        private readonly IBaysManager m_BaysManager;

        public CarPark([NotNull] ISelkieLogger logger,
                       [NotNull] IBaysManagerFactory factory,
                       [NotNull] string name,
                       int numberOfBays)
        {
            Logger = logger;
            Factory = factory;
            Name = name;
            m_BaysManager = factory.Create(numberOfBays);
        }

        private IBaysManager BaysManager
        {
            get
            {
                return m_BaysManager;
            }
        }

        public ISelkieLogger Logger { get; set; }
        public IBaysManagerFactory Factory { get; set; }
        public string Name { get; private set; }

        public IEnumerable <IBay> Bays
        {
            get
            {
                return BaysManager.Bays;
            }
        }

        public IEnumerable <IVehicle> Vehicles
        {
            get
            {
                return m_BaysManager.Vehicles;
            }
        }

        public int NumberOfBays
        {
            get
            {
                return BaysManager.NumberOfBays;
            }
        }

        public int NumberOfOccupiedBays
        {
            get
            {
                return BaysManager.NumberOfOccupiedBays;
            }
        }

        public bool IsFull
        {
            get
            {
                return BaysManager.IsFull;
            }
        }

        public void Enter(IVehicle vehicle)
        {
            if ( m_BaysManager.IsFull )
            {
                throw new CarParkIsFullException(vehicle);
            }

            m_BaysManager.AssignBay(vehicle);

            Logger.Info("Vehicle '{0}' entered car park!".Inject(vehicle.Id));
        }

        public void Exit(IVehicle vehicle)
        {
            if ( !vehicle.IsFeePaid )
            {
                throw new CarDidNotPayFeeException(vehicle);
            }

            m_BaysManager.ReleaseBay(vehicle);

            Logger.Info("Vehicle '{0}' exited car park!".Inject(vehicle.Id));
        }

        public void Dispose()
        {
            Factory.Release(BaysManager);
        }
    }
}