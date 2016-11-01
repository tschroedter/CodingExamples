using System.Diagnostics.CodeAnalysis;
using Game.Interfaces;

namespace Game
{
    public sealed class CircleOfPeopleFactory : ICircleOfPeopleFactory
    {
        public ICircleOfPeople Create(int numberOfPeopleStanding)
        {
            return new CircleOfPeople(numberOfPeopleStanding);
        }

        [ExcludeFromCodeCoverage]
        public void Release(ICircleOfPeople circleOfPeople)
        {
        }
    }
}