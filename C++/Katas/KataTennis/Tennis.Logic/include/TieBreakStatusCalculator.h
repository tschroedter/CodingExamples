#pragma once

#include "ITieBreak.h"
#include "ITieBreakScore.h"

namespace Tennis
{
    namespace Logic
    {
        class TieBreakStatusCalculator
        {
        private:
            static bool TieBreakStatusCalculator::has_status_InProgress (
                const ITieBreakScore* score_one,
                const ITieBreakScore* score_two );
            static bool TieBreakStatusCalculator::has_status_NotStarted (
                const ITieBreakScore* score_one,
                const ITieBreakScore* score_two );
            static bool has_status_PlayerOneWon (
                const ITieBreakScore* player_one,
                const ITieBreakScore* player_two );

            static bool has_status_PlayerTwoWon (
                const ITieBreakScore* player_one,
                const ITieBreakScore* player_two );
        public:
            static TieBreakStatus calculate (
                const ITieBreakScore* score_one,
                const ITieBreakScore* score_two );
        };
    }
}
