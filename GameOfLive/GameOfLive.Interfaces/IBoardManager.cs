using System.Collections.Generic;
using GameOfLive.Interfaces.Board;
using JetBrains.Annotations;

namespace GameOfLive.Interfaces
{
    public interface IBoardManager
    {
        void SetDeadCell(int rowIndex,
                         int columnIndex);

        void SetAliveCell(int rowIndex,
                          int columnIndex);

        void NextGeneration();
        void Update([NotNull] IEnumerable <ICellInformation> cells);

        [NotNull]
        IEnumerable <ICellInformation> LivingCells();
    }
}