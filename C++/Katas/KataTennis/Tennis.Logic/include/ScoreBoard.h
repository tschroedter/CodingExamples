#pragma once
#include "IMatch.h"
#include "ISets.h"
#include "IPlayerNameManager.h"
#include "IGamesCounter.h"
#include "IScoresForPlayerCalculator.h"
#include "Match.h"
#include "IScoreboard.h"
#include <iostream>

namespace Tennis
{
    namespace Logic
    {
        class ScoreBoard
                : public IScoreBoard
        {
        private:
            const size_t PLAYER_NAME_MAX = 10;

            IScoresForPlayerCalculator_Ptr m_scores_for_player_calculator;
            IPlayerNameManager_Ptr m_manager;
            IGamesCounter_Ptr m_counter;
            ISets_Ptr m_sets;
            IMatch_Ptr m_match;

            void padTo(std::string& str, const size_t num, const char paddingChar = ' ') const;
            std::string get_player_name_to_display ( const Player player ) const;

        public:
            ScoreBoard (
                IScoresForPlayerCalculator_Ptr scores_for_player_calculator,
                IGamesCounter_Ptr counter )
                : m_scores_for_player_calculator ( scores_for_player_calculator )
                , m_counter ( counter )
                , m_match ( nullptr )
            {
            }

            void initialize ( 
                const ISets_Ptr sets,
                const IPlayerNameManager_Ptr manager) override;

            void print ( std::ostream& out = std::cout ) const override;

            std::string ScoreBoard::score_for_player_as_string ( const Player player ) const override;
        };
    };
};
