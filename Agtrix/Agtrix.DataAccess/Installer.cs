using System.Diagnostics.CodeAnalysis;
using Selkie.Windsor;

namespace Agtrix.DataAccess
{
    [ExcludeFromCodeCoverage]
    public class Installer : BaseInstaller <Installer>
    {
        public override string GetPrefixOfDllsToInstall()
        {
            return "Agtrix";
        }
    }
}