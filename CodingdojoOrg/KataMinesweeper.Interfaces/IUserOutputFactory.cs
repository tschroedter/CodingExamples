using JetBrains.Annotations;
using Selkie.Windsor;

namespace KataMinesweeper.Interfaces
{
    public interface IUserOutputFactory : ITypedFactory
    {
        IUserOutput Create([NotNull] IHintField hintField,
                           [NotNull] IPlayingField playingField);

        void Release([NotNull] IDisplayPlayingField mineLayer);
    }
}