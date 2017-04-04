#pragma once

#include "Player.h"

namespace Tennis
{
    namespace Logic
    {
        class ISetWonPointHandler
        {
        public:
            virtual ~ISetWonPointHandler () = default;

            virtual void won_game_point ( Player player ) const = 0;
            virtual void won_tie_break_point ( Player player ) const = 0;
            virtual void won_point ( Player player ) const = 0;
            virtual bool is_tie_break_Required () const = 0;
        };
    };
};
