using JetBrains.Annotations;
using Selkie.Windsor;

namespace DSim.Common
{
    public interface IProbeFactory : ITypedFactory
    {
        IProbe Create([NotNull] IWire wire);

        void Release([NotNull] IProbe probe);
    }
}