namespace GameOfLive.Interfaces.Rules.Rules
{
    public interface IRule <T>
    {
        int Priority { get; }
        void ClearConditions();
        void Initialize(T info);
        bool IsValid();
        T Apply(T info);
    }
}