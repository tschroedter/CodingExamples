#pragma once

#include "Player.h"
#include "ISets.h"
<<<<<<< HEAD
=======
#include <cstdint>
#include <memory>
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
        class IMatchCounter
        {
        public:
<<<<<<< HEAD
            virtual ~IMatchCounter() = default;

            virtual int8_t count_sets_won_by_player(
                const Player player,
                const ISets* sets) const = 0;
        };
    };
};
=======
            virtual ~IMatchCounter () = default;

            virtual int8_t count_sets_won_by_player (
                const Player player,
                const ISets_Ptr sets ) const = 0;
        };

        typedef std::shared_ptr<IMatchCounter> IMatchCounter_Ptr;
    };
};
>>>>>>> Update from private repository
