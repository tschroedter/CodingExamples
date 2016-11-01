using GameOfLive.Interfaces.Rules.Conditions;

namespace GameOfLive.Board.Rules.Conditions
{
    public class IsEqual
        : BaseCondition,
          ICondition
    {
        public override bool IsSatisfied()
        {
            return Actual == Threshold;
        }
    }
}