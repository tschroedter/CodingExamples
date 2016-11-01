using System.Collections.Generic;
using IAsset.MicroServices.Flights.Interfaces.DataAccess;
using IAsset.MicroServices.Flights.Interfaces.Nancy;
using JetBrains.Annotations;
using Nancy;
using Newtonsoft.Json;
using Selkie.Windsor;

namespace IAsset.MicroServices.Flights.Nancy
{
    [ProjectComponent(Lifestyle.Transient)]
    public class FlightsRequestHandler : IFlightsRequestHandler
    {
        public FlightsRequestHandler([NotNull] IFlightsInformationFinder informationFinder)
        {
            m_InformationFinder = informationFinder;
        }

        private readonly IFlightsInformationFinder m_InformationFinder;

        public Response List()
        {
            IEnumerable <IFlight> responses = m_InformationFinder.List();

            return AsJson(responses);
        }

        public Response FindById(int id)
        {
            IFlight response = m_InformationFinder.FindById(id);

            return response == null
                       ? HttpStatusCode.NotFound
                       : AsJson(response);
        }

        public Response Save(IFlight flightAssignedToGate)
        {
            IFlight saved = m_InformationFinder.Save(flightAssignedToGate);

            return AsJson(saved);
        }

        public Response DeleteById(int id)
        {
            IFlight response = m_InformationFinder.Delete(id);

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