using System;
using System.Diagnostics.CodeAnalysis;
using Nancy.Hosting.Self;
using NLog;

namespace SelfHosting
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static void CreateHost()
        {
            var reader = new PortnumberReader(Logger);

            var uri =
                new Uri("http://localhost:" + reader.Portnumber);

            using ( var host = new NancyHost(uri) )
            {
                host.Start();

                Console.WriteLine("Your application is running on " + uri);
                Console.WriteLine("Press any [Enter] to close the host.");
                Console.ReadLine();
            }
        }

        private static void Main()
        {
            try
            {
                CreateHost();
            }
            catch ( Exception exception )
            {
                Logger.Error(exception);
            }
        }
    }
}