using System.Collections.Generic;
using JetBrains.Annotations;
using MicroServices.Nancy.Persons.Interfaces;
using Nancy;
using Newtonsoft.Json;
using Selkie.Windsor;

namespace MicroServices.Nancy.Persons
{
    [ProjectComponent(Lifestyle.Transient)]
    public class RequestHandler : IRequestHandler
    {
        private readonly IInformationFinder m_InformationFinder;

        public RequestHandler([NotNull] IInformationFinder informationFinder)
        {
            m_InformationFinder = informationFinder;
        }

        public Response List()
        {
            IEnumerable <IPersonForResponse> doctors = m_InformationFinder.List();

            return AsJson(doctors);
        }

        public Response FindById(int id)
        {
            IPersonForResponse doctor = m_InformationFinder.FindById(id);

            if ( doctor == null )
            {
                return HttpStatusCode.NotFound;
            }

            return AsJson(doctor);
        }

        public Response Save(IPersonForResponse doctor)
        {
            IPersonForResponse saved = m_InformationFinder.Save(doctor);

            return AsJson(saved);
        }

        public Response DeleteById(int id)
        {
            IPersonForResponse doctor = m_InformationFinder.Delete(id);

            if ( doctor == null )
            {
                return HttpStatusCode.NotFound;
            }

            return AsJson(doctor);
        }

        private Response AsJson(object instance)
        {
            Response response = JsonConvert.SerializeObject(instance);

            response.ContentType = "application/json";

            return response;
        }
    }
}