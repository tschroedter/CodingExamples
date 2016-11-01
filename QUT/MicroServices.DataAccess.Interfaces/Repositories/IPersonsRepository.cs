using MicroServices.DataAccess.Interfaces.Entities;

namespace MicroServices.DataAccess.Interfaces.Repositories
{
    public interface IPersonsRepository
        : IRepository <IPerson>
    {
        IPerson Delete(int id);
    }
}