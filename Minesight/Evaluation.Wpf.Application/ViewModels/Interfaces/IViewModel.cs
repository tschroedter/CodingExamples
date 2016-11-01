using System.ComponentModel;

namespace Evaluation.Wpf.Application.ViewModels.Interfaces
{
    public interface IViewModel
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
}