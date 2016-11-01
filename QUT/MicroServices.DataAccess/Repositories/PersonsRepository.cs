using System.Linq;
using JetBrains.Annotations;
using MicroServices.DataAccess.Interfaces.Contexts;
using MicroServices.DataAccess.Interfaces.Entities;
using MicroServices.DataAccess.Interfaces.Repositories;
using Selkie.Windsor;

namespace MicroServices.DataAccess.Repositories
{
    [ProjectComponent(Lifestyle.Transient)]
    public class PersonsRepository
        : BaseRepository <IPerson, IPersonsContext>,
          IPersonsRepository
    {
        public PersonsRepository([NotNull] IPersonsContext context)
            : base(context)
        {
        }

        public IPerson Delete(int id)
        {
            return Context.Delete(id);
        }

        protected override IQueryable <IPerson> GetAll()
        {
            return Context.Persons();
        }
    }
}