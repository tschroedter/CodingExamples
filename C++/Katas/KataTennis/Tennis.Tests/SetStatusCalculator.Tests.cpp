#include "stdafx.h"
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "SetStatusCalculator.h"
#include <memory>
#include "MockIGames.h"
#include "MockIGamesCounterr.h"
#include "MockITieBreak.h"

void get_status_test_returned_status_for_given_score (
    Tennis::Logic::SetStatus exoected,
    int score_player_one,
    int score_player_two )
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetStatusCalculator sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    EXPECT_CALL(*mock_counter, count_games_for_player(One, &mock_games))
                                                                        .Times ( 1 )
                                                                        .WillOnce ( testing::Return ( static_cast<int8_t> ( score_player_one ) ) );

    EXPECT_CALL(*mock_counter, count_games_for_player(Two, &mock_games))
                                                                        .Times ( 1 )
                                                                        .WillOnce ( testing::Return ( static_cast<int8_t> ( score_player_two ) ) );

    // Act
    SetStatus actual = sut.get_status();

    // Assert
    EXPECT_EQ(exoected, actual);
}

TEST(SetStatusCalculator, get_status_returns_NotStarted_for_score_0_0)
{
    get_status_test_returned_status_for_given_score (
                                                     Tennis::Logic::SetStatus_NotStarted,
                                                     0,
                                                     0
                                                    );
}

TEST(SetStatusCalculator, get_status_returns_PlayerOneWon_for_score_6_4)
{
    get_status_test_returned_status_for_given_score (
                                                     Tennis::Logic::SetStatus_PlayerOneWon,
                                                     6,
                                                     4
                                                    );
}

TEST(SetStatusCalculator, get_status_returns_PlayerOneWon_for_score_7_6)
{
    get_status_test_returned_status_for_given_score (
                                                     Tennis::Logic::SetStatus_PlayerOneWon,
                                                     7,
                                                     6
                                                    );
}

TEST(SetStatusCalculator, get_status_returns_InProgress_for_score_6_5)
{
    get_status_test_returned_status_for_given_score (
                                                     Tennis::Logic::SetStatus_InProgress,
                                                     6,
                                                     5
                                                    );
}

TEST(SetStatusCalculator, get_status_returns_PlayerTwoWon_for_score_4_6)
{
    get_status_test_returned_status_for_given_score (
                                                     Tennis::Logic::SetStatus_PlayerTwoWon,
                                                     4,
                                                     6
                                                    );
}

TEST(SetStatusCalculator, get_status_returns_PlayerTwoWon_for_score_6_7)
{
    get_status_test_returned_status_for_given_score (
                                                     Tennis::Logic::SetStatus_PlayerTwoWon,
                                                     6,
                                                     7
                                                    );
}

TEST(SetStatusCalculator, get_status_returns_InProgress_for_score_5_6)
{
    get_status_test_returned_status_for_given_score (
                                                     Tennis::Logic::SetStatus_InProgress,
                                                     6,
                                                     5
                                                    );
}

TEST(SetStatusCalculator, get_status_returns_InTieBreak_for_score_6_6)
{
    get_status_test_returned_status_for_given_score (
                                                     Tennis::Logic::SetStatus_InTieBreak,
                                                     6,
                                                     6
                                                    );
}
