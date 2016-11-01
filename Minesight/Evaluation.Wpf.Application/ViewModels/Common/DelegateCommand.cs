using System;
using System.Windows.Input;
using Evaluation.Wpf.Application.ViewModels.Interfaces;
using JetBrains.Annotations;

namespace Evaluation.Wpf.Application.ViewModels.Common
{
    public class DelegateCommand : ICommand
    {
        private readonly Func <bool> m_CanExecuteMethod;
        private readonly ICommandManager m_CommandManager;
        private readonly Action m_ExecuteMethod;

        public DelegateCommand(ICommandManager commandManager,
                               Action executeMethod)
            : this(commandManager,
                   executeMethod,
                   () => true)
        {
        }

        public DelegateCommand([NotNull] ICommandManager commandManager,
                               [NotNull] Action executeMethod,
                               [NotNull] Func <bool> canExecuteMethod)
        {
            m_CommandManager = commandManager;
            m_ExecuteMethod = executeMethod;
            m_CanExecuteMethod = canExecuteMethod;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add
            {
                m_CommandManager.RequerySuggested += value;
            }
            remove
            {
                m_CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object stupid)
        {
            return CanExecute();
        }

        public void Execute(object parameter)
        {
            Execute();
        }

        public bool CanExecute()
        {
            return m_CanExecuteMethod();
        }

        public void Execute()
        {
            m_ExecuteMethod();
        }

        public void OnCanExecuteChanged()
        {
            m_CommandManager.InvalidateRequerySuggested();
        }

        #endregion ICommand Members
    }
}