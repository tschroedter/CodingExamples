#include "include/TieBreak.h"
#include "include/TieBreakStatusCalculator.h"

namespace Tennis
{
    namespace Logic
    {
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
