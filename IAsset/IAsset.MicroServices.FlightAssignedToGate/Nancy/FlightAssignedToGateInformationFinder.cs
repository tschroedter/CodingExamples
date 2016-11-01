using System.Collections.Generic;
using System.Linq;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.DataAccess;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.Nancy;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace IAsset.MicroServices.FlightAssignedToGate.Nancy
{
    [ProjectComponent(Lifestyle.Singleton)]
    public class FlightAssignedToGateInformationFinder
        : IFlightAssignedToGateInformationFinder
    {
        public FlightAssignedToGateInformationFinder(
            [NotNull] IFlightAssignedToGateRepository repository)
        {
            m_Repository = repository;
        }

        private readonly IFlightAssignedToGateRepository m_Repository;

        public IFlightAssignedToGate Delete(int id)
        {
            IFlightAssignedToGate entity = m_Repository.FindById(id);

            m_Repository.Remove(entity);

            return entity;
        }

        public IFlightAssignedToGate FindById(int id)
        {
            IFlightAssignedToGate entity = m_Repository.FindById(id);

            return entity;
        }

        public IEnumerable <IFlightAssignedToGate> List()
        {
            IQueryable <IFlightAssignedToGate> all = m_Repository.All;

            return all;
        }

        public IFlightAssignedToGate Save(IFlightAssignedToGate entity)
        {
            m_Repository.Save(entity);

            return entity;
        }

        public IEnumerable <IFlightAssignedToGate> FlightsAssignedToGate(int gateId)
        {
            IQueryable <IFlightAssignedToGate> all = m_Repository.All.Where(x => x.GateId == gateId);

            return all;
        }
    }
}