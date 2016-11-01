using System;

namespace DSim.Common
{
    public class SignalChangedEventArgs : EventArgs
    {
        public SignalChangedEventArgs(int time)
        {
            Time = time;
        }

        public int Time { get; private set; }
    }
}