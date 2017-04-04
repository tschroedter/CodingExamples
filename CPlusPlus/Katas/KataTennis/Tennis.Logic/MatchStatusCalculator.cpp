#include "include/MatchStatus.h"
#include "include/MatchStatusCalculator.h"

namespace Tennis
{
    namespace Logic
    {
        const MatchStatus MatchStatusCalculator::get_status () const
        {
            if ( m_sets->get_length() == 0 )
            {
                return MatchStatus_NotStarted;
            }

            int8_t sets_won_by_player_one =
                    m_counter->count_sets_won_by_player (
                                                         One,
                                                         m_sets );

            if ( sets_won_by_player_one == m_required_sets_to_win ) // warning assumes that enum value is matching integer
            {
                return MatchStatus_PlayerOneWon;
            }

            int8_t sets_won_by_player_two =
                    m_counter->count_sets_won_by_player (
                                                         Two,
                                                         m_sets );

            if ( sets_won_by_player_two == m_required_sets_to_win ) // warning assumes that enum value is matching integer
            {
                return MatchStatus_PlayerTwoWon;
            }

            return MatchStatus_InProgress;
        }
    };
};
