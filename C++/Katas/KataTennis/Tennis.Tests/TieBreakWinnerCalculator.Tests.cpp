#include "stdafx.h"
#include <gtest/gtest.h>
#include "MockILogger.h"
#include "TieBreakWinnerCalculator.h"
#include "MockITieBreak.h"

void test_was_tie_break_won_by_player (
    Tennis::Logic::TieBreakStatus tie_break_status,
    Tennis::Logic::Player player,
    bool expected )
{
    using namespace Tennis::Logic;

    // Arrange
    MockITieBreak* mock_tie_break = new MockITieBreak();
    ITieBreak_Ptr tie_break ( mock_tie_break );

    TieBreakWinnerCalculator sut {};

    EXPECT_CALL(*mock_tie_break, get_status())
                                              .Times ( 1 )
                                              .WillRepeatedly ( testing::Return ( tie_break_status ) );

    // Act
    auto actual = sut.was_tie_break_won_by_player (
                                                   tie_break,
                                                   player );

    // Assert
    EXPECT_EQ(expected, actual);
}

TEST(TieBreakWinnerCalculator, was_tie_break_won_by_player_return_true_for_PlayerOneWon_and_asking_for_one)
{
    using namespace Tennis::Logic;

    test_was_tie_break_won_by_player (
                                      TieBreakStatus_PlayerOneWon,
                                      One,
                                      true );
}

TEST(TieBreakWinnerCalculator, was_tie_break_won_by_player_return_false_for_PlayerOneWon_and_asking_for_two)
{
    using namespace Tennis::Logic;

    test_was_tie_break_won_by_player (
                                      TieBreakStatus_PlayerOneWon,
                                      Two,
                                      false );
}

TEST(TieBreakWinnerCalculator, was_tie_break_won_by_player_return_true_for_PlayerTwoWon_and_asking_for_one)
{
    using namespace Tennis::Logic;

    test_was_tie_break_won_by_player (
                                      TieBreakStatus_PlayerTwoWon,
                                      One,
                                      false );
}

TEST(TieBreakWinnerCalculator, was_tie_break_won_by_player_return_true_for_PlayerTwoWon_and_asking_for_two)
{
    using namespace Tennis::Logic;

    test_was_tie_break_won_by_player (
                                      TieBreakStatus_PlayerTwoWon,
                                      Two,
                                      true );
}

TEST(TieBreakWinnerCalculator, was_tie_break_won_by_player_return_false_for_InProgress_and_asking_for_one)
{
    using namespace Tennis::Logic;

    test_was_tie_break_won_by_player (
                                      TieBreakStatus_InProgress,
                                      One,
                                      false );
}

TEST(TieBreakWinnerCalculator, was_tie_break_won_by_player_return_false_for_InProgress_and_asking_for_Two)
{
    using namespace Tennis::Logic;

    test_was_tie_break_won_by_player (
                                      TieBreakStatus_InProgress,
                                      Two,
                                      false );
}

TEST(TieBreakWinnerCalculator, was_tie_break_won_by_player_return_false_for_NotStarted_and_asking_for_one)
{
    using namespace Tennis::Logic;

    test_was_tie_break_won_by_player (
                                      TieBreakStatus_NotStarted,
                                      One,
                                      false );
}

TEST(TieBreakWinnerCalculator, was_tie_break_won_by_player_return_false_for_NotStarted_and_asking_for_Two)
{
    using namespace Tennis::Logic;

    test_was_tie_break_won_by_player (
                                      TieBreakStatus_NotStarted,
                                      Two,
                                      false );
}

TEST(TieBreakWinnerCalculator, was_tie_break_won_by_player_return_false_for_Max_and_asking_for_one)
{
    using namespace Tennis::Logic;

    test_was_tie_break_won_by_player (
                                      TieBreakStatus_GameStatus_Max,
                                      One,
                                      false );
}

TEST(TieBreakWinnerCalculator, was_tie_break_won_by_player_return_false_for_Max_and_asking_for_Two)
{
    using namespace Tennis::Logic;

    test_was_tie_break_won_by_player (
                                      TieBreakStatus_GameStatus_Max,
                                      Two,
                                      false );
}
