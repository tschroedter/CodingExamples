using System;
using System.Collections.Generic;
using System.Linq;
using Game.Interfaces;
using JetBrains.Annotations;

namespace Game
{
    public class Circle : ICircle
    {
        private readonly ICircleOfPeopleFactory m_Factory;

        public Circle([NotNull] ICircleOfPeopleFactory factory)
        {
            m_Factory = factory;
        }

        public IEnumerable <int> Run(int numberOfPeopleStandingInACircle,
                                     int numberOfPeopleToCountOverEachTime)
        {
            CheckParameters(numberOfPeopleStandingInACircle,
                            numberOfPeopleToCountOverEachTime);

            ICircleOfPeople circleOfPeople = m_Factory.Create(numberOfPeopleStandingInACircle);

            IEnumerable <int> removedPersonIds = StartCountingTo(circleOfPeople,
                                                                 numberOfPeopleToCountOverEachTime);

            m_Factory.Release(circleOfPeople);

            return removedPersonIds;
        }

        private IEnumerable <int> StartCountingTo([NotNull] ICircleOfPeople circleOfPeople,
                                                  int countTo)
        {
            var removedPersonIds = new List <int>();
            var fromPersonId = 1;

            do
            {
                int removedPersonId = circleOfPeople.NextPersonForCountTo(fromPersonId,
                                                                          countTo);

                fromPersonId = circleOfPeople.NextPerson(removedPersonId);
                circleOfPeople.RemovePerson(removedPersonId);
                removedPersonIds.Add(removedPersonId);
            }
            while ( circleOfPeople.PeopleStanding.Any() );

            return removedPersonIds;
        }

        // ReSharper disable UnusedParameter.Local
        private static void CheckParameters(int numberOfPeopleStandingInACircle,
                                            int numberOfPeopleToCountOverEachTime)
        {
            if ( numberOfPeopleStandingInACircle < 1 )
            {
                string message =
                    string.Format("'numberOfPeopleStandingInACircle' is {0} but it can't be zero or negative!",
                                  numberOfPeopleStandingInACircle);

                throw new ArgumentException(message,
                                            "numberOfPeopleStandingInACircle");
            }

            if ( numberOfPeopleToCountOverEachTime < 1 )
            {
                string message =
                    string.Format("'numberOfPeopleToCountOverEachTime' is {0} can't be zero or negative!",
                                  numberOfPeopleToCountOverEachTime);

                throw new ArgumentException(message,
                                            "numberOfPeopleToCountOverEachTime");
            }
        }

        // ReSharper restore UnusedParameter.Local
    }
}