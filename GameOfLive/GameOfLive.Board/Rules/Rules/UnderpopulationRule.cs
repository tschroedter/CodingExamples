using GameOfLive.Board.Rules.Conditions;
using GameOfLive.Interfaces.Board;
using GameOfLive.Interfaces.Rules.Rules;

namespace GameOfLive.Board.Rules.Rules
{
    public class UnderpopulationRule
        : BaseCellInformationRule,
          IRule <ICellInformation>
    {
        public override void Initialize(ICellInformation info)
        {
            Conditions.Add(new IsLessThan
                           {
                               Threshold = 2,
                               Actual = info.NeighboursAlive
                           });
        }

        public override ICellInformation Apply(ICellInformation info)
        {
            info.Status = Cell.Status.Dead;

            return info;
        }

        public override int GetPriority()
        {
            return 1;
        }
    }
}