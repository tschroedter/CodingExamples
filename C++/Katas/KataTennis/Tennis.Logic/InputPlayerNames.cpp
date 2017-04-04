#include "include/InputPlayerNames.h"
#include <iostream>
#include <string>

namespace Tennis
{
    namespace Logic
    {
        std::string InputPlayerNames::getString ()  // todo rename
        {
            std::string choice;
            do
            {
                std::cin >> choice;
            }
            while ( choice.length() == 0 );

            return choice;
        }

        std::string InputPlayerNames::getPlayerName ( std::string text )
        {
            std::cout << text;

            return getString();
        }
    };
};
