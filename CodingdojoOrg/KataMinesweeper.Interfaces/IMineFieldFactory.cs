using JetBrains.Annotations;
using Selkie.Windsor;

namespace KataMinesweeper.Interfaces
{
    public interface IMineFieldFactory : ITypedFactory
    {
        IMineField Create(int numberOfRows,
                          int numberOfColumns);

        void Release([NotNull] IMineField mineField);
    }
}