#include "include/GameStatusCalculator.h"
#include "include/Scores.h"

namespace Tennis
{
    namespace Logic
    {
        bool GameStatusCalculator::is_player_one_winner (
            const Scores player_one,
            const Scores player_two )
        {
            if ( AdvantageWon == player_one )
            {
                return true;
            }

            if ( Advantage == player_one )
            {
                if ( Thirty >= player_two )
                {
                    return true;
                }
            }

            return false;
        }

        bool GameStatusCalculator::has_player_one_won (
            const Scores player_one,
            const Scores player_two )
        {
            return is_player_one_winner (
                                         player_one,
                                         player_two );
        }

        bool GameStatusCalculator::has_player_two_won (
            const Scores player_one,
            const Scores player_two )
        {
            return is_player_one_winner (
                                         player_two,
                                         player_one );
        }

        GameStatus GameStatusCalculator::calculate (
            const Scores score_one,
            const Scores score_two )
        {
            if ( is_player_one_winner (
                                       score_one,
                                       score_two ) )
            {
                return PlayerOneWon;
            }

            if ( is_player_one_winner (
                                       score_two,
                                       score_one ) )
            {
                return PlayerTwoWon;
            }

            if ( Forty == score_one &&
                Forty == score_two )
            {
                return Deuce;
            }

            if ( Advantage == score_one &&
                Forty == score_two )
            {
                return AdvandtagePlayerOne;
            }

            if ( Forty == score_one &&
                Advantage == score_two )
            {
                return AdvandtagePlayerTwo;
            }

            return InProgress;
        }
    };
};
