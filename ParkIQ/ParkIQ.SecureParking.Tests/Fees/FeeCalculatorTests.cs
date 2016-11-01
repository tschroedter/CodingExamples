using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NSubstitute;
using NUnit.Framework;
using ParkIQ.SecureParking.Fees;
using ParkIQ.SecureParking.Interaces.Fees;

namespace ParkIQ.SecureParking.Tests.Fees
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class FeeCalculatorTests
    {
        private IEnumerable <IFee> CreateFees()
        {
            var one = Substitute.For <IFee>();
            one.Calculate().Returns(1);

            var two = Substitute.For <IFee>();
            two.Calculate().Returns(2);

            var three = Substitute.For <IFee>();
            three.Calculate().Returns(3);

            var fees = new[]
                       {
                           one,
                           two,
                           three
                       };

            return fees;
        }

        [Test]
        public void Calulate_RetrunsSumOfFees_ForGivenFees()
        {
            // Arrange
            IEnumerable <IFee> fees = CreateFees();
            var sut = new FeeCalculator();

            // Act
            int actual = sut.Calulate(fees);

            // Assert
            Assert.AreEqual(6,
                            actual);
        }
    }
}