using System;
using System.Collections;

namespace MissingInteger
{
    public class SolutionCodibility
    {
        public int solution(int[] A)
        {
            if (A.Length == 1)
            {
                if(A[0] > 0)
                {
                    return A[0] + 1;
                }
                return 1;
            }

            var existingNumbers = FindExistingNumbers(A);
            var sortedNumbers = SortedExistingNumbers(existingNumbers);
            var missingNumber = FindMissingPositiveNumber(sortedNumbers);

            return missingNumber;
        }

        private static int[] SortedExistingNumbers(Hashtable existingNumbers)
        {
            var sortedNumbers = new int[existingNumbers.Keys.Count];
            existingNumbers.Values.CopyTo(sortedNumbers, 0);
            Array.Sort(sortedNumbers);
            return sortedNumbers;
        }

        private static Hashtable FindExistingNumbers(int[] A)
        {
            var existingNumbers = new Hashtable();

            foreach (int number in A)
            {
                if (!existingNumbers.Contains(number))
                {
                    existingNumbers.Add(number, number);
                }
            }
            return existingNumbers;
        }

        private int FindMissingPositiveNumber(int[] sortedNumbers)
        {
            for (int i = 0; i < sortedNumbers.Length-1; i++)
            {
                int current = sortedNumbers[i];

                if (current < 0)
                {
                    continue;
                }

                int next = sortedNumbers[i + 1];

                if (current + 1 != next)
                {
                    return current + 1;
                }
            }

            var lastNumber = sortedNumbers[sortedNumbers.Length-1];

            if (lastNumber > 0 &&
                lastNumber < int.MaxValue)
            {
                return lastNumber + 1;
            }

            return 1;
        }
    }
}