namespace KataMinesweeper.Interfaces
{
    public interface IPlayingField
    {
        int RowsCount { get; }

        int ColumnsCount { get; }
        GameStatus.Player Status { get; }

        bool HasPlayerWon();

        void SelectField(int row,
                         int column);

        bool IsSelected(int row,
                        int column);
    }
}