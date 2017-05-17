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
<<<<<<< HEAD
            m_sets->new_set();
        }

        void Match::won_point ( Player player )
        {
            auto status = get_status();
=======
            m_sets->create_new_set();

            m_calculator->initialize ( m_sets );
            m_handler->initialize ( m_sets );
        }

        void Match::won_point ( const Player player )
        {
            MatchStatus status = get_status();
>>>>>>> Update from private repository

            if ( status == MatchStatus_NotStarted ||
                status == MatchStatus_InProgress )
            {
                m_handler->won_point ( player );
            }
<<<<<<< HEAD
            // todo log error, match finished
=======
            else
            {
                m_logger->error ( "Match is finished!" );
            }
>>>>>>> Update from private repository
        }

        MatchStatus Match::get_status () const
        {
<<<<<<< HEAD
            return m_calculator->get_status(); // todo maybe better to use parameters
=======
            return m_calculator->get_status();
>>>>>>> Update from private repository
        }

        RequiredSetsToWin Match::get_required_sets_to_win () const
        {
            return m_required_sets_to_win;
        }

<<<<<<< HEAD
        ISets* Match::get_sets () const // todo not nice, scoreboard needs it
        {
            return m_sets.get();    // todo testing
=======
        ISets_Ptr Match::get_sets () const
        {
            return m_sets;
>>>>>>> Update from private repository
        }
    };
};
