using Castle.Core.Configuration;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GameOfLive.Board.Board;
using GameOfLive.Board.Finders;
using GameOfLive.Board.Rules;
using GameOfLive.Interfaces;
using GameOfLive.Interfaces.Board;
using GameOfLive.Interfaces.Finders;
using GameOfLive.Interfaces.Rules;
using GameOfLive.Interfaces.Rules.Conditions;
using GameOfLive.Interfaces.Rules.Rules;

namespace GameOfLive.Board
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container,
                            IConfigurationStore store)
        {
            container.Register(Component.For(typeof ( ICellInformation ))
                                        .ImplementedBy(typeof ( CellInformation ))
                                        .LifeStyle.Transient);

            container.Register(Component.For(typeof ( ICells ))
                                        .ImplementedBy(typeof ( Cells ))
                                        .LifeStyle.Transient);

            container.Register(Component.For(typeof ( IBoard ))
                                        .ImplementedBy(typeof ( UnlimitedBoard ))
                                        .LifeStyle.Transient);

            container.Register(Component.For(typeof ( ILivingCellFinder ))
                                        .ImplementedBy(typeof ( LivingCellFinder ))
                                        .LifeStyle.Transient);

            container.Register(Component.For(typeof ( INeighboursFinder ))
                                        .ImplementedBy(typeof ( NeighboursFinder ))
                                        .LifeStyle.Transient);

            container.Register(Classes.FromThisAssembly()
                                      .BasedOn <IRule <ICellInformation>>()
                                      .WithService
                                      .AllInterfaces()
                                      .LifestyleTransient());

            container.Register(Component.For(typeof ( IBoardManager ))
                                        .ImplementedBy(typeof ( BoardManager ))
                                        .LifeStyle.Singleton);

            container.Register(Classes.FromThisAssembly()
                                      .BasedOn <ICondition>()
                                      .WithService
                                      .AllInterfaces()
                                      .LifestyleTransient());

            container.Register(Component.For(typeof ( IRuleRepository ))
                                        .ImplementedBy(typeof ( RuleRepository ))
                                        .LifeStyle.Transient);

            container.Register(Component.For(typeof ( IStringToCellInformationConverter ))
                                        .ImplementedBy(typeof ( StringToCellInformationConverter ))
                                        .LifeStyle.Transient);

            container.Register(Component.For(typeof ( ICellInformationToStringConverter ))
                                        .ImplementedBy(typeof ( CellInformationToStringConverter ))
                                        .LifeStyle.Transient);

            container.Register(Component.For(typeof ( IEngine ))
                                        .ImplementedBy(typeof ( Engine ))
                                        .LifeStyle.Transient);
        }
    }

    public class ArrayFacility : IFacility
    {
        public void Init(IKernel kernel,
                         IConfiguration facilityConfig)
        {
            kernel.Resolver.AddSubResolver(new ArrayResolver(kernel));
        }

        public void Terminate()
        {
        }
    }
}