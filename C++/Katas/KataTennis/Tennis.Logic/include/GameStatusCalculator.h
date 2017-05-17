#pragma once

#include "PossibleScores.h"
#include "GameStatus.h"

namespace Tennis
{
    namespace Logic
    {
        class GameStatusCalculator
        {
        private:
            static bool is_player_one_winner (
<<<<<<< HEAD
                Scores player_one,
                Scores player_two );

            static bool has_player_one_won (
                Scores player_one,
                Scores player_two );

            static bool has_player_two_won (
                Scores player_one,
                Scores player_two );

        public:
            static GameStatus calculate (
                Scores score_one,
                Scores score_two );
=======
                const Scores player_one,
                const Scores player_two );

            static bool has_player_one_won (
                const Scores player_one,
                const Scores player_two );

            static bool has_player_two_won (
                const Scores player_one,
                const Scores player_two );

        public:
            static GameStatus calculate (
                const Scores score_one,
                const Scores score_two );
>>>>>>> Update from private repository
        };
    };
};
