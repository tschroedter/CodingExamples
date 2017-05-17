#include "include/Player.h"
#include "include/GameStatus.h"
#include "include/Game.h"
#include "include/GameStatusCalculator.h"
#include "include/Scores.h"
#include <string>
#include "include/PlayerException.h"

namespace Tennis
{
    namespace Logic
    {
        bool Game::isDeuce (
            Scores player_one,
            Scores player_two )
        {
            return
                    player_one == Forty &&
                    player_two == Forty;
        }

        void Game::awardPoint ( const Player player ) const
        {
            m_award_points->award_point (
                                         player,
                                         m_score_player_one.get(),
                                         m_score_player_two.get() );
        }

        void Game::updateStatus ()
        {
            m_game_status =
                    GameStatusCalculator::calculate (
                                                     m_score_player_one->get_score(),
                                                     m_score_player_two->get_score() );
        }

        void Game::won_point ( const Player player )
        {
            awardPoint ( player );
            updateStatus();
        }

        GameStatus Game::get_status () const
        {
            return m_game_status;
        }

        Scores Game::get_score_for_player ( const Player player ) const
        {
            switch ( player )
            {
                case One :
                    return m_score_player_one->get_score();
                case Two :
                    return m_score_player_two->get_score();
                default :
                    throw PlayerException ( "Unknown Player type: " + std::to_string ( player ) );
            }
        }

        std::string Game::get_score_for_player_as_string ( const Player player ) const
        {
            switch ( player )
            {
                case One :
                    return m_score_player_one->to_string();
                case Two :
                    return m_score_player_two->to_string();
                default :
                    throw PlayerException ( "Unknown Player type: " + std::to_string ( player ) );
            }
        }
    };
};
