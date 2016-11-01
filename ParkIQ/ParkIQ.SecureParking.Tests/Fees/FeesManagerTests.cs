using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NSubstitute;
using NUnit.Framework;
using ParkIQ.SecureParking.Fees;
using ParkIQ.SecureParking.Interaces.Fees;
using ParkIQ.SecureParking.Interaces.Vehicles;

namespace ParkIQ.SecureParking.Tests.Fees
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class FeesManagerTests
    {
        private IFeeManager CreateSut(IFeesForVehicleFactory feesForVehicleFactory = null,
                                      IVehicleFeesFactory vehicleFeesFactory = null)
        {
            if ( feesForVehicleFactory == null )
            {
                feesForVehicleFactory = Substitute.For <IFeesForVehicleFactory>();
            }

            if ( vehicleFeesFactory == null )
            {
                vehicleFeesFactory = Substitute.For <IVehicleFeesFactory>();
            }

            var sut = new FeesManager(feesForVehicleFactory,
                                      vehicleFeesFactory);

            return sut;
        }

        [Test]
        public void CreateSut_CreatesVehicleFees_ForVehicle()
        {
            // Arrange
            var vehicle = Substitute.For <IStandardCar>();
            IFeeManager sut = CreateSut();

            // Act
            sut.CreateFees(vehicle);

            // Assert
            IVehicleFees actual = sut.GetFees(vehicle);

            Assert.NotNull(actual);
        }

        [Test]
        public void DeleteFees_RemovesFees_ForVehicle()
        {
            // Arrange
            var vehicle = Substitute.For <IStandardCar>();
            var factory = Substitute.For <IFeesForVehicleFactory>();

            IFeeManager sut = CreateSut(factory);
            sut.CreateFees(vehicle);

            // Act
            sut.DeleteFees(vehicle);

            // Assert
            factory.Received().Release(Arg.Any <IEnumerable <IFee>>());
        }

        [Test]
        public void DeleteFees_RemovesVehicleFees_ForVehicle()
        {
            // Arrange
            var vehicle = Substitute.For<IStandardCar>();
            var feefactory = Substitute.For<IFeesForVehicleFactory>();
            var vehicleFeesfactory = Substitute.For<IVehicleFeesFactory>();

            IFeeManager sut = CreateSut(feefactory,
                                        vehicleFeesfactory);
            sut.CreateFees(vehicle);

            // Act
            sut.DeleteFees(vehicle);

            // Assert
            vehicleFeesfactory.Received().Release(Arg.Any<IVehicleFees>());
        }

        [Test]
        public void DeleteFees_DoesNothing_ForUnknownVehicle()
        {
            // Arrange
            var vehicle = Substitute.For<IStandardCar>();
            var feefactory = Substitute.For<IFeesForVehicleFactory>();
            var vehicleFeesfactory = Substitute.For<IVehicleFeesFactory>();

            IFeeManager sut = CreateSut(feefactory,
                                        vehicleFeesfactory);

            // Act
            sut.DeleteFees(vehicle);

            // Assert
            vehicleFeesfactory.DidNotReceive().Release(Arg.Any<IVehicleFees>());
        }

        [Test]
        public void GetFees_ThrowsException_ForUnknownVehicle()
        {
            // Arrange
            var vehicle = Substitute.For <IStandardCar>();
            IFeeManager sut = CreateSut();

            // Act
            // Assert
            Assert.Throws <CarDoesNotHaveAnyFeesException>(() => sut.GetFees(vehicle));
        }
    }
}