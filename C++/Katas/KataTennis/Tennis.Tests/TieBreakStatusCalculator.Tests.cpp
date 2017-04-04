#include "stdafx.h"
#include <gtest/gtest.h>
#include "TieBreakStatusCalculator.h"
#include "TieBreakScore.h"

TEST(TieBreakStatusCalculator, calculate_returns_default_NotStarted)
{
    using namespace Tennis::Logic;

    // Arrange
    TieBreakScore score_one {};
    TieBreakScore score_two {};

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_NotStarted, actual);
}

TEST(TieBreakStatusCalculator, calculate_returns_player_one_for_score_7_0)
{
    using namespace Tennis::Logic;

    // Arrange
    TieBreakScore score_one { 7 };
    TieBreakScore score_two {};

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_PlayerOneWon, actual);
}

TEST(TieBreakStatusCalculator, calculate_returns_player_one_for_score_7_5)
{
    using namespace Tennis::Logic;

    // Arrange
    TieBreakScore score_one { 7 };
    TieBreakScore score_two { 5 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_PlayerOneWon, actual);
}

TEST(TieBreakStatusCalculator, calculate_returns_player_one_for_score_8_6)
{
    using namespace Tennis::Logic;

    // Arrange
    TieBreakScore score_one { 8 };
    TieBreakScore score_two { 6 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_PlayerOneWon, actual);
}

TEST(TieBreakStatusCalculator, calculate_returns_player_one_for_score_7_6)
{
    using namespace Tennis::Logic;

    // Arrange
    TieBreakScore score_one { 7 };
    TieBreakScore score_two { 6 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_InProgress, actual);
}

TEST(TieBreakStatusCalculator, calculate_returns_player_one_for_score_6_6)
{
    using namespace Tennis::Logic;

    // Arrange
    TieBreakScore score_one { 6 };
    TieBreakScore score_two { 6 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_InProgress, actual);
}

TEST(TieBreakStatusCalculator, calculate_returns_player_one_for_score_7_7)
{
    using namespace Tennis::Logic;

    // Arrange
    TieBreakScore score_one { 7 };
    TieBreakScore score_two { 7 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_InProgress, actual);
}

TEST(TieBreakStatusCalculator, calculate_returns_player_two_for_score_0_7)
{
    using namespace Tennis::Logic;

    // Arrange
    TieBreakScore score_one {};
    TieBreakScore score_two { 7 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_PlayerTwoWon, actual);
}

TEST(TieBreakStatusCalculator, calculate_returns_player_two_for_score_5_7)
{
    using namespace Tennis::Logic;

    // Arrange
    TieBreakScore score_one { 5 };
    TieBreakScore score_two { 7 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_PlayerTwoWon, actual);
}

TEST(TieBreakStatusCalculator, calculate_returns_player_two_for_score_6_8)
{
    using namespace Tennis::Logic;

    // Arrange
    TieBreakScore score_one { 6 };
    TieBreakScore score_two { 8 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_PlayerTwoWon, actual);
}
