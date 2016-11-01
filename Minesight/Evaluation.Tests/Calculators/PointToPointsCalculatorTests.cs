using System.Diagnostics.CodeAnalysis;
using Evaluation.Geometry.Calculators;
using Evaluation.Geometry.Shapes;
using Evaluation.Interfaces;
using Evaluation.Interfaces.Geometry.Calculators;
using NSubstitute;
using NUnit.Framework;

namespace Evaluation.Tests.Calculators
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class PointToPointsCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
            m_FromPoint = new Point3D(0,
                                      0.0,
                                      0.0,
                                      0.0,
                                      "From Point");

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

            m_PointThree = new Point3D(3,
                                       3.0,
                                       3.0,
                                       3.0,
                                       "Point Three");

            m_PointFour = new Point3D(4,
                                      -1.0,
                                      -1.0,
                                      -1.0,
                                      "Same distance as Point One");

            m_Points = new[] // not sorted by distance by default
                       {
                           m_PointThree,
                           m_PointTwo,
                           m_PointOne,
                           m_PointFour
                       };

            m_Manager = Substitute.For <IPointsManager>();
            m_Manager.All().Returns(m_Points);

            m_Calculator = new DistanceCalculator3D();

            m_Sut = new PointToPointsCalculator(m_Manager,
                                                m_Calculator);
        }

        private IPointsManager m_Manager;
        private IDistanceCalculator3D m_Calculator;
        private PointToPointsCalculator m_Sut;
        private Point3D m_PointOne;
        private Point3D m_PointTwo;
        private Point3D[] m_Points;
        private Point3D m_FromPoint;
        private Point3D m_PointThree;
        private Point3D m_PointFour;

        [Test]
        public void Calculate_SetsDistances_WhenCalled()
        {
            // Arrange
            var expected = new[]
                           {
                               1.73205080756888,
                               1.73205080756888,
                               3.46410161513775,
                               5.19615242270663
                           };

            // Act
            m_Sut.Calculate(m_FromPoint);

            // Assert
            NUnitHelper.AssertDoubles(expected,
                                      m_Sut.Distances());
        }

        [Test]
        public void Calculate_SetsIds_WhenCalled()
        {
            // Arrange
            var expected = new[]
                           {
                               1,
                               4,
                               2,
                               3
                           };

            // Act
            m_Sut.Calculate(m_FromPoint);

            // Assert
            NUnitHelper.AssertIntegers(expected,
                                       m_Sut.Ids());
        }
    }
}