using System.Data.Entity;
using System.Linq;
using JetBrains.Annotations;
using MicroServices.DataAccess.Interfaces.Contexts;
using MicroServices.DataAccess.Interfaces.Entities;
using MicroServices.DataAccess.Interfaces.Repositories;

namespace MicroServices.DataAccess.Repositories
{
    public abstract class BaseRepository <TType, TContext>
        : IRepository <TType>
        where TType : IEntity
        where TContext : IDbContext <TType>
    {
        protected BaseRepository([NotNull] TContext context)
        {
            Context = context;
        }

        protected TContext Context { get; private set; }

        public IQueryable <TType> All
        {
            get
            {
                return GetAll();
            }
        }

        public TType FindById(int id)
        {
            return Context.Find(id);
        }

        public void Save(TType instance)
        {
            // todo make catch exception everywhere and nice
            if ( instance.Id == default ( int ) )
            {
                Context.Add(instance);
            }
            else
            {
                Context.SetStateForSlot(instance,
                                        EntityState.Modified);
            }

            Context.SaveChanges(); // todo testing
        }

        public void Remove(TType instance)
        {
            Context.Remove(instance);
            Context.SaveChanges();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        protected abstract IQueryable <TType> GetAll();
    }
}