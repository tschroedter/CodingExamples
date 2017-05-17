#include "include/TieBreakStatusCalculator.h"

namespace Tennis
{
    namespace Logic
    {
        bool TieBreakStatusCalculator::has_status_InProgress (
            const ITieBreakScore* score_one,
            const ITieBreakScore* score_two )
        {
            return score_one->get_score() + score_two->get_score() > 0;
        }

        bool TieBreakStatusCalculator::has_status_NotStarted (
            const ITieBreakScore* score_one,
            const ITieBreakScore* score_two )
        {
            return score_one->get_score() == 0 &&
                    score_two->get_score() == 0;
        }

        bool TieBreakStatusCalculator::has_status_PlayerOneWon (
            const ITieBreakScore* score_one,
            const ITieBreakScore* score_two )
        {
            return ( score_one->get_score() >= 7 &&
                ( score_one->get_score() - score_two->get_score() ) >= 2 );
        }

        bool TieBreakStatusCalculator::has_status_PlayerTwoWon (
            const ITieBreakScore* score_one,
            const ITieBreakScore* score_two )
        {
            return ( score_two->get_score() >= 7 &&
                ( score_two->get_score() - score_one->get_score() ) >= 2 );
        }

        TieBreakStatus TieBreakStatusCalculator::calculate (
            const ITieBreakScore* score_one,
            const ITieBreakScore* score_two )
        {
            if ( has_status_NotStarted ( score_one, score_two ) )
            {
                return TieBreakStatus_NotStarted;
            }

            if ( has_status_PlayerOneWon ( score_one, score_two ) )
            {
                return TieBreakStatus_PlayerOneWon;
            }

            if ( has_status_PlayerTwoWon ( score_one, score_two ) )
            {
                return TieBreakStatus_PlayerTwoWon;
            }

            if ( has_status_InProgress ( score_one, score_two ) )
            {
                return TieBreakStatus_InProgress;
            }

            return TieBreakStatus_NotStarted;
        }
    };
};
