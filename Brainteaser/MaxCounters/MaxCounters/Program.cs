using System;
using System.Text;

namespace MaxCounters
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new SolutionCodibility();
            var A = BigArray(10000000);

            var expected = new[] { 3, 2, 2, 4, 2 };
            var actual = solution.solution(A.Length-1, A);

//            var message = string.Format("\n\nExpected:\t{0}\nActual:\t\t{1}",
//                            ArrayToString(expected),
//                            ArrayToString(actual));

            var message = "Done!";
            Console.WriteLine(message);
            Console.ReadLine();
        }

        private static string ArrayToString(int[] array)
        {
            StringBuilder builder = new StringBuilder();

            foreach (int number in array)
            {
                builder.Append(" " + number);
            }

            return builder.ToString();
        }

        private static int[] BigArray(int size)
        {
            var random = new Random(0);

            var array = new int[size];

            for(int i=0; i<size; i++)
            {
                array[i] = random.Next(1, size - 1);
            }

            return array;
        }
    }
}
