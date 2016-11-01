namespace Importer.Interfaces
{
    public interface ISilence
    {
        float Start { get; }
        float End { get; }
        float Duration { get; }
        float CutTime { get; }
    }
}