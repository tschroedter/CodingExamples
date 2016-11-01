using JetBrains.Annotations;

namespace KataMinesweeper.Interfaces
{
    public interface IGame
    {
        void Start();

        void Initialize(int numberOfRows,
                        int numberOfColumns,
                        int numberOfMines);

        void Initialize([NotNull] string text);
    }
}