using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using ParkIQ.SecureParking.Fees;
using ParkIQ.SecureParking.Interaces.Fees;

namespace ParkIQ.SecureParking.Tests.Fees
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class VehicleFeesTests
    {
        private static VehicleFees CreateSut(IFeeCalculator calculator = null)
        {
            if ( calculator == null )
            {
                calculator = Substitute.For <IFeeCalculator>();
            }

            var sut = new VehicleFees(calculator);
            return sut;
        }

        [Test]
        public void AddFee_AddsFeeToFees_ForGivenFee()
        {
            // Arrange
            var fee = Substitute.For <IFee>();
            var calculator = Substitute.For <IFeeCalculator>();
            VehicleFees sut = CreateSut(calculator);

            // Act
            sut.AddFee(fee);

            // Assert
            IFee actual = sut.Fees.First();

            Assert.AreEqual(fee,
                            actual);
        }

        [Test]
        public void AddFee_IncreasesFeesCount_ForGivenFee()
        {
            // Arrange
            var fee = Substitute.For <IFee>();
            var calculator = Substitute.For <IFeeCalculator>();
            VehicleFees sut = CreateSut(calculator);

            // Act
            sut.AddFee(fee);

            // Assert
            Assert.AreEqual(1,
                            sut.Fees.Count());
        }

        [Test]
        public void AddFee_ThrowsException_ForAddingFeeTwice()
        {
            // Arrange
            var fee = Substitute.For <IFee>();
            var calculator = Substitute.For <IFeeCalculator>();
            VehicleFees sut = CreateSut(calculator);
            sut.AddFee(fee);

            // Act
            // Assert
            Assert.Throws <FeeAlreadyAddedException>(() => sut.AddFee(fee));
        }

        [Test]
        public void Calulate_CallsFeeCalculator_WhenCalled()
        {
            // Arrange
            var calculator = Substitute.For <IFeeCalculator>();
            calculator.Calulate(new IFee[0]).ReturnsForAnyArgs(123);
            VehicleFees sut = CreateSut(calculator);

            // Act
            int actual = sut.Calulate();

            // Assert
            Assert.AreEqual(123,
                            actual);
        }

        [Test]
        public void ContainsFee_ReturnsFalse_ForFeeNotInFees()
        {
            // Arrange
            var fee = Substitute.For <IFee>();
            var calculator = Substitute.For <IFeeCalculator>();
            VehicleFees sut = CreateSut(calculator);

            // Act
            // Assert
            Assert.False(sut.ContainsFee(fee));
        }

        [Test]
        public void ContainsFee_ReturnsTrue_ForFeeInFees()
        {
            // Arrange
            var fee = Substitute.For <IFee>();
            var calculator = Substitute.For <IFeeCalculator>();
            VehicleFees sut = CreateSut(calculator);
            sut.AddFee(fee);

            // Act
            // Assert
            Assert.True(sut.ContainsFee(fee));
        }

        [Test]
        public void IsFeePaid_ReturnsFalse_ByDefault()
        {
            // Arrange
            var calculator = Substitute.For <IFeeCalculator>();
            VehicleFees sut = CreateSut(calculator);

            // Act
            // Assert
            Assert.False(sut.IsFeePaid);
        }

        [Test]
        public void IsFeePaid_ReturnsTrue_WhenFeeIsPaid()
        {
            // Arrange
            var calculator = Substitute.For <IFeeCalculator>();
            VehicleFees sut = CreateSut(calculator);
            sut.FeeIsPaid();

            // Act
            // Assert
            Assert.True(sut.IsFeePaid);
        }

        [Test]
        public void RemoveFee_DecreasesFeesCount_ForGivenFee()
        {
            // Arrange
            var fee = Substitute.For <IFee>();
            var calculator = Substitute.For <IFeeCalculator>();
            VehicleFees sut = CreateSut(calculator);
            sut.AddFee(fee);

            // Act
            sut.RemoveFee(fee);

            // Assert
            Assert.AreEqual(0,
                            sut.Fees.Count());
        }

        [Test]
        public void RemoveFee_RemovesFeeFromFees_ForGivenFee()
        {
            // Arrange
            var fee = Substitute.For <IFee>();
            var calculator = Substitute.For <IFeeCalculator>();
            VehicleFees sut = CreateSut(calculator);
            sut.AddFee(fee);

            // Act
            sut.RemoveFee(fee);

            // Assert
            Assert.False(sut.ContainsFee(fee));
        }

        [Test]
        public void RemoveFee_RemovesFeeFromFees_ForUnknownFee()
        {
            // Arrange
            var fee = Substitute.For <IFee>();
            var calculator = Substitute.For <IFeeCalculator>();
            VehicleFees sut = CreateSut(calculator);

            // Act
            sut.RemoveFee(fee);

            // Assert
            Assert.False(sut.ContainsFee(fee));
        }
    }
}