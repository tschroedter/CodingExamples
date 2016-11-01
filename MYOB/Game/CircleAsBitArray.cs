using System;
using System.Collections.Generic;
using System.Linq;
using Game.Interfaces;

namespace Game
{
    public class CircleAsBitArray : ICircle
    {
        internal const long DefaultMaxLoopCount = 10000000;
        private bool[] m_BitArray;

        public CircleAsBitArray()
        {
            MaxLoopCount = DefaultMaxLoopCount;
        }

        public long MaxLoopCount { get; private set; }

        public IEnumerable <int> Run(int numberOfPeopleStandingInACircle,
                                     int numberOfPeopleToCountOverEachTime)
        {
            m_BitArray = Enumerable.Repeat(true,
                                           numberOfPeopleStandingInACircle + 1).ToArray();
            m_BitArray [ 0 ] = false;

            IEnumerable <int> result = StartCounting(numberOfPeopleToCountOverEachTime);

            return result;
        }

        private IEnumerable <int> StartCounting(int countTo)
        {
            var result = new List <int>();

            var fromPersonId = 1;

            do
            {
                int removePersonId = NextPersonIdForCountTo(m_BitArray,
                                                            fromPersonId,
                                                            countTo);
                result.Add(removePersonId);

                m_BitArray [ removePersonId ] = false;

                if ( !m_BitArray.Any(x => x) )
                {
                    break;
                }

                fromPersonId = NextPersonId(m_BitArray,
                                            removePersonId);
            }
            while ( true );

            return result;
        }

        // Started off with recursive implementation but changed it when I tested with big numbers:
        // Got StackOverflow exception and change implementation.
        internal int NextPersonIdForCountTo(bool[] bitArray,
                                            int fromPersonId,
                                            int countTo)
        {
            if ( countTo == 1 )
            {
                return fromPersonId;
            }

            int nextPersonId = fromPersonId;
            var currentCount = 0;
            var loopCounter = 0;

            do
            {
                if ( bitArray [ nextPersonId ] )
                {
                    currentCount++;

                    if ( currentCount == countTo )
                    {
                        break;
                    }
                }

                nextPersonId = ( nextPersonId + 1 ) % bitArray.Length;

                if ( loopCounter++ > MaxLoopCount )
                {
                    throw new ArgumentException(
                        "Calling NextPersonIdForCountTo(...) might be in an endless loop and was stop!");
                }
            }
            while ( true );

            return nextPersonId;
        }

        // Started off with recursive implementation but changed it when I tested with big numbers:
        // Got StackOverflow exception and change implementation.
        internal int NextPersonId(bool[] bitArray,
                                  int personId)
        {
            int nextPersonId = personId;
            var loopCounter = 0;

            do
            {
                nextPersonId = ( nextPersonId + 1 ) % bitArray.Length;

                if ( bitArray [ nextPersonId ] )
                {
                    break;
                }

                if ( loopCounter++ > MaxLoopCount )
                {
                    throw new ArgumentException("Calling NextPersonId(...) might be in an endless loop and was stop!");
                }
            }
            while ( true );

            return nextPersonId;
        }

        public void SetMaxLoopCount(int maxLoopCount)
        {
            if ( maxLoopCount > 0 )
            {
                MaxLoopCount = maxLoopCount;
            }
        }
    }
}