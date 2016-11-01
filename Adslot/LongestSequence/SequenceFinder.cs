using JetBrains.Annotations;

namespace LongestSequence
{
    public sealed class SequenceFinder
    {
        public int FindIndex([NotNull] int[] numbers)
        {
            if ( numbers.Length == 0 )
            {
                return -1;
            }

            var longestSequenceIndex = 0;
            var longestSequenceCount = 1;
            var longestSequenceMax = 1;
            var currentSequenceStartIndex = 0;
            int currentNumber = numbers [ 0 ];

            for ( var i = 1 ; i < numbers.Length ; i++ )
            {
                int nextNumber = numbers [ i ];

                if ( currentNumber < nextNumber )
                {
                    longestSequenceCount++;
                }
                else
                {
                    if ( longestSequenceCount > longestSequenceMax )
                    {
                        longestSequenceMax = longestSequenceCount;
                        longestSequenceIndex = currentSequenceStartIndex;
                    }

                    longestSequenceCount = 1;
                    currentSequenceStartIndex = i;
                }

                currentNumber = nextNumber;
            }

            if ( longestSequenceCount > longestSequenceMax )
            {
                longestSequenceIndex = currentSequenceStartIndex;
            }

            return longestSequenceIndex;
        }
    }
}