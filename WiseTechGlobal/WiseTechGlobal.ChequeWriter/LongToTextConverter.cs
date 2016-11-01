using System.Text;

namespace WiseTechGlobal.ChequeWriter
{
    /*
     * ATTENTION: The original code is from the internet! 
     *            I modified it to use it with Test1.
     *            https://nickstips.wordpress.com/2010/05/03/c-printing-check-amounts-converting-numbers-to-words/
     * 
     * Please, if you are really interested in how I split up problems and code look at my GitHub projects
     */

    public class LongToTextConverter : ILongToTextConverter
    {
        private readonly string[] m_Ones =
        {
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"
        };

        private readonly string[] m_Powers =
        {
            "thousand",
            "million",
            "billion"
        };

        private readonly string[] m_Tens =
        {
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety"
        };

        public LongToTextConverter()
        {
            Text = string.Empty;
        }

        public string Text { get; private set; }

        public void Convert(long number)
        {
            var wordNumber = new StringBuilder();

            if ( number == 0 )
            {
                Text = "zero";
                return;
            }

            if ( number < 0 )
            {
                wordNumber.Append("NEGATIVE ");
                number = -number;
            }

            long[] groupedNumber = CreateAndPopulateGroups(number);

            wordNumber.Append(ProcessGroups(groupedNumber));

            Text = wordNumber.ToString().Trim();
        }

        private long[] CreateAndPopulateGroups(long number)
        {
            long[] groupedNumber =
            {
                0,
                0,
                0,
                0
            };

            var groupIndex = 0;

            while ( number > 0 )
            {
                groupedNumber [ groupIndex++ ] = number % 1000;
                number /= 1000;
            }

            return groupedNumber;
        }

        private string ProcessGroups(long[] groupedNumber)
        {
            var wordNumber = new StringBuilder();

            for ( var i = 3 ; i >= 0 ; i-- )
            {
                long group = groupedNumber [ i ];
                var isAndRequired = false;

                if ( @group >= 100 )
                {
                    isAndRequired = true;

                    wordNumber.Append(m_Ones [ @group / 100 - 1 ] + " hundred ");
                    @group %= 100;

                    if ( @group == 0 &&
                         i > 0 )
                    {
                        wordNumber.Append(m_Powers [ i - 1 ] + ", ");
                    }
                }

                if ( @group >= 20 )
                {
                    if ( isAndRequired )
                    {
                        wordNumber.Append("and ");
                    }

                    if ( @group % 10 != 0 )
                    {
                        wordNumber.Append(m_Tens [ @group / 10 - 2 ] + " " + m_Ones [ @group % 10 - 1 ] + " ");
                    }
                    else
                    {
                        wordNumber.Append(m_Tens [ @group / 10 - 2 ] + " ");
                    }
                }
                else if ( @group > 0 )
                {
                    wordNumber.Append(m_Ones [ @group - 1 ] + " ");
                }

                if ( @group != 0 &&
                     i > 0 )
                {
                    wordNumber.Append(m_Powers [ i - 1 ] + ", ");
                }
            }

            return wordNumber.ToString();
        }
    }
}