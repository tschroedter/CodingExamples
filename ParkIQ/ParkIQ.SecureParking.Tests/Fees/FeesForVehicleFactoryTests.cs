using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using ParkIQ.SecureParking.Fees;
using ParkIQ.SecureParking.Interaces.Fees;
using ParkIQ.SecureParking.Interaces.Vehicles;

namespace ParkIQ.SecureParking.Tests.Fees
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class FeesForVehicleFactoryTests
    {
        private const int MinWeightInKilogramToForceWeightFee = 101;

        private FeesForVehicleFactory CreateSut(IFeeFactory factory = null)
        {
            if ( factory == null )
            {
                factory = Substitute.For <IFeeFactory>();
            }

            var sut = new FeesForVehicleFactory(factory);

            return sut;
        }

        [Test]
        public void Create_ReturnsVehicleWithLuxuryCarFee_ForVehicleTypeLuxuryCar()
        {
            // Arrange
            var vehicle = Substitute.For <ILuxuryCar>();
            FeesForVehicleFactory sut = CreateSut();

            // Act
            IEnumerable <IFee> actual = sut.Create(vehicle);

            // Assert
            Assert.True(actual.Any(x => x is ILuxuryCarFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithMotorbikeFee_ForVehicleTypeMotorbike()
        {
            // Arrange
            var vehicle = Substitute.For <IMotorbike>();
            FeesForVehicleFactory sut = CreateSut();

            // Act
            IEnumerable <IFee> actual = sut.Create(vehicle);

            // Assert
            Assert.True(actual.Any(x => x is IMotorbikeFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithStandardCarFee_ForVehicleTypeStandardCar()
        {
            // Arrange
            var vehicle = Substitute.For <IStandardCar>();
            FeesForVehicleFactory sut = CreateSut();

            // Act
            IEnumerable <IFee> actual = sut.Create(vehicle);

            // Assert
            Assert.True(actual.Any(x => x is IStandardCarFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithTruckFee_ForVehicleTypeTruck()
        {
            // Arrange
            var vehicle = Substitute.For <ITruck>();
            FeesForVehicleFactory sut = CreateSut();

            // Act
            IEnumerable <IFee> actual = sut.Create(vehicle);

            // Assert
            Assert.True(actual.Any(x => x is ITruckFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeLuxuryCar()
        {
            // Arrange
            var vehicle = Substitute.For <ILuxuryCar>();
            FeesForVehicleFactory sut = CreateSut();

            // Act
            IEnumerable <IFee> actual = sut.Create(vehicle);

            // Assert
            Assert.True(actual.Any(x => x is IVehicleFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeMotorbike()
        {
            // Arrange
            var vehicle = Substitute.For <IMotorbike>();
            FeesForVehicleFactory sut = CreateSut();

            // Act
            IEnumerable <IFee> actual = sut.Create(vehicle);

            // Assert
            Assert.True(actual.Any(x => x is IVehicleFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeStandardCar()
        {
            // Arrange
            var vehicle = Substitute.For <IStandardCar>();
            FeesForVehicleFactory sut = CreateSut();

            // Act
            IEnumerable <IFee> actual = sut.Create(vehicle);

            // Assert
            Assert.True(actual.Any(x => x is IVehicleFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeTruck()
        {
            // Arrange
            var vehicle = Substitute.For <ITruck>();
            FeesForVehicleFactory sut = CreateSut();

            // Act
            IEnumerable <IFee> actual = sut.Create(vehicle);

            // Assert
            Assert.True(actual.Any(x => x is IVehicleFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithWeightFee_ForLuxuryCarAndHeavyVehicle()
        {
            // Arrange
            var vehicle = Substitute.For <ILuxuryCar>();
            vehicle.WeightInKilogram.Returns(MinWeightInKilogramToForceWeightFee);
            FeesForVehicleFactory sut = CreateSut();

            // Act
            IEnumerable <IFee> actual = sut.Create(vehicle);

            // Assert
            Assert.True(actual.Any(x => x is IWeightFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithWeightFee_ForMotorbikeAndHeavyVehicle()
        {
            // Arrange
            var vehicle = Substitute.For <IMotorbike>();
            vehicle.WeightInKilogram.Returns(MinWeightInKilogramToForceWeightFee);
            FeesForVehicleFactory sut = CreateSut();

            // Act
            IEnumerable <IFee> actual = sut.Create(vehicle);

            // Assert
            Assert.True(actual.Any(x => x is IWeightFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithWeightFee_ForStandardCarAndHeavyVehicle()
        {
            // Arrange
            var vehicle = Substitute.For <IStandardCar>();
            vehicle.WeightInKilogram.Returns(MinWeightInKilogramToForceWeightFee);
            FeesForVehicleFactory sut = CreateSut();

            // Act
            IEnumerable <IFee> actual = sut.Create(vehicle);

            // Assert
            Assert.True(actual.Any(x => x is IWeightFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithWeightFee_ForTruckAndHeavyVehicle()
        {
            // Arrange
            var vehicle = Substitute.For <ITruck>();
            vehicle.WeightInKilogram.Returns(MinWeightInKilogramToForceWeightFee);
            FeesForVehicleFactory sut = CreateSut();

            // Act
            IEnumerable <IFee> actual = sut.Create(vehicle);

            // Assert
            Assert.True(actual.Any(x => x is IWeightFee));
        }

        [Test]
        public void Release_CallsFactory_ForFees()
        {
            // Arrange
            var truckFee = Substitute.For <ITruckFee>();
            var vehicleFee = Substitute.For <IVehicleFee>();
            var vehicle = Substitute.For <ITruck>();
            var factory = Substitute.For <IFeeFactory>();
            factory.Create <IVehicleFee>().Returns(vehicleFee);
            factory.Create <ITruckFee>().Returns(truckFee);
            FeesForVehicleFactory sut = CreateSut(factory);
            IEnumerable <IFee> fees = sut.Create(vehicle);

            // Act
            sut.Release(fees);

            // Assert
            factory.Received(2).Release(Arg.Any <IFee>());
        }

        [Test]
        public void ThrowsException_ForUnknowVehicleType()
        {
            // Arrange
            var vehicle = Substitute.For <IVehicle>();
            vehicle.WeightInKilogram.Returns(MinWeightInKilogramToForceWeightFee);
            FeesForVehicleFactory sut = CreateSut();

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.Create(vehicle));
        }
    }
}