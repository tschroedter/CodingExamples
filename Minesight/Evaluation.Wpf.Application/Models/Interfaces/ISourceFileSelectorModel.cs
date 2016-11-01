using JetBrains.Annotations;

namespace Evaluation.Wpf.Application.Models.Interfaces
{
    public interface ISourceFileSelectorModel
        : IModel
    {
        [NotNull]
        string Filename { get; }
    }
}