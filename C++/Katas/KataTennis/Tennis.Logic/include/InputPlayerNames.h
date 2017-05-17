#pragma once

#include <iostream>

namespace Tennis
{
    namespace Logic
    {
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
        };
    };
};
