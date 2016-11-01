using JetBrains.Annotations;
using Selkie.Windsor;

namespace IAsset.MicroServices.FlightsAssignedToGates
{
    [UsedImplicitly]
    public class Installer : BaseInstaller <Installer>
    {
        public override string GetPrefixOfDllsToInstall()
        {
            return "IAsset.MicroServices.FlightsAssignedToGates";
        }
    }
}