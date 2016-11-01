using DSim.Common;
using NSubstitute;
using NUnit.Framework;
using Should;

namespace DSim.Tests.Common
{
    [TestFixture]
    internal sealed class TimedTaskTests
    {
        [SetUp]
        public void Setup()
        {
            m_One = new TimedTask(12,
                                  Substitute.For <ITask>());
            m_Two = new TimedTask(13,
                                  Substitute.For <ITask>());
            m_SameTimeAsOne = new TimedTask(12,
                                            Substitute.For <ITask>());
        }

        private TimedTask m_One;
        private TimedTask m_Two;
        private TimedTask m_SameTimeAsOne;

        [Test]
        public void CompareTo_ReturnsGreaterThanZero_ForSameTimeButDifferentId()
        {
            // Arrange
            // Act
            int actual = m_SameTimeAsOne.CompareTo(m_One);

            // Assert
            actual.ShouldBeGreaterThan(0);
        }

        [Test]
        public void CompareTo_ReturnsGreaterThanZero_ForTime13And12()
        {
            // Arrange
            // Act
            int actual = m_Two.CompareTo(m_One);

            // Assert
            actual.ShouldBeGreaterThan(0);
        }

        [Test]
        public void CompareTo_ReturnsLessThanZero_ForSameTimeButDifferentId()
        {
            // Arrange
            // Act
            int actual = m_One.CompareTo(m_SameTimeAsOne);

            // Assert
            actual.ShouldBeLessThan(0);
        }

        [Test]
        public void CompareTo_ReturnsLessThanZero_ForTime12And13()
        {
            // Arrange
            // Act
            int actual = m_One.CompareTo(m_Two);

            // Assert
            actual.ShouldBeLessThan(0);
        }

        [Test]
        public void CompareTo_ReturnsZero_ForSameTimeAndId()
        {
            // Arrange
            // Act
            int actual = m_Two.CompareTo(m_Two);

            // Assert
            actual.ShouldEqual(0);
        }

        [Test]
        public void Run_CallsRunOnTask_WhenCalled()
        {
            // Arrange
            var task = Substitute.For <ITask>();
            var sut = new TimedTask(123,
                                    task);

            // Act
            sut.Run();

            // Assert
            task.Received().Run(123);
        }
    }
}