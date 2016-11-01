using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace WiseTechGlobal.RomanCalculator
{
    public class RomanNumeralsToIntegerConverter
    {
        private readonly Dictionary <string, int> m_RomanNumbers = new Dictionary <string, int>();

        public RomanNumeralsToIntegerConverter()
        {
            m_RomanNumbers.Add("M",
                               1000);
            m_RomanNumbers.Add("CM",
                               900);
            m_RomanNumbers.Add("D",
                               500);
            m_RomanNumbers.Add("CD",
                               400);
            m_RomanNumbers.Add("C",
                               100);
            m_RomanNumbers.Add("XC",
                               90);
            m_RomanNumbers.Add("L",
                               50);
            m_RomanNumbers.Add("XL",
                               40);
            m_RomanNumbers.Add("X",
                               10);
            m_RomanNumbers.Add("IX",
                               9);
            m_RomanNumbers.Add("V",
                               5);
            m_RomanNumbers.Add("IV",
                               4);
            m_RomanNumbers.Add("I",
                               1);
        }

        public int Convert([NotNull] string text)
        {
            var result = 0;

            foreach ( KeyValuePair <string, int> pair in m_RomanNumbers )
            {
                while ( text.IndexOf(pair.Key,
                                     StringComparison.Ordinal) == 0 )
                {
                    result += pair.Value;
                    text = text.Substring(pair.Key.Length);
                }
            }

            return result;
        }
    }
}