using System.Collections.Generic;

namespace KataMinesweeper.Interfaces
{
    public interface IMineField
    {
        int RowsCount { get; }
        int ColumnsCount { get; }

        void PutMineAt(int row,
                       int column);

        bool IsMineAt(int row,
                      int column);

        void RemoveMineAt(int row,
                          int column);

        IEnumerable <bool> GetRowAt(int numberOfRow);
        IEnumerable <IEnumerable <bool>> Rows();
    }
}