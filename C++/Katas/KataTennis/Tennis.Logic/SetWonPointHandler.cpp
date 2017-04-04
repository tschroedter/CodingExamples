#include "include/SetWonPointHandler.h"
#include "include/Player.h"
#include "include/IGame.h"
#include "include/TieBreakStatus.h"
#include "include/IGames.h"

namespace Tennis
{
    namespace Logic
    {
        void SetWonPointHandler::won_game_point ( Player player ) const
        {
            IGame* m_current_game = m_games->get_current_game();

            m_current_game->won_point ( player );

            GameStatus game_status = m_current_game->get_status();

            if ( game_status == PlayerOneWon ||
                game_status == PlayerTwoWon )
            {
                m_games->new_game();
            }
        }

        void SetWonPointHandler::won_tie_break_point ( Player player ) const
        {
            TieBreakStatus tie_break_status = m_tie_break->get_status();

            if ( tie_break_status == NotStarted ||
                tie_break_status == InProgress )
            {
                m_tie_break->won_point ( player );
            }
        }

        bool SetWonPointHandler::is_tie_break_Required () const
        {
            int8_t count_games_for_player_one =
                    m_counter->count_games_for_player (
                                                       One,
                                                       m_games );

            int8_t count_games_for_player_two =
                    m_counter->count_games_for_player (
                                                       Two,
                                                       m_games );

            bool result =
                    count_games_for_player_one == MAX_GAME_SCORE &&
                    count_games_for_player_two == MAX_GAME_SCORE;

            return
                    result;
        }

        void SetWonPointHandler::won_point ( Player player ) const
        {
            // ReSharper disable once CppDefaultCaseNotHandledInSwitchStatement
            switch ( is_tie_break_Required() )
            {
                case WonGamePoint :
                    won_game_point ( player );
                    break;
                case WonTieBreakPoint :
                    won_tie_break_point ( player );
                    break;
            }
        }
    }
}
