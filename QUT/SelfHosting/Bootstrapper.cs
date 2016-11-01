using System.Diagnostics.CodeAnalysis;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Nancy.Bootstrappers.Windsor;
using Selkie.Windsor;

namespace SelfHosting
{
    [ExcludeFromCodeCoverage]
    //ncrunch: no coverage start
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(IWindsorContainer existingContainer)
        {
            base.ConfigureApplicationContainer(existingContainer);

            // Add the Array Resolver, so we can take dependencies on T[]
            // while only registering T.
            existingContainer.Kernel.Resolver.AddSubResolver(new ArrayResolver(existingContainer.Kernel));

            existingContainer.Install(FromAssembly.Containing(typeof ( Installer )));
            existingContainer.Install(FromAssembly.Containing(typeof ( MicroServices.DataAccess.Installer )));
            existingContainer.Install(FromAssembly.Containing(typeof ( MicroServices.Nancy.Persons.Installer )));
        }
    }
}