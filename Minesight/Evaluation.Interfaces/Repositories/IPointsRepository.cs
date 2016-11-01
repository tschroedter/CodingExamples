using System.Collections.Generic;
using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;

namespace Evaluation.Interfaces.Repositories
{
    public interface IPointsRepository : IRepository <IPoint3D, int>
    {
        void Clear();
        void AddRange([NotNull] IEnumerable <IPoint3D> points);
    }
}