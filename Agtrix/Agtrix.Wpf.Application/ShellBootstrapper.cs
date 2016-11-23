using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using Agtrix.DataAccess.Interfaces.Repositories;
using Agtrix.Wpf.Application.Interfaces.Views;
using Caliburn.Micro;
using Castle.Windsor;
using Selkie.Windsor;
using Selkie.Windsor.Extensions;

namespace Agtrix.Wpf.Application
{
    public class ShellBootstrapper : BootstrapperBase
    {
        public ShellBootstrapper()
        {
            Initialize();
        }

        public ISelkieLogger Logger { get; private set; }

        private readonly IWindsorContainer m_Container = new WindsorContainer();

        protected override void Configure()
        {
            m_Container.Install(new ShellInstaller());
        }

        protected override object GetInstance(Type service,
                                              string key)
        {
            if ( m_Container.Kernel.HasComponent(service) )
            {
                object resolved = m_Container.Resolve(service);

                if ( resolved != null )
                {
                    return resolved;
                }

                return base.GetInstance(service,
                                        key);
            }

            // ReSharper disable once InvertIf
            if ( m_Container.Kernel.HasComponent(key) )
            {
                object resolved = m_Container.Resolve(key,
                                                      service);

                if ( resolved != null )
                {
                    return resolved;
                }

                return base.GetInstance(service,
                                        key);
            }

            throw new ArgumentException("Could not create instance for service '{0}' or key '{1}!".Inject(service,
                                                                                                          key));
        }

        protected override void OnStartup(object sender,
                                          StartupEventArgs e)
        {
            PrePopulateRepositories();
            Logger = m_Container.Resolve <ISelkieLogger>();

            ConfigureAndDisplayRootView();
        }

        protected override void OnUnhandledException(object sender,
                                                     DispatcherUnhandledExceptionEventArgs e)
        {
            Logger.Error("Unhandled Exception",
                         e.Exception.ToString());

            e.Handled = true;

            MessageBox.Show(e.Exception.Message +
                            "\r\n\r\n" +
                            "Check the log file for more details!");
        }

        private void ConfigureAndDisplayRootView()
        {
            var settings = new Dictionary <string, object>
                           {
                               {
                                   "SizeToContent", SizeToContent.Manual
                               },
                               {
                                   "Height", 450
                               },
                               {
                                   "Width", 640
                               },
                               {
                                   "Title",
                                   "Agtrix WPF assignment"
                               }
                           };

            DisplayRootViewFor <IShellViewModel>(settings);
        }

        private void PrePopulateRepositories()
        {
            var populate = m_Container.Resolve <IPrePopulateRepositories>();
            populate.PrePopulate();
            m_Container.Release(populate);
        }
    }
}