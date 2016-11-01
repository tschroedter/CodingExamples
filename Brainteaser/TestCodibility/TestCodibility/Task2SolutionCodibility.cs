using System;
using System.Globalization;
using System.Linq;

namespace TestCodibility
{
    public class Task2SolutionCodibility
    {
        public int solution(int N)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            string text = N.ToString(CultureInfo.InvariantCulture);

            if(text[0] == '-')
            {
                text = text.Substring(1);
            }

            int[] digits = text.ToCharArray().Select(x => (int)Char.GetNumericValue(x)).Distinct().ToArray();

            return digits.Length;
        } 
    }
}