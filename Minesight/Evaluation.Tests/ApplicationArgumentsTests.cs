using System;
using System.Diagnostics.CodeAnalysis;
using Evaluation.Geometry.Shapes;
using Evaluation.Interfaces.Shapes;
using NUnit.Framework;

namespace Evaluation.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class ApplicationArgumentsTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new ApplicationArguments
                    {
                        Source = "Source",
                        NumberOfClosestPoints = 1,
                        QueryPointCoordinates = "-1.0 2.0 -3.0",
                        ShiftPointCoordinates = "-11.0 22.0 -33.0",
                        Verbose = true
                    };
        }

        private ApplicationArguments m_Sut;

        [Test]
        public void GetQueryPoint3D_ReturnsPoint_ForValidString()
        {
            // Arrange
            var expected = new Point3D(-1,
                                       -1.0,
                                       2.0,
                                       -3.0,
                                       "Query Point");
            // Act
            IPoint3D actual = m_Sut.GetQueryPoint3D();

            // Assert
            NUnitHelper.AssertPoint3D(expected,
                                      actual);
        }

        [Test]
        public void GetQueryPoint3D_ThrowsException_ForInvalidString()
        {
            // Arrange
            m_Sut.QueryPointCoordinates = "invalid";

            // Act
            // Assert
            Assert.Throws <FormatException>(() => m_Sut.GetQueryPoint3D());
        }

        [Test]
        public void GetShiftVector3D_ReturnsPoint_ForValidString()
        {
            // Arrange
            var expected = new Point3D(-1,
                                       -11.0,
                                       22.0,
                                       -33.0,
                                       "Shift Vector");
            // Act
            IPoint3D actual = m_Sut.GetShiftVector3D();

            // Assert
            NUnitHelper.AssertPoint3D(expected,
                                      actual);
        }

        [Test]
        public void NumberOfClosestPoints_ReturnsNumberOfClosestPoints_WhenCalled()
        {
            Assert.AreEqual(1,
                            m_Sut.NumberOfClosestPoints);
        }

        [Test]
        public void Source_ReturnsSource_WhenCalled()
        {
            Assert.AreEqual("Source",
                            m_Sut.Source);
        }

        [Test]
        public void Verbose_ReturnsTrue_WhenCalled()
        {
            Assert.True(m_Sut.Verbose);
        }
    }
}