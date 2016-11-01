using System.Collections.Generic;
using GameOfLive.Interfaces.Board;
using JetBrains.Annotations;

namespace GameOfLive.Interfaces.Rules
{
    public interface IEngine
    {
        void ApplyRules([NotNull] IEnumerable <ICellInformation> cells);
    }
}