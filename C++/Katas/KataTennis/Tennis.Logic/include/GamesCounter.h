#pragma once

#include <cstdint>
<<<<<<< HEAD
#include "Set.h"
=======
#include "IGames.h"
>>>>>>> Update from private repository
#include "IGamesCounter.h"

namespace Tennis
{
    namespace Logic
    {
        class GamesCounter
                : public IGamesCounter
        {
        public:
            int8_t count_games_for_player (
                const Player player,
<<<<<<< HEAD
                const IGames* games ) override;
=======
                const IGames_Ptr games ) override;
>>>>>>> Update from private repository
        };
    };
};
