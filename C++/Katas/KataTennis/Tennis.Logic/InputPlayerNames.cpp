#include "include/InputPlayerNames.h"
<<<<<<< HEAD
#include <iostream>
=======
>>>>>>> Update from private repository
#include <string>

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        std::string InputPlayerNames::getString ()  // todo rename
=======
        std::string InputPlayerNames::get_string () const
>>>>>>> Update from private repository
        {
            std::string choice;
            do
            {
<<<<<<< HEAD
                std::cin >> choice;
=======
                m_in >> choice;
>>>>>>> Update from private repository
            }
            while ( choice.length() == 0 );

            return choice;
        }

<<<<<<< HEAD
        std::string InputPlayerNames::getPlayerName ( std::string text )
        {
            std::cout << text;

            return getString();
=======
        std::string InputPlayerNames::get_player_name ( std::string text ) const
        {
            m_out << text;

            return get_string();
>>>>>>> Update from private repository
        }
    };
};
