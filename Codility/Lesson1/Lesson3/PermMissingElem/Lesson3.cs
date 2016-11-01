namespace PermMissingElem
{
    public class Lesson3
    {
        public int Solution(int[] a)
        {
            if ( a == null ||
                 a.Length <= 1 )
            {
                return 1;
            }

            return FindMissingNumberI(a);
        }

        private static int FindMissingNumberI(int[] a)
        {
            bool[] numbersFound = CreateArrayToStoreNumbersFound(a);

            foreach ( int number in a )
            {
                numbersFound [ number ] = true;
            }

            for ( var i = 0 ; i < numbersFound.Length ; i++ )
            {
                if ( !numbersFound [ i ] )
                {
                    return i;
                }
            }

            return -1;
        }

        private static bool[] CreateArrayToStoreNumbersFound(int[] a)
        {
            int lengthRequired = a.Length + 2;
            
            var numbersFound = new bool[lengthRequired];

            numbersFound [ 0 ] = true;

            return numbersFound;
        }
    }
}