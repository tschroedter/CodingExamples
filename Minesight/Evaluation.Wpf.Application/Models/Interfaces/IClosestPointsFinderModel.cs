using System.Collections.Generic;
using JetBrains.Annotations;

namespace Evaluation.Wpf.Application.Models.Interfaces
{
    public interface IClosestPointsFinderModel
        : IModel
    {
        [NotNull]
        IEnumerable <int> ClosestIds { get; }
    }
}