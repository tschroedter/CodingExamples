using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Evaluation.Geometry.Calculators;
using Evaluation.Geometry.Shapes;
using Evaluation.Interfaces.Geometry.Calculators;
using Evaluation.Interfaces.Repositories;
using Evaluation.Interfaces.Shapes;
using Evaluation.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace Evaluation.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class RepositoryPointsShifterTests
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

            m_Points = new[]
                       {
                           m_PointOne,
                           m_PointTwo
                       };

            m_ShiftByPoint = new Point3D(-1,
                                         1.0,
                                         1.0,
                                         1.0,
                                         "Shift By Point");

            m_Repository = Substitute.For <IPointsRepository>();
            m_Repository.All().Returns(m_Points);

            m_Calculator = Substitute.For <IShiftPointCalculator>();

            m_Sut = new RepositoryPointsShifter(m_Calculator);
        }

        private IShiftPointCalculator m_Calculator;
        private RepositoryPointsShifter m_Sut;
        private Point3D m_ShiftByPoint;
        private IPointsRepository m_Repository;
        private IEnumerable <IPoint3D> m_Points;
        private Point3D m_PointTwo;
        private Point3D m_PointOne;

        private RepositoryPointsShifter CreateSut()
        {
            return new RepositoryPointsShifter(new ShiftPointCalculator());
        }

        private IEnumerable <Point3D> CreateExpectedShiftedPoints()
        {
            var one = new Point3D(1,
                                  2.0,
                                  2.0,
                                  2.0,
                                  "Point One");


            var two = new Point3D(2,
                                  3.0,
                                  3.0,
                                  3.0,
                                  "Point Two");

            return new[]
                   {
                       one,
                       two
                   };
        }

        private PointsRepository CreateAndPopulatePointsRepository()
        {
            var repository = new PointsRepository();

            repository.AddRange(m_Points);

            return repository;
        }

        [Test]
        public void Shift_CallsAddRangeOnRepository_WhenCalled()
        {
            // Arrange
            // Act
            m_Sut.Shift(m_Repository,
                        m_ShiftByPoint);

            // Assert
            m_Repository.Received().AddRange(Arg.Any <IEnumerable <IPoint3D>>());
        }

        [Test]
        public void Shift_CallsClearOnRepository_WhenCalled()
        {
            // Arrange
            // Act
            m_Sut.Shift(m_Repository,
                        m_ShiftByPoint);

            // Assert
            m_Repository.Received().Clear();
        }

        [Test]
        public void Shift_ShiftsAllPoints_WhenCalled()
        {
            // Arrange
            IEnumerable <Point3D> expected = CreateExpectedShiftedPoints();
            PointsRepository repository = CreateAndPopulatePointsRepository();
            RepositoryPointsShifter sut = CreateSut();

            // Act
            sut.Shift(repository,
                      m_ShiftByPoint);

            // Assert
            NUnitHelper.AssertPoint3Ds(expected,
                                       repository.All());
        }
    }
}