using System.Windows.Input;
using Evaluation.Wpf.Application.Models.Interfaces;
using Evaluation.Wpf.Application.Models.Messages;
using Evaluation.Wpf.Application.ViewModels.Common;
using Evaluation.Wpf.Application.ViewModels.Interfaces;
using JetBrains.Annotations;
using Selkie.EasyNetQ;

namespace Evaluation.Wpf.Application.ViewModels
{
    public class QueryPointViewModel
        : ViewModel,
          IQueryPointViewModel
    {
        private readonly ISelkieInMemoryBus m_Bus;
        private readonly ICommandManager m_Manager;
        private ICommand m_ApplyCommand;

        public QueryPointViewModel(
            [NotNull] ISelkieInMemoryBus bus,
            [NotNull] ICommandManager manager,
            [NotNull, UsedImplicitly] IQueryPointModel model)
        {
            m_Bus = bus;
            m_Manager = manager;

            bus.SubscribeAsync <QueryPointChangedMessage>(GetType().FullName,
                                                          QueryPointChangedHandler);

            bus.PublishAsync(new QueryPointRequestMessage());
        }

        public ICommand ApplyCommand
        {
            get
            {
                return m_ApplyCommand ?? ( m_ApplyCommand = new DelegateCommand(m_Manager,
                                                                                SendQueryPointSetMessage,
                                                                                CanExecuteBrowseCommand) );
            }
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        internal void SendQueryPointSetMessage()
        {
            var message = new QueryPointSetMessage
                          {
                              X = X,
                              Y = Y,
                              Z = Z
                          };

            m_Bus.PublishAsync(message);
        }

        internal bool CanExecuteBrowseCommand()
        {
            return true;
        }

        internal void QueryPointChangedHandler(QueryPointChangedMessage message)
        {
            X = message.X;
            Y = message.Y;
            Z = message.Z;

            Update();
        }

        private void Update()
        {
            NotifyPropertyChanged("X");
            NotifyPropertyChanged("Y");
            NotifyPropertyChanged("Z");

            m_Manager.InvalidateRequerySuggested();
        }
    }
}