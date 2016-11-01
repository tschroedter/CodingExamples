using System.Windows.Input;

namespace Evaluation.Wpf.Application.ViewModels.Interfaces
{
    public interface IShiftPointViewModel
        : IPointViewModel
    {
        ICommand ApplyCommand { get; }
    }
}