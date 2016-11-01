using DSim.Common;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace DSim.LogicGates.RealTime
{
    public interface IOrFactory : ITypedFactory
    {
        IOr Create([NotNull] IWire wireInOne,
                   [NotNull] IWire wireInTwo,
                   [NotNull] IWire wireOut);

        void Release([NotNull] IOr or);
    }
}