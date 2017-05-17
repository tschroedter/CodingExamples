#include "stdafx.h"
#include <gtest/gtest.h>
#include "CountPlayerGames.h"
#include "MockITieBreakWinnerCalculator.h"
#include "MockISet.h"
#include "MockITieBreak.h"
#include "MockIGames.h"
#include "MockIGamesCounter.h"

TEST(CountPlayerGames, get_games_count_for_player_returns_string_for_normal_set)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    IGamesCounter_Ptr counter ( mock_counter );
    MockITieBreakWinnerCalculator* mock_calculator = new MockITieBreakWinnerCalculator{};
    ITieBreakWinnerCalculator_Ptr calculator ( mock_calculator );

    CountPlayerGames sut {
        counter,
        calculator
    };

    EXPECT_CALL(*mock_counter,
        count_games_for_player(
            One,
            games))
                   .Times ( 1 )
                   .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    EXPECT_CALL(*mock_calculator,
        was_tie_break_won_by_player(
            tie_break,
            One))
                 .Times ( 1 )
                 .WillOnce ( testing::Return ( false ) );

    // Act
    auto actual = sut.count_games ( One,
                                    games,
                                    tie_break );

    // Assert
    EXPECT_EQ("6", actual);
}

TEST(CountPlayerGames, get_games_count_for_player_returns_string_for_tie_break_set)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    IGamesCounter_Ptr counter ( mock_counter );
    MockITieBreakWinnerCalculator* mock_calculator = new MockITieBreakWinnerCalculator{};
    ITieBreakWinnerCalculator_Ptr calculator ( mock_calculator );

    CountPlayerGames sut {
        counter,
        calculator,
    };

    EXPECT_CALL(*mock_counter,
        count_games_for_player(
            One,
            games))
                   .Times ( 1 )
                   .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    EXPECT_CALL(*mock_calculator,
        was_tie_break_won_by_player(
            tie_break,
            One))
                 .Times ( 1 )
                 .WillOnce ( testing::Return ( true ) );

    // Act
    auto actual = sut.count_games ( One,
                                    games,
                                    tie_break );

    // Assert
    EXPECT_EQ("7", actual);
}
