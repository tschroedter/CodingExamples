using System.ComponentModel;
using Evaluation.Wpf.Application.ViewModels.Interfaces;

namespace Evaluation.Wpf.Application.ViewModels.Common
{
    public abstract class ViewModel
        : IViewModel,
          INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal void NotifyPropertyChanged(string propertyName)
        {
            if ( PropertyChanged != null )
            {
                PropertyChanged(this,
                                new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}