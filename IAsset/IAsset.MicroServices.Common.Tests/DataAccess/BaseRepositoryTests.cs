using System.Diagnostics.CodeAnalysis;
using System.Linq;
using IAsset.MicroServices.Common.DataAccess;
using NUnit.Framework;

namespace IAsset.MicroServices.Common.Tests.DataAccess
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class BaseRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new TestBaseRepository();
        }

        private TestBaseRepository m_Sut;

        private class TestEntity : IEntity
        {
            public TestEntity(int id)
            {
                Id = id;
            }

            public int Id { get; set; }
        }

        private class TestBaseRepository : BaseRepository <TestEntity>
        {
        }

        private void PopulateWithThreeEntities(TestBaseRepository mSut)
        {
            var one = new TestEntity(1);
            m_Sut.Save(one);

            var two = new TestEntity(2);
            m_Sut.Save(two);

            var three = new TestEntity(3);
            m_Sut.Save(three);
        }

        [Test]
        public void All_ReturnsAllEntities_WhenCalled()
        {
            // Arrange
            PopulateWithThreeEntities(m_Sut);

            // Act
            IQueryable <TestEntity> actual = m_Sut.All;

            // Assert
            Assert.AreEqual(3,
                            actual.Count());
        }

        [Test]
        public void FindById_ReturnsEntity_ForKnownId()
        {
            // Arrange
            PopulateWithThreeEntities(m_Sut);

            // Act
            TestEntity actual = m_Sut.FindById(1);

            // Assert
            Assert.AreEqual(1,
                            actual.Id);
        }

        [Test]
        public void FindById_ReturnsNull_ForUnknownId()
        {
            // Arrange
            var unknownId = 1234;

            // Act
            TestEntity actual = m_Sut.FindById(unknownId);

            // Assert
            Assert.Null(actual);
        }

        [Test]
        public void Remove_DeletesEntity_ForKnownEntity()
        {
            // Arrange
            var entity = new TestEntity(1);
            m_Sut.Save(entity);

            // Act
            m_Sut.Remove(entity);

            // Assert
            Assert.Null(m_Sut.FindById(entity.Id));
        }

        [Test]
        public void Remove_DoesNotThrow_ForUnknownEntity()
        {
            // Arrange
            var entity = new TestEntity(1);

            // Act
            // Assert
            Assert.DoesNotThrow(() => m_Sut.Remove(entity));
        }

        [Test]
        public void Save_CreatesNewId_ForIdIsZeroAndRepositoryEmpty()
        {
            // Arrange
            var entity = new TestEntity(0);

            // Act
            m_Sut.Save(entity);

            // Assert
            Assert.AreEqual(1,
                            entity.Id);
        }

        [Test]
        public void Save_CreatesNewId_ForIdIsZeroAndRepositoryNotEmpty()
        {
            // Arrange
            var one = new TestEntity(0);
            m_Sut.Save(one);

            var entity = new TestEntity(0);

            // Act
            m_Sut.Save(entity);

            // Assert
            Assert.AreEqual(2,
                            entity.Id);
        }

        [Test]
        public void Save_DoesNotThrow_WhenCalled()
        {
            // Arrange
            // Act
            // Assert
            Assert.DoesNotThrow(() => m_Sut.Save());
        }

        [Test]
        public void Save_ReplacesEntity_ForExistingEntity()
        {
            // Arrange
            var entity = new TestEntity(1);
            m_Sut.Save(entity);

            var replaceEntity = new TestEntity(1);

            // Act
            m_Sut.Save(replaceEntity);

            // Assert
            Assert.AreEqual(replaceEntity,
                            m_Sut.FindById(1));
        }

        [Test]
        public void Save_StoresEntity_ForNewEntity()
        {
            // Arrange
            var entity = new TestEntity(1);

            // Act
            m_Sut.Save(entity);

            // Assert
            Assert.AreEqual(entity,
                            m_Sut.FindById(1));
        }
    }
}