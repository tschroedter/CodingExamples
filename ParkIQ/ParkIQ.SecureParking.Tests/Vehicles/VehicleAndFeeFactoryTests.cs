using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using ParkIQ.SecureParking.Fees;
using ParkIQ.SecureParking.Interaces.Fees;
using ParkIQ.SecureParking.Interaces.Vehicles;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking.Tests.Vehicles
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class VehicleAndFeeFactoryTests
    {
        private const int DoesNotMatterWeight = 1;
        private const int DefaultWeight = 100;
        private const int MinWeightInKilogramToForceWeightFee = 101;

        private static VehicleAndFeeFactory CreateSut(IVehicleFactory vehicleFactory = null,
                                                      IFeesForVehicleFactory feeFactory = null)
        {
            if ( vehicleFactory == null )
            {
                vehicleFactory = new TestIVehicleFactory();
            }

            if ( feeFactory == null )
            {
                feeFactory = new FeesForVehicleFactory(new TestIFeeFactory());
            }

            var sut = new VehicleAndFeeFactory(vehicleFactory,
                                               feeFactory);

            return sut;
        }

        [Test]
        public void Create_ReturnsCallsVehicleFactory_WithGivenWeight()
        {
            // Arrange
            var factory = Substitute.For <IVehicleFactory>();
            VehicleAndFeeFactory sut = CreateSut(factory);

            // Act
            sut.Create <IStandardCar>(DefaultWeight);

            // Assert
            factory.Received().Create <IStandardCar>(1,
                                                     DefaultWeight);
        }

        [Test]
        public void Create_ReturnsVehicle_WhenCalled()
        {
            // Arrange
            var factory = Substitute.For <IVehicleFactory>();
            VehicleAndFeeFactory sut = CreateSut(factory);

            // Act
            var actual = sut.Create <IStandardCar>(DefaultWeight);

            // Assert
            Assert.NotNull(actual,
                           "Should not be null!");
        }

        [Test]
        public void Create_ReturnsVehicleWithDifferentIds_ForSameVehicleType()
        {
            // Arrange
            VehicleAndFeeFactory sut = CreateSut();

            // Act
            var one = sut.Create <ITruck>(DoesNotMatterWeight);
            var two = sut.Create <ITruck>(DoesNotMatterWeight);

            // Assert
            Assert.AreNotEqual(one.Id,
                               two.Id);
        }

        [Test]
        public void Create_ReturnsVehicleWithDifferentIds_ForVehicles()
        {
            // Arrange
            VehicleAndFeeFactory sut = CreateSut();

            // Act
            var one = sut.Create <IStandardCar>(DoesNotMatterWeight);
            var two = sut.Create <ILuxuryCar>(DoesNotMatterWeight);
            var three = sut.Create <IMotorbike>(DoesNotMatterWeight);
            var four = sut.Create <ITruck>(DoesNotMatterWeight);

            // Assert
            Assert.AreEqual(1,
                            one.Id,
                            "one.Id");
            Assert.AreEqual(2,
                            two.Id,
                            "two.Id");
            Assert.AreEqual(3,
                            three.Id,
                            "three.Id");
            Assert.AreEqual(4,
                            four.Id,
                            "four.Id");
        }

        [Test]
        public void Create_ReturnsVehicleWithLuxuryCarFee_ForVehicleTypeLuxuryCar()
        {
            // Arrange
            VehicleAndFeeFactory sut = CreateSut();

            // Act
            var actual = sut.Create <ILuxuryCar>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is ILuxuryCarFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithMotorbikeFee_ForVehicleTypeMotorbike()
        {
            // Arrange
            VehicleAndFeeFactory sut = CreateSut();

            // Act
            var actual = sut.Create <IMotorbike>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is IMotorbikeFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithStandardCarFee_ForVehicleTypeStandardCar()
        {
            // Arrange
            VehicleAndFeeFactory sut = CreateSut();

            // Act
            var actual = sut.Create <IStandardCar>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is IStandardCarFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithTruckFee_ForVehicleTypeTruck()
        {
            // Arrange
            VehicleAndFeeFactory sut = CreateSut();

            // Act
            var actual = sut.Create <ITruck>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is ITruckFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeLuxuryCar()
        {
            // Arrange
            VehicleAndFeeFactory sut = CreateSut();

            // Act
            var actual = sut.Create <ILuxuryCar>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is IVehicleFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeMotorbike()
        {
            // Arrange
            VehicleAndFeeFactory sut = CreateSut();

            // Act
            var actual = sut.Create <IMotorbike>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is IVehicleFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeStandardCar()
        {
            // Arrange
            VehicleAndFeeFactory sut = CreateSut();

            // Act
            var actual = sut.Create <IStandardCar>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is IVehicleFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeTruck()
        {
            // Arrange
            VehicleAndFeeFactory sut = CreateSut();

            // Act
            var actual = sut.Create <ITruck>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is IVehicleFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithWeightFee_ForLuxuryCarAndHeavyVehicle()
        {
            // Arrange
            VehicleAndFeeFactory sut = CreateSut();

            // Act
            var actual = sut.Create <ILuxuryCar>(MinWeightInKilogramToForceWeightFee);

            // Assert
            Assert.True(actual.Fees.Any(x => x is IWeightFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithWeightFee_ForMotorbikeAndHeavyVehicle()
        {
            // Arrange
            VehicleAndFeeFactory sut = CreateSut();

            // Act
            var actual = sut.Create <IMotorbike>(MinWeightInKilogramToForceWeightFee);

            // Assert
            Assert.True(actual.Fees.Any(x => x is IWeightFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithWeightFee_ForStandardCarAndHeavyVehicle()
        {
            // Arrange
            VehicleAndFeeFactory sut = CreateSut();

            // Act
            var actual = sut.Create <IStandardCar>(MinWeightInKilogramToForceWeightFee);

            // Assert
            Assert.True(actual.Fees.Any(x => x is IWeightFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithWeightFee_ForTruckAndHeavyVehicle()
        {
            // Arrange
            VehicleAndFeeFactory sut = CreateSut();

            // Act
            var actual = sut.Create <ITruck>(MinWeightInKilogramToForceWeightFee);

            // Assert
            Assert.True(actual.Fees.Any(x => x is IWeightFee));
        }

        [Test]
        public void Release_CallsFeeFactory_WhenCalled()
        {
            // Arrange
            var vehicleFactory = Substitute.For <IVehicleFactory>();
            var feeFactory = Substitute.For <IFeesForVehicleFactory>();
            VehicleAndFeeFactory sut = CreateSut(vehicleFactory,
                                                 feeFactory);
            var vehicle = sut.Create <IStandardCar>(DefaultWeight);

            // Act
            sut.Release(vehicle);

            // Assert
            feeFactory.Received().Release(Arg.Any <IEnumerable <IFee>>());
        }

        [Test]
        public void Release_CallsVehicleFactory_WhenCalled()
        {
            // Arrange
            var vehicleFactory = Substitute.For <IVehicleFactory>();
            var feeFactory = Substitute.For <IFeesForVehicleFactory>();
            VehicleAndFeeFactory sut = CreateSut(vehicleFactory,
                                                 feeFactory);
            var vehicle = sut.Create <IStandardCar>(DefaultWeight);

            // Act
            sut.Release(vehicle);

            // Assert
            vehicleFactory.Received().Release(Arg.Any <IVehicle>());
        }
    }
}