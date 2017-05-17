#pragma once

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
                const IGames_Ptr games ) = 0;
        };

        typedef std::shared_ptr<IGamesCounter> IGamesCounter_Ptr;
    };
};
