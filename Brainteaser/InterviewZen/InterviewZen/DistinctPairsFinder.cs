/*
Q5. Given an array of integers, return the distinct pairs of array values who's sum is an odd number. 

E.g. An array of [1, 2, 3, 4, 2] returns;

1+2, 2+3, 1+4, 3+4

Write the method(s) in C# and make use of multiple threads.
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewZen
{
    public class DistinctPairsFinder
    {
        private readonly int[] m_Numbers;
        private readonly List<OddPair> m_OddPairs = new List<OddPair>();

        public DistinctPairsFinder(int[] numbers)
        {
            m_Numbers = numbers;
        }

        public int[] Numbers
        {
            get { return m_Numbers; }
        }

        public OddPair[] OddPairs
        {
            get { return m_OddPairs.ToArray(); }
        }

        public void Find()
        {
            m_OddPairs.Clear();

            Parallel.For(0, m_Numbers.Length, FindOddPairsForIndex);
/*
            var tasks = new List<Task>();

            for (int i = 0; i < m_Numbers.Length; i++)
            {
                int index = i;
                var task = new Task(() => FindOddPairsForIndex(index));
                tasks.Add(task);
                task.Start();
            }

            foreach (Task task in tasks)
            {
                task.Wait();
            }
 */
        }

        private void FindOddPairsForIndex(int i)
        {
            for (int j = 0; j < m_Numbers.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                int sum = m_Numbers[i] + m_Numbers[j];

                if (sum%2 != 0)
                {
                    var oddPair = new OddPair(m_Numbers[i], m_Numbers[j]);

                    lock (this)
                    {
                        if (!m_OddPairs.Contains(oddPair))
                        {
                            m_OddPairs.Add(oddPair);
                        }
                    }
                }
            }
        }
    }
}