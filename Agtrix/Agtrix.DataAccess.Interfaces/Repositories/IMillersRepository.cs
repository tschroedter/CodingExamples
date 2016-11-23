using System.Linq;
using Agtrix.DataAccess.Interfaces.Entities;

namespace Agtrix.DataAccess.Interfaces.Repositories
{
    public interface IMillersRepository
        : IRepository <IMiller>
    {
        IQueryable <IMiller> SearchByMillerName(
            string searchText);
    }
}