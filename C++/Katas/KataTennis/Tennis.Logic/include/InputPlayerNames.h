#pragma once

<<<<<<< HEAD
#include "Game.h"
=======
#include <iostream>
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        class InputPlayerNames // todo testing
        {
        private:
            static std::string getString ();
        public:
            static std::string getPlayerName ( std::string text = "Player name? " );
=======
        class InputPlayerNames
        {
        private:
            std::istream& m_in;
            std::ostream& m_out;
            std::string get_string () const;
        public:
            InputPlayerNames (
                std::ostream& out = std::cout,
                std::istream& in = std::cin )
                : m_in ( in )
                , m_out ( out )
            {
            }

            std::string get_player_name ( std::string text = "Player name? " ) const;
>>>>>>> Update from private repository
        };
    };
};
