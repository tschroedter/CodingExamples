#pragma once

#include "Player.h"
#include "ISets.h"
#include <cstdint>
#include <memory>

namespace Tennis
{
    namespace Logic
    {
        class IMatchCounter
        {
        public:
            virtual ~IMatchCounter () = default;

            virtual int8_t count_sets_won_by_player (
                const Player player,
                const ISets_Ptr sets ) const = 0;
        };

        typedef std::shared_ptr<IMatchCounter> IMatchCounter_Ptr;
    };
};
