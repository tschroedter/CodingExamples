using JetBrains.Annotations;
using Selkie.Windsor;

namespace IAsset.MicroServices.FlightAssignedToGate
{
    [UsedImplicitly]
    public class Installer : BaseInstaller <Installer>
    {
        public override string GetPrefixOfDllsToInstall()
        {
            return "IAsset.MicroServices.FlightAssignedToGate";
        }
    }
}