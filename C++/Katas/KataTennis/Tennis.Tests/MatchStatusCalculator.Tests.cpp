#include "stdafx.h"
#include <gtest/gtest.h>
#include "Match.h"
#include "MockISets.h"
#include "MockIMatchCounter.h"
#include "MatchStatusCalculator.h"

TEST(MatchStatusCalculator, get_status_returns_NotStarted_for_no_sets)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIMatchCounter* mock_counter = new MockIMatchCounter();
<<<<<<< HEAD
    std::unique_ptr<IMatchCounter> counter ( mock_counter );

    MockISets* mock_sets = new MockISets();
    std::unique_ptr<ISets> sets ( mock_sets );

    MatchStatusCalculator sut {
        std::move ( counter ),
        sets.get(),
        RequiredSetsToWin_Two
    };

=======
    IMatchCounter_Ptr counter ( mock_counter );

    MockISets* mock_sets = new MockISets();
    ISets_Ptr sets ( mock_sets );

    MatchStatusCalculator sut {
        counter,
        RequiredSetsToWin_Two
    };

    sut.initialize ( sets );

>>>>>>> Update from private repository
    // Assert
    // Act
    MatchStatus actual = sut.get_status();
    EXPECT_EQ(MatchStatus_NotStarted, actual);
}

TEST(MatchStatusCalculator, get_status_returns_PlayerOneWon_for_player_one_won_required_sets)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIMatchCounter* mock_counter = new MockIMatchCounter();
<<<<<<< HEAD
    std::unique_ptr<IMatchCounter> counter ( mock_counter );

    MockISets* mock_sets = new MockISets();
    std::unique_ptr<ISets> sets ( mock_sets );
    mock_sets->mock_get_length_value = 1; // todo not nice, maybe to mocks required

    MatchStatusCalculator sut {
        std::move ( counter ),
        sets.get(),
        RequiredSetsToWin_Two
    };

    // Assert
    EXPECT_CALL(*mock_counter, count_sets_won_by_player(One, mock_sets))
                                                                        .Times ( 1 )
                                                                        .WillRepeatedly ( testing::Return ( 2 ) );

    EXPECT_CALL(*mock_counter, count_sets_won_by_player(Two, mock_sets))
                                                                        .Times ( 0 )
                                                                        .WillRepeatedly ( testing::Return ( 0 ) );
=======
    IMatchCounter_Ptr counter ( mock_counter );

    MockISets* mock_sets = new MockISets();
    ISets_Ptr sets ( mock_sets );

    MatchStatusCalculator sut {
        counter,
        RequiredSetsToWin_Two
    };

    sut.initialize ( sets );

    // Assert
    EXPECT_CALL(*mock_counter, count_sets_won_by_player(One, sets))
                                                                   .Times ( 1 )
                                                                   .WillRepeatedly ( testing::Return ( 2 ) );

    EXPECT_CALL(*mock_counter, count_sets_won_by_player(Two, sets))
                                                                   .Times ( 0 )
                                                                   .WillRepeatedly ( testing::Return ( 0 ) );

    EXPECT_CALL(*mock_sets, get_number_of_sets())
                                                 .Times ( 1 )
                                                 .WillRepeatedly ( testing::Return ( 1 ) );
>>>>>>> Update from private repository

    // Act
    MatchStatus actual = sut.get_status();
    EXPECT_EQ(MatchStatus_PlayerOneWon, actual);
}

TEST(MatchStatusCalculator, get_status_returns_PlayerTwoWon_for_player_two_won_required_sets)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIMatchCounter* mock_counter = new MockIMatchCounter();
<<<<<<< HEAD
    std::unique_ptr<IMatchCounter> counter ( mock_counter );

    MockISets* mock_sets = new MockISets();
    std::unique_ptr<ISets> sets ( mock_sets );
    mock_sets->mock_get_length_value = 1;

    MatchStatusCalculator sut {
        std::move ( counter ),
        sets.get(),
        RequiredSetsToWin_Two
    };

    // Assert
    EXPECT_CALL(*mock_counter, count_sets_won_by_player(One, mock_sets))
                                                                        .Times ( 1 )
                                                                        .WillRepeatedly ( testing::Return ( 0 ) );

    EXPECT_CALL(*mock_counter, count_sets_won_by_player(Two, mock_sets))
                                                                        .Times ( 1 )
                                                                        .WillRepeatedly ( testing::Return ( 2 ) );
=======
    IMatchCounter_Ptr counter ( mock_counter );

    MockISets* mock_sets = new MockISets();
    ISets_Ptr sets ( mock_sets );

    MatchStatusCalculator sut {
        counter,
        RequiredSetsToWin_Two
    };

    sut.initialize ( sets );

    // Assert
    EXPECT_CALL(*mock_counter, count_sets_won_by_player(One, sets))
                                                                   .Times ( 1 )
                                                                   .WillRepeatedly ( testing::Return ( 0 ) );

    EXPECT_CALL(*mock_counter, count_sets_won_by_player(Two, sets))
                                                                   .Times ( 1 )
                                                                   .WillRepeatedly ( testing::Return ( 2 ) );

    EXPECT_CALL(*mock_sets, get_number_of_sets())
                                                 .Times ( 1 )
                                                 .WillRepeatedly ( testing::Return ( 1 ) );
>>>>>>> Update from private repository

    // Act
    MatchStatus actual = sut.get_status();
    EXPECT_EQ(MatchStatus_PlayerTwoWon, actual);
}
<<<<<<< HEAD
=======

TEST(MatchStatusCalculator, set_required_sets_to_win_sets_required_sets)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIMatchCounter* mock_counter = new MockIMatchCounter();
    IMatchCounter_Ptr counter ( mock_counter );

    MockISets* mock_sets = new MockISets();
    ISets_Ptr sets ( mock_sets );

    MatchStatusCalculator sut {
        counter,
        RequiredSetsToWin_Two
    };

    sut.initialize ( sets );

    // Assert
    sut.set_required_sets_to_win ( RequiredSetsToWin_Three );

    // Act
    RequiredSetsToWin actual = sut.get_required_sets_to_win();
    EXPECT_EQ(RequiredSetsToWin_Three, actual);
}
>>>>>>> Update from private repository
