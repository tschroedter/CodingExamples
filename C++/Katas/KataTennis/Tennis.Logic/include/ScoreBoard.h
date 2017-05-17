#pragma once
<<<<<<< HEAD
#include <string>
#include "include/ISet.h"
#include "include/GamesCounter.h"
#include "include/PlayerNameManager.h"
#include "IMatch.h"
#include "ISets.h"
=======
#include "IMatch.h"
#include "ISets.h"
#include "IPlayerNameManager.h"
#include "IGamesCounter.h"
#include "IScoresForPlayerCalculator.h"
#include "Match.h"
#include "IScoreboard.h"
#include <iostream>
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
        class ScoreBoard
<<<<<<< HEAD
        {
        private:
            IPlayerNameManager* m_manager;
            IGamesCounter* m_counter;
            ISets* m_sets;
            IMatch* m_match;

            static std::string reduceTwo2Digits ( std::string scores_for_player_one );
            std::string ScoreBoard::get_games_count_for_player(
                Player player,
                ISet* set) const;
            std::string ScoreBoard::get_current_score_for_player(
                Player player,
                ISet* set) const;

        public:
            ScoreBoard (
                IPlayerNameManager* manager,
                IGamesCounter* counter,
                ISets* set )
                : m_manager ( manager )
                , m_counter ( counter )
                , m_sets ( set )
            {
            }

            void print ( std::ostream& out ) const;

            std::string ScoreBoard::score_for_player_as_string ( 
                const Player player) const;

            static bool ScoreBoard::was_tie_break_won_by_player ( 
                const ITieBreak* tie_break, 
                const Player player );
=======
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
>>>>>>> Update from private repository
        };
    };
};
