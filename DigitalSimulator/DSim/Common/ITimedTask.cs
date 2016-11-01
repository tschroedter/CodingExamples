namespace DSim.Common
{
    public interface ITimedTask
    {
        int Time { get; }
        int Id { get; }
        void Run();
    }
}