#include "include/MatchWonPointHandler.h"
#include "include/SetStatusException.h"
#include <iostream>

namespace Tennis
{
    namespace Logic
    {
        bool MatchWonPointHandler::is_tie_break_finsihed () const
        {
            ISet_Ptr current_set = m_sets->get_current_set();

            TieBreakStatus tie_break_status =
                    current_set->get_tie_break_status();

            return tie_break_status == TieBreakStatus_PlayerOneWon ||
                    tie_break_status == TieBreakStatus_PlayerTwoWon;
        }

        void MatchWonPointHandler::create_new_set_and_call_won_point ( Player player ) const
        {
            ISet_Ptr set = m_sets->create_new_set();
            set->won_point ( player );
        }

        void MatchWonPointHandler::initialize ( ISets_Ptr sets )
        {
            m_sets = sets;
        }

        void MatchWonPointHandler::won_point ( const Player player )
        {
            ISet_Ptr current_set = m_sets->get_current_set();

            SetStatus status = current_set->get_status();

            switch ( status )
            {
                case SetStatus_InTieBreak :
                    is_tie_break_finsihed()
                        ? create_new_set_and_call_won_point ( player )
                        : current_set->won_point ( player );
                    break;
                case SetStatus_NotStarted :
                case SetStatus_InProgress :
                    current_set->won_point ( player );
                    break;
                case SetStatus_PlayerOneWon :
                case SetStatus_PlayerTwoWon :
                    create_new_set_and_call_won_point ( player );
                    break;
                default :
                    throw SetStatusException ( "Unknown SetStatus value " + std::to_string ( status ) + "!" );
            }
        }
    };
};
