#include "include/Set.h"
#include "include/SetStatus.h"

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        void Set::won_point ( Player player )
        {
            m_handler->won_point( player );
        }

        IGame* Set::get_current_game () const
=======
        void Set::initialize ()
        {
            m_games->create_new_game();

            m_handler->intitialize ( m_games,
                                     m_tie_break );
        }

        void Set::won_point ( Player player )
        {
            m_handler->won_point ( player );
        }

        IGame_Ptr Set::get_current_game () const
>>>>>>> Update from private repository
        {
            return m_games->get_current_game();
        }

<<<<<<< HEAD
        const IGames* Set::get_games () const
        {
            return m_games.get();
=======
        const IGames_Ptr Set::get_games () const
        {
            return m_games;
>>>>>>> Update from private repository
        }

        size_t Set::get_games_length () const
        {
<<<<<<< HEAD
            return m_games->get_length();
        }

        const ITieBreak* Set::get_tie_break () const
        {
            return m_tie_break.get();
        }

        const SetStatus Set::get_status() const
        {
            return m_calculator->get_status();
=======
            return m_games->get_number_of_games();
        }

        const ITieBreak_Ptr Set::get_tie_break () const
        {
            return m_tie_break;
        }

        const SetStatus Set::get_status () const
        {
            return m_calculator->get_status ( m_games,
                                              m_tie_break );
        }

        const TieBreakStatus Set::get_tie_break_status () const
        {
            return m_tie_break->get_status();
>>>>>>> Update from private repository
        }
    };
};
