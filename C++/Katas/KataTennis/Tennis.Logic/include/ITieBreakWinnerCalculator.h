#pragma once

#include "ITieBreak.h"
#include "Player.h"
#include <memory>

namespace Tennis
{
    namespace Logic
    {
        class ITieBreakWinnerCalculator
        {
        public:
            virtual ~ITieBreakWinnerCalculator () = default;

            virtual bool was_tie_break_won_by_player (
                const ITieBreak_Ptr tie_break,
                const Player player ) const = 0;
        };

        typedef std::shared_ptr<ITieBreakWinnerCalculator> ITieBreakWinnerCalculator_Ptr;
    };
};
