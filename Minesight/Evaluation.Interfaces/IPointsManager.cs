using System.Collections.Generic;
using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;

namespace Evaluation.Interfaces
{
    public interface IPointsManager
    {
        [CanBeNull]
        IPoint3D Get(int key);

        [NotNull]
        IEnumerable <IPoint3D> All();

        void Add([NotNull] IPoint3D instance);
        void Remove([NotNull] IPoint3D instance);
        int Count();
        void Shift([NotNull] IPoint3D shiftByPoint3D);
        void AddRange([NotNull] IEnumerable <IPoint3D> points);
        void Clear();
    }
}