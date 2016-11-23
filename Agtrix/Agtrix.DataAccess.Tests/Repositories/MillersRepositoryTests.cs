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
    internal sealed class MillersRepositoryTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void SearchByMillerName_ReturnsMatchingFarms_ForSearchText(
            [NotNull] IMiller expected,
            [NotNull] MillersRepository sut)
        {
            // Arrange
            expected.Name = "Name";
            sut.Save(expected);

            // Act
            IQueryable <IMiller> actual = sut.SearchByMillerName("Na");

            // Assert
            Assert.AreEqual(expected,
                            actual.First());
        }

        [Theory]
        [AutoNSubstituteData]
        public void FindById_ReturnsMiller_ForKnownId(
            [NotNull] IMiller expected,
            [NotNull] MillersRepository sut)
        {
            // Arrange
            sut.Save(expected);

            // Act
            IMiller actual = sut.FindById(expected.Id);

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }

        [Theory]
        [AutoNSubstituteData]
        public void FindById_ReturnsNull_ForUnknownId(
            [NotNull] MillersRepository sut)
        {
            // Arrange
            // Act
            IMiller actual = sut.FindById(Guid.Empty);

            // Assert
            Assert.Null(actual);
        }
    }
}