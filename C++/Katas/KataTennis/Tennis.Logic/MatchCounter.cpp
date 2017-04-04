#include "include/MatchCounter.h"

namespace Tennis
{
    namespace Logic
    {
        int8_t MatchCounter::count_sets_won_by_player (
            const Player player,
            const ISets* sets ) const
        {
            SetStatus set_status =
                    One == player
                        ? SetStatus_PlayerOneWon
                        : SetStatus_PlayerTwoWon;

            int8_t counter = 0;

            size_t number_of_sets = sets->get_length();

            for ( size_t i = 0 ; i < number_of_sets ; i++ )
            {
                ISet* set = ( *sets ) [ i ]; // todo should be set.game[i], mock access []

                if ( set_status == set->get_status() )
                {
                    counter++;
                }
            }

            return counter;
        }
    };
};
