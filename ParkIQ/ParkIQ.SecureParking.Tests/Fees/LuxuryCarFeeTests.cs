using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using ParkIQ.SecureParking.Fees;
using ParkIQ.SecureParking.Interaces.Fees;

namespace ParkIQ.SecureParking.Tests.Fees
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class LuxuryCarFeeTests
    {
        [Test]
        public void Calculate_ReturnsCorrectCharge_ForExtraCharges()
        {
            // Arrange
            IFee sut = new LuxuryCarFee(new StandardCarFee());

            // Act
            int actual = sut.Calculate();

            // Assert
            Assert.AreEqual(8,
                            actual);
        }
    }
}