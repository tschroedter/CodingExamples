using System.Diagnostics.CodeAnalysis;
using Evaluation.Geometry.Shapes;
using NUnit.Framework;

namespace Evaluation.Tests.Geometry.Shapes
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class Point3DTests
    {
        private Point3D CreateSutWithPositiveXYZ()
        {
            return new Point3D(1,
                               1.0,
                               2.0,
                               3.0,
                               "Test");
        }

        private Point3D CreateSutWithNegativeXYZ()
        {
            return new Point3D(1,
                               -1.0,
                               -2.0,
                               -3.0,
                               "Negative Test");
        }

        [Test]
        public void Constructor_SetsDescription_WhenCalled()
        {
            // Arrange
            Point3D sut = CreateSutWithPositiveXYZ();

            // Act
            string actual = sut.Description;

            // Assert
            Assert.AreEqual("Test",
                            actual);
        }

        [Test]
        public void Constructor_SetsId_WhenCalled()
        {
            // Arrange
            Point3D sut = CreateSutWithPositiveXYZ();

            // Act
            int actual = sut.Id;

            // Assert
            Assert.AreEqual(1,
                            actual);
        }

        [Test]
        public void Constructor_SetsX_ForNegativeX()
        {
            // Arrange
            Point3D sut = CreateSutWithNegativeXYZ();

            // Act
            double actual = sut.X;

            // Assert
            NUnitHelper.AssertDouble(-1.0,
                                     actual);
        }

        [Test]
        public void Constructor_SetsX_WhenCalled()
        {
            // Arrange
            Point3D sut = CreateSutWithPositiveXYZ();

            // Act
            double actual = sut.X;

            // Assert
            NUnitHelper.AssertDouble(1.0,
                                     actual);
        }

        [Test]
        public void Constructor_SetsY_ForNegativeY()
        {
            // Arrange
            Point3D sut = CreateSutWithNegativeXYZ();

            // Act
            double actual = sut.Y;

            // Assert
            NUnitHelper.AssertDouble(-2.0,
                                     actual);
        }

        [Test]
        public void Constructor_SetsY_WhenCalled()
        {
            // Arrange
            Point3D sut = CreateSutWithPositiveXYZ();

            // Act
            double actual = sut.Y;

            // Assert
            NUnitHelper.AssertDouble(2.0,
                                     actual);
        }

        [Test]
        public void Constructor_SetsZ_ForNegativeZ()
        {
            // Arrange
            Point3D sut = CreateSutWithNegativeXYZ();

            // Act
            double actual = sut.Z;

            // Assert
            NUnitHelper.AssertDouble(-3.0,
                                     actual);
        }

        [Test]
        public void Constructor_SetsZ_WhenCalled()
        {
            // Arrange
            Point3D sut = CreateSutWithPositiveXYZ();

            // Act
            double actual = sut.Z;

            // Assert
            NUnitHelper.AssertDouble(3.0,
                                     actual);
        }
    }
}