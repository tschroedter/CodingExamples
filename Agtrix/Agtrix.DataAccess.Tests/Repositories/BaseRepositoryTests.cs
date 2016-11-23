using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Agtrix.Common.Tests;
using Agtrix.DataAccess.Interfaces.Entities;
using Agtrix.DataAccess.Interfaces.Repositories;
using Agtrix.DataAccess.Repositories;
using JetBrains.Annotations;
using NSubstitute;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;
using Selkie.Windsor;

namespace Agtrix.DataAccess.Tests.Repositories
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class BaseRepositoryTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void All_ReturnsEntities_WhenCalled(
            [NotNull] Test one,
            [NotNull] Test two,
            [NotNull] Test three,
            [NotNull] TestBaseRepository sut)
        {
            // Arrange
            sut.Save(one);
            sut.Save(two);
            sut.Save(three);

            // Act
            IEnumerable <ITest> actual = sut.All;

            // Assert
            Assert.AreEqual(3,
                            actual.Count());
        }

        [Theory]
        [AutoNSubstituteData]
        public void FindById_ReturnsEntity_ForKnownId(
            [NotNull] Test expected,
            [NotNull] TestBaseRepository sut)
        {
            // Arrange
            sut.Save(expected);

            // Act
            ITest actual = sut.FindById(expected.Id);

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Start_LogsText_WhenCalled(
            [NotNull] [Frozen] ISelkieLogger logger,
            [NotNull] TestBaseRepository sut)
        {
            // Arrange
            // Act
            sut.Start();

            // Assert
            logger.Received().Info(Arg.Any <string>());
        }

        [Theory]
        [AutoNSubstituteData]
        public void Stop_LogsText_WhenCalled(
            [NotNull] [Frozen] ISelkieLogger logger,
            [NotNull] TestBaseRepository sut)
        {
            // Arrange
            // Act
            sut.Stop();

            // Assert
            logger.Received().Info(Arg.Any <string>());
        }

        [Theory]
        [AutoNSubstituteData]
        public void FindById_ReturnsNull_ForUnknownId(
            [NotNull] TestBaseRepository sut)
        {
            // Arrange
            // Act
            ITest actual = sut.FindById(Guid.Empty);

            // Assert
            Assert.Null(actual);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Remove_DeletesEntity_WhenCalled(
            [NotNull] Test test,
            [NotNull] TestBaseRepository sut)
        {
            // Arrange
            sut.Save(test);

            // Act
            sut.Remove(test);

            // Assert
            Assert.Null(sut.FindById(test.Id));
        }

        [Theory]
        [AutoNSubstituteData]
        public void Save_AddsEntity_WhenCalled(
            [NotNull] Test expected,
            [NotNull] TestBaseRepository sut)
        {
            // Arrange
            // Act
            sut.Save(expected);

            // Assert
            Assert.AreEqual(expected,
                            sut.FindById(expected.Id));
        }

        [Theory]
        [AutoNSubstituteData]
        public void Save_AddsEntityWithNewId_WhenIdIsDefault(
            [NotNull] TestBaseRepository sut)
        {
            // Arrange
            ITest test = new Test();

            // Act
            sut.Save(test);

            // Assert
            ITest actual = sut.All.First();

            Assert.AreNotEqual(Guid.Empty,
                               actual.Id);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Save_UpdatesEntity_WhenCalledTwice(
            [NotNull] Test expected,
            [NotNull] TestBaseRepository sut)
        {
            // Arrange
            sut.Save(expected);

            expected.Text = "Updated";

            // Act
            sut.Save(expected);

            // Assert
            ITest actual = sut.FindById(expected.Id);

            Assert.AreEqual("Updated",
                            actual.Text);
        }

        public interface ITest : IEntity
        {
            string Text { get; set; }
        }

        public class Test : ITest
        {
            public Guid Id { get; set; }
            public string Text { get; set; }
        }

        public class TestBaseRepository
            : BaseRepository <ITest>,
              IRepository <ITest>
        {
            public TestBaseRepository(
                [NotNull] ISelkieLogger logger)
                : base(logger)
            {
            }

            public override ITest FindById(Guid id)
            {
                ITest entity;
                if ( Storage.TryGetValue(id,
                                         out entity) )
                {
                    return entity;
                }

                return null;
            }
        }
    }
}