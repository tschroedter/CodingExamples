using System;
using System.Linq;
using Agtrix.DataAccess.Interfaces.Entities;

namespace Agtrix.DataAccess.Interfaces.Repositories
{
    public interface IPaddocksRepository
        : IRepository <IPaddock>
    {
        IQueryable <IPaddock> FindByFarmId(Guid farmId);
    }
}