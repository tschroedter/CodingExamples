using System;
using System.Collections.Generic;
using DSim.Common;

namespace DSim.LogicGates.RealTime
{
    public interface IBaseRealTimeLogicGate
        : ITask,
          IDisposable
    {
        IEnumerable <IWire> Inputs { get; }
        IEnumerable <IWire> Outputs { get; }
        IWire GetInputWithIndex(int number);

        IWire GetOutputWithIndex(int number); // todo testing
    }
}