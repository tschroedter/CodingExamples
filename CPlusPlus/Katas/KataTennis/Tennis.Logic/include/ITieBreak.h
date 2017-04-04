#pragma once

#include "Player.h"
#include <cstdint>
#include "TieBreakStatus.h"

namespace Tennis
{
    namespace Logic
    {
        class ITieBreak
        {
        public:
            virtual ~ITieBreak () = default;

            virtual void won_point ( Player player ) = 0;
            virtual uint8_t get_score ( Player player ) const = 0;
            virtual TieBreakStatus get_status () const = 0;
        };
    }
}
