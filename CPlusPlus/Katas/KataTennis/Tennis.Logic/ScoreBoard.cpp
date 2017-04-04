#include "include/Player.h"
#include "include/IGame.h"
#include "include/ScoreBoard.h"
#include <iostream>

namespace Tennis
{
    namespace Logic
    {
        // todo class too complex
        // todo maybe use IMatch as parameter so we can avoid printing 0 current score when Match was won
        bool ScoreBoard::was_tie_break_won_by_player ( // todo testing
            const ITieBreak* tie_break,
            Player player )
        {
            if ( tie_break )
            {
                TieBreakStatus tie_break_status = tie_break->get_status();

                switch ( tie_break_status )
                {
                    case TieBreakStatus_PlayerOneWon :
                        if ( player == One )
                        {
                            return true;
                        }
                        break;
                    case TieBreakStatus_PlayerTwoWon :
                        if ( player == Two )
                        {
                            return true;
                        }
                        break;
                    case TieBreakStatus_InProgress :
                    case TieBreakStatus_NotStarted :
                    case TieBreakStatus_GameStatus_Max :
                        return false;
                    default :
                        return false;
                }
            }

            return false;
        }

        std::string ScoreBoard::reduceTwo2Digits ( std::string scores_for_player_one )
        {
            return scores_for_player_one.substr ( 0, 2 );
        }

        std::string ScoreBoard::get_games_count_for_player (
            Player player,
            ISet* set ) const
        {
            int8_t count_games_for_player =
                    m_counter->count_games_for_player (
                                                       player,
                                                       set->get_games() );

            const ITieBreak* tie_break = set->get_tie_break();

            if ( was_tie_break_won_by_player ( tie_break, player ) ) // todo testing
            {
                count_games_for_player++;
            }

            return std::to_string ( count_games_for_player );
        }

        std::string ScoreBoard::get_current_score_for_player (
            Player player,
            ISet* set ) const // todo defensive programming check for null
        {
            if ( !set )
            {
                return "Unknown Set";
            }

            IGame* current_game = set->get_current_game();

            std::string scores_for_player =
                    current_game->get_score_for_player_as_string ( player );

            const ITieBreak* tie_break = set->get_tie_break();

            if ( tie_break->get_status() == TieBreakStatus_InProgress )
            {
                scores_for_player = std::to_string ( tie_break->get_score ( player ) ); // todo testing
                scores_for_player += "T";
            }

            std::string truncated = reduceTwo2Digits ( scores_for_player );

            return truncated;
        }

        std::string ScoreBoard::score_for_player_as_string ( const Player player ) const
        {
            if ( !m_sets )
            {
                return "Unknown Sets";
            }

            std::string total_score = m_manager->get_player_name ( player );

            size_t number_of_sets = m_sets->get_length();

            for ( size_t i = 0 ; i < number_of_sets ; i++ )
            {
                ISet* set = ( *m_sets ) [ i ];

                std::string games_for_player =
                        get_games_count_for_player (
                                                    player,
                                                    set );

                if ( i != number_of_sets - 1 )
                {
                    total_score += " " + games_for_player;
                }
                else
                {
                    std::string score_for_player =
                            get_current_score_for_player (
                                                          player,
                                                          set );

                    total_score +=
                            " "
                            + games_for_player
                            + " "
                            + score_for_player;
                }
            }

            return total_score;
        }

        void ScoreBoard::print ( std::ostream& out ) const
        {
            out << score_for_player_as_string ( One ) << '\n';
            out << score_for_player_as_string ( Two ) << '\n';
        }
    };
};
