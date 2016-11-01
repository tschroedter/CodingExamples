using System.Collections.Generic;
using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;

namespace Evaluation.Interfaces.Importers.CSV
{
    public interface IImporter
    {
        [NotNull]
        IEnumerable <IPoint3D> Points { get; }

        void FromFile([NotNull] string filename);
    }
}