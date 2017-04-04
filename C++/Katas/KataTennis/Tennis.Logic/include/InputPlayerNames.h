#pragma once

#include "Game.h"

namespace Tennis
{
    namespace Logic
    {
        class InputPlayerNames // todo testing
        {
        private:
            static std::string getString ();
        public:
            static std::string getPlayerName ( std::string text = "Player name? " );
        };
    };
};
