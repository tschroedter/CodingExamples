#include "stdafx.h"
#include <gtest/gtest.h>
#include "Match.h"
#include "MockISets.h"
#include "MatchCounter.h"
#include "MockISet.h"

TEST(MatchCounter, count_sets_won_by_player_returns_sets_won_by_player)
{
    using namespace Tennis::Logic;

    // Arrange
    MockISet* mock_set_one = new MockISet();
    ISet_Ptr set_one { mock_set_one };

    MockISet* mock_set_two = new MockISet();
    ISet_Ptr set_two { mock_set_two };

    MockISets* mock_sets = new MockISets();
    ISets_Ptr sets ( mock_sets );

    MatchCounter sut {};

    // Assert
    EXPECT_CALL(*mock_set_one, get_status())
                                            .Times ( 1 )
                                            .WillOnce ( testing::Return ( SetStatus_PlayerOneWon ) );

    EXPECT_CALL(*mock_set_two, get_status())
                                            .Times ( 1 )
                                            .WillOnce ( testing::Return ( SetStatus_PlayerOneWon ) );

    EXPECT_CALL(*mock_sets, get_number_of_sets())
                                                 .Times ( 1 )
                                                 .WillOnce ( testing::Return ( 2 ) );

    EXPECT_CALL(*mock_sets, get_set_at_index(0))
                                                .Times ( 1 )
                                                .WillOnce ( testing::Return ( set_one ) );

    EXPECT_CALL(*mock_sets, get_set_at_index(1))
                                                .Times ( 1 )
                                                .WillOnce ( testing::Return ( set_two ) );

    // Act
    int8_t actual = sut.count_sets_won_by_player (
                                                  One,
                                                  sets );
    EXPECT_EQ(2, actual);
}

TEST(MatchCounter, count_sets_won_by_player_returns_sets_won_by_player_not_for_the_other_one)
{
    using namespace Tennis::Logic;

    // Arrange
    MockISet* mock_set_one = new MockISet();
    ISet_Ptr set_one { mock_set_one };

    MockISet* mock_set_two = new MockISet();
    ISet_Ptr set_two { mock_set_two };

    MockISets* mock_sets = new MockISets();
    ISets_Ptr sets ( mock_sets );

    MatchCounter sut {};

    // Assert
    EXPECT_CALL(*mock_set_one, get_status())
                                            .Times ( 1 )
                                            .WillOnce ( testing::Return ( SetStatus_PlayerOneWon ) );

    EXPECT_CALL(*mock_set_two, get_status())
                                            .Times ( 1 )
                                            .WillOnce ( testing::Return ( SetStatus_PlayerOneWon ) );

    EXPECT_CALL(*mock_sets, get_number_of_sets())
                                                 .Times ( 1 )
                                                 .WillOnce ( testing::Return ( 2 ) );

    EXPECT_CALL(*mock_sets, get_set_at_index(0))
                                                .Times ( 1 )
                                                .WillOnce ( testing::Return ( set_one ) );

    EXPECT_CALL(*mock_sets, get_set_at_index(1))
                                                .Times ( 1 )
                                                .WillOnce ( testing::Return ( set_two ) );

    // Act
    int8_t actual = sut.count_sets_won_by_player (
                                                  Two,
                                                  sets );
    EXPECT_EQ(0, actual);
}
