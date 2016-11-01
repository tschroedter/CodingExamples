using JetBrains.Annotations;

namespace KataMinesweeper.Interfaces
{
    public interface IStringToMineFieldConverter
    {
        IMineField ToMineField([NotNull] string text);
    }
}