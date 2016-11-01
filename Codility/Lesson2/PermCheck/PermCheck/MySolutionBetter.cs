using System.Collections.Generic;

namespace PermCheck
{
    public class MySolutionBetter
    {
        public int Solution(int[] a)
        {
            // idea: add to set,dictionary. Count the size and compare to N.
            // dedupe data when needed. 
            var set = new HashSet<int>();
            var max = int.MinValue;

            foreach (var item in a)
            {
                if (set.Contains(item))
                {
                    return 0;
                }

                set.Add(item);
                if (item > max)
                {
                    max = item;
                }
            }
            return set.Count == max ? 1 : 0;
        }
    }
}