#include "include/TieBreak.h"
#include "include/TieBreakStatusCalculator.h"
<<<<<<< HEAD
=======
#include "include/PlayerException.h"
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        void TieBreak::won_point ( Player player )
        {
            switch ( player )
            {
                case Player::One :
                    m_score_player_one->won_point();
                    break;
                case Player::Two :
                    m_score_player_two->won_point();
                    break;
                default :
                    m_logger->error ( "Unknown Player type: " + std::to_string ( player ) );
                    break;
            }
        }

        uint8_t TieBreak::get_score ( Player player ) const
        {
            switch ( player )
            {
                case Player::One :
                    return m_score_player_one->get_score();
                case Player::Two :
                    return m_score_player_two->get_score();
                default :
                    m_logger->error ( "Unknown Player type: " + std::to_string ( player ) );
                    return -1;
=======
        void TieBreak::won_point ( const Player player )
        {
            switch ( player )
            {
                case One :
                    m_score_player_one->won_point();
                    break;
                case Two :
                    m_score_player_two->won_point();
                    break;
                default :
                    throw PlayerException ( "Unknown Player type: " + std::to_string ( player ) );
            }
        }

        uint8_t TieBreak::get_score ( const Player player ) const
        {
            switch ( player )
            {
                case One :
                    return m_score_player_one->get_score();
                case Two :
                    return m_score_player_two->get_score();
                default :
                    throw PlayerException ( "Unknown Player type: " + std::to_string ( player ) );
>>>>>>> Update from private repository
            }
        }

        TieBreakStatus TieBreak::get_status () const
        {
            return TieBreakStatusCalculator::calculate (
                                                        m_score_player_one.get(),
                                                        m_score_player_two.get() );
        }
    };
};
