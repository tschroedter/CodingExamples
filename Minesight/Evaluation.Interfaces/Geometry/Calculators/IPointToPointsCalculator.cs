using System.Collections.Generic;
using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;

namespace Evaluation.Interfaces.Geometry.Calculators
{
    public interface IPointToPointsCalculator
    {
        void Calculate([NotNull] IPoint3D fromPoint3D);

        [NotNull]
        IEnumerable <double> Distances();

        [NotNull]
        IEnumerable <int> Ids();
    }
}