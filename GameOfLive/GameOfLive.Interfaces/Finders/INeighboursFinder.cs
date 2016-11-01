using System.Collections.Generic;
using GameOfLive.Interfaces.Board;
using JetBrains.Annotations;

namespace GameOfLive.Interfaces.Finders
{
    public interface INeighboursFinder
    {
        int NumberOfAliveNeighbours([NotNull] Dictionary <int, ICells> rows,
                                    int rowIndex,
                                    int columnIndex);

        IEnumerable <ICellInformation> Neighbours(Dictionary <int, ICells> rows,
                                                  int rowIndex,
                                                  int columnIndex);
    }
}