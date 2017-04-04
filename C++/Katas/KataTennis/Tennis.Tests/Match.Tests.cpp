#include "stdafx.h"
#include <gtest/gtest.h>
#include "Match.h"
#include "MockISets.h"
#include "MockIMatchCounter.h"
#include "MockIMatchStatusCalculator.h"
#include "MockITieBreak.h"
#include "MockIMatchWonPointHandler.h"

TEST(Match, constructor_sets_required_sets_to_win)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIMatchWonPointHandler* mock_handler = new MockIMatchWonPointHandler();
    std::unique_ptr<IMatchWonPointHandler> handler ( mock_handler );

    MockIMatchStatusCalculator* mock_calculator = new MockIMatchStatusCalculator();
    std::unique_ptr<IMatchStatusCalculator> calculator ( mock_calculator );

    MockISets* mock_sets = new MockISets();
    std::unique_ptr<ISets> sets ( mock_sets );

    Match sut {
        std::move ( handler ),
        std::move ( calculator ),
        std::move ( sets ),
        RequiredSetsToWin_Two
    };

    // Act
    RequiredSetsToWin actual = sut.get_required_sets_to_win();

    // Assert
    EXPECT_EQ(RequiredSetsToWin_Two, actual);
}

TEST(Match, initialize_calls_sets)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIMatchWonPointHandler* mock_handler = new MockIMatchWonPointHandler();
    std::unique_ptr<IMatchWonPointHandler> handler ( mock_handler );

    MockIMatchStatusCalculator* mock_calculator = new MockIMatchStatusCalculator();
    std::unique_ptr<IMatchStatusCalculator> calculator ( mock_calculator );

    MockISets* mock_sets = new MockISets();
    std::unique_ptr<ISets> sets ( mock_sets );

    Match sut {
        std::move ( handler ),
        std::move ( calculator ),
        std::move ( sets ),
        RequiredSetsToWin_Two
    };

    // Assert
    EXPECT_CALL(*mock_sets, new_set())
                                      .Times ( 1 );

    // Act
    sut.initialize();
}

void won_point_calls_handler_for_given_status_n_times (
    Tennis::Logic::MatchStatus status,
    int won_point_n_times )
{
    using namespace Tennis::Logic;

    // Arrange
    MockITieBreak mock_tie_break {};

    MockIMatchWonPointHandler* mock_handler = new MockIMatchWonPointHandler();
    std::unique_ptr<IMatchWonPointHandler> handler ( mock_handler );

    MockIMatchStatusCalculator* mock_calculator = new MockIMatchStatusCalculator();
    std::unique_ptr<IMatchStatusCalculator> calculator ( mock_calculator );

    MockISet mock_set {};
    MockISets* mock_sets = new MockISets();
    std::unique_ptr<ISets> sets ( mock_sets );

    Match sut {
        std::move ( handler ),
        std::move ( calculator ),
        std::move ( sets ),
        RequiredSetsToWin_Two
    };

    // Assert
    EXPECT_CALL(*mock_calculator, get_status())
                                               .Times ( 1 )
                                               .WillRepeatedly ( testing::Return ( status ) );

    EXPECT_CALL(*mock_handler,
        won_point(One))
                       .Times ( won_point_n_times );

    // Act
    sut.won_point ( One );
}

TEST(Match, won_point_calls_handler_for_status_NotStarted)
{
    using namespace Tennis::Logic;

    won_point_calls_handler_for_given_status_n_times ( MatchStatus_NotStarted, 1 );
}

TEST(Match, won_point_calls_handler_for_status_InProgress)
{
    using namespace Tennis::Logic;

    won_point_calls_handler_for_given_status_n_times ( MatchStatus_InProgress, 1 );
}

TEST(Match, won_point_does_not_calls_handler_for_status_PlayerOneWon)
{
    using namespace Tennis::Logic;

    won_point_calls_handler_for_given_status_n_times ( MatchStatus_PlayerOneWon, 0 );
}

TEST(Match, won_point_does_not_calls_handler_for_status_Max)
{
    using namespace Tennis::Logic;

    won_point_calls_handler_for_given_status_n_times ( MatchStatus_Max, 0 );
}

TEST(Match, get_status_calls_calculator)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIMatchWonPointHandler* mock_handler = new MockIMatchWonPointHandler();
    std::unique_ptr<IMatchWonPointHandler> handler ( mock_handler );

    MockIMatchStatusCalculator* mock_calculator = new MockIMatchStatusCalculator();
    std::unique_ptr<IMatchStatusCalculator> calculator ( mock_calculator );

    MockISets* mock_sets = new MockISets();
    std::unique_ptr<ISets> sets ( mock_sets );
    mock_sets->mock_get_length_value = 1;

    Match sut {
        std::move ( handler ),
        std::move ( calculator ),
        std::move ( sets ),
        RequiredSetsToWin_Two
    };

    // Assert
    EXPECT_CALL(*mock_calculator, get_status())
                                               .Times ( 1 )
                                               .WillRepeatedly ( testing::Return ( MatchStatus_PlayerOneWon ) );

    // Act
    MatchStatus actual = sut.get_status();
    EXPECT_EQ(MatchStatus_PlayerOneWon, actual);
}
