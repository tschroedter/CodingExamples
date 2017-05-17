#include "include/TieBreak.h"
#include "include/TieBreakStatusCalculator.h"
#include "include/PlayerException.h"

namespace Tennis
{
    namespace Logic
    {
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
