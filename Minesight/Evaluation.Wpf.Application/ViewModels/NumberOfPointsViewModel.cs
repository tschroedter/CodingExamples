using System.Windows.Input;
using Evaluation.Wpf.Application.Models.Interfaces;
using Evaluation.Wpf.Application.Models.Messages;
using Evaluation.Wpf.Application.ViewModels.Common;
using Evaluation.Wpf.Application.ViewModels.Interfaces;
using JetBrains.Annotations;
using Selkie.EasyNetQ;

namespace Evaluation.Wpf.Application.ViewModels
{
    public class NumberOfPointsViewModel
        : ViewModel,
          INumberOfPointsViewModel
    {
        private readonly ISelkieInMemoryBus m_Bus;
        private readonly ICommandManager m_Manager;
        private ICommand m_ApplyCommand;

        public NumberOfPointsViewModel(
            [NotNull] ISelkieInMemoryBus bus,
            [NotNull] ICommandManager manager,
            [NotNull, UsedImplicitly] INumberOfPointsModel model)
        {
            m_Bus = bus;
            m_Manager = manager;

            bus.SubscribeAsync <NumberOfPointsChangedMessage>(GetType().FullName,
                                                              NumberOfPointsChangedHandler);

            bus.PublishAsync(new NumberOfPointsRequestMessage());

            NumberOfPoints = 1;
        }

        public int NumberOfPoints { get; set; }

        public ICommand ApplyCommand
        {
            get
            {
                return m_ApplyCommand ?? ( m_ApplyCommand = new DelegateCommand(m_Manager,
                                                                                SendNumberOfPointsSetMessage,
                                                                                CanExecuteApplyCommand) );
            }
        }

        internal bool CanExecuteApplyCommand()
        {
            return true;
        }

        internal void SendNumberOfPointsSetMessage()
        {
            var message = new NumberOfPointsSetMessage
                          {
                              NumberOfPoints = NumberOfPoints
                          };

            m_Bus.PublishAsync(message);
        }

        internal void NumberOfPointsChangedHandler(NumberOfPointsChangedMessage message)
        {
            NumberOfPoints = message.NumberOfPoints;

            Update();
        }

        internal void Update()
        {
            NotifyPropertyChanged("NumberOfPoints");

            m_Manager.InvalidateRequerySuggested();
        }
    }
}