using GameOfLive.Board.Rules.Conditions;
using GameOfLive.Interfaces.Board;
using GameOfLive.Interfaces.Rules.Rules;

namespace GameOfLive.Board.Rules.Rules
{
    public class SurvivorRule
        : BaseCellInformationRule,
          IRule <ICellInformation>
    {
        public override void Initialize(ICellInformation info)
        {
            Conditions.Add(new IsMoreThan
                           {
                               Threshold = 1,
                               Actual = info.NeighboursAlive
                           });

            Conditions.Add(new IsLessThan
                           {
                               Threshold = 4,
                               Actual = info.NeighboursAlive
                           });
        }

        public override ICellInformation Apply(ICellInformation info)
        {
            info.Status = Cell.Status.Alive;

            return info;
        }

        public override int GetPriority()
        {
            return 3;
        }
    }
}