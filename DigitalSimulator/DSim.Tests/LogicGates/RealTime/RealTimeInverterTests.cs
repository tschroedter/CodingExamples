using DSim.Common;
using DSim.LogicGates;
using DSim.LogicGates.RealTime;
using NSubstitute;
using NUnit.Framework;

namespace DSim.Tests.LogicGates.RealTime
{
    [TestFixture]
    internal sealed class RealTimeInverterTests
    {
        [SetUp]
        public void Setup()
        {
            m_Disposer = Substitute.For <IDisposer>();
            m_Agenda = Substitute.For <IAgenda>();
            m_WireIn = Substitute.For <IWire>();
            m_WireOut = Substitute.For <IWire>();
            m_Inverter = Substitute.For <IInverter>();

            m_Factory = Substitute.For <IInverterFactory>();
            m_Factory.Create(Arg.Any <IWire>(),
                             Arg.Any <IWire>()).Returns(m_Inverter);

            m_Sut = new RealTimeInverter(m_Disposer,
                                         m_Agenda,
                                         m_Factory,
                                         m_WireIn,
                                         m_WireOut);
        }

        [TearDown]
        public void Teardown()
        {
            m_Sut.Dispose();
        }

        private const int TimeDoesNotMatter = 0;
        private IWire m_WireIn;
        private IWire m_WireOut;
        private IInverter m_Inverter;
        private IDisposer m_Disposer;
        private IInverterFactory m_Factory;
        private RealTimeInverter m_Sut;
        private IAgenda m_Agenda;

        // todo remove ?
//        [Test]
//        public void SignalChangedHandler_CallsCalculate_WhenSignalChanges()
//        {
//            // Arrange
//            // Act
//            m_WireIn.SignalChangedEvent += Raise.EventWith(new SignalChangedEventArgs(TimeDoesNotMatter));
//
//            // Assert
//            m_Inverter.Received().Calculate(RealTimeInverter.Delay);
//        }
    }
}