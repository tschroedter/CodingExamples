#pragma once

#include "Player.h"
#include "ISets.h"

namespace Tennis
{
    namespace Logic
    {
        class IMatchCounter
        {
        public:
            virtual ~IMatchCounter() = default;

            virtual int8_t count_sets_won_by_player(
                const Player player,
                const ISets* sets) const = 0;
        };
    };
};