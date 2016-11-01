/*
Q5. Given an array of integers, return the distinct pairs of array values who's sum is an odd number. 

E.g. An array of [1, 2, 3, 4, 2] returns;

1+2, 2+3, 1+4, 3+4

Write the method(s) in C# and make use of multiple threads.
 */

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewZen
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Enumerable.Range(0, 1000000).ToArray();
            long total = 0;

            // Use type parameter to make subtotal a long, not an int
            Parallel.For<long>(0, nums.Length, () => 0, (j, loop, subtotal) =>
            {
                subtotal += nums[j];
                return subtotal;
            },
                (x) => Interlocked.Add(ref total, x)
            );

            Parallel.For(0, nums.Length, i => Test(i, nums));

            Console.WriteLine("The total is {0:N0}", total);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void Test(int i,
                                 int[] nums)
        {
            Console.WriteLine("{0} : {1}", i, nums[i]);
        }
    }
}
