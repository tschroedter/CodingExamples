using System.Collections.Generic;
using System.Linq;

namespace IAsset.MicroServices.Common.DataAccess
{
    public class BaseRepository <T>
        : IRepository <T>
        where T : IEntity
    {
        protected BaseRepository()
        {
            Entities = new List <T>();
        }

        protected List <T> Entities { get; private set; }

        public IQueryable <T> All
        {
            get
            {
                return Entities.AsQueryable();
            }
        }

        public T FindById(int id)
        {
            return Entities.Find(x => x.Id == id);
        }

        public void Save(T entity)
        {
            if ( entity.Id == 0 )
            {
                entity.Id = CreateNextId(); // todo testing
            }
            else
            {
                T existing = FindById(entity.Id);

                if ( existing != null )
                {
                    Entities.Remove(existing);
                }
            }

            Entities.Add(entity);
        }

        public void Remove(T entity)
        {
            Entities.Remove(entity);
        }

        public void Save()
        {
            // todo future use
        }

        private int CreateNextId()
        {
            if ( Entities.Count == 0 )
            {
                return 1;
            }
            return Entities.Max(x => x.Id) + 1;
        }
    }
}