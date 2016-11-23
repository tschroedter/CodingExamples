using System;
using System.Linq;
using Agtrix.DataAccess.Interfaces.Entities;
using Agtrix.DataAccess.Interfaces.Repositories;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace Agtrix.DataAccess.Repositories
{
    [ProjectComponent(Lifestyle.Startable)]
    public class FarmsRepository
        : BaseRepository <IFarm>,
          IFarmsRepository
    {
        public FarmsRepository([NotNull] ISelkieLogger logger)
            : base(logger)
        {
        }

        public override IFarm FindById(Guid id)
        {
            IFarm instance;

            return Storage.TryGetValue(id,
                                       out instance)
                       ? instance
                       : null;
        }

        public IQueryable <IFarm> SearchByFarmName(
            string searchText)
        {
            return Storage.Values.Where(x => x.Name.StartsWith(searchText)).AsQueryable();
        }
    }
}