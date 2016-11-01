using System.Windows.Input;
using Evaluation.Wpf.Application.Common.Interfaces;
using Evaluation.Wpf.Application.Models.Interfaces;
using Evaluation.Wpf.Application.Models.Messages;
using Evaluation.Wpf.Application.ViewModels.Common;
using Evaluation.Wpf.Application.ViewModels.Interfaces;
using JetBrains.Annotations;
using Selkie.EasyNetQ;

namespace Evaluation.Wpf.Application.ViewModels
{
    public class ClosestPointsFinderViewModel
        : ViewModel,
          IClosestPointsFinderViewModel
    {
        private readonly ISelkieInMemoryBus m_Bus;
        private readonly ICommandManager m_Manager;
        private ICommand m_CalculateCommand;

        public ClosestPointsFinderViewModel(
            [NotNull] ISelkieInMemoryBus bus,
            [NotNull] ICommandManager manager,
            [NotNull] ISettingsManager settingsManager,
            [NotNull, UsedImplicitly] IClosestPointsFinderModel model)
        {
            m_Bus = bus;
            m_Manager = manager;

            bus.SubscribeAsync <ClosestIdsChangedMessage>(GetType().FullName,
                                                          ClosestIdsChangeHandler);

            bus.PublishAsync(new ClosestIdsRequestMessage());
        }

        public int[] ClosestPointIds { get; set; }

        public ICommand CalculateCommand
        {
            get
            {
                return m_CalculateCommand ?? ( m_CalculateCommand = new DelegateCommand(m_Manager,
                                                                                        SendClosestIdsCalculateMessage,
                                                                                        CanExecuteCalculateCommand) );
            }
        }

        internal void SendClosestIdsCalculateMessage()
        {
            var message = new ClosestIdsCalculateMessage();

            m_Bus.PublishAsync(message);
        }

        internal bool CanExecuteCalculateCommand()
        {
            return true;
        }

        internal void ClosestIdsChangeHandler(ClosestIdsChangedMessage message)
        {
            ClosestPointIds = message.ClosestPointIds;

            Update();
        }

        private void Update()
        {
            NotifyPropertyChanged("ClosestPointIds");

            m_Manager.InvalidateRequerySuggested();
        }
    }
}