using System;

namespace TestCodibility
{
    public class Task4SolutionCodibility
    {
        public int solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)

            if (null == A)
            {
                return -1;
            }

            if (A.Length < 3)
            {
                return -1;
            }

            Array.Sort(A);

            int maxSum = -1;

            for (int i = 0; i < A.Length - 2 && A[i] > 0; i++)
            {
                if (A[i] + A[i + 1] > A[i + 2])
                {
                    int sum = A[i] + A[i + 1] + A[i + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }
            }

            return maxSum;
        }
    }
}