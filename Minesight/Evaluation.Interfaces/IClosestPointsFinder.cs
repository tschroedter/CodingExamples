using System.Collections.Generic;
using JetBrains.Annotations;

namespace Evaluation.Interfaces
{
    public interface IClosestPointsFinder
    {
        [NotNull]
        IEnumerable <int> ClosestIds { get; }

        void Run([NotNull] IApplicationArguments args);
    }
}