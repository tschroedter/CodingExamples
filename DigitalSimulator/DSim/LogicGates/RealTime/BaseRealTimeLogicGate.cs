using System.Collections.Generic;
using System.Linq;
using DSim.Common;
using JetBrains.Annotations;

namespace DSim.LogicGates.RealTime
{
    public abstract class BaseRealTimeLogicGate
        : IBaseRealTimeLogicGate
    {
        private readonly IAgenda m_Agenda;
        private readonly IDisposer m_Disposer;

        protected BaseRealTimeLogicGate([NotNull] IDisposer disposer,
                                        [NotNull] IAgenda agenda,
                                        [NotNull] IEnumerable <IWire> wiresIn,
                                        [NotNull] IEnumerable <IWire> wiresOut)
        {
            m_Disposer = disposer;
            m_Agenda = agenda;
            Inputs = wiresIn;
            Outputs = wiresOut;

            SignalChangedHandlersSubscribe();
            m_Disposer.AddResource(SignalChangedHandlersUnsubscribe);
        }

        public IEnumerable <IWire> Inputs { get; private set; }
        public IEnumerable <IWire> Outputs { get; private set; }

        public void Dispose()
        {
            if ( !m_Disposer.IsDisposed )
            {
                m_Disposer.Dispose();
            }
        }

        public IWire GetInputWithIndex(int number)
        {
            IWire input = Inputs.ElementAt(number);

            return input;
        }

        public IWire GetOutputWithIndex(int number)
        {
            IWire input = Outputs.ElementAt(number);

            return input;
        }

        public abstract void Run(int time);

        internal void SignalChangedHandlersSubscribe()
        {
            foreach ( IWire input in Inputs )
            {
                input.SignalChangedEvent += SignalChangedHandler;
            }
        }

        internal void SignalChangedHandlersUnsubscribe()
        {
            foreach ( IWire input in Inputs )
            {
                input.SignalChangedEvent -= SignalChangedHandler;
            }
        }

        internal void SignalChangedHandler(object sender,
                                           SignalChangedEventArgs e)
        {
            OnSignalChanged(e.Time + GetDelay());
        }

        protected void OnSignalChanged(int time) // todo this might go away
        {
            m_Agenda.Schedule(time,
                              this);
        }

        protected abstract int GetDelay();
    }
}