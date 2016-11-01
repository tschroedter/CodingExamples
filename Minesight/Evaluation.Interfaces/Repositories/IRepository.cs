using System.Collections.Generic;
using JetBrains.Annotations;

namespace Evaluation.Interfaces.Repositories
{
    public interface IRepository <T, in TKey>
    {
        [CanBeNull]
        T Get(TKey key);

        [NotNull]
        IEnumerable <T> All();

        void Add([NotNull] T instance);
        void Remove([NotNull] T instance);
        int Count();
    }
}