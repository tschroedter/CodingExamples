namespace DSim.Common
{
    public interface IProbe
    {
        bool GetSignal();
        void Calculate(int time);
        string GetLog();
    }
}