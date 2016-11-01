using JetBrains.Annotations;

namespace Game.Interfaces
{
    public interface ICircleOfPeopleFactory
    {
        ICircleOfPeople Create(int numberOfPeopleStanding);
        void Release([NotNull] ICircleOfPeople circleOfPeople);
    }
}