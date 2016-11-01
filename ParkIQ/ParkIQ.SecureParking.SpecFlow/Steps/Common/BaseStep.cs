using System;
using Castle.Windsor;
using JetBrains.Annotations;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Interaces;
using ParkIQ.SecureParking.Interaces.Vehicles;
using TechTalk.SpecFlow;

namespace ParkIQ.SecureParking.SpecFlow.Steps.Common
{
    [Binding]
    public abstract class BaseStep
    {
        protected IWindsorContainer Container
        {
            get
            {
                return ( IWindsorContainer ) ScenarioContext.Current [ "WindsorContainer" ];
            }
            set
            {
                ScenarioContext.Current [ "WindsorContainer" ] = value;
            }
        }

        protected IVehicleAndFeeFactory VehicleAndFeeFactory
        {
            get
            {
                if ( !ScenarioContext.Current.ContainsKey("VehicleAndFeeFactory") )
                {
                    ScenarioContext.Current [ "VehicleAndFeeFactory" ] = Container.Resolve <IVehicleAndFeeFactory>();
                }

                return ( IVehicleAndFeeFactory ) ScenarioContext.Current [ "VehicleAndFeeFactory" ];
            }
        }

        protected ICarPark CarPark
        {
            get
            {
                return ( ICarPark ) ScenarioContext.Current [ "CarPark" ];
            }
            set
            {
                ScenarioContext.Current [ "CarPark" ] = value;
            }
        }

        protected IVehicle CreateVehicle([NotNull] string vehicleTypeString,
                                         int weightInKilogram)
        {
            switch ( vehicleTypeString )
            {
                case "StandardCar":
                    return VehicleAndFeeFactory.Create <IStandardCar>(weightInKilogram);

                case "LuxuryCar":
                    return VehicleAndFeeFactory.Create <ILuxuryCar>(weightInKilogram);

                case "Motorbike":
                    return VehicleAndFeeFactory.Create <IMotorbike>(weightInKilogram);

                case "Truck":
                    return VehicleAndFeeFactory.Create <ITruck>(weightInKilogram);

                default:
                    throw new ArgumentException("Unknown vehivle type '{0}'!".Inject(vehicleTypeString));
            }
        }
    }
}