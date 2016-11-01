using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using NSubstitute;
using NUnit.Framework;
using ParkIQ.SecureParking.Interaces.Fees;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking.Tests.Vehicles
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class BaseVehicleTests
    {
        private class TestBaseVehilce : BaseVehicle
        {
            public TestBaseVehilce([NotNull] IVehicleFees vehicleFees,
                                   int id,
                                   int weightInKilogram)
                : base(vehicleFees,
                       id,
                       weightInKilogram)
            {
            }
        }

        private const int DefaultId = 1;
        private const int DefaultWeightInKilogram = 2;

        [Test]
        public void Constructor_SetsId_WhenCalled()
        {
            // Arrange
            var fees = Substitute.For <IVehicleFees>();
            var sut = new TestBaseVehilce(fees,
                                          DefaultId,
                                          DefaultWeightInKilogram);

            // Act
            int actual = sut.Id;

            // Assert
            Assert.AreEqual(DefaultId,
                            actual);
        }

        [Test]
        public void Constructor_SetsWeightInKilogram_WhenCalled()
        {
            // Arrange
            var fees = Substitute.For <IVehicleFees>();
            var sut = new TestBaseVehilce(fees,
                                          DefaultId,
                                          DefaultWeightInKilogram);

            // Act
            int actual = sut.WeightInKilogram;

            // Assert
            Assert.AreEqual(DefaultWeightInKilogram,
                            actual);
        }

        [Test]
        public void ContainsFee_CallsVehicleFees_WhenCalled()
        {
            // Arrange
            var fee = Substitute.For <IFee>();
            var fees = Substitute.For <IVehicleFees>();
            var sut = new TestBaseVehilce(fees,
                                          DefaultId,
                                          DefaultWeightInKilogram);

            // Act
            sut.ContainsFee(fee);

            // Assert
            fees.Received().ContainsFee(fee);
        }

        [Test]
        public void Fees_CallsVehicleFees_WhenCalled()
        {
            // Arrange
            var expected = new IFee[0];
            var fees = Substitute.For <IVehicleFees>();
            fees.Fees.Returns(expected);
            var sut = new TestBaseVehilce(fees,
                                          DefaultId,
                                          DefaultWeightInKilogram);

            // Act
            IEnumerable <IFee> actual = sut.Fees;

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }

        [Test]
        public void IsFeePaid_CallsVehicleFees_WhenCalled()
        {
            // Arrange
            var fees = Substitute.For <IVehicleFees>();
            fees.IsFeePaid.Returns(true);
            var sut = new TestBaseVehilce(fees,
                                          DefaultId,
                                          DefaultWeightInKilogram);

            // Act
            bool actual = sut.IsFeePaid;

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void PaysFees_CallsVehicleFees_WhenCalled()
        {
            // Arrange
            var fees = Substitute.For <IVehicleFees>();
            var sut = new TestBaseVehilce(fees,
                                          DefaultId,
                                          DefaultWeightInKilogram);

            // Act
            sut.PaysFee();

            // Assert
            fees.Received().FeeIsPaid();
        }

        [Test]
        public void ShortDescription_ReturnsString_WhenCalled()
        {
            // Arrange
            var fees = Substitute.For <IVehicleFees>();
            var sut = new TestBaseVehilce(fees,
                                          DefaultId,
                                          DefaultWeightInKilogram);

            // Act
            string actual = sut.ShortDescription;

            // Assert
            Assert.AreEqual(string.Empty,
                            actual);
        }

        [Test]
        public void ToString_ReturnsString_WhenCalled()
        {
            // Arrange
            var fees = Substitute.For <IVehicleFees>();
            var sut = new TestBaseVehilce(fees,
                                          DefaultId,
                                          DefaultWeightInKilogram);

            // Act
            string actual = sut.ToString();

            // Assert
            Assert.AreEqual("Id: 1 ShortDescription:  Fees: 0 IsFeePaid: False",
                            actual);
        }
    }
}