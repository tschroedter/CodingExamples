using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using ParkIQ.SecureParking.Interaces;
using ParkIQ.SecureParking.Interaces.Vehicles;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class CarParkTests
    {
        [SetUp]
        public void Setup()
        {
            m_ThreeVehicles = new[]
                              {
                                  Substitute.For <IVehicle>(),
                                  Substitute.For <IVehicle>(),
                                  Substitute.For <IVehicle>()
                              };

            m_ThreeBays = new[]
                          {
                              Substitute.For <IBay>(),
                              Substitute.For <IBay>(),
                              Substitute.For <IBay>()
                          };

            m_DefaultName = "King Street";
            m_BayManager = Substitute.For <IBaysManager>();

            m_Factory = Substitute.For <IBaysManagerFactory>();
            m_Factory.Create(Arg.Any <int>()).Returns(m_BayManager);
        }

        private IBaysManager m_BayManager;
        private string m_DefaultName;
        private IBay[] m_ThreeBays;
        private IVehicle[] m_ThreeVehicles;
        private IBaysManagerFactory m_Factory;

        private CarPark CreateSut(IBaysManagerFactory baysManagerFactory = null)
        {
            if ( baysManagerFactory == null )
            {
                baysManagerFactory = m_Factory;
            }

            var sut = new CarPark(Substitute.For<ISelkieLogger>(),
                                  baysManagerFactory,
                                  m_DefaultName,
                                  3);
            return sut;
        }

        [Test]
        public void Bays_ReturnsBays_WhenCalled()
        {
            // Arrange
            m_BayManager.Bays.Returns(m_ThreeBays);

            CarPark sut = CreateSut();

            // Act
            // Assert
            Assert.AreEqual(m_ThreeBays,
                            sut.Bays);
        }

        [Test]
        public void Constructor_CallsCreate_WhenCalled()
        {
            // Arrange
            var factory = Substitute.For <IBaysManagerFactory>();
            CarPark sut = CreateSut(factory);

            // Act
            sut.Dispose();

            // Assert
            factory.Received().Create(Arg.Any <int>());
        }

        [Test]
        public void Dispose_CallsRelease_WhenCalled()
        {
            // Arrange
            var manager = Substitute.For <IBaysManager>();
            var factory = Substitute.For <IBaysManagerFactory>();
            factory.Create(Arg.Any <int>()).Returns(manager);

            CarPark sut = CreateSut(factory);

            // Act
            sut.Dispose();

            // Assert
            factory.Received().Release(manager);
        }

        [Test]
        public void Enter_CallBayManager_ForCarParkIsNotFull()
        {
            // Arrange
            var vehicle = Substitute.For <IVehicle>();
            m_BayManager.IsFull.Returns(false);
            CarPark sut = CreateSut();

            // Act
            sut.Enter(vehicle);

            // Assert
            m_BayManager.Received().AssignBay(vehicle);
        }

        [Test]
        public void Enter_ThrowsException_ForCarParkIsFull()
        {
            // Arrange
            var vehicle = Substitute.For <IVehicle>();
            m_BayManager.IsFull.Returns(true);
            CarPark sut = CreateSut();

            // Act
            // Assert
            Assert.Throws <CarParkIsFullException>(() => sut.Enter(vehicle));
        }

        [Test]
        public void Exit_CallBayManager_ForFeeIsPaid()
        {
            // Arrange
            var vehicle = Substitute.For <IVehicle>();
            vehicle.IsFeePaid.Returns(true);
            CarPark sut = CreateSut();

            // Act
            sut.Exit(vehicle);

            // Assert
            m_BayManager.Received().ReleaseBay(vehicle);
        }

        [Test]
        public void Exit_ThrowsException_Exit_CallBayManager_ForFeeIsNotPaid()
        {
            // Arrange
            var vehicle = Substitute.For <IVehicle>();
            vehicle.IsFeePaid.Returns(false);
            CarPark sut = CreateSut();

            // Act
            // Assert
            Assert.Throws <CarDidNotPayFeeException>(() => sut.Exit(vehicle));
        }

        [Test]
        public void IsFull_CallBayManager_WhenCalled()
        {
            // Arrange
            m_BayManager.IsFull.Returns(true);
            CarPark sut = CreateSut();

            // Act
            // Assert
            Assert.AreEqual(true,
                            sut.IsFull);
        }

        [Test]
        public void Name_ReturnsName_WhenCalled()
        {
            // Arrange
            // Act
            CarPark sut = CreateSut();

            // Assert
            Assert.AreEqual(m_DefaultName,
                            sut.Name);
        }

        [Test]
        public void NumberOfBays_CallBayManager_WhenCalled()
        {
            // Arrange
            m_BayManager.NumberOfBays.Returns(1);
            CarPark sut = CreateSut();

            // Act
            // Assert
            Assert.AreEqual(1,
                            sut.NumberOfBays);
        }

        [Test]
        public void NumberOfOccupiedBays_CallBayManager_WhenCalled()
        {
            // Arrange
            m_BayManager.NumberOfOccupiedBays.Returns(1);
            CarPark sut = CreateSut();

            // Act
            // Assert
            Assert.AreEqual(1,
                            sut.NumberOfOccupiedBays);
        }

        [Test]
        public void Vehicles_ReturnsVehicles_WhenCalled()
        {
            // Arrange
            m_BayManager.Vehicles.Returns(m_ThreeVehicles);
            CarPark sut = CreateSut();

            // Act
            // Assert
            Assert.AreEqual(m_ThreeVehicles.Length,
                            sut.Vehicles.Count());
        }
    }
}