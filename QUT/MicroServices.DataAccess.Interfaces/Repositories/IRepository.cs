using System.Linq;
using MicroServices.DataAccess.Interfaces.Entities;

namespace MicroServices.DataAccess.Interfaces.Repositories
{
    public interface IRepository <T>
        where T : IEntity
    {
        IQueryable <T> All { get; }
        T FindById(int id);
        void Save(T instance);
        void Remove(T entity);
        void Save();
    }
}