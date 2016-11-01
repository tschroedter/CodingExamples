using System;
using JetBrains.Annotations;

namespace WiseTechGlobal.RomanNumerals
{
    public class RomanNumeralConverter
    {
        private readonly RomanDigit[] m_RomanNumerals;

        public RomanNumeralConverter()
        {
            m_RomanNumerals = new[]
                              {
                                  new RomanDigit
                                  {
                                      Digit = "M",
                                      Value = 1000
                                  },
                                  new RomanDigit
                                  {
                                      Digit = "CM",
                                      Value = 900
                                  },
                                  new RomanDigit
                                  {
                                      Digit = "D",
                                      Value = 500
                                  },
                                  new RomanDigit
                                  {
                                      Digit = "CD",
                                      Value = 400
                                  },
                                  new RomanDigit
                                  {
                                      Digit = "C",
                                      Value = 100
                                  },
                                  new RomanDigit
                                  {
                                      Digit = "XC",
                                      Value = 90
                                  },
                                  new RomanDigit
                                  {
                                      Digit = "L",
                                      Value = 50
                                  },
                                  new RomanDigit
                                  {
                                      Digit = "XL",
                                      Value = 40
                                  },
                                  new RomanDigit
                                  {
                                      Digit = "X",
                                      Value = 10
                                  },
                                  new RomanDigit
                                  {
                                      Digit = "IX",
                                      Value = 9
                                  },
                                  new RomanDigit
                                  {
                                      Digit = "V",
                                      Value = 5
                                  },
                                  new RomanDigit
                                  {
                                      Digit = "IV",
                                      Value = 4
                                  },
                                  new RomanDigit
                                  {
                                      Digit = "I",
                                      Value = 1
                                  }
                              };
        }

        public string Convert([NotNull] string value)
        {
            int number = StringToInteger(value);

            return Convert(number);
        }

        public string Convert(int number)
        {
            string romanNumbers = string.Empty;
            for ( var i = 0 ; number > 0 ; i++ )
            {
                while ( m_RomanNumerals [ i ].Value <= number )
                {
                    romanNumbers += m_RomanNumerals [ i ].Digit;
                    number -= m_RomanNumerals [ i ].Value;
                }
            }
            return romanNumbers;
        }

        private int StringToInteger([NotNull] string text)
        {
            if ( string.IsNullOrEmpty(text) )
            {
                throw new ArgumentException("Input can't be null or empty!");
            }

            int number;

            if ( !int.TryParse(text,
                               out number) )
            {
                throw new ArgumentException("Can't handle '" + text + "'!");
            }

            return number;
        }

        private struct RomanDigit
        {
            public string Digit;
            public int Value;
        }
    }
}