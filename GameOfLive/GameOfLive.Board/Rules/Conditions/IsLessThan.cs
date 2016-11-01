using GameOfLive.Interfaces.Rules.Conditions;

namespace GameOfLive.Board.Rules.Conditions
{
    public class IsLessThan
        : BaseCondition,
          ICondition
    {
        public override bool IsSatisfied()
        {
            return Actual < Threshold;
        }
    }
}