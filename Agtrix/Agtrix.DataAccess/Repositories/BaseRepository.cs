using System;
using System.Collections.Generic;
using System.Linq;
using Agtrix.DataAccess.Interfaces.Entities;
using Agtrix.DataAccess.Interfaces.Repositories;
using Castle.Core;
using JetBrains.Annotations;
using Selkie.Windsor;
using Selkie.Windsor.Extensions;

namespace Agtrix.DataAccess.Repositories
{
    public abstract class BaseRepository <TType>
        : IRepository <TType>,
          IStartable
        where TType : IEntity
    {
        protected readonly ISelkieLogger Logger;

        protected BaseRepository(
            [NotNull] ISelkieLogger logger)
        {
            Logger = logger;
        }

        protected readonly IDictionary <Guid, TType> Storage = new Dictionary <Guid, TType>();

        public IQueryable <TType> All
        {
            get
            {
                return Storage.Values.AsQueryable();
            }
        }

        public abstract TType FindById(Guid id);

        public void Save(TType instance)
        {
            if ( instance.Id == default( Guid ) )
            {
                instance.Id = Guid.NewGuid();
            }
            else
            {
                Storage.Remove(instance.Id);
            }

            Storage.Add(instance.Id,
                        instance);
        }

        public void Remove(TType instance)
        {
            Storage.Remove(instance.Id);
        }

        public virtual void Start()
        {
            Logger.Info("Starting repository '{0}'...".Inject(GetType().FullName));
        }

        public virtual void Stop()
        {
            Logger.Info("...stopping repository '{0}'!".Inject(GetType().FullName));
        }
    }
}