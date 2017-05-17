#pragma once
#include "Match.h"
#include "ScoreBoard.h"

namespace Tennis
{
    namespace Match
    {
        class MemoryLeakTest
        {
        private:
            const static size_t POINTS_PER_GAME = 4;
            static void player_on_wins_tie_break ( Logic::IMatch_Ptr match );
            static void print_status ( Logic::IMatch_Ptr match );
            static void create_games_won (
                Logic::IMatch_Ptr match,
                Logic::Player two,
                size_t games_scored_by_player_two );
            static void create_set_with_score (
                Logic::IMatch_Ptr match,
                size_t games_scored_by_player_one,
                size_t games_scored_by_player_two );

            Logic::IMatch_Ptr m_match;
            Logic::IScoreBoard_Ptr m_score_board;

        public:
            MemoryLeakTest (
                Logic::IMatch_Ptr match,
                Logic::IScoreBoard_Ptr score_board )
                : m_match ( match )
                , m_score_board ( score_board )
            {
            }

            ~MemoryLeakTest ()
            {
            }

            void run () const;
        };
    }
}
