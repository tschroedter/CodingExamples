namespace GameOfLive.Board.Rules.Conditions
{
    public abstract class BaseCondition
    {
        public int Actual { get; set; }
        public int Threshold { get; set; }

        public abstract bool IsSatisfied();
    }
}