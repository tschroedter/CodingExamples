#include "include/MatchStatus.h"
#include "include/Match.h"
#include "include/Player.h"
#include "include/RequiredSetsToWin.h"

namespace Tennis
{
    namespace Logic
    {
        void Match::initialize ()
        {
            m_sets->create_new_set();

            m_calculator->initialize ( m_sets );
            m_handler->initialize ( m_sets );
        }

        void Match::won_point ( const Player player )
        {
            MatchStatus status = get_status();

            if ( status == MatchStatus_NotStarted ||
                status == MatchStatus_InProgress )
            {
                m_handler->won_point ( player );
            }
            else
            {
                m_logger->error ( "Match is finished!" );
            }
        }

        MatchStatus Match::get_status () const
        {
            return m_calculator->get_status();
        }

        RequiredSetsToWin Match::get_required_sets_to_win () const
        {
            return m_required_sets_to_win;
        }

        ISets_Ptr Match::get_sets () const
        {
            return m_sets;
        }
    };
};
