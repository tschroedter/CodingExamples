using System.Windows.Input;
using Evaluation.Wpf.Application.Models.Interfaces;
using Evaluation.Wpf.Application.Models.Messages;
using Evaluation.Wpf.Application.ViewModels.Common;
using Evaluation.Wpf.Application.ViewModels.Interfaces;
using JetBrains.Annotations;
using Selkie.EasyNetQ;

namespace Evaluation.Wpf.Application.ViewModels
{
    public class ShiftPointViewModel
        : ViewModel,
          IShiftPointViewModel
    {
        private readonly ISelkieInMemoryBus m_Bus;
        private readonly ICommandManager m_Manager;
        private ICommand m_ApplyCommand;

        public ShiftPointViewModel(
            [NotNull] ISelkieInMemoryBus bus,
            [NotNull] ICommandManager manager,
            [NotNull, UsedImplicitly] IShiftPointModel model)
        {
            m_Bus = bus;
            m_Manager = manager;

            bus.SubscribeAsync <ShiftPointChangedMessage>(GetType().FullName,
                                                          ShiftPointChangedHandler);

            bus.PublishAsync(new ShiftPointRequestMessage());
        }

        public ICommand ApplyCommand
        {
            get
            {
                return m_ApplyCommand ?? ( m_ApplyCommand = new DelegateCommand(m_Manager,
                                                                                SendShiftPointSetMessage,
                                                                                CanExecuteApplyCommand) );
            }
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        internal void SendShiftPointSetMessage()
        {
            var message = new ShiftPointSetMessage
                          {
                              X = X,
                              Y = Y,
                              Z = Z
                          };

            m_Bus.PublishAsync(message);
        }

        internal bool CanExecuteApplyCommand()
        {
            return true;
        }

        internal void ShiftPointChangedHandler(ShiftPointChangedMessage message)
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