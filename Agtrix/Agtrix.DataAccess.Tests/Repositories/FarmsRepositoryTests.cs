using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Agtrix.Common.Tests;
using Agtrix.DataAccess.Interfaces.Entities;
using Agtrix.DataAccess.Repositories;
using JetBrains.Annotations;
using NUnit.Framework;

namespace Agtrix.DataAccess.Tests.Repositories
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class FarmsRepositoryTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void SearchByFarmName_ReturnsMatchingFarms_ForSearchText(
            [NotNull] IFarm expected,
            [NotNull] FarmsRepository sut)
        {
            // Arrange
            expected.Name = "Name";
            sut.Save(expected);

            // Act
            IQueryable <IFarm> actual = sut.SearchByFarmName("Na");

            // Assert
            Assert.AreEqual(expected,
                            actual.First());
        }

        [Theory]
        [AutoNSubstituteData]
        public void FindById_ReturnsFarm_ForKnownId(
            [NotNull] IFarm expected,
            [NotNull] FarmsRepository sut)
        {
            // Arrange
            sut.Save(expected);

            // Act
            IFarm actual = sut.FindById(expected.Id);

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }

        [Theory]
        [AutoNSubstituteData]
        public void FindById_ReturnsNull_ForUnknownId(
            [NotNull] FarmsRepository sut)
        {
            // Arrange
            // Act
            IFarm actual = sut.FindById(Guid.Empty);

            // Assert
            Assert.Null(actual);
        }
    }
}