using System;
using System.Linq;
using Agtrix.DataAccess.Interfaces.Entities;
using Agtrix.DataAccess.Interfaces.Repositories;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace Agtrix.DataAccess.Repositories
{
    [ProjectComponent(Lifestyle.Startable)]
    public class PaddocksRepository
        : BaseRepository <IPaddock>,
          IPaddocksRepository
    {
        public PaddocksRepository([NotNull] ISelkieLogger logger)
            : base(logger)
        {
        }

        public override IPaddock FindById(Guid id)
        {
            IPaddock instance;

            return Storage.TryGetValue(id,
                                       out instance)
                       ? instance
                       : null;
        }

        public IQueryable <IPaddock> FindByFarmId(Guid farmId)
        {
            IQueryable <IPaddock> paddocks = All.Where(x => x.FarmId == farmId);

            return paddocks;
        }
    }
}