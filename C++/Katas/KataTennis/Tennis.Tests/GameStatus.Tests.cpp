#include "stdafx.h"
#include <gtest/gtest.h>
#include "GameStatusCalculator.h"
#include "PossibleScores.h"

void calculate_returns_status_for_given_scores (
    Tennis::Logic::Scores score_player_one,
    Tennis::Logic::Scores score_player_two,
    Tennis::Logic::GameStatus expected )
{
    using namespace Tennis::Logic;

    // Arrange
    GameStatusCalculator sut {};

    // Act
    GameStatus actual = sut.calculate (
                                       score_player_one,
                                       score_player_two );

    // Assert
    EXPECT_EQ(expected, actual);
}

// Player One

TEST(GameStatusCalculator, calculate_returns_PlayerOneWon_for_score_isAdvantageWon_to_Forty)
{
    using namespace Tennis::Logic;

    calculate_returns_status_for_given_scores (
                                               AdvantageWon,
                                               Forty,
                                               PlayerOneWon
                                              );
}

TEST(GameStatusCalculator, calculate_returns_PlayerOneWon_for_score_is_Advantage_to_Love)
{
    using namespace Tennis::Logic;

    calculate_returns_status_for_given_scores (
                                               Advantage,
                                               Love,
                                               PlayerOneWon
                                              );
}

TEST(GameStatusCalculator, calculate_returns_PlayerOneWon_for_score_is_Advantage_to_15)
{
    using namespace Tennis::Logic;

    calculate_returns_status_for_given_scores (
                                               Advantage,
                                               Fifteen,
                                               PlayerOneWon
                                              );
}

TEST(GameStatusCalculator, calculate_returns_PlayerOneWon_for_score_is_Advantage_to_30)
{
    using namespace Tennis::Logic;

    calculate_returns_status_for_given_scores (
                                               Advantage,
                                               Thirty,
                                               PlayerOneWon
                                              );
}

TEST(GameStatusCalculator, calculate_returns_AdvandtagePlayerOne_for_score_is_Advantage_to_Forty)
{
    using namespace Tennis::Logic;

    calculate_returns_status_for_given_scores (
                                               Advantage,
                                               Forty,
                                               AdvandtagePlayerOne
                                              );
}

TEST(GameStatusCalculator, calculate_returns_Deuce_for_score_is_Forty_to_Forty)
{
    using namespace Tennis::Logic;

    calculate_returns_status_for_given_scores (
                                               Forty,
                                               Forty,
                                               Deuce
                                              );
}

// Player Two

TEST(GameStatusCalculator, calculate_returns_PlayerTwoWon_for_score_is_Forty_to_AdvantageWon)
{
    using namespace Tennis::Logic;

    calculate_returns_status_for_given_scores (
                                               Forty,
                                               AdvantageWon,
                                               PlayerTwoWon
                                              );
}

TEST(GameStatusCalculator, calculate_returns_PlayerTwoWone_for_score_is_Love_to_Advantage)
{
    using namespace Tennis::Logic;

    calculate_returns_status_for_given_scores (
                                               Love,
                                               Advantage,
                                               PlayerTwoWon
                                              );
}

TEST(GameStatusCalculator, calculate_returns_PlayerTwoWon_for_score_is_15_to_Advantage)
{
    using namespace Tennis::Logic;

    calculate_returns_status_for_given_scores (
                                               Fifteen,
                                               Advantage,
                                               PlayerTwoWon
                                              );
}

TEST(GameStatusCalculator, calculate_returns_PlayerTwoWon_for_score_is_30_to_Advantage)
{
    using namespace Tennis::Logic;

    calculate_returns_status_for_given_scores (
                                               Thirty,
                                               Advantage,
                                               PlayerTwoWon
                                              );
}

TEST(GameStatusCalculator, calculate_returns_AdvandtagePlayerTwo_for_score_is_Forty_to_Advantage)
{
    using namespace Tennis::Logic;

    calculate_returns_status_for_given_scores (
                                               Forty,
                                               Advantage,
                                               AdvandtagePlayerTwo
                                              );
}
