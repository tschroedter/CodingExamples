using System.Linq;
using Agtrix.DataAccess.Interfaces.Entities;
using JetBrains.Annotations;

namespace Agtrix.DataAccess.Interfaces.Repositories
{
    public interface IFarmsRepository
        : IRepository <IFarm>
    {
        IQueryable <IFarm> SearchByFarmName(
            [NotNull] string searchText);
    }
}