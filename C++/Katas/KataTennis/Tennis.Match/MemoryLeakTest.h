#pragma once
#include <memory>
#include "IMatch.h"
#include "MatchFactory.h"

namespace Tennis
{
    namespace Match
    {
        class MemoryLeakTest
        {
        private:
            const static size_t POINTS_PER_GAME = 4;
            static void player_on_wins_tie_break(Tennis::Logic::IMatch* match);
            static void print_status(Tennis::Logic::IMatch* match);
            static void create_games_won ( 
                Tennis::Logic::IMatch* match,
                Logic::Player two, 
                size_t games_scored_by_player_two );
            static void create_set_with_score(
                Tennis::Logic::IMatch* match,
                size_t games_scored_by_player_one,
                size_t games_scored_by_player_two);

        public:
            MemoryLeakTest()
            {
            }

            ~MemoryLeakTest()
            {
            }

            void run() const;
        };
    }
}
