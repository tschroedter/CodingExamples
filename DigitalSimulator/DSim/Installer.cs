using Selkie.Windsor;

namespace DSim
{
    public class Installer
        : BaseInstaller <Installer>
    {
        public override string GetPrefixOfDllsToInstall()
        {
            return "DSim.";
        }
    }
}