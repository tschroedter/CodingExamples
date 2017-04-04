#include "stdafx.h"
#include <gtest/gtest.h>
#include "Match.h"
#include "MockISets.h"
#include "MatchCounter.h"

TEST(MatchCounter, count_sets_won_by_player_returns_sets_won_by_player)
{
    using namespace Tennis::Logic;

    // Arrange
    MockISet* mock_set_one = new MockISet();
    std::unique_ptr<ISet> set_one { mock_set_one };

    MockISet* mock_set_two = new MockISet();
    std::unique_ptr<ISet> set_two { mock_set_two };

    MockISets* mock_sets = new MockISets();
    mock_sets->sets.clear();
    mock_sets->sets.push_back ( set_one.get() );
    mock_sets->sets.push_back ( set_two.get() );

    MatchCounter sut {};

    // Assert
    EXPECT_CALL(*mock_set_one, get_status())
                                            .Times ( 1 )
                                            .WillOnce ( testing::Return ( SetStatus_PlayerOneWon ) );

    EXPECT_CALL(*mock_set_two, get_status())
                                            .Times ( 1 )
                                            .WillOnce ( testing::Return ( SetStatus_PlayerOneWon ) );

    // Act
    int8_t actual = sut.count_sets_won_by_player (
                                                  One,
                                                  mock_sets );
    EXPECT_EQ(2, actual);
}

TEST(MatchCounter, count_sets_won_by_player_returns_sets_won_by_player_not_for_the_other_one)
{
    using namespace Tennis::Logic;

    // Arrange
    MockISet* mock_set_one = new MockISet();
    std::unique_ptr<ISet> set_one { mock_set_one };

    MockISet* mock_set_two = new MockISet();
    std::unique_ptr<ISet> set_two { mock_set_two };

    MockISets* mock_sets = new MockISets();
    mock_sets->sets.clear();
    mock_sets->sets.push_back ( set_one.get() );
    mock_sets->sets.push_back ( set_two.get() );

    MatchCounter sut {};

    // Assert
    EXPECT_CALL(*mock_set_one, get_status())
                                            .Times ( 1 )
                                            .WillOnce ( testing::Return ( SetStatus_PlayerOneWon ) );

    EXPECT_CALL(*mock_set_two, get_status())
                                            .Times ( 1 )
                                            .WillOnce ( testing::Return ( SetStatus_PlayerOneWon ) );

    // Act
    int8_t actual = sut.count_sets_won_by_player (
                                                  Two,
                                                  mock_sets );
    EXPECT_EQ(0, actual);
}
