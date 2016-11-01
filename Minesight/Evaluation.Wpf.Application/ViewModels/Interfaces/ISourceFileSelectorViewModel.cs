using System.Windows.Input;
using JetBrains.Annotations;

namespace Evaluation.Wpf.Application.ViewModels.Interfaces
{
    public interface ISourceFileSelectorViewModel
        : IViewModel
    {
        [NotNull]
        string Filename { get; set; }

        [NotNull]
        ICommand BrowseCommand { get; }
    }
}