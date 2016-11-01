using IAsset.MicroServices.Common.DataAccess;
using IAsset.MicroServices.Gates.Interfaces.DataAccess;
using Selkie.Windsor;

namespace IAsset.MicroServices.Gates.DataAccess
{
    [ProjectComponent(Lifestyle.Singleton)]
    public class GatesRepository
        : BaseRepository <IGate>,
          IGatesRepository
    {
    }
}