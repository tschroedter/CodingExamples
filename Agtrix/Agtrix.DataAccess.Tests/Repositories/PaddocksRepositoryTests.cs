using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Agtrix.Common.Tests;
using Agtrix.DataAccess.Entities;
using Agtrix.DataAccess.Interfaces.Entities;
using Agtrix.DataAccess.Repositories;
using JetBrains.Annotations;
using NUnit.Framework;

namespace Agtrix.DataAccess.Tests.Repositories
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class PaddocksRepositoryTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void FindById_ReturnsPaddock_ForKnownId(
            [NotNull] IPaddock expected,
            [NotNull] PaddocksRepository sut)
        {
            // Arrange
            sut.Save(expected);

            // Act
            IPaddock actual = sut.FindById(expected.Id);

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }

        [Theory]
        [AutoNSubstituteData]
        public void FindById_ReturnsNull_ForUnknownId(
            [NotNull] PaddocksRepository sut)
        {
            // Arrange
            // Act
            IPaddock actual = sut.FindById(Guid.Empty);

            // Assert
            Assert.Null(actual);
        }

        [Theory]
        [AutoNSubstituteData]
        public void FindByFarmId_ReturnsEmpty_ForUnknownFarmId(
            [NotNull] PaddocksRepository sut)
        {
            // Arrange
            // Act
            IQueryable <IPaddock> actual = sut.FindByFarmId(Guid.Empty);

            // Assert
            Assert.AreEqual(0,
                            actual.Count());
        }

        [Theory]
        [AutoNSubstituteData]
        public void FindByFarmId_ReturnsPaddocks_ForKnownFarmId(
            [NotNull] Paddock one,
            [NotNull] Paddock two,
            Guid farmId,
            [NotNull] PaddocksRepository sut)
        {
            // Arrange
            one.FarmId = farmId;
            two.FarmId = farmId;

            sut.Save(one);
            sut.Save(two);

            // Act
            IQueryable <IPaddock> actual = sut.FindByFarmId(farmId);

            // Assert
            Assert.AreEqual(2,
                            actual.Count());
        }
    }
}