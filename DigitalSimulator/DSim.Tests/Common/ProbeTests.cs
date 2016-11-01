using DSim.Common;
using NSubstitute;
using NUnit.Framework;

namespace DSim.Tests.Common
{
    [TestFixture]
    internal sealed class ProbeTests
    {
        [SetUp]
        public void Setup()
        {
            m_Wire = Substitute.For <IWire>();
            m_Sut = new Probe(m_Wire);
        }

        private const int TimeDoesNotMatter = 0;
        private IWire m_Wire;
        private Probe m_Sut;

        [Test]
        public void Calculate_AddsToLogString_WhenCalled()
        {
            // Arrange
            m_Wire.GetSignal().Returns(true);

            // Act
            m_Sut.Calculate(TimeDoesNotMatter);

            // Assert
            Assert.AreEqual("[0,1]",
                            m_Sut.GetLog());
        }

        [Test]
        public void Calculate_AddsToLogString_WhenCalledMultipleTimes()
        {
            // Arrange
            m_Wire.GetSignal().Returns(true);
            m_Sut.Calculate(1);
            m_Sut.Calculate(2);
            m_Wire.GetSignal().Returns(false);
            m_Sut.Calculate(3);
            m_Sut.Calculate(4);

            // Act
            string actual = m_Sut.GetLog();

            // Assert
            Assert.AreEqual("[1,1][2,1][3,0][4,0]",
                            actual);
        }

        [Test]
        public void GetSignal_ReturnsTrue_ForWireSignalIsFalse()
        {
            // Arrange
            m_Wire.GetSignal().Returns(false);

            // Act
            bool actual = m_Sut.GetSignal();

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void GetSignal_ReturnsTrue_ForWireSignalIsTrue()
        {
            // Arrange
            m_Wire.GetSignal().Returns(true);

            // Act
            bool actual = m_Sut.GetSignal();

            // Assert
            Assert.True(actual);
        }
    }
}