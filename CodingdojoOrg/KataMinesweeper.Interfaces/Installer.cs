using System.Diagnostics.CodeAnalysis;
using Selkie.Windsor;

namespace KataMinesweeper.Interfaces
{
    [ExcludeFromCodeCoverage]
    //ncrunch: no coverage start
    public class Installer : BaseInstaller <Installer>
    {
        public override string GetPrefixOfDllsToInstall()
        {
            return "KataMinesweeper";
        }
    }
}