#pragma once

#include "Player.h"
#include "ISets.h"
#include "IMatchCounter.h"

namespace Tennis
{
    namespace Logic
    {
        class MatchCounter
                : public IMatchCounter
        {
        public:
            ~MatchCounter ()
            {
            }

            int8_t count_sets_won_by_player (
                const Player player,
                const ISets_Ptr sets ) const override;
        };
    };
};
