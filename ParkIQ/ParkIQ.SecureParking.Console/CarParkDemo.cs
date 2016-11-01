using System;
using System.Diagnostics.CodeAnalysis;
using Castle.Windsor;
using JetBrains.Annotations;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Interaces;
using ParkIQ.SecureParking.Interaces.Vehicles;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Console
{
    [ExcludeFromCodeCoverage]
    public class CarParkDemo : IDisposable
    {
        private const int DoesNotMatterWeightInKilogram = 1;
        private readonly IWindsorContainer m_Container;

        public CarParkDemo([NotNull] IWindsorContainer container)
        {
            m_Container = container;
            VehicleFactory = container.Resolve <IVehicleFactory>();
            Logger = m_Container.Resolve <ISelkieLogger>();

            VehicleAndFeeFactory = container.Resolve <IVehicleAndFeeFactory>();
            CreateVehicles();

            // 1.	Initialise the car park with 10 bays and a name of “Test carpark”
            var carParkFactory = container.Resolve <ICarParkFactory>();
            CarPark = carParkFactory.Create("Test carpark",
                                            10);
        }

        public ISelkieLogger Logger { get; private set; }

        public IVehicleFactory VehicleFactory { get; private set; }

        private IVehicleAndFeeFactory VehicleAndFeeFactory { get; set; }
        private IVehicle StandardCar { get; set; }
        private IVehicle LuxuryCar { get; set; }
        private IVehicle Motorbike { get; set; }
        private IVehicle MotorbikeOther { get; set; }
        private IVehicle Truck { get; set; }
        private ICarPark CarPark { get; set; }

        public void Dispose()
        {
            m_Container.Dispose();
        }

        private void CreateVehicles()
        {
            StandardCar = VehicleAndFeeFactory.Create <IStandardCar>(DoesNotMatterWeightInKilogram);
            LuxuryCar = VehicleAndFeeFactory.Create <ILuxuryCar>(DoesNotMatterWeightInKilogram);
            Motorbike = VehicleAndFeeFactory.Create <IMotorbike>(DoesNotMatterWeightInKilogram);
            Truck = VehicleAndFeeFactory.Create <ITruck>(101);
            MotorbikeOther = VehicleAndFeeFactory.Create <IMotorbike>(DoesNotMatterWeightInKilogram);
        }

        public void Run()
        {
            try
            {
                CarsOfEachTypeEntering();
                ListVehicleDetails();
                LuxuryCarPaysFee();
                ListVehicleDetails();
                LuxuryCarExits();
                ListVehicleDetails();
                PayFeesForAllOtherCars();
                AllOtherCarsExits();
                ListVehicleDetails();
                MotorbikeEntering();
                MotorbikeExits();
                ListVehicleDetails();
            }
            catch ( Exception ex )
            {
                Logger.Error("Exception: {0}".Inject(ex.Message), ex);
            }
        }

        private void CarsOfEachTypeEntering()
        {
            // 2.	Have one of each type of vehicles enter the car park. The truck should have a weight of 101 kg.
            CarPark.Enter(StandardCar);
            CarPark.Enter(LuxuryCar);
            CarPark.Enter(Motorbike);
            CarPark.Enter(Truck);
        }

        private void ListVehicleDetails()
        {
            // 3.	List the details of all the vehicles in the car park including their type and outstanding fees.
            Logger.Info("\r\n\t\tVehicle Details");

            foreach ( IVehicle vehicle in CarPark.Vehicles )
            {
                Logger.Info("\t\t{0}".Inject(vehicle));
            }

            Logger.Info("");
        }

        private void LuxuryCarPaysFee()
        {
            // 4.	Pay the outstanding fee for the luxury car
            LuxuryCar.PaysFee();
        }

        private void LuxuryCarExits()
        {
            // 6.	Have the luxury car exit the car park
            CarPark.Exit(LuxuryCar);
        }

        private void PayFeesForAllOtherCars()
        {
            // 8.	Pay the outstanding fees for the remaining cars
            StandardCar.PaysFee();
            Motorbike.PaysFee();
            Truck.PaysFee();
        }

        private void AllOtherCarsExits()
        {
            // 9.	Have the remaining cars exit the car park
            CarPark.Exit(StandardCar);
            CarPark.Exit(Motorbike);
            CarPark.Exit(Truck);
        }

        private void MotorbikeEntering()
        {
            // 11.	Have a motorbike enter the car park
            CarPark.Enter(MotorbikeOther);
        }

        private void MotorbikeExits()
        {
            // 11.	Have a motorbike enter the car park
            CarPark.Exit(MotorbikeOther);
        }
    }
}