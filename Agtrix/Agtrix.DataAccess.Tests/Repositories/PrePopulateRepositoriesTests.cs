using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Agtrix.DataAccess.Interfaces.Repositories;
using Agtrix.DataAccess.Repositories;
using NUnit.Framework;
using NSubstitute;
using Selkie.Windsor;

namespace Agtrix.DataAccess.Tests.Repositories
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class PrePopulateRepositoriesTests
    {
        [SetUp]
        public void Setup()
        {
            m_Logger = Substitute.For <ISelkieLogger>();

            m_Millers = new MillersRepository(m_Logger);
            m_Farms = new FarmsRepository(m_Logger);
            m_Paddocks = new PaddocksRepository(m_Logger);

            m_Sut = new PrePopulateRepositories(m_Millers,
                                                m_Farms,
                                                m_Paddocks);
        }

        private ISelkieLogger m_Logger;
        private IMillersRepository m_Millers;
        private IFarmsRepository m_Farms;
        private IPaddocksRepository m_Paddocks;

        private PrePopulateRepositories m_Sut;

        [Test]
        public void PrePopulate_PopulatesFarmsRepository_WhenCalled()
        {
            // Arrange
            const int expectedNumberOfFarms = 100;

            // Act
            m_Sut.PrePopulate();

            // Assert
            Assert.AreEqual(expectedNumberOfFarms,
                            m_Farms.All.Count());
        }

        [Test]
        public void PrePopulate_PopulatesMillersRepository_WhenCalled()
        {
            // Arrange
            const int expectedNumberOfMillers = 10;

            // Act
            m_Sut.PrePopulate();

            // Assert
            Assert.AreEqual(expectedNumberOfMillers,
                            m_Millers.All.Count());
        }

        [Test]
        public void PrePopulate_PopulatesPaddocksRepository_WhenCalled()
        {
            // Arrange
            const int expectedNumberOfPaddocks = 100 * 20; // Farms * Paddocks per farm

            // Act
            m_Sut.PrePopulate();

            // Assert
            Assert.AreEqual(expectedNumberOfPaddocks,
                            m_Paddocks.All.Count());
        }
    }
}