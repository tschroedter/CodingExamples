using System;
using System.Diagnostics.CodeAnalysis;
using Castle.Windsor;

namespace ParkIQ.SecureParking.Console
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        private static void Main()
        {
            try
            {
                var container = new WindsorContainer();
                var installer = new Installer();
                container.Install(installer);

                var demo = new CarParkDemo(container);
                demo.Run();

                System.Console.WriteLine("Press 'Return' to exit...");
                System.Console.ReadLine();
            }
            catch ( Exception ex )
            {
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine(ex.StackTrace);
            }
        }
    }
}