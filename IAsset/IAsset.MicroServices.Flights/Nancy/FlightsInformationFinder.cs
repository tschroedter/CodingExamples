using System.Collections.Generic;
using System.Linq;
using IAsset.MicroServices.Flights.Interfaces.DataAccess;
using IAsset.MicroServices.Flights.Interfaces.Nancy;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace IAsset.MicroServices.Flights.Nancy
{
    [ProjectComponent(Lifestyle.Singleton)]
    public class FlightsInformationFinder
        : IFlightsInformationFinder
    {
        public FlightsInformationFinder(
            [NotNull] IFlightsRepository repository)
        {
            m_Repository = repository;
        }

        private readonly IFlightsRepository m_Repository;

        public IFlight Delete(int id)
        {
            IFlight entity = m_Repository.FindById(id);

            m_Repository.Remove(entity);

            return entity;
        }

        public IFlight FindById(int id)
        {
            IFlight entity = m_Repository.FindById(id);

            return entity;
        }

        public IEnumerable <IFlight> List()
        {
            IQueryable <IFlight> all = m_Repository.All;

            return all;
        }

        public IFlight Save(IFlight entity)
        {
            m_Repository.Save(entity);

            return entity;
        }
    }
}