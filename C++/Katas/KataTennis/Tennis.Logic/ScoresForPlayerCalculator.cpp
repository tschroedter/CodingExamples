#include "include/Player.h"
#include "include/ISet.h"
#include "include/ScoresForPlayerCalculator.h"
#include "include/ISets.h"

namespace Tennis
{
    namespace Logic
    {
        std::string ScoresForPlayerCalculator::get_scores_for_player (
            const Player player,
            const ISets_Ptr sets ) const
        {
            std::string text = "";

            size_t number_of_sets = sets->get_number_of_sets();

            for ( size_t i = 0 ; i < number_of_sets ; i++ )
            {
                ISet_Ptr set = sets->get_set_at_index ( i );

                std::string games_for_player =
                        m_count_player_games->count_games ( player,
                                                            set->get_games(),
                                                            set->get_tie_break() );

                if ( i != number_of_sets - 1 )
                {
                    text += games_for_player;
                    text += number_of_sets > 1 ? " " : "";
                }
                else
                {
                    std::string score_for_player =
                            m_current_player_score_calculator->get_current_score_for_player (
                                                                                             player,
                                                                                             set );

                    text +=
                            games_for_player
                            + " "
                            + score_for_player;
                }
            }

            return text;
        }
    }
}
