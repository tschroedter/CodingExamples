#include "stdafx.h"
#include <gtest/gtest.h>
#include "GameStatusCalculator.h"
#include "PossibleScores.h"

<<<<<<< HEAD
// Player One

TEST(GameStatusCalculator, calculate_returns_PlayerOneWon_for_score_isAdvantageWon_to_Forty)
=======
void calculate_returns_status_for_given_scores (
    Tennis::Logic::Scores score_player_one,
    Tennis::Logic::Scores score_player_two,
    Tennis::Logic::GameStatus expected )
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
<<<<<<< HEAD
    Scores score_player_one;
    Scores score_player_two;

    score_player_one = AdvantageWon;
    score_player_two = Forty;

=======
>>>>>>> Update from private repository
    GameStatusCalculator sut {};

    // Act
    GameStatus actual = sut.calculate (
                                       score_player_one,
                                       score_player_two );

    // Assert
<<<<<<< HEAD
    EXPECT_EQ(GameStatus::PlayerOneWon, actual);
}

TEST(GameStatusCalculator, calculate_returns_PlayerOneWon_for_score_is_Advantage_to_Love)
{
    using namespace Tennis::Logic;

    // Arrange
    Scores score_player_one;
    Scores score_player_two;

    score_player_one = Advantage;
    score_player_two = Love;

    GameStatusCalculator sut {};

    // Act
    GameStatus actual = sut.calculate (
                                       score_player_one,
                                       score_player_two );

    // Assert
    EXPECT_EQ(GameStatus::PlayerOneWon, actual);
=======
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
>>>>>>> Update from private repository
}

TEST(GameStatusCalculator, calculate_returns_PlayerOneWon_for_score_is_Advantage_to_15)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    Scores score_player_one;
    Scores score_player_two;

    score_player_one = Advantage;
    score_player_two = Fifteen;

    GameStatusCalculator sut {};

    // Act
    GameStatus actual = sut.calculate (
                                       score_player_one,
                                       score_player_two );

    // Assert
    EXPECT_EQ(GameStatus::PlayerOneWon, actual);
=======
    calculate_returns_status_for_given_scores (
                                               Advantage,
                                               Fifteen,
                                               PlayerOneWon
                                              );
>>>>>>> Update from private repository
}

TEST(GameStatusCalculator, calculate_returns_PlayerOneWon_for_score_is_Advantage_to_30)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    Scores score_player_one;
    Scores score_player_two;

    score_player_one = Advantage;
    score_player_two = Thirty;

    GameStatusCalculator sut {};

    // Act
    GameStatus actual = sut.calculate (
                                       score_player_one,
                                       score_player_two );

    // Assert
    EXPECT_EQ(GameStatus::PlayerOneWon, actual);
=======
    calculate_returns_status_for_given_scores (
                                               Advantage,
                                               Thirty,
                                               PlayerOneWon
                                              );
>>>>>>> Update from private repository
}

TEST(GameStatusCalculator, calculate_returns_AdvandtagePlayerOne_for_score_is_Advantage_to_Forty)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    Scores score_player_one;
    Scores score_player_two;

    score_player_one = Advantage;
    score_player_two = Forty;

    GameStatusCalculator sut {};

    // Act
    GameStatus actual = sut.calculate (
                                       score_player_one,
                                       score_player_two );

    // Assert
    EXPECT_EQ(GameStatus::AdvandtagePlayerOne, actual);
=======
    calculate_returns_status_for_given_scores (
                                               Advantage,
                                               Forty,
                                               AdvandtagePlayerOne
                                              );
>>>>>>> Update from private repository
}

TEST(GameStatusCalculator, calculate_returns_Deuce_for_score_is_Forty_to_Forty)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    Scores score_player_one;
    Scores score_player_two;

    score_player_one = Forty;
    score_player_two = Forty;

    GameStatusCalculator sut {};

    // Act
    GameStatus actual = sut.calculate (
                                       score_player_one,
                                       score_player_two );

    // Assert
    EXPECT_EQ(GameStatus::Deuce, actual);
=======
    calculate_returns_status_for_given_scores (
                                               Forty,
                                               Forty,
                                               Deuce
                                              );
>>>>>>> Update from private repository
}

// Player Two

TEST(GameStatusCalculator, calculate_returns_PlayerTwoWon_for_score_is_Forty_to_AdvantageWon)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    Scores score_player_one;
    Scores score_player_two;

    score_player_one = Forty;
    score_player_two = AdvantageWon;

    GameStatusCalculator sut {};

    // Act
    GameStatus actual = sut.calculate (
                                       score_player_one,
                                       score_player_two );

    // Assert
    EXPECT_EQ(GameStatus::PlayerTwoWon, actual);
=======
    calculate_returns_status_for_given_scores (
                                               Forty,
                                               AdvantageWon,
                                               PlayerTwoWon
                                              );
>>>>>>> Update from private repository
}

TEST(GameStatusCalculator, calculate_returns_PlayerTwoWone_for_score_is_Love_to_Advantage)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    Scores score_player_one;
    Scores score_player_two;

    score_player_one = Love;
    score_player_two = Advantage;

    GameStatusCalculator sut {};

    // Act
    GameStatus actual = sut.calculate (
                                       score_player_one,
                                       score_player_two );

    // Assert
    EXPECT_EQ(GameStatus::PlayerTwoWon, actual);
=======
    calculate_returns_status_for_given_scores (
                                               Love,
                                               Advantage,
                                               PlayerTwoWon
                                              );
>>>>>>> Update from private repository
}

TEST(GameStatusCalculator, calculate_returns_PlayerTwoWon_for_score_is_15_to_Advantage)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    Scores score_player_one;
    Scores score_player_two;

    score_player_one = Fifteen;
    score_player_two = Advantage;

    GameStatusCalculator sut {};

    // Act
    GameStatus actual = sut.calculate (
                                       score_player_one,
                                       score_player_two );

    // Assert
    EXPECT_EQ(GameStatus::PlayerTwoWon, actual);
=======
    calculate_returns_status_for_given_scores (
                                               Fifteen,
                                               Advantage,
                                               PlayerTwoWon
                                              );
>>>>>>> Update from private repository
}

TEST(GameStatusCalculator, calculate_returns_PlayerTwoWon_for_score_is_30_to_Advantage)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    Scores score_player_one;
    Scores score_player_two;

    score_player_one = Thirty;
    score_player_two = Advantage;

    GameStatusCalculator sut {};

    // Act
    GameStatus actual = sut.calculate (
                                       score_player_one,
                                       score_player_two );

    // Assert
    EXPECT_EQ(GameStatus::PlayerTwoWon, actual);
=======
    calculate_returns_status_for_given_scores (
                                               Thirty,
                                               Advantage,
                                               PlayerTwoWon
                                              );
>>>>>>> Update from private repository
}

TEST(GameStatusCalculator, calculate_returns_AdvandtagePlayerTwo_for_score_is_Forty_to_Advantage)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    Scores score_player_one;
    Scores score_player_two;

    score_player_one = Forty;
    score_player_two = Advantage;

    GameStatusCalculator sut {};

    // Act
    GameStatus actual = sut.calculate (
                                       score_player_one,
                                       score_player_two );

    // Assert
    EXPECT_EQ(GameStatus::AdvandtagePlayerTwo, actual);
=======
    calculate_returns_status_for_given_scores (
                                               Forty,
                                               Advantage,
                                               AdvandtagePlayerTwo
                                              );
>>>>>>> Update from private repository
}
