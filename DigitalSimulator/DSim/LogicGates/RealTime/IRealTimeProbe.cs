namespace DSim.LogicGates.RealTime
{
    public interface IRealTimeProbe : IBaseRealTimeLogicGate
    {
        bool GetSignal();
        string GetLog();
    }
}