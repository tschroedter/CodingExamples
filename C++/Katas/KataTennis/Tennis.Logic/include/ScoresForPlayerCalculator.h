#pragma once

#pragma once
#include "IScoresForPlayerCalculator.h"
#include "Player.h"
#include "ICountPlayerGames.h"
#include "ICurrentPlayerScoreCalculator.h"

namespace Tennis
{
    namespace Logic
    {
        class ISets;

        class ScoresForPlayerCalculator
                : public IScoresForPlayerCalculator
        {
        private:
            ICurrentPlayerScoreCalculator_Ptr m_current_player_score_calculator;
            ICountPlayerGames_Ptr m_count_player_games;

        public:
            ScoresForPlayerCalculator (
                ICurrentPlayerScoreCalculator_Ptr current_player_score_calculator,
                ICountPlayerGames_Ptr count_player_games )
                : m_current_player_score_calculator ( current_player_score_calculator )
                , m_count_player_games ( count_player_games )
            {
            }

            std::string get_scores_for_player (
                const Player player,
                const ISets_Ptr sets ) const override;
        };
    }
}
