using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace GameOfLive.Console
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container,
                            IConfigurationStore store)
        {
            container.Kernel
                     .Resolver
                     .AddSubResolver(new ArrayResolver(container.Kernel));

            container.Kernel
                     .Resolver
                     .AddSubResolver(new CollectionResolver(container.Kernel));

            container.Kernel
                     .Resolver
                     .AddSubResolver(new ListResolver(container.Kernel));

            container.Install(FromAssembly.Containing(typeof ( Board.Installer )));
        }
    }
}