#include "include/GameStatusCalculator.h"
#include "include/Scores.h"

namespace Tennis
{
    namespace Logic
    {
        bool GameStatusCalculator::is_player_one_winner (
            Scores player_one,
            Scores player_two )
        {
            if ( Scores::AdvantageWon == player_one )
            {
                return true;
            }

            if ( Scores::Advantage == player_one )
            {
                if ( Scores::Thirty >= player_two )
                {
                    return true;
                }
            }

            return false;
        }

        bool GameStatusCalculator::has_player_one_won (
            Scores player_one,
            Scores player_two )
        {
            return is_player_one_winner (
                                         player_one,
                                         player_two );
        }

        bool GameStatusCalculator::has_player_two_won (
            Scores player_one,
            Scores player_two )
        {
            return is_player_one_winner (
                                         player_two,
                                         player_one );
        }

        GameStatus GameStatusCalculator::calculate (
            Scores score_one,
            Scores score_two )
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
