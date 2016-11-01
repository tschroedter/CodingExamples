using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Windows;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ComponentActivator;
using Castle.MicroKernel.Context;
using Evaluation.Wpf.Application.View.Interfaces;
using Evaluation.Wpf.Application.ViewModels.Interfaces;

namespace Evaluation.Wpf.Application.Windsor
{
    [ExcludeFromCodeCoverage]
    public class WpfWindowActivator : DefaultComponentActivator
    {
        public WpfWindowActivator(ComponentModel model,
                                  IKernelInternal kernel,
                                  ComponentInstanceDelegate onCreation,
                                  ComponentInstanceDelegate onDestruction)
            : base(model,
                   kernel,
                   onCreation,
                   onDestruction)
        {
        }

        protected override object CreateInstance(CreationContext context,
                                                 ConstructorCandidate constructor,
                                                 object[] arguments)
        {
            object component = base.CreateInstance(context,
                                                   constructor,
                                                   arguments);
            AssignViewModel(component,
                            arguments);
            return component;
        }

        private void AssignParentView(FrameworkElement frameworkElement,
                                      object dataContext)
        {
            var view = frameworkElement as IView;
            if ( view == null )
            {
                return;
            }

            PropertyInfo viewProp =
                dataContext.GetType()
                           .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                           .FirstOrDefault(p => p.CanWrite && typeof( IView ).IsAssignableFrom(p.PropertyType));
            if ( viewProp != null )
            {
                viewProp.SetValue(dataContext,
                                  frameworkElement,
                                  null);
            }
        }

        /// <summary>
        ///     Find the first ctor argument that implements IViewModel.
        ///     Assume it is the View Model and assign it to the component's
        ///     DataContext property.
        /// </summary>
        /// <param name="component">The activated WPF element.</param>
        /// <param name="arguments">The constructor arguments</param>
        private void AssignViewModel(object component,
                                     IEnumerable <object> arguments)
        {
            var frameworkElement = component as FrameworkElement;
            if ( frameworkElement == null ||
                 arguments == null )
            {
                return;
            }

            object vm = arguments.FirstOrDefault(a => a is IViewModel);
            if ( vm == null )
            {
                return;
            }

            frameworkElement.DataContext = vm;
            AssignParentView(frameworkElement,
                             vm);
        }
    }
}