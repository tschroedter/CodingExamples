using JetBrains.Annotations;
using KataMinesweeper.Interfaces;
using Selkie.Windsor;

namespace KataMinesweeper
{
    public interface IHintCompassFactory : ITypedFactory
    {
        IHintCompass Create([NotNull] IMineField mineField);
        void Release([NotNull] IHintCompass hintCompass);
    }
}