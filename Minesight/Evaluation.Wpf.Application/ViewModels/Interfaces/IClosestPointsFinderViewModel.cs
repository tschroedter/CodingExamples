using System.Windows.Input;

namespace Evaluation.Wpf.Application.ViewModels.Interfaces
{
    public interface IClosestPointsFinderViewModel
        : IViewModel
    {
        ICommand CalculateCommand { get; }
    }
}