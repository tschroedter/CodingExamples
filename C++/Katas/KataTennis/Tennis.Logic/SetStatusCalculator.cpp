#include "include/SetStatusCalculator.h"

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        bool SetStatusCalculator::has_score_one_won_set ( // todo continue here
            int8_t score_one,
            int8_t score_two )
=======
        bool SetStatusCalculator::has_score_one_won_set (
            const int8_t score_one,
            const int8_t score_two )
>>>>>>> Update from private repository
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
<<<<<<< HEAD
            Player player,
            int8_t games_for_player_one,
            int8_t games_for_player_two )
=======
            const Player player,
            const int8_t games_for_player_one,
            const int8_t games_for_player_two )
>>>>>>> Update from private repository
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
<<<<<<< HEAD
            int8_t games_for_player_one,
            int8_t games_for_player_two )
=======
            const int8_t games_for_player_one,
            const int8_t games_for_player_two )
>>>>>>> Update from private repository
        {
            return games_for_player_one == MAX_GAME_SCORE &&
                    games_for_player_two == MAX_GAME_SCORE;
        }

        bool SetStatusCalculator::is_in_progress (
<<<<<<< HEAD
            int8_t games_for_player_one,
            int8_t games_for_player_two )
=======
            const int8_t games_for_player_one,
            const int8_t games_for_player_two )
>>>>>>> Update from private repository
        {
            return games_for_player_one > 0 ||
                    games_for_player_two > 0;
        }

<<<<<<< HEAD
        const SetStatus SetStatusCalculator::get_status () const
        {
            int8_t games_for_player_one =
                    m_counter->count_games_for_player (
                                                       One,
                                                       m_games );

            int8_t games_for_player_two =
                    m_counter->count_games_for_player (
                                                       Two,
                                                       m_games );
=======
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
>>>>>>> Update from private repository

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
