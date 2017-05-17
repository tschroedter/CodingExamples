#pragma once

#include "Player.h"
#include "IIOCContainerBuilder.h"

namespace Tennis
{
    namespace Match
    {
        class PlayMatch
        {
        private:
            static int get_int_1_or_2 ();
            static Logic::Player ask_which_player_won_point ();

            Container_Ptr m_container;

        public:
            PlayMatch ( Container_Ptr container )
                : m_container ( container )
            {
            }

            void run () const;
        };
    }
}
