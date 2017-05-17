#include "stdafx.h"
#include <gtest/gtest.h>
#include "ScoreBoard.h"
#include <gmock/gmock-generated-function-mockers.h>
#include "MockIGame.h"
#include "MockIPlayerNameManager.h"
#include "MockIGamesCounter.h"
#include "MockISets.h"
#include "MockIScoresForPlayerCalculator.h"

void test_score_for_player_as_string_with_different_player_names (
    const std::string player_name,
    const std::string expected )
{
    using namespace Tennis::Logic;

    // Arrange
    ISets_Ptr sets {};
    IScoresForPlayerCalculator_Ptr scores_for_player_calculator = std::make_shared<MockIScoresForPlayerCalculator>();
    MockIPlayerNameManager* mock_manager = new MockIPlayerNameManager{};
    IPlayerNameManager_Ptr manager ( mock_manager );
    IGamesCounter_Ptr counter = std::make_shared<MockIGamesCounter>();

    ScoreBoard sut
    {
        scores_for_player_calculator,
        counter
    };

    sut.initialize ( sets, manager );

    EXPECT_CALL(*mock_manager, get_player_name(One))
                                                    .Times ( 1 )
                                                    .WillOnce ( testing::Return ( player_name ) );

    // Act
    std::string actual = sut.score_for_player_as_string ( One );

    // Assert
    EXPECT_EQ(expected, actual);
}

TEST(ScoreBoard, score_for_player_as_string_returns_string_for_sets_is_null)
{
    test_score_for_player_as_string_with_different_player_names (
                                                                 "Player One",
                                                                 "Player One Unknown" );
}

TEST(ScoreBoard, score_for_player_as_string_returns_string_for_sets_with_fixed_length_for_short_player_name)
{
    test_score_for_player_as_string_with_different_player_names (
                                                                 "One",
                                                                 "One        Unknown" );
}

TEST(ScoreBoard, score_for_player_as_string_returns_string_for_sets_with_fixed_length_for_long_player_name)
{
    test_score_for_player_as_string_with_different_player_names (
                                                                 "01234567890123456789",
                                                                 "0123456789 Unknown" );
}

TEST(ScoreBoard, score_for_player_as_string_returns_string_for_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    ISets_Ptr sets = std::make_shared<MockISets>();

    MockIScoresForPlayerCalculator* mock_calculator = new MockIScoresForPlayerCalculator{};
    IScoresForPlayerCalculator_Ptr calculator ( mock_calculator );
    MockIPlayerNameManager* mock_manager = new MockIPlayerNameManager{};
    IPlayerNameManager_Ptr manager ( mock_manager );
    IGamesCounter_Ptr counter = std::make_shared<MockIGamesCounter>();

    ScoreBoard sut
    {
        calculator,
        counter
    };

    sut.initialize ( sets, manager );

    EXPECT_CALL(*mock_manager, get_player_name(One))
                                                    .Times ( 1 )
                                                    .WillOnce ( testing::Return ( "Player One" ) );

    EXPECT_CALL(*mock_calculator, get_scores_for_player(One, sets))
                                                                   .Times ( 1 )
                                                                   .WillOnce ( testing::Return ( "3 15" ) );

    // Act
    std::string actual = sut.score_for_player_as_string ( One );

    // Assert
    EXPECT_EQ("Player One 3 15", actual);
}
