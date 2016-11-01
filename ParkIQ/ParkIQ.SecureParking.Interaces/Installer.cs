using System.Diagnostics.CodeAnalysis;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Interaces
{
    [ExcludeFromCodeCoverage]
    public class Installer : BaseInstaller <Installer>
    {
        public override string GetPrefixOfDllsToInstall()
        {
            return "ParkIQ.";
        }
    }
}