using System.Diagnostics.CodeAnalysis;
using Evaluation.Geometry.Calculators;
using Evaluation.Geometry.Shapes;
using NUnit.Framework;

namespace Evaluation.Tests.Calculators
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class DistanceCalculator3DTests
    {
        [SetUp]
        public void Setup()
        {
            m_AllPositive = new Point3D(1,
                                        1.0,
                                        1.0,
                                        1.0,
                                        "X,Y,Z are positve");

            m_AllPositiveOther = new Point3D(2,
                                             11.0,
                                             11.0,
                                             11.0,
                                             "X,Y,Z are positve");

            m_AllNegative = new Point3D(1,
                                        -1.0,
                                        -1.0,
                                        -1.0,
                                        "X,Y,Z are negative");

            m_AllNegativeOther = new Point3D(2,
                                             -11.0,
                                             -11.0,
                                             -11.0,
                                             "X,Y,Z are negative");

            m_Sut = new DistanceCalculator3D();
        }

        private DistanceCalculator3D m_Sut;
        private Point3D m_AllPositive;
        private Point3D m_AllPositiveOther;
        private Point3D m_AllNegativeOther;
        private Point3D m_AllNegative;

        [Test]
        public void Calculate_ReturnsDistance_ForAllNegative()
        {
            // Arrange
            // Act
            double actual = m_Sut.Calculate(m_AllNegative,
                                            m_AllNegativeOther);

            // Assert
            NUnitHelper.AssertDouble(17.3205080756888,
                                     actual);
        }

        [Test]
        public void Calculate_ReturnsDistance_ForAllNegativeReverse()
        {
            // Arrange
            // Act
            double actual = m_Sut.Calculate(m_AllNegativeOther,
                                            m_AllNegative);

            // Assert
            NUnitHelper.AssertDouble(17.3205080756888,
                                     actual);
        }

        [Test]
        public void Calculate_ReturnsDistance_ForAllPositive()
        {
            // Arrange
            // Act
            double actual = m_Sut.Calculate(m_AllPositive,
                                            m_AllPositiveOther);

            // Assert
            NUnitHelper.AssertDouble(17.3205080756888,
                                     actual);
        }

        [Test]
        public void Calculate_ReturnsDistance_ForAllPositiveReverse()
        {
            // Arrange
            // Act
            double actual = m_Sut.Calculate(m_AllPositiveOther,
                                            m_AllPositive);

            // Assert
            NUnitHelper.AssertDouble(17.3205080756888,
                                     actual);
        }

        [Test]
        public void Calculate_ReturnsDistance_ForPositiveAndNegative()
        {
            // Arrange
            // Act
            double actual = m_Sut.Calculate(m_AllPositive,
                                            m_AllNegative);

            // Assert
            NUnitHelper.AssertDouble(3.46410161513775,
                                     actual);
        }
    }
}