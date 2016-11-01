// you can also use other imports, for example:
// using System.Collections.Generic;

// you can use Console.WriteLine for debugging purposes, e.g.
// Console.WriteLine("this is numbers debug message");

using System;
using System.Linq;

namespace TapeEquilibrium
{
    public class SolutionCodility
    {
        public int Solution(int[] numbers)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            if (numbers.Length == 2)
            {
                return Math.Abs(numbers[0] - numbers[1]);
            }

            int minimum = int.MaxValue;

            int sumLeft = 0;
            int sumright = numbers.Sum();

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                sumLeft += numbers[i];
                sumright -= numbers[i];

                var abs = Math.Abs(sumLeft-sumright);

                if (abs < minimum)
                {
                    minimum = abs;
                }
            }

            return minimum;
        }

        internal int SplitSum(int[] numbers,
                              int splitAtIndex)
        {
            if (splitAtIndex <= 0 ||
                splitAtIndex >= numbers.Length)
            {
                return -1;
            }

            int sumLeft = 0;
            for (int i = 0; i < splitAtIndex; i++)
            {
                sumLeft += numbers[i];
            }

            int sumRight = 0;
            for (int i = splitAtIndex; i < numbers.Length; i++)
            {
                sumRight += numbers[i];
            }

            return Math.Abs(sumLeft - sumRight);
        }
    }
}