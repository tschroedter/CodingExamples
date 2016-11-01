using System;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace DSim.Common
{
    // todo testing
    [ProjectComponent(Lifestyle.Transient)]
    public class Wire : IWire
    {
        private static int s_NextId = 1;

        public Wire()
        {
            Id = s_NextId++;
            Name = Id.ToString();
        }

        private bool Signal { get; set; }

        [NotNull]
        public string Name { get; set; }

        public event EventHandler <SignalChangedEventArgs> SignalChangedEvent;

        public int Id { get; private set; }

        public void SetSignal(int time,
                              bool value)
        {
            Signal = value;

            OnSignalChangedEvent(new SignalChangedEventArgs(time));
        }

        public bool GetSignal()
        {
            return Signal;
        }

        protected virtual void OnSignalChangedEvent(SignalChangedEventArgs e)
        {
            EventHandler <SignalChangedEventArgs> handler = SignalChangedEvent;

            if ( handler != null )
            {
                handler(this,
                        e);
            }
        }
    }
}