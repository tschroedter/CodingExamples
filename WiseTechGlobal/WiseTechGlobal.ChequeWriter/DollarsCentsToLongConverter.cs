using System;

namespace WiseTechGlobal.ChequeWriter
{
    public class DollarsCentsToLongConverter : IDollarsCentsToLongConverter
    {
        private const int DollarsIndex = 0;
        private const int CentsIndex = 1;

        private long m_Cents;
        private long m_Dollars;

        public long Dollars
        {
            get
            {
                return m_Dollars;
            }
        }

        public long Cents
        {
            get
            {
                return m_Cents;
            }
        }

        public void Convert(string dollarAndCentsAmount)
        {
            string[] arrayDollarCents = dollarAndCentsAmount.Split('.');

            if ( arrayDollarCents.Length != 2 ||
                 arrayDollarCents [ 0 ] == string.Empty ||
                 arrayDollarCents [ 1 ] == string.Empty )
            {
                throw new ArgumentException("Expected format is dollars.cents, e.g. 1234.56");
            }

            m_Dollars = 0;

            if ( !long.TryParse(arrayDollarCents [ DollarsIndex ],
                                out m_Dollars) )
            {
                throw new ArgumentException("Expected format is dollars.cents, e.g. 1234.56");
            }

            m_Cents = 0;

            if ( HasNotMoreThanTwoDigits(arrayDollarCents) ||
                 !long.TryParse(arrayDollarCents [ CentsIndex ],
                                out m_Cents) )
            {
                throw new ArgumentException("Expected format is dollars.cents, e.g. 1234.56");
            }
        }

        private static bool HasNotMoreThanTwoDigits(string[] arrayDollarCents)
        {
            return arrayDollarCents [ CentsIndex ].Length > 2;
        }
    }
}