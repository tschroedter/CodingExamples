using JetBrains.Annotations;
using Selkie.Windsor;

namespace KataMinesweeper.Interfaces
{
    public interface IPlayingFieldFactory : ITypedFactory
    {
        IPlayingField Create([NotNull] IMineField mineField);
        void Release([NotNull] IPlayingField mineLayer);
    }
}