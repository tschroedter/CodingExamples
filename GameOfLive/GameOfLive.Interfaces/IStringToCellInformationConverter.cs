using System.Collections.Generic;
using GameOfLive.Interfaces.Board;
using JetBrains.Annotations;

namespace GameOfLive.Interfaces
{
    public interface IStringToCellInformationConverter
    {
        IEnumerable <ICellInformation> Convert([NotNull] string[] text);
    }
}