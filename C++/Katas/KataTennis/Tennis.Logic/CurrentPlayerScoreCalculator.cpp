#include "include/Player.h"
#include "include/CurrentPlayerScoreCalculator.h"
#include <string>

namespace Tennis
{
    namespace Logic
    {
        std::string CurrentPlayerScoreCalculator::get_current_score_for_player (
            const Player player,
            const ISet_Ptr set ) const
        {
            if ( !set )
            {
                return "Unknown Set";
            }

            IGame_Ptr current_game = set->get_current_game();

            std::string scores_for_player =
                    current_game->get_score_for_player_as_string ( player );

            const ITieBreak_Ptr tie_break = set->get_tie_break();

            if ( tie_break->get_status() == TieBreakStatus_InProgress )
            {
                scores_for_player = std::to_string ( tie_break->get_score ( player ) );
                scores_for_player += "T";
            }

            std::string truncated = scores_for_player.substr ( 0,
                                                               REDUCE_TO_2_DIGITS );

            return truncated;
        }
    };
};
