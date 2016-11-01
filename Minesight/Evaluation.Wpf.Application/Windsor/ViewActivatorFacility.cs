using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Castle.Core;
using Castle.MicroKernel.Facilities;

namespace Evaluation.Wpf.Application.Windsor
{
    [ExcludeFromCodeCoverage]
    public class ViewActivatorFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.ComponentModelCreated += Kernel_ComponentModelCreated;
        }

        private void Kernel_ComponentModelCreated(ComponentModel model)
        {
            IEnumerable <Type> services = model.Services;
            bool isView = services.Any(x => x.GetInterface("IView") != null);

            //		   if (!services.Select(service => typeof (IView).IsAssignableFrom(service)).Any(isView => isView))
            //		   {
            //		      return;
            //		   }
            //
            //		   if (model.CustomComponentActivator == null)
            //		   {
            //		      model.CustomComponentActivator = typeof (WpfWindowActivator);
            //		   }

            //         bool isView = model
            //
            if ( !isView )
            {
                return;
            }

            if ( model.CustomComponentActivator == null )
            {
                model.CustomComponentActivator = typeof( WpfWindowActivator );
            }
        }
    }
}