using System.Linq;

namespace IAsset.MicroServices.Common.DataAccess
{
    public interface IRepository <T>
        where T : IEntity
    {
        IQueryable <T> All { get; }
        T FindById(int id);
        void Remove(T entity);
        void Save(T entity);
        void Save();
    }
}