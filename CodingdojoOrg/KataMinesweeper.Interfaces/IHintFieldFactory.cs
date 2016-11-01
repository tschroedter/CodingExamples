using JetBrains.Annotations;
using Selkie.Windsor;

namespace KataMinesweeper.Interfaces
{
    public interface IHintFieldFactory : ITypedFactory
    {
        IHintField Create([NotNull] IMineField mineField);
        void Release([NotNull] IHintField mineLayer);
    }
}