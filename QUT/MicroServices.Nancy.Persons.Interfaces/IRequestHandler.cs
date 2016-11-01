using JetBrains.Annotations;
using Nancy;

namespace MicroServices.Nancy.Persons.Interfaces
{
    public interface IRequestHandler
    {
        Response List();
        Response FindById(int id);
        Response Save([NotNull] IPersonForResponse doctor);
        Response DeleteById(int id);
    }
}