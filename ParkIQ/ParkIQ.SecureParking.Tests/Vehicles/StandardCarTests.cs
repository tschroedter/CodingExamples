using System.Diagnostics.CodeAnalysis;
using NSubstitute;
using NUnit.Framework;
using ParkIQ.SecureParking.Interaces.Fees;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking.Tests.Vehicles
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class StandardCarTests
    {
        private const int DefaultId = 1;
        private const int DefaultWeightInKilogram = 2;

        [Test]
        public void ShortDescription_ReturnsString_WhenCalled()
        {
            // Arrange
            var fees = Substitute.For <IVehicleFees>();
            var sut = new StandardCar(fees,
                                      DefaultId,
                                      DefaultWeightInKilogram);

            // Act
            string actual = sut.ShortDescription;

            // Assert
            Assert.AreEqual("StandardCar",
                            actual);
        }
    }
}