using System;

namespace Evaluation.Wpf.Application.ViewModels.Interfaces
{
    public interface ICommandManager
    {
        void InvalidateRequerySuggested();
        event EventHandler RequerySuggested;
    }
}