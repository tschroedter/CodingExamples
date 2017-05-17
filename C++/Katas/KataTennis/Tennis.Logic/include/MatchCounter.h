#pragma once

#include "Player.h"
#include "ISets.h"
#include "IMatchCounter.h"

namespace Tennis
{
    namespace Logic
    {
        class MatchCounter
<<<<<<< HEAD
            : public IMatchCounter
        {
        public:
            MatchCounter()
            {
            }

            ~MatchCounter()
            {
            }

            int8_t count_sets_won_by_player(
                const Player player,
                const ISets* sets) const override;
=======
                : public IMatchCounter
        {
        public:
            ~MatchCounter ()
            {
            }

            int8_t count_sets_won_by_player (
                const Player player,
                const ISets_Ptr sets ) const override;
>>>>>>> Update from private repository
        };
    };
};
