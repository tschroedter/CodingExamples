using System;

namespace TestCodibility
{
    public class TaskOneSolutionCodibility
    {
        public int solution(int[] A)
        {
            int a = A[0];
            int b = A[1];
            int c = A[2];
            int d = A[3];

            return solution(a, b, c, d);
        }

        public int solution(int a, int b, int c, int d)
        {
            int[] sorted = {a, b, c, d};
            Array.Sort(sorted);

            int arrayA = sorted[0];
            int arrayB = sorted[1];
            int arrayC = sorted[2];
            int arrayD = sorted[3];

            int[] s = {arrayB, arrayD, arrayA, arrayC};

            return shuffle(s);
        }

        private int shuffle(int[] s)
        {
            var one = Math.Abs(s[0] - s[1]);
            var two = Math.Abs(s[1] - s[2]);
            var three = Math.Abs(s[2] - s[3]);

            return one + two + three;
        }
    }
}