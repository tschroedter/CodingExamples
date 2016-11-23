using System;
using System.Linq;
using Agtrix.DataAccess.Interfaces.Entities;
using JetBrains.Annotations;

namespace Agtrix.DataAccess.Interfaces.Repositories
{
    public interface IRepository <T>
        where T : IEntity
    {
        IQueryable <T> All { get; }

        [CanBeNull]
        T FindById(Guid id);

        void Remove(T entity);
        void Save(T instance);
    }
}