using System;
using System.Linq;
using Agtrix.DataAccess.Interfaces.Entities;
using Agtrix.DataAccess.Interfaces.Repositories;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace Agtrix.DataAccess.Repositories
{
    [ProjectComponent(Lifestyle.Startable)]
    public class MillersRepository
        : BaseRepository <IMiller>,
          IMillersRepository
    {
        public MillersRepository([NotNull] ISelkieLogger logger)
            : base(logger)
        {
        }

        public override IMiller FindById(Guid id)
        {
            IMiller instance;

            return Storage.TryGetValue(id,
                                       out instance)
                       ? instance
                       : null;
        }

        public IQueryable <IMiller> SearchByMillerName(
            string searchText)
        {
            return Storage.Values.Where(x => x.Name.StartsWith(searchText)).AsQueryable();
        }
    }
}