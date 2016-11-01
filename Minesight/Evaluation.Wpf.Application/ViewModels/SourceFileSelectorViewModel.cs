using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Input;
using Evaluation.Wpf.Application.Models.Interfaces;
using Evaluation.Wpf.Application.Models.Messages;
using Evaluation.Wpf.Application.ViewModels.Common;
using Evaluation.Wpf.Application.ViewModels.Interfaces;
using Evaluation.Wpf.Application.ViewModels.Messages;
using JetBrains.Annotations;
using Microsoft.Win32;
using Selkie.EasyNetQ;

namespace Evaluation.Wpf.Application.ViewModels
{
    public class SourceFileSelectorViewModel
        : ViewModel,
          ISourceFileSelectorViewModel
    {
        private const string DefaultFilename = "Please select a source file...";
        private readonly ISelkieInMemoryBus m_Bus;
        private readonly ICommandManager m_Manager;
        private ICommand m_BrowseCommand;

        public SourceFileSelectorViewModel(
            [NotNull] ISelkieInMemoryBus bus,
            [NotNull] ICommandManager manager,
            [NotNull, UsedImplicitly] ISourceFileSelectorModel model)
        {
            m_Bus = bus;
            m_Manager = manager;
            Filename = DefaultFilename;

            bus.SubscribeAsync <ShowBrowseDialogMessage>(GetType().FullName,
                                                         ShowBrowseDialogHandler);
            bus.SubscribeAsync <FilenameChangedMessage>(GetType().FullName,
                                                        FilenameChangedHandler);

            bus.PublishAsync(new FilenameRequestMessage());
        }

        public string Filename { get; set; }

        public ICommand BrowseCommand
        {
            get
            {
                return m_BrowseCommand ?? ( m_BrowseCommand = new DelegateCommand(m_Manager,
                                                                                  SendBrowseRequestMessage,
                                                                                  CanExecuteBrowseCommand) );
            }
        }

        internal bool CanExecuteBrowseCommand()
        {
            return true;
        }

        internal void SendBrowseRequestMessage()
        {
            m_Bus.PublishAsync(new BrowseRequestMessage());
        }

        // todo IOpenFileDialog for testing
        [ExcludeFromCodeCoverage]
        private void ShowBrowseDialogHandler(ShowBrowseDialogMessage obj)
        {
            var openFileDialog = new OpenFileDialog
                                 {
                                     Multiselect = false,
                                     Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                                     InitialDirectory =
                                         Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                                 };

            if ( openFileDialog.ShowDialog() != true )
            {
                return;
            }

            string filename = openFileDialog.FileNames.First(); // todo maybe better check required

            m_Bus.PublishAsync(new FilenameSetMessage
                               {
                                   Filename = filename
                               });
        }

        internal void FilenameChangedHandler(FilenameChangedMessage message)
        {
            Filename = message.Filename;

            Update();
        }

        internal void Update()
        {
            NotifyPropertyChanged("Filename");

            m_Manager.InvalidateRequerySuggested();
        }
    }
}