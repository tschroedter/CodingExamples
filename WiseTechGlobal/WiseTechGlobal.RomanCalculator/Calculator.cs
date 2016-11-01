using System;
using JetBrains.Annotations;
using WiseTechGlobal.RomanNumerals;

namespace WiseTechGlobal.RomanCalculator
{
    public class Calculator
    {
        private readonly RomanNumeralConverter m_RomanNumeral;
        private readonly RomanNumeralsToIntegerConverter m_RomanNumeralsToInteger;
        private readonly InputValidator m_Validator;
        private int m_One;
        private int m_Two;

        public Calculator()
        {
            m_Validator = new InputValidator();
            m_RomanNumeralsToInteger = new RomanNumeralsToIntegerConverter();
            m_RomanNumeral = new RomanNumeralConverter();
        }

        public string Add([NotNull] string valueOne,
                          [NotNull] string valueTwo)
        {
            ValidateAndSetValues(valueOne,
                                 valueTwo);

            string result = m_RomanNumeral.Convert(m_One + m_Two);

            return result;
        }

        private void ValidateAndSetValues(string valueOne,
                                          string valueTwo)
        {
            if ( !m_Validator.IsValid(valueOne) )
            {
                throw new ArgumentException("Invalid value one: " + valueOne);
            }

            if ( !m_Validator.IsValid(valueTwo) )
            {
                throw new ArgumentException("Invalid value one: " + valueTwo);
            }

            m_One = m_RomanNumeralsToInteger.Convert(valueOne);
            m_Two = m_RomanNumeralsToInteger.Convert(valueTwo);
        }
    }
}