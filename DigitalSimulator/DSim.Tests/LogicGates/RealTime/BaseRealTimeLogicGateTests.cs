using System;
using System.Collections.Generic;
using System.Linq;
using DSim.Common;
using DSim.LogicGates.RealTime;
using JetBrains.Annotations;
using NSubstitute;
using NUnit.Framework;
using Should;

namespace DSim.Tests.LogicGates.RealTime
{
    [TestFixture]
    internal sealed class BaseRealTimeLogicGateTests
    {
        [SetUp]
        public void Setup()
        {
            m_Disposer = Substitute.For <IDisposer>();
            m_Agenda = Substitute.For <IAgenda>();
            m_WireIn = Substitute.For <IWire>();
            m_WireOut = Substitute.For <IWire>();

            m_Sut = new TestLogicGate(m_Disposer,
                                      m_Agenda,
                                      m_WireIn,
                                      m_WireOut);
        }

        [TearDown]
        public void Teardown()
        {
            m_Sut.Dispose();
        }

        private class TestLogicGate : BaseRealTimeLogicGate
        {
            public TestLogicGate([NotNull] IDisposer disposer,
                                 [NotNull] IAgenda agenda,
                                 [NotNull] IWire wireIn,
                                 [NotNull] IWire wireOut)
                : base(disposer,
                       agenda,
                       new[]
                       {
                           wireIn
                       },
                       new[]
                       {
                           wireOut
                       })
            {
            }

            public bool WasCalledOnSignalChanged { get; private set; }

            public int TimeWhenSignalChanged { get; private set; }

            public bool WasCalledRun { get; private set; }

// todo remove ?
//            protected override void OnSignalChanged(int time)
//            {
//                WasCalledOnSignalChanged = true;
//                TimeWhenSignalChanged = time;
//            }

            protected override int GetDelay()
            {
                return 5;
            }

            public override void Run(int time)
            {
                WasCalledRun = true;
            }

            public void CallRun(int time)
            {
                Run(time);
            }
        }

        private const int TimeDoesNotMatter = 0;
        private IWire m_WireIn;
        private IDisposer m_Disposer;
        private TestLogicGate m_Sut;
        private IWire m_WireOut;
        private IAgenda m_Agenda;

        [Test]
        public void Constructor_AddsListener_WhenCalled()
        {
            // Arrange
            // Act
            // Assert
            m_WireIn.Received().SignalChangedEvent += m_Sut.SignalChangedHandler;
        }

        [Test]
        public void Constructor_AddsListenerToDisposer_WhenCalled()
        {
            // Arrange
            // Act
            // Assert
            m_Disposer.Received().AddResource(m_Sut.SignalChangedHandlersUnsubscribe);
        }

        [Test]
        public void Dispose_CallsDisposer_WhenCalled()
        {
            // Arrange
            // Act
            m_Sut.Dispose();

            // Assert
            m_Disposer.Received().Dispose();
        }

        [Test]
        public void GetInputWithIndex_ReturnsWireIn_ForZero()
        {
            // Arrange
            // Act
            IWire actual = m_Sut.GetInputWithIndex(0);

            // Assert
            actual.ShouldEqual(m_WireIn);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(100)]
        public void GetInputWithIndex_ThrowsException_ForInvalidIndex(int index)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws <ArgumentOutOfRangeException>(() => m_Sut.GetInputWithIndex(index));
        }

        [Test]
        public void GetOutputWithIndex_ReturnsWireIn_ForZero()
        {
            // Arrange
            // Act
            IWire actual = m_Sut.GetOutputWithIndex(0);

            // Assert
            actual.ShouldEqual(m_WireOut);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(100)]
        public void GetOutputWithIndex_ThrowsException_ForInvalidIndex(int index)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws <ArgumentOutOfRangeException>(() => m_Sut.GetOutputWithIndex(index));
        }

        [Test]
        public void Inputs_ContainsInputWire_WhenCalled()
        {
            // Arrange
            // Act
            IEnumerable <IWire> actual = m_Sut.Inputs;

            // Assert
            actual.ShouldContain(m_WireIn);
        }

        [Test]
        public void Inputs_ReturnsInputs_WhenCalled()
        {
            // Arrange
            // Act
            IEnumerable <IWire> actual = m_Sut.Inputs;

            // Assert
            actual.Count().ShouldEqual(1);
        }

        [Test]
        public void Output_ReturnsOutput_WhenCalled()
        {
            // Arrange
            // Act
            IWire actual = m_Sut.GetOutputWithIndex(0);

            // Assert
            actual.ShouldEqual(m_WireOut);
        }

        [Test]
        public void Run_IsCalled_ForCallRun()
        {
            // Arrange
            // Act
            m_Sut.CallRun(123);

            // Assert
            m_Sut.WasCalledRun.ShouldBeTrue();
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
//            m_Sut.WasCalledOnSignalChanged.ShouldBeTrue();
//        }
//
//        [Test]
//        public void SignalChangedHandler_CallsCalculateWithCorrectTime_WhenSignalChanges()
//        {
//            // Arrange
//            // Act
//            m_WireIn.SignalChangedEvent += Raise.EventWith(new SignalChangedEventArgs(2));
//
//            // Assert
//            m_Sut.TimeWhenSignalChanged.ShouldEqual(2 + 5);
//        }

        [Test]
        public void SignalChangedHandlerUnsubscribe_Unsubscribes_WhenCalled()
        {
            // Arrange
            // Act
            m_Sut.SignalChangedHandlersUnsubscribe();

            // Assert
            m_WireIn.Received().SignalChangedEvent -= m_Sut.SignalChangedHandler;
        }
    }
}