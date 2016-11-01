using System.Windows.Input;

namespace Evaluation.Wpf.Application.ViewModels.Interfaces
{
    public interface INumberOfPointsViewModel
        : IViewModel
    {
        int NumberOfPoints { get; set; }
        ICommand ApplyCommand { get; }
    }
}