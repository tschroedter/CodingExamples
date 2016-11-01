using System.Collections.Generic;
using System.Linq;
using IAsset.MicroServices.Gates.Interfaces.DataAccess;
using IAsset.MicroServices.Gates.Interfaces.Nancy;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace IAsset.MicroServices.Gates.Nancy
{
    [ProjectComponent(Lifestyle.Singleton)]
    public class GatesInformationFinder
        : IGatesInformationFinder
    {
        public GatesInformationFinder(
            [NotNull] IGatesRepository repository)
        {
            m_Repository = repository;
        }

        private readonly IGatesRepository m_Repository;

        public IGate Delete(int id)
        {
            IGate entity = m_Repository.FindById(id);

            m_Repository.Remove(entity);

            return entity;
        }

        public IGate FindById(int id)
        {
            IGate entity = m_Repository.FindById(id);

            return entity;
        }

        public IEnumerable <IGate> List()
        {
            IQueryable <IGate> all = m_Repository.All;

            return all;
        }

        public IGate Save(IGate entity)
        {
            m_Repository.Save(entity);

            return entity;
        }
    }
}