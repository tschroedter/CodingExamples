using System.Collections.Generic;
using IAsset.MicroServices.Gates.Interfaces.DataAccess;
using IAsset.MicroServices.Gates.Interfaces.Nancy;
using JetBrains.Annotations;
using Nancy;
using Newtonsoft.Json;
using Selkie.Windsor;

namespace IAsset.MicroServices.Gates.Nancy
{
    [ProjectComponent(Lifestyle.Transient)]
    public class GatesRequestHandler : IGatesRequestHandler
    {
        public GatesRequestHandler([NotNull] IGatesInformationFinder informationFinder)
        {
            m_InformationFinder = informationFinder;
        }

        private readonly IGatesInformationFinder m_InformationFinder;

        public Response List()
        {
            IEnumerable <IGate> responses = m_InformationFinder.List();

            return AsJson(responses);
        }

        public Response FindById(int id)
        {
            IGate response = m_InformationFinder.FindById(id);

            return response == null
                       ? HttpStatusCode.NotFound
                       : AsJson(response);
        }

        public Response Save(IGate flightAssignedToGate)
        {
            IGate saved = m_InformationFinder.Save(flightAssignedToGate);

            return AsJson(saved);
        }

        public Response DeleteById(int id)
        {
            IGate response = m_InformationFinder.Delete(id);

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