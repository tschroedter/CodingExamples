using System.Collections.Generic;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.DataAccess;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.Nancy;
using JetBrains.Annotations;
using Nancy;
using Newtonsoft.Json;
using Selkie.Windsor;

namespace IAsset.MicroServices.FlightAssignedToGate.Nancy
{
    [ProjectComponent(Lifestyle.Transient)]
    public class FlightAssignedToGateRequestHandler : IFlightAssignedToGateRequestHandler
    {
        public FlightAssignedToGateRequestHandler([NotNull] IFlightAssignedToGateInformationFinder informationFinder)
        {
            m_InformationFinder = informationFinder;
        }

        private readonly IFlightAssignedToGateInformationFinder m_InformationFinder;

        public Response List()
        {
            IEnumerable <IFlightAssignedToGate> responses = m_InformationFinder.List();

            return AsJson(responses);
        }

        public Response FindById(int id)
        {
            IFlightAssignedToGate response = m_InformationFinder.FindById(id);

            return response == null
                       ? HttpStatusCode.NotFound
                       : AsJson(response);
        }

        public Response Save(IFlightAssignedToGate flightAssignedToGate)
        {
            IFlightAssignedToGate saved = m_InformationFinder.Save(flightAssignedToGate);

            return AsJson(saved);
        }

        public Response FlightsAssignedToGate(int id)
        {
            IEnumerable <IFlightAssignedToGate> response = m_InformationFinder.FlightsAssignedToGate(id);

            return response == null
                       ? HttpStatusCode.NotFound
                       : AsJson(response);
        }

        public Response DeleteById(int id)
        {
            IFlightAssignedToGate response = m_InformationFinder.Delete(id);

            return response == null
                       ? HttpStatusCode.NotFound
                       : AsJson(response);
        }

        private Response AsJson(object instance)
        {
            Response response = JsonConvert.SerializeObject(instance);

            response.ContentType = "application/json";

            return response;
        }
    }
}