using JetBrains.Annotations;
using Selkie.Windsor;

namespace DSim.Common
{
    public interface IWireFactory : ITypedFactory
    {
        IWire Create();
        void Release([NotNull] IWire wire);
    }
}