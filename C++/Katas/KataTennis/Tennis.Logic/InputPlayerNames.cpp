#include "include/InputPlayerNames.h"
#include <string>

namespace Tennis
{
    namespace Logic
    {
        std::string InputPlayerNames::get_string () const
        {
            std::string choice;
            do
            {
                m_in >> choice;
            }
            while ( choice.length() == 0 );

            return choice;
        }

        std::string InputPlayerNames::get_player_name ( std::string text ) const
        {
            m_out << text;

            return get_string();
        }
    };
};
