using System.Diagnostics.CodeAnalysis;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Fees;
using ParkIQ.SecureParking.Interaces.Vehicles;
using Selkie.Windsor;

namespace ParkIQ.SecureParking
{
    [ExcludeFromCodeCoverage]
    public class Installer : BaseInstaller <Installer>
    {
        protected override void InstallComponents([NotNull] IWindsorContainer container,
                                                  [NotNull] IConfigurationStore store)
        {
            base.InstallComponents(container,
                                   store);

            container.Register(
                               Classes.FromThisAssembly()
                                      .BasedOn <IVehicle>()
                                      .WithServiceFromInterface(typeof ( IVehicle ))
                                      .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)));

            container.Register(
                               Classes.FromThisAssembly()
                                      .BasedOn <IFee>()
                                      .WithServiceFromInterface(typeof ( IFee ))
                                      .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)));
        }

        public override string GetPrefixOfDllsToInstall()
        {
            return "ParkIQ.";
        }
    }
}