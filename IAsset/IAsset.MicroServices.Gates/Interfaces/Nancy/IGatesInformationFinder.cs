using IAsset.MicroServices.Common.Nancy;
using IAsset.MicroServices.Gates.Interfaces.DataAccess;

namespace IAsset.MicroServices.Gates.Interfaces.Nancy
{
    public interface IGatesInformationFinder
        : IInformationFinder <IGate>
    {
    }
}