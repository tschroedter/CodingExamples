using Castle.Core;
using JetBrains.Annotations;
using Selkie.Windsor;
using Selkie.Windsor.Extensions;

namespace Agtrix.Wpf.Application.Services
{
    public class BaseService
        : IStartable
    {
        protected readonly ISelkieLogger Logger;

        public BaseService(
            [NotNull] ISelkieLogger logger)
        {
            Logger = logger;
        }

        public virtual void Start()
        {
            Logger.Info("Starting service '{0}'...".Inject(GetType().FullName));
        }

        public virtual void Stop()
        {
            Logger.Info("...stopping service '{0}'!".Inject(GetType().FullName));
        }
    }
}