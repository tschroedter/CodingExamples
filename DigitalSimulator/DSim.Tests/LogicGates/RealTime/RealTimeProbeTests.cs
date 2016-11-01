using DSim.Common;
using DSim.LogicGates.RealTime;
using NSubstitute;
using NUnit.Framework;

namespace DSim.Tests.LogicGates.RealTime
{
    [TestFixture]
    internal sealed class RealTimeProbeTests
    {
        [SetUp]
        public void Setup()
        {
            m_Disposer = Substitute.For <IDisposer>();
            m_Agenda = Substitute.For <IAgenda>();
            m_WireIn = Substitute.For <IWire>();
            m_Probe = Substitute.For <IProbe>();

            m_Factory = Substitute.For <IProbeFactory>();
            m_Factory.Create(Arg.Any <IWire>()).Returns(m_Probe);

            m_Sut = new RealTimeProbe(m_Disposer,
                                      m_Agenda,
                                      m_WireIn,
                                      m_Factory);
        }

        [TearDown]
        public void Teardown()
        {
            m_Sut.Dispose();
        }

        private const int TimeDoesNotMatter = 0;
        private IWire m_WireIn;
        private IProbe m_Probe;
        private IDisposer m_Disposer;
        private IProbeFactory m_Factory;
        private RealTimeProbe m_Sut;
        private IAgenda m_Agenda;

        [Test]
        public void GetLog_CallsProbe_WhenCalled()
        {
            // Arrange
            // Act
            m_Sut.GetLog();

            // Assert
            m_Probe.Received().GetLog();
        }

        [Test]
        public void GetSignal_CallsGetSignal_WhenCalled()
        {
            // Arrange
            m_Probe.GetSignal().Returns(true);

            // Act
            bool actual = m_Sut.GetSignal();

            // Assert
            Assert.True(actual);
        }

        // todo remove
//        [Test]
//        public void SignalChangedHandler_CallsCalculate_WhenSignalChanges()
//        {
//            // Arrange
//            // Act
//            m_WireIn.SignalChangedEvent += Raise.EventWith(new SignalChangedEventArgs(TimeDoesNotMatter));
//
//            // Assert
//            m_Probe.Received().Calculate(TimeDoesNotMatter);
//        }
    }
}