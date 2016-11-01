using GameOfLive.Interfaces.Rules.Conditions;

namespace GameOfLive.Board.Rules.Conditions
{
    public class IsMoreThan
        : BaseCondition,
          ICondition
    {
        public override bool IsSatisfied()
        {
            return Actual > Threshold;
        }
    }
}