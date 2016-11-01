using Castle.MicroKernel.Registration;
using Selkie.Windsor;

namespace DSim.Tests.Specflow
{
    public class Installer
        : BasicConsoleInstaller,
          IWindsorInstaller
    {
        public override string GetPrefixOfDllsToInstall()
        {
            return "DSim.";
        }
    }
}