using Importer.Interfaces;

namespace Importer
{
    public class Silence : ISilence
    {
        public const float DelayTimeForCut = 0.1f;

        public Silence(float start,
                       float end,
                       float duration)
        {
            Start = start;
            End = end;
            Duration = duration;
            CutTime = start + DelayTimeForCut;
        }

        public float Start { get; private set; }
        public float End { get; private set; }
        public float Duration { get; private set; }
        public float CutTime { get; private set; }
    }
}