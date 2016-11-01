using Selkie.Windsor;

namespace MicroServices.Nancy.Persons
{
    public sealed class Installer : BaseInstaller <Installer>
    {
        public override string GetPrefixOfDllsToInstall()
        {
            return "MicroServices.";
        }
    }
}