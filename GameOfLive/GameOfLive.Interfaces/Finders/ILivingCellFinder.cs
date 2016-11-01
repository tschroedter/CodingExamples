using System.Collections.Generic;
using GameOfLive.Interfaces.Board;

namespace GameOfLive.Interfaces.Finders
{
    public interface ILivingCellFinder
    {
        IEnumerable <ICellInformation> Find(Dictionary <int, ICells> board);

        IEnumerable <ICellInformation> Neighbours(Dictionary <int, ICells> rows,
                                                  int rowIndex,
                                                  int columnIndex);
    }
}