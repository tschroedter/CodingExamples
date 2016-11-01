using JetBrains.Annotations;
using MicroServices.Common.Tests;
using MicroServices.DataAccess.Interfaces.Entities;
using Xunit;
using Xunit.Extensions;

namespace MicroServices.Nancy.Persons.Tests
{
    public sealed class PersonForResponseTests
    {
        [Fact]
        public void DefaultConstructor_SetsId_WhenCalled()
        {
            // Arrange
            // Act
            var sut = new PersonForResponse();

            // Assert
            Assert.Equal(0,
                         sut.Id);
        }

        [Fact]
        public void DefaultConstructor_SetsFirstName_WhenCalled()
        {
            // Arrange
            // Act
            var sut = new PersonForResponse();

            // Assert
            Assert.Equal(string.Empty,
                         sut.FirstName);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Constructor_SetsProperties_WhenCalled([NotNull] IPerson person)
        {
            // Arrange
            // Act
            var sut = new PersonForResponse(person);

            // Assert
            Assert.Equal(person.Id,
                         sut.Id); // todo add string to show which test is failling
            Assert.Equal(person.FirstName,
                         sut.FirstName);
            Assert.Equal(person.Surname,
                         sut.Surname);
            Assert.Equal(person.DateOfBirth.ToShortDateString(),
                         sut.DateOfBirth);
            Assert.Equal(person.Sex,
                         sut.Sex);
            Assert.Equal(person.Email,
                         sut.Email);
        }
    }
}