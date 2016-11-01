using JetBrains.Annotations;
using Selkie.Windsor;

namespace KataMinesweeper.Interfaces
{
    public interface IMineLayerFactory : ITypedFactory
    {
        IMineLayer Create([NotNull] IMineField mineField);
        void Release([NotNull] IMineLayer mineLayer);
    }
}