using System.Diagnostics.CodeAnalysis;
using Castle.Windsor;
using Castle.Windsor.Installer;
using KataMinesweeper.Interfaces;

namespace KataMinesweeper.Console
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        private static void Main()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Install(FromAssembly.This());

            var console = new MinesweeperConsole();

            var game = container.Resolve <IGame>();

            game.Initialize(3,
                            3,
                            2);
            game.Start();

            console.ReadLine();
        }
    }
}