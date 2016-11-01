using System.Collections.Generic;
using System.Linq;

namespace TestCodibility
{
    public class Task3SolutionCodibility
    {
        public int solution(int[] A)
        {
            int N = A.Length;

            Dictionary<int, List<int>> dictonary = CreateDictonary(A);

            return dictonary.Keys.Sum(key => FindValidPairs(dictonary[key], N));
        }

        private int FindValidPairs(List<int> ints, int N)
        {
            int[] indexes = ints.ToArray();

            int sum = 0;

            for(int i = 0; i<indexes.Length-1; i++)
            {
                int P = indexes[i];

                for (int j = i; j < indexes.Length - 1; j++)
                {
                    int Q = indexes[i + 1];

                    if (0 <= P &&
                        P <= Q &&
                        Q < N)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private Dictionary<int, List<int>> CreateDictonary(int[] A)
        {
            var dictionary = new Dictionary<int, List<int>>();

            for (int index = 0; index < A.Length; index++)
            {
                int value = A[index];

                List<int> sortedList;

                if (dictionary.ContainsKey(value))
                {
                    sortedList = dictionary[value];
                }
                else
                {
                    sortedList = new List<int>();
                    dictionary.Add(value, sortedList);
                }

                sortedList.Add(index);
            }

            return dictionary;
        }
    }
}