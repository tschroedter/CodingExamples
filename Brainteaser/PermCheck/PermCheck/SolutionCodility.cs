using System;
using System.Linq;

namespace PermCheck
{
    public class SolutionCodility
    {
        public int Solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            if (A.Length == 1)
            {
                return A[0] == 1 ? 1 : 0;
            }

            int maxNumber = A.Length;

            var existing = new bool[maxNumber + 1];
            existing[0] = true;

            foreach (int number in A)
            {
                if (number < A.Length + 1)
                {
                    existing[number] = true;
                }
                else
                {
                    return 0;
                }
            }

            if (existing.Any(exist => !exist))
            {
                return 0;
            }

            return 1;
        }
    }
}