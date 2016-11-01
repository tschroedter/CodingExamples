using System;
using System.Collections;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers;
using Castle.Windsor;
using KataMinesweeper.Interfaces;
using NSubstitute;
using NUnit.Framework;
using Component = Castle.MicroKernel.Registration.Component;

namespace KataMinesweeper.Tests
{
    public class AutoMockRepository
    {
        protected WindsorContainer Container { get; private set; }

        public AutoMockRepository()
        {
            Container = new WindsorContainer();
            Container.Register(Component.For<LazyComponentAutoMocker>());

            var installers = new IWindsorInstaller[]
                             {
                                 new Selkie.Windsor.Installer(),
                                 new Interfaces.Installer(),
                             };

            Container.Install(installers);
        }

        protected T MockOf <T>() where T : class
        {
            return Container.Resolve <T>();
        }

        protected T Create <T>() where T : class
        {
            Container.Register(Component.For <T>());
            return Container.Resolve <T>();
        }

    }

    [TestFixture]
    internal abstract class AutoMockedTestFixtureBase <TClassUnderTest>
        where TClassUnderTest : class
    {
        private WindsorContainer m_MockContainer;

        [SetUp]
        public void Setup()
        {
            SetUpContainer();
            SetUp();
            Sut = m_MockContainer.Resolve <TClassUnderTest>();
        }

        private void SetUpContainer()
        {
            m_MockContainer = new WindsorContainer();
            m_MockContainer.Register(Component.For <LazyComponentAutoMocker>());

            var installers = new IWindsorInstaller[]
                             {
                                 new Selkie.Windsor.Installer(),
                                 new Interfaces.Installer(),
                                 new Installer(),
                             };

            m_MockContainer.Install(installers);
        }

        protected virtual void SetUp()
        {
        }

        protected TClassUnderTest Sut { get; private set; }

        protected TDependency GetDependency <TDependency>()
        {
            return m_MockContainer.Resolve <TDependency>();
        }

        protected TDependency RegisterDependency <TDependency>(TDependency dependency) where TDependency : class
        {
            m_MockContainer.Register(Component.For <TDependency>().Instance(dependency));

            return dependency;
        }

        protected void RegisterDependency <TService, TDependency>() where TDependency : TService where TService : class
        {
            m_MockContainer.Register(Component.For <TService>().ImplementedBy <TDependency>());
        }
    }

    public class LazyComponentAutoMocker : ILazyComponentLoader
    {
        public IRegistration Load(string key,
                                  Type service,
                                  IDictionary arguments)
        {
            return Component.For(service)
                            .Instance(Substitute.For(new[]
                                                     {
                                                         service
                                                     },
                                                     null));
        }
    }

    /*
    public class AutoMoqResolver : ISubDependencyResolver
    {
        private readonly IKernel m_Kernel;

        public AutoMoqResolver(IKernel kernel)
        {
            this.m_Kernel = kernel;
        }

        public bool CanResolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency)
        {
            return dependency.TargetType.IsInterface;
        }

        public object Resolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency)
        {
            var mockType = typeof(Substitute.For<> ).MakeGenericType(dependency.TargetType);
            return ((Mock)this.m_Kernel.Resolve(mockType)).Object;
        }
    }*/
}