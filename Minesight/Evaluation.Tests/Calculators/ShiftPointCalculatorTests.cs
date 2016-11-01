using System.Diagnostics.CodeAnalysis;
using Evaluation.Geometry.Calculators;
using Evaluation.Geometry.Shapes;
using Evaluation.Interfaces.Shapes;
using NUnit.Framework;

namespace Evaluation.Tests.Calculators
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class ShiftPointCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
            m_Source = new Point3D(1,
                                   0.0,
                                   0.0,
                                   0.0,
                                   "Source");

            m_ShiftBy = new Point3D(2,
                                    1.0,
                                    2.0,
                                    3.0,
                                    "Shift By");

            m_ShiftByReverse = new Point3D(3,
                                           -1.0,
                                           -2.0,
                                           -3.0,
                                           "Shift Reverse By");

            m_Sut = new ShiftPointCalculator();
        }

        private ShiftPointCalculator m_Sut;
        private Point3D m_Source;
        private Point3D m_ShiftBy;
        private Point3D m_ShiftByReverse;

        [Test]
        public void Calculate_ReturnsShiftedPoint_WhenCalled()
        {
            // Arrange
            var expected = new Point3D(1,
                                       1.0,
                                       2.0,
                                       3.0,
                                       "Source");

            // Act
            IPoint3D actual = m_Sut.Calculate(m_Source,
                                              m_ShiftBy);

            // Assert
            NUnitHelper.AssertPoint3D(expected,
                                      actual);
        }

        [Test]
        public void Calculate_ReturnsShiftedPoint_WhenShiftedForwardAndBackwards()
        {
            // Arrange
            IPoint3D shifted = m_Sut.Calculate(m_Source,
                                               m_ShiftBy);

            // Act
            IPoint3D actual = m_Sut.Calculate(shifted,
                                              m_ShiftByReverse);

            // Assert
            NUnitHelper.AssertPoint3D(m_Source,
                                      actual);
        }
    }
}