using System.Collections.Generic;
using JetBrains.Annotations;

namespace GameOfLive.Interfaces.Board
{
    public interface IBoard
    {
        Cell.Status GetStatus(int rowIndex,
                              int columnIndex);

        void SetStatus(int rowIndex,
                       int columnIndex,
                       Cell.Status status);

        [NotNull]
        IEnumerable <ICellInformation> LivingCells();

        void Update([NotNull] IEnumerable <ICellInformation> cells);

        [NotNull]
        IEnumerable <ICellInformation> Neighbours([NotNull] ICellInformation cell);
    }
}