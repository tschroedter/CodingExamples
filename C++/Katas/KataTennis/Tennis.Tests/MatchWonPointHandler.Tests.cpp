#include "stdafx.h"
#include <gtest/gtest.h>
#include "Match.h"
#include "MockISets.h"
#include "MockIMatchCounter.h"
#include "MockITieBreak.h"
#include "MatchWonPointHandler.h"

void won_point_calls_sets_for_given_status_n_times(
    Tennis::Logic::SetStatus status,
    int get_current_set_n_times,
    int won_point_n_times,
    int new_set_n_times)
{
    using namespace Tennis::Logic;

    // Arrange
    MockISet mock_set{};
    MockISets mock_sets{};

    MatchWonPointHandler sut{&mock_sets};

    // Assert
    EXPECT_CALL(mock_sets,
        get_current_set())
        .Times(get_current_set_n_times)
        .WillRepeatedly(testing::Return(&mock_set));

    EXPECT_CALL(mock_sets,
        new_set())
        .Times(new_set_n_times)
        .WillRepeatedly(testing::Return(&mock_set));

    EXPECT_CALL(mock_set,
        get_status())
        .Times(1)
        .WillRepeatedly(testing::Return(status));

    EXPECT_CALL(mock_set,
        won_point(One))
        .Times(won_point_n_times);

    // Act
    sut.won_point(One);
}

TEST(Match, won_point_calls_sets_for_status_InProgress)
{
    won_point_calls_sets_for_given_status_n_times(
        Tennis::Logic::SetStatus_InProgress,
        1,
        1,
        0);
}

TEST(Match, won_point_calls_sets_for_status_NotStarted)
{
    won_point_calls_sets_for_given_status_n_times(
        Tennis::Logic::SetStatus_NotStarted,
        1,
        1,
        0);
}

TEST(Match, won_point_calls_sets_for_status_PlayerOneWon)
{
    won_point_calls_sets_for_given_status_n_times(
        Tennis::Logic::SetStatus_PlayerOneWon,
        2,
        1,
        1);
}

TEST(Match, won_point_calls_sets_for_status_PlayerTwoWon)
{
    won_point_calls_sets_for_given_status_n_times(
        Tennis::Logic::SetStatus_PlayerTwoWon,
        2,
        1,
        1);
}

TEST(Match, won_point_calls_sets_for_status_InTieBreak_PlayerOneWon)
{
    using namespace Tennis::Logic;

    // Arrange
    MockITieBreak mock_tie_break{};
    MockISet mock_set{};
    MockISets mock_sets{};

    MatchWonPointHandler sut{ &mock_sets };


    // Assert
    EXPECT_CALL(mock_set,
        get_tie_break())
        .Times(1)
        .WillOnce(testing::Return(&mock_tie_break));

    EXPECT_CALL(mock_tie_break,
        get_status())
        .Times(1)
        .WillOnce(testing::Return(TieBreakStatus_PlayerOneWon));

    EXPECT_CALL(mock_sets,
        get_current_set())
        .Times(3)
        .WillRepeatedly(testing::Return(&mock_set));

    EXPECT_CALL(mock_sets,
        new_set())
        .Times(1)
        .WillOnce(testing::Return(&mock_set));

    EXPECT_CALL(mock_set,
        get_status())
        .Times(1)
        .WillOnce(testing::Return(SetStatus_InTieBreak));

    EXPECT_CALL(mock_set,
        won_point(One))
        .Times(1);

    // Act
    sut.won_point(One);
}

TEST(Match, won_point_calls_sets_for_status_InTieBreak_InProgress)
{
    using namespace Tennis::Logic;

    // Arrange
    MockITieBreak mock_tie_break{};

    MockISet mock_set{};
    MockISets mock_sets{};

    MatchWonPointHandler sut{ &mock_sets };

    // Assert
    EXPECT_CALL(mock_set,
        get_tie_break())
        .Times(1)
        .WillOnce(testing::Return(&mock_tie_break));

    EXPECT_CALL(mock_tie_break,
        get_status())
        .Times(1)
        .WillOnce(testing::Return(TieBreakStatus_InProgress));

    EXPECT_CALL(mock_sets,
        get_current_set())
        .Times(2)
        .WillRepeatedly(testing::Return(&mock_set));

    EXPECT_CALL(mock_set,
        get_status())
        .Times(1)
        .WillOnce(testing::Return(SetStatus_InTieBreak));

    EXPECT_CALL(mock_set,
        won_point(One))
        .Times(1);

    // Act
    sut.won_point(One);
}