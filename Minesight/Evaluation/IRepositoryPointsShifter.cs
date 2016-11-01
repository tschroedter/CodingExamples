using Evaluation.Interfaces.Repositories;
using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;

namespace Evaluation
{
    public interface IRepositoryPointsShifter
    {
        void Shift([NotNull] IPointsRepository repository,
                   [NotNull] IPoint3D shiftByPoint3D);
    }
}