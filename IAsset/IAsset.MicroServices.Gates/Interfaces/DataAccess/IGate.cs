using IAsset.MicroServices.Common.DataAccess;
using JetBrains.Annotations;

namespace IAsset.MicroServices.Gates.Interfaces.DataAccess
{
    public interface IGate : IEntity
    {
        [NotNull]
        string Description { get; set; }
    }
}