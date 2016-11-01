using System.Linq;
using JetBrains.Annotations;
using MicroServices.Common.Tests;
using MicroServices.DataAccess.Interfaces.Contexts;
using MicroServices.DataAccess.Interfaces.Entities;
using MicroServices.DataAccess.Repositories;
using NSubstitute;
using NSubstitute.Core;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace MicroServices.DataAccess.Tests.Repositories
{
    public sealed class PersonsRepositoryTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void Delete_ReturnsPerson_WhenCalled(
            [NotNull] IPerson person,
            [NotNull, Frozen] IPersonsContext context,
            [NotNull] PersonsRepository sut)
        {
            // Arrange
            context.Delete(Arg.Any <int>()).Returns(person);

            // Act
            IPerson actual = sut.Delete(-1);

            // Assert
            Assert.Equal(person,
                         actual);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Delete_CallsContextDelete_WhenCalled(
            [NotNull, Frozen] IPersonsContext context,
            [NotNull] PersonsRepository sut)
        {
            // Arrange
            // Act
            sut.Delete(-1);

            // Assert
            context.Received().Delete(-1);
        }

        [Theory]
        [AutoNSubstituteData]
        public void All_CallsContextPersons_WhenCalled(
            [NotNull, Frozen] IPersonsContext context,
            [NotNull] PersonsRepository sut)
        {
            // Arrange
            // Act
            // ReSharper disable once UnusedVariable
            IQueryable <IPerson> actual = sut.All;

            // Assert
            context.Received().Persons();
        }


        [Theory]
        [AutoNSubstituteData]
        public void All_ReturnsPersons_WhenCalled(
            [NotNull, Frozen] IPersonsContext context,
            [NotNull] PersonsRepository sut)
        {
            // Arrange
            context.Persons().Returns(CreatePersons);

            // Act
            // ReSharper disable once UnusedVariable
            IQueryable <IPerson> actual = sut.All;

            // Assert
            Assert.Equal(2,
                         actual.Count());
        }

        private IQueryable <IPerson> CreatePersons(CallInfo arg)
        {
            var one = Substitute.For <IPerson>();
            one.Id.Returns(1);

            var two = Substitute.For <IPerson>();
            two.Id.Returns(2);

            return new[]
                   {
                       one,
                       two
                   }.AsQueryable();
        }
    }
}