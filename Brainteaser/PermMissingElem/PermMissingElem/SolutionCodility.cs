namespace PermMissingElem
{
    public class SolutionCodility
    {
        public int Solution(int[] numbers)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            var possibleNumbers = new bool[numbers.Length + 2];
            possibleNumbers[0] = true;

            for(int i=0; i<numbers.Length; i++)
            {
                possibleNumbers[numbers[i]] = true;
            }

            for (int i = 0; i < possibleNumbers.Length; i++)
            {
                if(!possibleNumbers[i])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}