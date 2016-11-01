using System;
using System.Diagnostics.CodeAnalysis;
using Evaluation.Wpf.Application.ViewModels.Interfaces;
using Selkie.Windsor;

namespace Evaluation.Wpf.Application.ViewModels.Common
{
    [ExcludeFromCodeCoverage]
    [ProjectComponent(Lifestyle.Singleton)]
    public class CommandManager : ICommandManager
    {
        public void InvalidateRequerySuggested()
        {
            System.Windows.Input.CommandManager.InvalidateRequerySuggested();
        }

        public event EventHandler RequerySuggested
        {
            add
            {
                System.Windows.Input.CommandManager.RequerySuggested += value;
            }
            remove
            {
                System.Windows.Input.CommandManager.RequerySuggested -= value;
            }
        }
    }
}