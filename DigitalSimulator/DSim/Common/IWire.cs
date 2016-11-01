using System;

namespace DSim.Common
{
    public interface IWire
    {
        int Id { get; }
        string Name { get; set; }
        bool GetSignal();

        void SetSignal(int time,
                       bool value);

        event EventHandler <SignalChangedEventArgs> SignalChangedEvent;
    }
}