#pragma once
#include <string>
#include "include/ISet.h"
#include "include/GamesCounter.h"
#include "include/PlayerNameManager.h"
#include "IMatch.h"
#include "ISets.h"

namespace Tennis
{
    namespace Logic
    {
        class ScoreBoard
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
        };
    };
};
