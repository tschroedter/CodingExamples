using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Evaluation.Wpf.Application.View.Interfaces;
using Selkie.Windsor;
using Selkie.Windsor.Extensions;

namespace Evaluation.Wpf.Application
{
    [ExcludeFromCodeCoverage]
    public partial class App
    {
        private static readonly IWindsorContainer Container = new WindsorContainer();

        public App()
        {
            ConfigureContainer();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ISelkieLogger logger = null;

            try
            {
                logger = Container.Resolve <ISelkieLogger>();

                // ReSharper disable once UnusedVariable
                var factory = Container.Resolve <IViewFactory>();
                var main = factory.CreateView <IMainView>();
                main.ShowDialog();
            }
            catch ( Exception exception )
            {
                string message = LogException(logger,
                                              exception);

                MessageBox.Show(message);

                Console.WriteLine(exception);
                Console.WriteLine(exception.StackTrace);

                if ( logger != null )
                {
                    logger.Error(message,
                                 exception);
                }
            }
        }

        private void ConfigureContainer()
        {
            Container.Install(FromAssembly.This());
        }

        private string LogException(ISelkieLogger logger,
                                    Exception exception)
        {
            string message = "Failed to create components: {0}\r\n\r\n{1}".Inject(exception.Message,
                                                                                  exception.StackTrace);

            logger.Error(message);

            if ( exception.InnerException != null )
            {
                message += LogException(logger,
                                        exception.InnerException);
            }

            return message;
        }
    }
}