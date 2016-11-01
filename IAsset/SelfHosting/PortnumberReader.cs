using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using NLog;

namespace SelfHosting
{
    [ExcludeFromCodeCoverage]
    internal class PortnumberReader
    {
        public PortnumberReader(Logger logger)
        {
            logger.Info("Trying to read 'Portnumber' from app.config file...");

            string portnumberText = ConfigurationManager.AppSettings [ "Portnumber" ];

            Portnumber = int.Parse(portnumberText);

            logger.Info("Found 'Portnumber' in app.config file and using port: {0}",
                        Portnumber);
        }

        public int Portnumber { get; private set; }
    }
}