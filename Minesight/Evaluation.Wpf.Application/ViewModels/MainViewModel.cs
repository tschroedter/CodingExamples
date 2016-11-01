using System.Windows.Input;
using Evaluation.Wpf.Application.ViewModels.Common;
using Evaluation.Wpf.Application.ViewModels.Interfaces;
using JetBrains.Annotations;

namespace Evaluation.Wpf.Application.ViewModels
{
    public class MainViewModel
        : ViewModel,
          IMainViewModel
    {
        // todo guys have look at Selkie.WPF https://github.com/tschroedter/Selkie.WPF
        private readonly ICommandManager m_Manager;
        private ICommand m_CalculateCommand;

        public MainViewModel(
            [NotNull] ICommandManager manager,
            [NotNull] ISourceFileSelectorViewModel sourceFileSelectorViewModel,
            [NotNull] IQueryPointViewModel queryPointViewModel,
            [NotNull] IShiftPointViewModel shiftPointViewModel,
            [NotNull] INumberOfPointsViewModel numberOfPointsViewModel,
            [NotNull] IClosestPointsFinderViewModel closestPointsFinderViewModel)
        {
            m_Manager = manager;
            QueryPointViewModel = queryPointViewModel;
            ShiftPointViewModel = shiftPointViewModel;
            NumberOfPointsViewModel = numberOfPointsViewModel;
            ClosestPointsFinderViewModel = closestPointsFinderViewModel;
            SourceFileSelectorViewModel = sourceFileSelectorViewModel;
        }

        public ISourceFileSelectorViewModel SourceFileSelectorViewModel { get; private set; }
        public IQueryPointViewModel QueryPointViewModel { get; private set; }
        public IShiftPointViewModel ShiftPointViewModel { get; private set; }
        public INumberOfPointsViewModel NumberOfPointsViewModel { get; private set; }
        public IClosestPointsFinderViewModel ClosestPointsFinderViewModel { get; private set; }

        public ICommand CalculateCommand
        {
            get
            {
                return m_CalculateCommand ?? ( m_CalculateCommand = new DelegateCommand(m_Manager,
                                                                                        Calculate,
                                                                                        CanExecuteCalculateCommand) );
            }
        }

        private void Calculate()
        {
            QueryPointViewModel.ApplyCommand.Execute(this);
            ShiftPointViewModel.ApplyCommand.Execute(this);
            NumberOfPointsViewModel.ApplyCommand.Execute(this);
            ClosestPointsFinderViewModel.CalculateCommand.Execute(this);
        }

        private static bool CanExecuteCalculateCommand()
        {
            return true;
        }
    }
}