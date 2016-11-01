using System.Windows.Input;

namespace Evaluation.Wpf.Application.ViewModels.Interfaces
{
    public interface IQueryPointViewModel
        : IPointViewModel
    {
        ICommand ApplyCommand { get; }
    }
}