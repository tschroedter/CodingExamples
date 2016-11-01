using System.Collections.Generic;

namespace MicroServices.Nancy.Persons.Interfaces
{
    public interface IInformationFinder
    {
        IPersonForResponse FindById(int id);
        IEnumerable <IPersonForResponse> List();
        IPersonForResponse Delete(int id);
        IPersonForResponse Save(IPersonForResponse person);
    }
}