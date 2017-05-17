#include "stdafx.h"
#include <gtest/gtest.h>
#include "TieBreakStatusCalculator.h"
#include "TieBreakScore.h"

<<<<<<< HEAD
TEST(TieBreakStatusCalculator, calculate_returns_default_NotStarted)
=======
void test_calculate (
    uint8_t tie_break_score_one,
    uint8_t tie_break_score_two,
    Tennis::Logic::TieBreakStatus expected )
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
<<<<<<< HEAD
    TieBreakScore score_one {};
    TieBreakScore score_two {};
=======
    TieBreakScore score_one { tie_break_score_one };
    TieBreakScore score_two { tie_break_score_two };
>>>>>>> Update from private repository

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
<<<<<<< HEAD
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
=======
    EXPECT_EQ(expected, actual);
}

TEST(TieBreakStatusCalculator, calculate_returns_default_NotStarted)
{
    using namespace Tennis::Logic;

    test_calculate (
                    0,
                    0,
                    TieBreakStatus_NotStarted
                   );
}

TEST(TieBreakStatusCalculator, calculate_returns_player_one_for_score_7_0)
{
    using namespace Tennis::Logic;

    test_calculate (
                    7,
                    0,
                    TieBreakStatus_PlayerOneWon
                   );
>>>>>>> Update from private repository
}

TEST(TieBreakStatusCalculator, calculate_returns_player_one_for_score_7_5)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    TieBreakScore score_one { 7 };
    TieBreakScore score_two { 5 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_PlayerOneWon, actual);
=======
    test_calculate (
                    7,
                    5,
                    TieBreakStatus_PlayerOneWon
                   );
>>>>>>> Update from private repository
}

TEST(TieBreakStatusCalculator, calculate_returns_player_one_for_score_8_6)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    TieBreakScore score_one { 8 };
    TieBreakScore score_two { 6 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_PlayerOneWon, actual);
=======
    test_calculate (
                    8,
                    6,
                    TieBreakStatus_PlayerOneWon
                   );
>>>>>>> Update from private repository
}

TEST(TieBreakStatusCalculator, calculate_returns_player_one_for_score_7_6)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    TieBreakScore score_one { 7 };
    TieBreakScore score_two { 6 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_InProgress, actual);
=======
    test_calculate (
                    7,
                    6,
                    TieBreakStatus_InProgress
                   );
>>>>>>> Update from private repository
}

TEST(TieBreakStatusCalculator, calculate_returns_player_one_for_score_6_6)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    TieBreakScore score_one { 6 };
    TieBreakScore score_two { 6 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_InProgress, actual);
=======
    test_calculate (
                    6,
                    6,
                    TieBreakStatus_InProgress
                   );
>>>>>>> Update from private repository
}

TEST(TieBreakStatusCalculator, calculate_returns_player_one_for_score_7_7)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    TieBreakScore score_one { 7 };
    TieBreakScore score_two { 7 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_InProgress, actual);
=======
    test_calculate (
                    7,
                    7,
                    TieBreakStatus_InProgress
                   );
>>>>>>> Update from private repository
}

TEST(TieBreakStatusCalculator, calculate_returns_player_two_for_score_0_7)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    TieBreakScore score_one {};
    TieBreakScore score_two { 7 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_PlayerTwoWon, actual);
=======
    test_calculate (
                    0,
                    7,
                    TieBreakStatus_PlayerTwoWon
                   );
>>>>>>> Update from private repository
}

TEST(TieBreakStatusCalculator, calculate_returns_player_two_for_score_5_7)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    TieBreakScore score_one { 5 };
    TieBreakScore score_two { 7 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_PlayerTwoWon, actual);
=======
    test_calculate (
                    5,
                    7,
                    TieBreakStatus_PlayerTwoWon
                   );
>>>>>>> Update from private repository
}

TEST(TieBreakStatusCalculator, calculate_returns_player_two_for_score_6_8)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    TieBreakScore score_one { 6 };
    TieBreakScore score_two { 8 };

    // Act
    auto actual = TieBreakStatusCalculator::calculate (
                                                       &score_one,
                                                       &score_two );

    // Assert
    EXPECT_EQ(TieBreakStatus_PlayerTwoWon, actual);
=======
    test_calculate (
                    6,
                    8,
                    TieBreakStatus_PlayerTwoWon
                   );
>>>>>>> Update from private repository
}
