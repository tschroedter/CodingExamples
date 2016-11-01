using System.Collections.Generic;

namespace Game.Interfaces
{
    public interface ICircleOfPeople
    {
        IEnumerable <int> PeopleStanding { get; }
        int NextPerson(int personId);
        void RemovePerson(int personId);

        int NextPersonForCountTo(int personId,
                                 int countTo);
    }
}