#include "include/SetStatusCalculator.h"

namespace Tennis
{
    namespace Logic
    {
        bool SetStatusCalculator::has_score_one_won_set (
            const int8_t score_one,
            const int8_t score_two )
        {
            if ( score_one == MAX_GAME_SCORE &&
                score_two <= MAX_GAME_SCORE - 2 )
            {
                return true;
            }

            if ( score_one == WON_TIE_BREAK_SCORE &&
                score_two == MAX_GAME_SCORE )
            {
                return true;
            }

            return false;
        }

        bool SetStatusCalculator::has_player_won_set (
            const Player player,
            const int8_t games_for_player_one,
            const int8_t games_for_player_two )
        {
            bool has_player_one_won = has_score_one_won_set ( games_for_player_one,
                                                              games_for_player_two );

            if ( has_player_one_won && player == One )
            {
                return true;
            }

            bool has_player_two_won = has_score_one_won_set ( games_for_player_two,
                                                              games_for_player_one );

            if ( has_player_two_won && player == Two )
            {
                return true;
            }

            return false;
        }

        bool SetStatusCalculator::is_in_tie_break (
            const int8_t games_for_player_one,
            const int8_t games_for_player_two )
        {
            return games_for_player_one == MAX_GAME_SCORE &&
                    games_for_player_two == MAX_GAME_SCORE;
        }

        bool SetStatusCalculator::is_in_progress (
            const int8_t games_for_player_one,
            const int8_t games_for_player_two )
        {
            return games_for_player_one > 0 ||
                    games_for_player_two > 0;
        }

        const SetStatus SetStatusCalculator::get_status (
            const IGames_Ptr games,
            const ITieBreak_Ptr tie_break ) const
        {
            int8_t games_for_player_one =
                    m_counter->calculate_games (
                                                One,
                                                games,
                                                tie_break );

            int8_t games_for_player_two =
                    m_counter->calculate_games (
                                                Two,
                                                games,
                                                tie_break );

            if ( has_player_won_set ( One,
                                      games_for_player_one,
                                      games_for_player_two ) )
            {
                return SetStatus_PlayerOneWon;
            }

            if ( has_player_won_set ( Two,
                                      games_for_player_one,
                                      games_for_player_two ) )
            {
                return SetStatus_PlayerTwoWon;
            }

            if ( is_in_tie_break ( games_for_player_one,
                                   games_for_player_two ) )
            {
                return SetStatus_InTieBreak;
            }

            if ( is_in_progress ( games_for_player_one,
                                  games_for_player_two ) )
            {
                return SetStatus_InProgress;
            }

            return SetStatus_NotStarted;
        }
    };
};
