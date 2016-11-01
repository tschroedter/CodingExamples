using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
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
    [ExcludeFromCodeCoverage]
    public sealed class BaseRepositoryTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void FindById_ReturnsDay_ForKnownId([NotNull] ITest test)
        {
            // Arrange
            var context = Substitute.For <ITestContext>();
            context.Find(Arg.Any <int>()).Returns(test);
            TestBaseRepository sut = CreateSut(context);

            // Act
            ITest actual = sut.FindById(1);

            // Assert
            Assert.Equal(test,
                         actual);
        }

        [Fact]
        public void FindById_ReturnsNull_ForUnknownId()
        {
            // Arrange
            var context = Substitute.For <ITestContext>();
            context.Find(Arg.Any <int>()).Returns(( ITest ) null);
            TestBaseRepository sut = CreateSut(context);

            // Act
            ITest actual = sut.FindById(1);

            // Assert
            Assert.Null(actual);
        }

        [Fact]
        public void All_ReturnsDays_WhenCalled()
        {
            // Arrange
            var context = Substitute.For <ITestContext>();
            context.AllITests.Returns(CreateTestsForFindByDoctorIdKnownId);
            TestBaseRepository sut = CreateSut(context);

            // Act
            IEnumerable <ITest> actual = sut.All;

            // Assert
            Assert.Equal(3,
                         actual.Count());
        }

        [Theory]
        [AutoNSubstituteData]
        public void Save_CallsSave_WhenCalled([NotNull, Frozen] ITestContext context,
                                              [NotNull] TestBaseRepository sut)
        {
            // Arrange
            // Act
            sut.Save();

            // Assert
            context.Received().SaveChanges();
        }

        [Theory]
        [AutoNSubstituteData]
        public void Remove_CallsSave_WhenCalled([NotNull] ITest test,
                                                [NotNull, Frozen] ITestContext context,
                                                [NotNull] TestBaseRepository sut)
        {
            // Arrange
            // Act
            sut.Remove(test);

            // Assert
            context.Received().Remove(test);
        }

        [Theory]
        [AutoNSubstituteData]
        public void AddOrUpdate_CallsAdds_ForDayWithDefaultId([NotNull] ITest test,
                                                              [NotNull, Frozen] ITestContext context,
                                                              [NotNull] TestBaseRepository sut)
        {
            // Arrange
            test.Id.Returns(0);

            // Act
            sut.Save(test);

            // Assert
            context.Received().Add(test);
        }

        [Theory]
        [AutoNSubstituteData]
        public void AddOrUpdate_CallsSetStateForSlot_ForExistingDay([NotNull] ITest test,
                                                                    [NotNull, Frozen] ITestContext context,
                                                                    [NotNull] TestBaseRepository sut)
        {
            // Arrange
            test.Id.Returns(1);

            // Act
            sut.Save(test);

            // Assert
            context.Received().SetStateForSlot(test,
                                               EntityState.Modified);
        }

        private IQueryable <ITest> CreateTestsForFindByDoctorIdKnownId(CallInfo arg)
        {
            var one = Substitute.For <ITest>();
            one.Id.Returns(1);

            var two = Substitute.For <ITest>();
            two.Id.Returns(2);

            var three = Substitute.For <ITest>();
            three.Id.Returns(3);

            var list = new[]
                       {
                           one,
                           two,
                           three
                       };

            return list.AsQueryable();
        }

        private TestBaseRepository CreateSut(ITestContext context)
        {
            return new TestBaseRepository(context);
        }

        public interface ITest : IEntity
        {
        }

        public interface ITestContext : IDbContext <ITest>
        {
            IQueryable <ITest> AllITests { get; }
        }

        public class TestBaseRepository
            : BaseRepository <ITest, ITestContext>
        {
            public TestBaseRepository([NotNull] ITestContext context)
                : base(context)
            {
            }

            protected override IQueryable <ITest> GetAll()
            {
                return Context.AllITests;
            }
        }
    }
}