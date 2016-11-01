using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using MicroServices.Common.Tests;
using MicroServices.DataAccess.Interfaces.Entities;
using MicroServices.DataAccess.Interfaces.Repositories;
using MicroServices.Nancy.Persons.Interfaces;
using NSubstitute;
using NSubstitute.Core;
using Xunit;
using Xunit.Extensions;

namespace MicroServices.Nancy.Persons.Tests
{
    [ExcludeFromCodeCoverage]
    //ncrunch: no coverage start
    public sealed class InformationFinderTests
    {
        private const int DoesNotMatter = -1;

        [Theory]
        [AutoNSubstituteData]
        public void Save_CallsSave_WhenCalled([NotNull] IPersonForResponse toBeUpdated,
                                              [NotNull] IPerson doctor)
        {
            // Arrange
            var repository = Substitute.For <IPersonsRepository>();
            repository.Save(Arg.Any <IPerson>());
            InformationFinder sut = CreateSut(repository);

            // Act
            sut.Save(toBeUpdated);

            // Assert
            repository.Received().Save(Arg.Is <IPerson>(x => x.Id == toBeUpdated.Id));
        }

        [Theory]
        [AutoNSubstituteData]
        public void Save_ReturnsUpdatedPerson_ForExisting([NotNull] IPersonForResponse toBeUpdated,
                                                          [NotNull] IPerson doctor)
        {
            // Arrange
            var repository = Substitute.For <IPersonsRepository>();
            repository.Save(Arg.Any <IPerson>());
            InformationFinder sut = CreateSut(repository);

            // Act
            IPersonForResponse actual = sut.Save(toBeUpdated);

            // Assert
            Assert.Equal(toBeUpdated.Id,
                         actual.Id);
        }

        [Theory]
        [AutoNSubstituteData]
        public void FindById_ReturnsPerson_ForExistingId([NotNull] IPerson doctor)
        {
            // Arrange
            var repository = Substitute.For <IPersonsRepository>();
            repository.FindById(doctor.Id).Returns(doctor);
            InformationFinder sut = CreateSut(repository);

            // Act
            IPersonForResponse actual = sut.FindById(doctor.Id);

            // Assert
            Assert.Equal(doctor.Id,
                         actual.Id);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Delete_ReturnsNewPerson_WhenCalled([NotNull] IPerson doctor)
        {
            // Arrange
            var repository = Substitute.For <IPersonsRepository>();
            repository.Delete(Arg.Any <int>()).Returns(doctor);
            InformationFinder sut = CreateSut(repository);

            // Act
            IPersonForResponse actual = sut.Delete(DoesNotMatter);

            // Assert
            Assert.Equal(doctor.Id,
                         actual.Id);
        }

        [Fact]
        public void Delete_ReturnsNull_ForCanNotAdd()
        {
            // Arrange
            var repository = Substitute.For <IPersonsRepository>();
            repository.Delete(Arg.Any <int>()).Returns(( IPerson ) null);
            InformationFinder sut = CreateSut(repository);

            // Act
            IPersonForResponse actual = sut.Delete(DoesNotMatter);

            // Assert
            Assert.Null(actual);
        }

        [Fact]
        public void FindById_ReturnsNull_ForNotExistingId()
        {
            // Arrange
            var repository = Substitute.For <IPersonsRepository>();
            repository.FindById(DoesNotMatter).Returns(( IPerson ) null);
            InformationFinder sut = CreateSut(repository);

            // Act
            IPersonForResponse actual = sut.FindById(DoesNotMatter);

            // Assert
            Assert.Null(actual);
        }

        [Fact]
        public void List_ReturnsPersons_WhenCalled()
        {
            // Arrange
            var repository = Substitute.For <IPersonsRepository>();
            repository.All.Returns(CreateList);
            InformationFinder sut = CreateSut(repository);

            // Act
            IEnumerable <IPersonForResponse> actual = sut.List();

            // Assert
            Assert.Equal(2,
                         actual.Count());
        }

        private IQueryable <IPerson> CreateList(CallInfo arg)
        {
            var list = new Collection <IPerson>
                       {
                           Substitute.For <IPerson>(),
                           Substitute.For <IPerson>()
                       };


            return list.AsQueryable();
        }

        private InformationFinder CreateSut(IPersonsRepository repository)
        {
            return new InformationFinder(repository);
        }
    }
}