using System.Collections.Generic;
using System.Linq;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.DataAccess;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.Nancy;
using IAsset.MicroServices.FlightsAssignedToGates.Interfaces.Nancy;
using JetBrains.Annotations;
using Nancy;
using Newtonsoft.Json;
using Selkie.Windsor;

namespace IAsset.MicroServices.FlightsAssignedToGates.Nancy
{
    [ProjectComponent(Lifestyle.Transient)]
    public class FlightsAssignedToGatesRequestHandler : IFlightsAssignedToGatesRequestHandler
    {
        public FlightsAssignedToGatesRequestHandler([NotNull] IFlightAssignedToGateInformationFinder informationFinder)
            // todo not nice, dependency on other service
        {
            m_InformationFinder = informationFinder;
        }

        private readonly IFlightAssignedToGateInformationFinder m_InformationFinder;

        public Response FlightsAssignedToGate(int id)
        {
            IEnumerable <IFlightAssignedToGate> flights = m_InformationFinder.FlightsAssignedToGate(id);

            FlightsAssignedToGates response = CreateFlightsAssignedToGates(id,
                                                                           flights);

            return AsJson(response);
        }

        public Response List()
        {
            var response = new List <IFlightsAssignedToGates>();

            IEnumerable <IGrouping <int, IFlightAssignedToGate>> groupBy =
                m_InformationFinder.List().GroupBy(x => x.GateId);

            foreach ( IGrouping <int, IFlightAssignedToGate> group in groupBy )
            {
                FlightsAssignedToGates flightsAssignedToGates = CreateFlightsAssignedToGates(
                                                                                             group.Key,
                                                                                             group);

                response.Add(flightsAssignedToGates);
            }

            return AsJson(response);
        }

        private static FlightsAssignedToGates CreateFlightsAssignedToGates(
            int gateId,
            IEnumerable <IFlightAssignedToGate> assigned)
        {
            int[] flightId = assigned.Select(x => x.FlightId).ToArray();

            var instance = new FlightsAssignedToGates
                           {
                               GateId = gateId,
                               FlightIds = flightId
                           };

            return instance;
        }

        private Response AsJson(object instance)
        {
            Response response = JsonConvert.SerializeObject(instance);

            response.ContentType = "application/json";

            return response;
        }
    }
}