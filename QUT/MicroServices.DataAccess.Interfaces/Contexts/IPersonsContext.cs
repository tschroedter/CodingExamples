using System.Linq;
using MicroServices.DataAccess.Interfaces.Entities;

namespace MicroServices.DataAccess.Interfaces.Contexts
{
    public interface IPersonsContext : IDbContext <IPerson>
    {
        IQueryable <IPerson> Persons();
        IPerson Delete(int id);
    }
}