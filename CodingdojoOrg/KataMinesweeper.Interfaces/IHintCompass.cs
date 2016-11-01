namespace KataMinesweeper.Interfaces
{
    public interface IHintCompass
    {
        int GetMineCountFor(int rowIndex,
                            int columnIndex);
    }
}