using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace Game.Tests
{
    public sealed class CircleOfPeopleTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_Throws_ForParameterIsZeroOrNegative(
            int numberOfPeopleStanding)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => CreateSut(numberOfPeopleStanding));
        }

        [Theory]
        [InlineData(1, new[]
                       {
                           1
                       })]
        [InlineData(2, new[]
                       {
                           1,
                           2
                       })]
        [InlineData(3, new[]
                       {
                           1,
                           2,
                           3
                       })]
        public void Constructor_InitializesStanding_WhenCalled(
            int numberOfPeopleStanding,
            int[] expected)
        {
            // Arrange
            CircleOfPeople sut = CreateSut(numberOfPeopleStanding);

            // Act
            IEnumerable <int> actual = sut.PeopleStanding;

            // Assert
            TestHelper.AssertArray(expected,
                                   actual);
        }

        [Theory]
        [InlineData(3, 1, 2)]
        [InlineData(3, 2, 3)]
        [InlineData(3, 3, 1)]
        public void NextPerson_ReturnsPersonIdOfNextPersonInRing_WhenCalled(
            int numberOfPeopleStanding,
            int personId,
            int expected)
        {
            // Arrange
            CircleOfPeople sut = CreateSut(numberOfPeopleStanding);

            // Act
            int actual = sut.NextPerson(personId);

            // Assert
            Assert.Equal(expected,
                         actual);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(4)]
        public void NextPerson_Throws_ForPersonIdIsInvalid(
            int personId)
        {
            // Arrange
            CircleOfPeople sut = CreateSut(3);

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.NextPerson(personId));
        }

        [Theory]
        [InlineData(3, 1, new[]
                          {
                              2,
                              3
                          })]
        [InlineData(3, 2, new[]
                          {
                              1,
                              3
                          })]
        [InlineData(3, 3, new[]
                          {
                              1,
                              2
                          })]
        [InlineData(3, 0, new[]
                          {
                              1,
                              2,
                              3
                          })]
        [InlineData(3, 4, new[]
                          {
                              1,
                              2,
                              3
                          })]
        public void RemovePerson_RemovesPersonIdFromRing_WhenCalled(
            int numberOfPeopleStanding,
            int personId,
            int[] expected)
        {
            // Arrange
            CircleOfPeople sut = CreateSut(numberOfPeopleStanding);

            // Act
            sut.RemovePerson(personId);

            // Assert
            TestHelper.AssertArray(expected,
                                   sut.PeopleStanding);
        }

        [Theory]
        [InlineData(3, 1, 1, 1)]
        [InlineData(3, 1, 2, 2)]
        [InlineData(3, 1, 3, 3)]
        [InlineData(3, 1, 4, 1)]
        [InlineData(3, 1, 5, 2)]
        [InlineData(3, 1, 6, 3)]
        public void NextPersonForCountTo_ReturnsPersonId_ForGivenPersonIdAndCount(
            int numberOfPeopleStanding,
            int personId,
            int countTo,
            int expected)
        {
            // Arrange
            CircleOfPeople sut = CreateSut(numberOfPeopleStanding);

            // Act
            int actual = sut.NextPersonForCountTo(personId,
                                                  countTo);

            // Assert
            Assert.Equal(expected,
                         actual);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(1, -1)]
        public void NextPersonForCountTo_Throws_ForCountToIsZeroOrNegative(
            int personId,
            int countTo)
        {
            // Arrange
            CircleOfPeople sut = CreateSut(3);

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.NextPersonForCountTo(personId,
                                                                             countTo));
        }

        [Theory]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(4, 1)]
        public void NextPersonForCountTo_Throws_ForPersonIdIsInvalid(
            int personId,
            int countTo)
        {
            // Arrange
            CircleOfPeople sut = CreateSut(3);

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.NextPersonForCountTo(personId,
                                                                             countTo));
        }

        private CircleOfPeople CreateSut(int standing)
        {
            return new CircleOfPeople(standing);
        }
    }
}