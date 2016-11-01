using Selkie.Windsor;

namespace Evaluation
{
    public class Installer : BaseInstaller <Installer>
    {
        public override string GetPrefixOfDllsToInstall()
        {
            return "Evaluation.";
        }
    }
}