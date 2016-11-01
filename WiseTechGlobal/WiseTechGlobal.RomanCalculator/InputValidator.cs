using System.Linq;
using JetBrains.Annotations;

namespace WiseTechGlobal.RomanCalculator
{
    public class InputValidator
    {
        private readonly char[] m_ValidCharacters =
        {
            'I',
            'V',
            'X',
            'L',
            'C',
            'D',
            'M'
        };

        public bool IsValid([NotNull] string text)
        {
            if ( string.IsNullOrEmpty(text) ) // yes, I know it can't be null, but it's saver coding that way
            {
                return false;
            }

            foreach ( char c in text )
            {
                if ( !m_ValidCharacters.Any(x => x == c) )
                {
                    return false;
                }
            }

            return true;
        }
    }
}