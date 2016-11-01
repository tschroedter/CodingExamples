using System;
using System.Collections.Generic;
using System.Linq;
using Game.Interfaces;

namespace Game
{
    public class CircleOfPeople : ICircleOfPeople
    {
        private readonly int m_MaxPersonId;
        private readonly LinkedList <int> m_Ring = new LinkedList <int>();

        public CircleOfPeople(int numberOfPeopleStanding)
        {
            if ( numberOfPeopleStanding <= 0 )
            {
                throw new ArgumentException("'numberOfPeopleStanding' can't be zero or negative!",
                                            "numberOfPeopleStanding");
            }

            for ( var id = 1 ; id <= numberOfPeopleStanding ; id++ )
            {
                m_Ring.AddLast(id);
            }

            m_MaxPersonId = numberOfPeopleStanding;
        }

        public IEnumerable <int> PeopleStanding
        {
            get
            {
                return m_Ring.ToArray();
            }
        }

        public int NextPerson(int personId)
        {
            CheckPersonId(personId);

            int nextPersonId = FindNextPerson(personId);

            return nextPersonId;
        }

        public void RemovePerson(int personId)
        {
            m_Ring.Remove(personId);
        }

        public int NextPersonForCountTo(int personId,
                                        int countTo)
        {
            CheckPersonId(personId);

            if ( countTo <= 0 )
            {
                throw new ArgumentException("'countTo' can't be zero or negative",
                                            "countTo");
            }

            int findNextPersonIdForCountTo = FindNextPersonIdForCountTo(personId,
                                                                        countTo);

            return findNextPersonIdForCountTo;
        }

        private int FindNextPerson(int personId)
        {
            // ReSharper disable PossibleNullReferenceException
            // should never be null because we checked id before calling 
            // and created a ring. - If null here, I want an exception!
            LinkedListNode <int> item = m_Ring.Find(personId);

            LinkedListNode <int> next = item == m_Ring.Last
                                            ? m_Ring.First
                                            : item.Next;

            return next.Value;
            // ReSharper restore PossibleNullReferenceException
        }

        // ReSharper disable once UnusedParameter.Local
        private void CheckPersonId(int personId)
        {
            if ( personId <= 0 ||
                 personId > m_MaxPersonId )
            {
                throw new ArgumentException("'personId' can't be zero, negative or greater than " + m_MaxPersonId,
                                            "personId");
            }
        }

        private int FindNextPersonIdForCountTo(int personId,
                                               int countTo)
        {
            // ReSharper disable PossibleNullReferenceException
            // should never be null because we checked id before calling 
            // and created a ring. - If null here, I want an exception!
            LinkedListNode <int> item = m_Ring.Find(personId);

            int nextPersonId = item.Value;

            for ( var i = 1 ; i < countTo ; i++ )
            {
                nextPersonId = NextPerson(nextPersonId);
            }

            return nextPersonId;
            // ReSharper restore PossibleNullReferenceException
        }
    }
}