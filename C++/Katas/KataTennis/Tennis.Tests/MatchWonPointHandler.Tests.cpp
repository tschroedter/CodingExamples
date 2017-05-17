#include "stdafx.h"
#include <gtest/gtest.h>
#include "Match.h"
#include "MockISets.h"
#include "MockIMatchCounter.h"
#include "MockITieBreak.h"
#include "MatchWonPointHandler.h"
#include "MockISet.h"

void won_point_calls_sets_for_given_status_n_times (
    Tennis::Logic::SetStatus status,
    int get_current_item_n_times,
    int won_point_n_times,
    int new_set_n_times )
{
    using namespace Tennis::Logic;

    // Arrange
    MockISet* mock_set = new MockISet{};
    ISet_Ptr set ( mock_set );
    MockISets* mock_sets = new MockISets{};
    ISets_Ptr sets ( mock_sets );

    MatchWonPointHandler sut {};

    sut.initialize ( sets );

    // Assert
    EXPECT_CALL(*mock_sets,
        get_current_set())
                          .Times ( get_current_item_n_times )
                          .WillRepeatedly ( testing::Return ( set ) );

    EXPECT_CALL(*mock_sets,
        create_new_set())
                         .Times ( new_set_n_times )
                         .WillRepeatedly ( testing::Return ( set ) );

    EXPECT_CALL(*mock_set,
        get_status())
                     .Times ( 1 )
                     .WillRepeatedly ( testing::Return ( status ) );

    EXPECT_CALL(*mock_set,
        won_point(One))
                       .Times ( won_point_n_times );

    // Act
    sut.won_point ( One );
}

TEST(MatchWonPointHandler, won_point_calls_sets_for_status_InProgress)
{
    won_point_calls_sets_for_given_status_n_times (
                                                   Tennis::Logic::SetStatus_InProgress,
                                                   1,
                                                   1,
                                                   0 );
}

TEST(MatchWonPointHandler, won_point_calls_sets_for_status_NotStarted)
{
    won_point_calls_sets_for_given_status_n_times (
                                                   Tennis::Logic::SetStatus_NotStarted,
                                                   1,
                                                   1,
                                                   0 );
}

TEST(MatchWonPointHandler, won_point_calls_sets_for_status_PlayerOneWon)
{
    won_point_calls_sets_for_given_status_n_times (
                                                   Tennis::Logic::SetStatus_PlayerOneWon,
                                                   1,
                                                   1,
                                                   1 );
}

TEST(MatchWonPointHandler, won_point_calls_sets_for_status_PlayerTwoWon)
{
    won_point_calls_sets_for_given_status_n_times (
                                                   Tennis::Logic::SetStatus_PlayerTwoWon,
                                                   1,
                                                   1,
                                                   1 );
}

TEST(MatchWonPointHandler, won_point_calls_sets_for_status_InTieBreak_PlayerOneWon)
{
    using namespace Tennis::Logic;

    // Arrange
    MockISet* mock_set = new MockISet();
    ISet_Ptr set { mock_set };
    MockISets* mock_sets = new MockISets{};
    ISets_Ptr sets ( mock_sets );

    MatchWonPointHandler sut {};

    sut.initialize ( sets );

    // Assert
    EXPECT_CALL(*mock_set,
        get_tie_break_status())
                               .Times ( 1 )
                               .WillOnce ( testing::Return ( TieBreakStatus_PlayerOneWon ) );

    EXPECT_CALL(*mock_sets,
        get_current_set())
                          .Times ( 2 )
                          .WillRepeatedly ( testing::Return ( set ) );

    EXPECT_CALL(*mock_sets,
        create_new_set())
                         .Times ( 1 )
                         .WillOnce ( testing::Return ( set ) );

    EXPECT_CALL(*mock_set,
        get_status())
                     .Times ( 1 )
                     .WillOnce ( testing::Return ( SetStatus_InTieBreak ) );

    EXPECT_CALL(*mock_set,
        won_point(One))
                       .Times ( 1 );

    // Act
    sut.won_point ( One );
}

TEST(MatchWonPointHandler, won_point_calls_sets_for_status_InTieBreak_InProgress)
{
    using namespace Tennis::Logic;

    // Arrange
    MockISet* mock_set = new MockISet();
    ISet_Ptr set { mock_set };
    MockISets* mock_sets = new MockISets{};
    ISets_Ptr sets ( mock_sets );

    MatchWonPointHandler sut {};

    sut.initialize ( sets );

    // Assert
    EXPECT_CALL(*mock_set,
        get_tie_break_status())
                               .Times ( 1 )
                               .WillOnce ( testing::Return ( TieBreakStatus_InProgress ) );

    EXPECT_CALL(*mock_sets,
        get_current_set())
                          .Times ( 2 )
                          .WillRepeatedly ( testing::Return ( set ) );

    EXPECT_CALL(*mock_set,
        get_status())
                     .Times ( 1 )
                     .WillOnce ( testing::Return ( SetStatus_InTieBreak ) );

    EXPECT_CALL(*mock_set,
        won_point(One))
                       .Times ( 1 );

    // Act
    sut.won_point ( One );
}
