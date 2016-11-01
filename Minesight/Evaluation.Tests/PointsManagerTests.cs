using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Evaluation.Geometry.Shapes;
using Evaluation.Interfaces.Repositories;
using Evaluation.Interfaces.Shapes;
using NSubstitute;
using NUnit.Framework;

namespace Evaluation.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class PointsManagerTests
    {
        [SetUp]
        public void Setup()
        {
            m_PointOne = new Point3D(1,
                                     1.0,
                                     1.0,
                                     1.0,
                                     "Point One");


            m_PointTwo = new Point3D(2,
                                     2.0,
                                     2.0,
                                     2.0,
                                     "Point Two");

            m_ShiftByPoint = new Point3D(-1,
                                         1.0,
                                         1.0,
                                         1.0,
                                         "Shift By Point");

            m_Points = new[]
                       {
                           m_PointOne,
                           m_PointTwo
                       };

            m_Repository = Substitute.For <IPointsRepository>();
            m_Shifter = Substitute.For <IRepositoryPointsShifter>();

            m_Sut = new PointsManager(m_Repository,
                                      m_Shifter);
        }

        private IPointsRepository m_Repository;
        private PointsManager m_Sut;
        private IRepositoryPointsShifter m_Shifter;
        private Point3D m_PointOne;
        private Point3D m_PointTwo;
        private Point3D[] m_Points;
        private Point3D m_ShiftByPoint;

        [Test]
        public void Add_CallsRepository_WhenCalled()
        {
            // Arrange
            // Act
            m_Sut.Add(m_PointOne);

            // Assert
            m_Repository.Received().Add(m_PointOne);
        }

        [Test]
        public void AddRange_CallsAddRangeOnRepository_WhenCalled()
        {
            // Arrange
            // Act
            m_Sut.AddRange(m_Points);

            // Assert
            m_Repository.Received().AddRange(m_Points);
        }

        [Test]
        public void All_CallsRepository_WhenCalled()
        {
            // Arrange
            m_Repository.All().Returns(m_Points);

            // Act
            IEnumerable <IPoint3D> actual = m_Sut.All();

            // Assert
            Assert.AreEqual(m_Points,
                            actual);
        }

        [Test]
        public void Clear_CallsRepository_WhenCalled()
        {
            // Arrange
            // Act
            m_Sut.Clear();

            // Assert
            m_Repository.Received().Clear();
        }

        [Test]
        public void Count_CallsRepository_WhenCalled()
        {
            // Arrange
            m_Repository.Count().Returns(123);

            // Act
            int actual = m_Sut.Count();

            // Assert
            Assert.AreEqual(123,
                            actual);
        }

        [Test]
        public void Get_CallsRepository_WhenCalled()
        {
            // Arrange
            m_Repository.Get(1).Returns(m_PointOne);

            // Act
            IPoint3D actual = m_Sut.Get(1);

            // Assert
            Assert.AreEqual(m_PointOne,
                            actual);
        }

        [Test]
        public void Remove_CallsRepository_WhenCalled()
        {
            // Arrange
            // Act
            m_Sut.Remove(m_PointOne);

            // Assert
            m_Repository.Received().Remove(m_PointOne);
        }

        [Test]
        public void Shift_CallsAddRangeOnRepository_WhenCalled()
        {
            // Arrange
            // Act
            m_Sut.Shift(m_ShiftByPoint);

            // Assert
            m_Shifter.Received().Shift(m_Repository,
                                       m_ShiftByPoint);
        }
    }
}