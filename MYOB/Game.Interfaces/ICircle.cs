using System.Collections.Generic;

namespace Game.Interfaces
{
    public interface ICircle
    {
        IEnumerable <int> Run(int numberOfPeopleStandingInACircle,
                              int numberOfPeopleToCountOverEachTime);
    }
}