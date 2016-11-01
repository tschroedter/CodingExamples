using DSim.Common;
using DSim.LogicGates;
using DSim.LogicGates.RealTime;
using NSubstitute;
using NUnit.Framework;

namespace DSim.Tests.LogicGates.RealTime
{
    [TestFixture]
    internal sealed class RealTimeOrTests
    {
        [SetUp]
        public void Setup()
        {
            m_Disposer = Substitute.For <IDisposer>();
            m_Agenda = Substitute.For <IAgenda>();
            m_WireInOne = Substitute.For <IWire>();
            m_WireInTwo = Substitute.For <IWire>();
            m_WireOut = Substitute.For <IWire>();
            m_Or = Substitute.For <IOr>();

            m_Factory = Substitute.For <IOrFactory>();
            m_Factory.Create(Arg.Any <IWire>(),
                             Arg.Any <IWire>(),
                             Arg.Any <IWire>()).Returns(m_Or);

            m_Sut = new RealTimeOr(m_Disposer,
                                   m_Agenda,
                                   m_Factory,
                                   m_WireInOne,
                                   m_WireInTwo,
                                   m_WireOut);
        }

        [TearDown]
        public void Teardown()
        {
            m_Sut.Dispose();
        }

        private const int TimeDoesNotMatter = 0;
        private IWire m_WireInOne;
        private IWire m_WireOut;
        private IOr m_Or;
        private IDisposer m_Disposer;
        private IOrFactory m_Factory;
        private RealTimeOr m_Sut;
        private IWire m_WireInTwo;
        private IAgenda m_Agenda;
        // todo remove
//        [Test]
//        public void SignalChangedHandler_CallsCalculate_WhenSignalChanges()
//        {
//            // Arrange
//            // Act
//            m_WireInOne.SignalChangedEvent += Raise.EventWith(new SignalChangedEventArgs(TimeDoesNotMatter));
//
//            // Assert
//            m_Or.Received().Calculate(RealTimeOr.Delay);
//        }
    }
}