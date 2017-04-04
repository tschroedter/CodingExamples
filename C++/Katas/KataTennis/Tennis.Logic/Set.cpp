#include "include/Set.h"
#include "include/SetStatus.h"

namespace Tennis
{
    namespace Logic
    {
        void Set::won_point ( Player player )
        {
            m_handler->won_point( player );
        }

        IGame* Set::get_current_game () const
        {
            return m_games->get_current_game();
        }

        const IGames* Set::get_games () const
        {
            return m_games.get();
        }

        size_t Set::get_games_length () const
        {
            return m_games->get_length();
        }

        const ITieBreak* Set::get_tie_break () const
        {
            return m_tie_break.get();
        }

        const SetStatus Set::get_status() const
        {
            return m_calculator->get_status();
        }
    };
};
