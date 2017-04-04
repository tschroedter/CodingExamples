#pragma once
#include "ITieBreak.h"
#include "IGame.h"

namespace Tennis
{
    namespace Logic
    {
        class ITieBreaks
        {
        public:
            virtual ~ITieBreaks () = default;

            virtual ITieBreak* create_tie_break_for_game ( const IGame* game ) = 0;
            virtual ITieBreak* get_tie_break_for_game ( const IGame* game ) = 0;
            virtual ITieBreak* get_current_tie_break () = 0;
            virtual void won_point ( Player player ) = 0;
            virtual uint8_t get_score ( Player player ) = 0;
            virtual TieBreakStatus get_current_status () = 0;
        };
    };
};
