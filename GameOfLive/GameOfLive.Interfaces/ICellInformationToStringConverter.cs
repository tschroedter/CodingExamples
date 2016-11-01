using System.Collections.Generic;
using GameOfLive.Interfaces.Board;
using JetBrains.Annotations;

namespace GameOfLive.Interfaces
{
    public interface ICellInformationToStringConverter
    {
        IEnumerable <string> Convert([NotNull] IEnumerable <ICellInformation> cells);
    }
}