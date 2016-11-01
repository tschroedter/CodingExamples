using System.Collections.Generic;
using JetBrains.Annotations;

namespace Importer.Interfaces
{
    public interface IFfMpeg
    {
        [NotNull]
        string Text { get; }

        [NotNull]
        IEnumerable <ISilence> Silences { get; }

        void Find();
    }
}