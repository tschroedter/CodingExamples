using System.Collections.Generic;
using JetBrains.Annotations;

namespace IAsset.MicroServices.Common.Nancy
{
    public interface IInformationFinder <T>
    {
        T Delete(int id);

        [CanBeNull]
        T FindById(int id);

        IEnumerable <T> List();
        T Save(T colonySettings);
    }
}