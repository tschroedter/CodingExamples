using Nancy;

namespace IAsset.MicroServices.Common.Nancy
{
    public interface IRequestHandler <in T>
    {
        Response DeleteById(int id);
        Response FindById(int id);
        Response List();
        Response Save(T response);
    }
}