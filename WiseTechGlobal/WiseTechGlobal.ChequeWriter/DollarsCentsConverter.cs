using JetBrains.Annotations;

namespace WiseTechGlobal.ChequeWriter
{
    public class DollarsCentsConverter
    {
        private readonly IDollarsCentsToLongConverter m_LongConverter;
        private readonly LongToTextConverter m_LongToTextConverter;

        public DollarsCentsConverter()
        {
            m_LongConverter = new DollarsCentsToLongConverter();
            m_LongToTextConverter = new LongToTextConverter();
        }

        public string Convert([NotNull] string dollarAndCentsAmount)
        {
            m_LongConverter.Convert(dollarAndCentsAmount);

            return CreateDollarsCentsText(m_LongConverter.Dollars,
                                          m_LongConverter.Cents);
        }

        private string CreateDollarsCentsText(long dollars,
                                              long cents)
        {
            string asTextDollars = AmoutAsText(dollars);
            string asTextCents = AmoutAsText(cents);

            string asText = asTextDollars;

            if ( dollars == 1 )
            {
                asText += " DOLLAR";
            }
            else
            {
                asText += " DOLLARS";
            }

            if ( asTextCents.Length > 0 )
            {
                asText += " AND " + asTextCents;

                if ( cents == 1 )
                {
                    asText += " CENT";
                }
                else
                {
                    asText += " CENTS";
                }
            }

            return asText;
        }

        private string AmoutAsText(long amount)
        {
            m_LongToTextConverter.Convert(amount);

            return m_LongToTextConverter.Text;
        }
    }
}