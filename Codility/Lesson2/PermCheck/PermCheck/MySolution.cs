using System.Linq;

namespace PermCheck
{
    public class MySolution
    {
        public int Solution(int[] a)
        {
            if (a == null ||
                a.Length == 0)
            {
                return 0;
            }

            var result = IsPermutation(a);

            return result ? 1 : 0;
        }

        private bool IsPermutation(int[] numbers)
        {
            var maxNumber = numbers.Max();
            var numbersFound = new bool[maxNumber + 1];
            numbersFound[0] = true;

            foreach (int number in numbers)
            {
                if (numbersFound[number])
                {
                    return false;
                }

                numbersFound[number] = true;
            }

            return !numbersFound.Any(x => x == false);
        }
    }
}
