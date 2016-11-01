using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;

namespace Evaluation.Interfaces.Geometry.Calculators
{
    public interface IDistanceCalculator3D
    {
        double Calculate([NotNull] IPoint3D fromPoint,
                         [NotNull] IPoint3D toPoint);
    }
}