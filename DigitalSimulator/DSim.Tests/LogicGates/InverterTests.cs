using DSim.Common;
using DSim.LogicGates;
using NUnit.Framework;
using Should;

namespace DSim.Tests.LogicGates
{
    [TestFixture]
    internal sealed class InverterTests
    {
        [SetUp]
        public void Setup()
        {
            m_WireIn = new Wire();
            m_WireOut = new Wire();
        }

        private const int TimeDoesNotMatter = 0;
        private IWire m_WireIn;
        private IWire m_WireOut;

        private static Inverter CreateSut(IWire wireIn,
                                          IWire wireOut)
        {
            return new Inverter(wireIn,
                                wireOut);
        }

        [Test]
        public void Calculate_SetsWireOutToFalse_ForWireInIsTrue()
        {
            // Arrange
            Inverter sut = CreateSut(m_WireIn,
                                     m_WireOut);
            m_WireIn.SetSignal(TimeDoesNotMatter,
                               true);

            // Act
            sut.Calculate(0);

            // Assert
            m_WireOut.GetSignal().ShouldBeFalse();
        }

        [Test]
        public void Calculate_SetsWireOutToTrue_ForWireInIsFalse()
        {
            // Arrange
            Inverter sut = CreateSut(m_WireIn,
                                     m_WireOut);
            m_WireIn.SetSignal(TimeDoesNotMatter,
                               false);

            // Act
            sut.Calculate(TimeDoesNotMatter);

            // Assert
            m_WireOut.GetSignal().ShouldBeTrue();
        }
    }
}