using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using ParkIQ.SecureParking.Fees;
using ParkIQ.SecureParking.Interaces.Fees;

namespace ParkIQ.SecureParking.Tests.Fees
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class MotorbikeFeeTests
    {
        [Test]
        public void Calculate_ReturnsCorrectCharge_ForExtraCharges()
        {
            // Arrange
            IFee sut = new MotorbikeFee();

            // Act
            int actual = sut.Calculate();

            // Assert
            Assert.AreEqual(2,
                            actual);
        }
    }
}