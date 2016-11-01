using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Evaluation.Geometry.Shapes;
using Evaluation.Interfaces.Shapes;
using Evaluation.Repositories;
using NUnit.Framework;

namespace Evaluation.Tests.Repositories
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class PointsRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new PointsRepository();
        }

        private PointsRepository m_Sut;

        private Point3D CreatePoint()
        {
            return new Point3D(1,
                               1.0,
                               2.0,
                               3.0,
                               "");
        }

        private Point3D CreateOtherPointWithSameId()
        {
            return new Point3D(1,
                               11.0,
                               22.0,
                               33.0,
                               "Other");
        }

        private Point3D CreateOtherPoint()
        {
            return new Point3D(3,
                               111.0,
                               222.0,
                               333.0,
                               "Other Id");
        }

        [Test]
        public void Add_AddsPoints_ForNewPoint()
        {
            // Arrange
            Point3D point = CreatePoint();

            // Act
            m_Sut.Add(point);

            // Assert
            IPoint3D actual = m_Sut.Get(point.Id);

            Assert.NotNull(actual);

            NUnitHelper.AssertPoint3D(point,
                                      actual);
        }

        [Test]
        public void Add_ReplacesPoint_ForAddingPointWithSameIdTwice()
        {
            // Arrange
            Point3D point = CreatePoint();
            Point3D pointOther = CreateOtherPointWithSameId();

            // Act
            m_Sut.Add(point);
            m_Sut.Add(pointOther);

            // Assert
            IPoint3D actual = m_Sut.Get(point.Id);

            Assert.NotNull(actual);

            NUnitHelper.AssertPoint3D(pointOther,
                                      actual);
        }

        [Test]
        public void AddRange_AddsAllPoint_WhenCalled()
        {
            // Arrange
            Point3D pointOne = CreatePoint();
            Point3D pointTwo = CreateOtherPoint();
            var expected = new[]
                           {
                               pointOne,
                               pointTwo
                           };

            // Act
            m_Sut.AddRange(expected);

            // Assert
            NUnitHelper.AssertPoint3Ds(expected,
                                       m_Sut.All());
        }

        [Test]
        public void All_ReturnsCoints_WhenCalled()
        {
            // Arrange
            Point3D point = CreatePoint();
            Point3D pointOther = CreateOtherPoint();

            var expected = new[]
                           {
                               point,
                               pointOther
                           };

            // Act
            m_Sut.Add(point);
            m_Sut.Add(pointOther);

            // Assert
            IEnumerable <IPoint3D> actual = m_Sut.All();

            NUnitHelper.AssertPoint3Ds(expected,
                                       actual);
        }

        [Test]
        public void Clear_RemovesAllPoint_WhenCalled()
        {
            // Arrange
            Point3D point = CreatePoint();

            m_Sut.Add(point);

            // Act
            m_Sut.Clear();

            // Assert
            Assert.AreEqual(0,
                            m_Sut.Count());
        }

        [Test]
        public void Count_ReturnsCount_ForPoints()
        {
            // Arrange
            Point3D point = CreatePoint();

            m_Sut.Add(point);

            // Act
            int actual = m_Sut.Count();

            // Assert
            Assert.AreEqual(1,
                            actual);
        }

        [Test]
        public void Remove_RemovesPoint_ForExistingPoint()
        {
            // Arrange
            Point3D point = CreatePoint();

            m_Sut.Add(point);

            // Act
            m_Sut.Remove(point);

            // Assert
            Assert.Null(m_Sut.Get(point.Id));
        }
    }
}