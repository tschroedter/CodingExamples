using System;
using System.Collections.Generic;
using Game.Interfaces;
using NSubstitute;
using NSubstitute.Core;
using Xunit;
using Xunit.Extensions;

namespace Game.Tests
{
    public sealed class CircleTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Run_Throws_ForInvaildNumberOfPeopleStandingInACircle(
            int numberOfPeopleStandingInACircle)
        {
            // Arrange
            ICircleOfPeopleFactory factory = CreateFactory();
            Circle sut = CreateSut(factory);

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.Run(numberOfPeopleStandingInACircle,
                                                            1));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Run_Throws_ForInvaildNumberOfPeopleToCountOverEachTime(
            int numberOfPeopleToCountOverEachTime)
        {
            // Arrange
            ICircleOfPeopleFactory factory = CreateFactory();
            Circle sut = CreateSut(factory);

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.Run(1,
                                                            numberOfPeopleToCountOverEachTime));
        }

        [Theory]
        [InlineData(3, 1, new[]
                          {
                              1,
                              2,
                              3
                          })]
        [InlineData(3, 2, new[]
                          {
                              2,
                              1,
                              3
                          })]
        [InlineData(3, 3, new[]
                          {
                              3,
                              1,
                              2
                          })]
        [InlineData(3, 4, new[]
                          {
                              1,
                              3,
                              2
                          })]
        public void Run_ReturnsIds_ForGivenParameters(
            int numberOfPeopleStandingInACircle,
            int numberOfPeopleToCountOverEachTime,
            IEnumerable <int> expected)
        {
            // Arrange
            ICircleOfPeopleFactory factory = CreateFactory();
            Circle sut = CreateSut(factory);

            // Act
            IEnumerable <int> actual = sut.Run(numberOfPeopleStandingInACircle,
                                               numberOfPeopleToCountOverEachTime);

            // Assert
            TestHelper.AssertArray(expected,
                                   actual);
        }

        [Fact]
        public void Run_CallsCreate_WhenCalled()
        {
            // Arrange
            ICircleOfPeopleFactory factory = CreateFactory();
            Circle sut = CreateSut(factory);

            // Act
            sut.Run(3,
                    1);

            // Assert
            factory.Received().Create(3);
        }

        [Fact]
        public void Run_CallsRelease_WhenCalled()
        {
            // Arrange
            var ring = Substitute.For <ICircleOfPeople>();
            var factory = Substitute.For <ICircleOfPeopleFactory>();
            factory.Create(Arg.Any <int>()).Returns(ring);
            Circle sut = CreateSut(factory);

            // Act
            sut.Run(3,
                    1);

            // Assert
            factory.Received().Release(ring);
        }

        private ICircleOfPeopleFactory CreateFactory()
        {
            var factory = Substitute.For <ICircleOfPeopleFactory>();
            factory.Create(Arg.Any <int>()).Returns(CreateCircleOfPeople);

            return factory;
        }

        private ICircleOfPeople CreateCircleOfPeople(CallInfo arg)
        {
            var numberOfPeopleStanding = ( int ) arg [ 0 ];

            return new CircleOfPeople(numberOfPeopleStanding);
        }

        private Circle CreateSut(ICircleOfPeopleFactory factory)
        {
            return new Circle(factory);
        }
    }
}