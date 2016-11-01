using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;

namespace Evaluation.Interfaces.Geometry.Calculators
{
    public interface IShiftPointCalculator
    {
        [NotNull]
        IPoint3D Calculate([NotNull] IPoint3D sourcePoint3D,
                           [NotNull] IPoint3D shiftPoint3D);
    }
}