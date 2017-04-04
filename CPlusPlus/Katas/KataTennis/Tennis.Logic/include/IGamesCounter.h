#pragma once

#include "IGamesCounter.h"
#include "Player.h"
#include "IGames.h"

namespace Tennis
{
    namespace Logic
    {
        class IGames;

        class IGamesCounter
        {
        public:
            virtual ~IGamesCounter () = default;

            virtual int8_t count_games_for_player (
                const Player player,
                const IGames* games ) = 0;
        };
    };
};
