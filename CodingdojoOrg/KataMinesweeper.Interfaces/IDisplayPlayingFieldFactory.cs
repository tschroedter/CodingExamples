using JetBrains.Annotations;
using Selkie.Windsor;

namespace KataMinesweeper.Interfaces
{
    public interface IDisplayPlayingFieldFactory : ITypedFactory
    {
        IDisplayPlayingField Create([NotNull] IHintField hintField,
                                    [NotNull] IPlayingField playingField);

        void Release([NotNull] IDisplayPlayingField mineLayer);
    }
}