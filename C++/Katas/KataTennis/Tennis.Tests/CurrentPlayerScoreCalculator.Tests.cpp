#include "stdafx.h"
#include <gtest/gtest.h>
#include "ScoreBoard.h"
#include <gmock/gmock-generated-function-mockers.h>
#include <strstream>
#include "CurrentPlayerScoreCalculator.h"
#include "MockISet.h"
#include "MockIGame.h"
#include "MockITieBreak.h"

TEST(CurrentPlayerScoreCalculator, get_current_score_for_player_returns_string_for_normal_score)
{
    using namespace Tennis::Logic;

    // Arrange
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGame* mock_game = new MockIGame{};
    IGame_Ptr game ( mock_game );
    MockISet* mock_set = new MockISet{};
    ISet_Ptr set ( mock_set );

    CurrentPlayerScoreCalculator sut {};

    EXPECT_CALL(*mock_set,
        get_current_game())
                           .Times ( 1 )
                           .WillOnce ( testing::Return ( game ) );

    EXPECT_CALL(*mock_game,
        get_score_for_player_as_string(One))
                                            .Times ( 1 )
                                            .WillOnce ( testing::Return ( "15" ) );

    EXPECT_CALL(*mock_set,
        get_tie_break())
                        .Times ( 1 )
                        .WillOnce ( testing::Return ( tie_break ) );

    EXPECT_CALL(*mock_tie_break,
        get_status())
                     .Times ( 1 )
                     .WillOnce ( testing::Return ( TieBreakStatus_NotStarted ) );

    // Act
    std::string actual = sut.get_current_score_for_player ( One,
                                                            set );

    // Assert
    EXPECT_EQ("15", actual);
}

TEST(CurrentPlayerScoreCalculator, get_current_score_for_player_returns_string_for_tie_break_score)
{
    using namespace Tennis::Logic;

    // Arrange
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGame* mock_game = new MockIGame{};
    IGame_Ptr game ( mock_game );
    MockISet* mock_set = new MockISet{};
    ISet_Ptr set ( mock_set );

    CurrentPlayerScoreCalculator sut {};

    EXPECT_CALL(*mock_set,
        get_current_game())
                           .Times ( 1 )
                           .WillOnce ( testing::Return ( game ) );

    EXPECT_CALL(*mock_game,
        get_score_for_player_as_string(One))
                                            .Times ( 1 )
                                            .WillOnce ( testing::Return ( "0" ) );

    EXPECT_CALL(*mock_set,
        get_tie_break())
                        .Times ( 1 )
                        .WillOnce ( testing::Return ( tie_break ) );

    EXPECT_CALL(*mock_tie_break,
        get_status())
                     .Times ( 1 )
                     .WillOnce ( testing::Return ( TieBreakStatus_InProgress ) );

    EXPECT_CALL(*mock_tie_break,
        get_score(One))
                       .Times ( 1 )
                       .WillOnce ( testing::Return ( 1 ) );

    // Act
    std::string actual = sut.get_current_score_for_player ( One,
                                                            set );

    // Assert
    EXPECT_EQ("1T", actual);
}
