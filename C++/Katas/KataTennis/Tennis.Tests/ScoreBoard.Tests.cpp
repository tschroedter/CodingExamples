#include "stdafx.h"
#include <gtest/gtest.h>
#include "ScoreBoard.h"
#include <gmock/gmock-generated-function-mockers.h>
<<<<<<< HEAD
#include <strstream>
#include "MockIGame.h"
#include "MockIGames.h"
#include "MockIPlayerNameManager.h"
#include "MockIGamesCounterr.h"
#include "MockISet.h"
#include "MockITieBreak.h"
#include "MockISets.h"

TEST(ScoreBoard, score_for_player_as_string_returns_string_for_player_one)
=======
#include "MockIGame.h"
#include "MockIPlayerNameManager.h"
#include "MockIGamesCounter.h"
#include "MockISets.h"
#include "MockIScoresForPlayerCalculator.h"

void test_score_for_player_as_string_with_different_player_names (
    const std::string player_name,
    const std::string expected )
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
<<<<<<< HEAD
    MockITieBreak tie_break {};
    MockIGame game {};
    MockIGames games {};
    MockIPlayerNameManager manager {};
    MockIGamesCounter counter {};
    MockISet set {};
    MockISets sets {};
    sets.sets.push_back ( &set );

    ScoreBoard sut {
        &manager,
        &counter,
        &sets
    };

    // Assert
    EXPECT_CALL(manager, get_player_name(One))
                                              .Times ( 1 )
                                              .WillOnce ( testing::Return ( "Player One" ) );

    EXPECT_CALL(game, get_score_for_player_as_string(One))
                                                          .Times ( 1 )
                                                          .WillOnce ( testing::Return ( "15" ) );

    EXPECT_CALL(set, get_current_game())
                                        .Times ( 1 )
                                        .WillOnce ( testing::Return ( &game ) );

    EXPECT_CALL(set, get_games())
                                 .Times ( 1 )
                                 .WillOnce ( testing::Return ( &games ) );

    EXPECT_CALL(set, get_tie_break())
                                     .Times ( 2 )
                                     .WillRepeatedly ( testing::Return ( &tie_break ) );

    EXPECT_CALL(tie_break, get_status())
                                        .Times ( 2 )
                                        .WillRepeatedly ( testing::Return ( TieBreakStatus_NotStarted ) );

    EXPECT_CALL(
        counter,
        count_games_for_player(One,
            &games))
                    .Times ( 1 )
                    .WillOnce ( testing::Return ( 6 ) );
=======
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
>>>>>>> Update from private repository

    // Act
    std::string actual = sut.score_for_player_as_string ( One );

    // Assert
<<<<<<< HEAD
    EXPECT_EQ("Player One 6 15", actual);
}

TEST(ScoreBoard, score_for_player_as_string_returns_string_for_player_one_with_multiple_sets)
{
    using namespace Tennis::Logic;
    // todo huge Arrange code

    // Arrange
    MockITieBreak set_one_tie_break {};
    MockIGames set_one_games {};
    MockISet set_one {};

    MockITieBreak set_two_tie_break {};
    MockIGame set_two_game {};
    MockIGames set_two_games {};
    MockISet set_two {};

    MockISets sets {};
    sets.sets.push_back ( &set_one );
    sets.sets.push_back ( &set_two );

    MockIPlayerNameManager manager {};
    MockIGamesCounter counter {};

    ScoreBoard sut {
        &manager,
        &counter,
        &sets
    };

    // Assert
    EXPECT_CALL(manager, get_player_name(One))
                                              .Times ( 1 )
                                              .WillOnce ( testing::Return ( "Player One" ) );

    EXPECT_CALL(set_one, get_games())
                                     .Times ( 1 )
                                     .WillOnce ( testing::Return ( &set_one_games ) );

    EXPECT_CALL(set_one, get_tie_break())
                                         .Times ( 1 )
                                         .WillRepeatedly ( testing::Return ( &set_one_tie_break ) );

    EXPECT_CALL(set_one_tie_break, get_status())
                                                .Times ( 1 )
                                                .WillRepeatedly ( testing::Return ( TieBreakStatus_NotStarted ) );

    EXPECT_CALL(
        counter,
        count_games_for_player(One,
            &set_one_games))
                            .Times ( 1 )
                            .WillOnce ( testing::Return ( 6 ) );

    EXPECT_CALL(set_two_game, get_score_for_player_as_string(One))
                                                                  .Times ( 1 )
                                                                  .WillOnce ( testing::Return ( "15" ) );

    EXPECT_CALL(set_two, get_current_game())
                                            .Times ( 1 )
                                            .WillOnce ( testing::Return ( &set_two_game ) );

    EXPECT_CALL(set_two, get_games())
                                     .Times ( 1 )
                                     .WillOnce ( testing::Return ( &set_two_games ) );

    EXPECT_CALL(set_two, get_tie_break())
                                         .Times ( 2 )
                                         .WillRepeatedly ( testing::Return ( &set_two_tie_break ) );

    EXPECT_CALL(set_two_tie_break, get_status())
                                                .Times ( 2 )
                                                .WillRepeatedly ( testing::Return ( TieBreakStatus_NotStarted ) );

    EXPECT_CALL(
        counter,
        count_games_for_player(One,
            &set_two_games))
                            .Times ( 1 )
                            .WillOnce ( testing::Return ( 3 ) );

    // Act
    std::string actual = sut.score_for_player_as_string ( One );

    // Assert
    EXPECT_EQ("Player One 6 3 15", actual);
}

TEST(ScoreBoard, print_returns_string_for_players)
=======
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
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
<<<<<<< HEAD
    MockITieBreak tie_break {};
    MockIGame game {};
    MockIGames games {};
    MockIPlayerNameManager manager {};
    MockIGamesCounter counter {};
    MockISet set {};
    MockISets sets {};
    sets.sets.push_back ( &set );

    ScoreBoard sut {
        &manager,
        &counter,
        &sets
    };

    // Assert
    EXPECT_CALL(manager, get_player_name(One))
                                              .Times ( 1 )
                                              .WillOnce ( testing::Return ( "Player One" ) );

    EXPECT_CALL(manager, get_player_name(Two))
                                              .Times ( 1 )
                                              .WillOnce ( testing::Return ( "Player Two" ) );

    EXPECT_CALL(game, get_score_for_player_as_string(One))
                                                          .Times ( 1 )
                                                          .WillOnce ( testing::Return ( "15" ) );

    EXPECT_CALL(game, get_score_for_player_as_string(Two))
                                                          .Times ( 1 )
                                                          .WillOnce ( testing::Return ( "30" ) );

    EXPECT_CALL(set, get_current_game())
                                        .Times ( 2 )
                                        .WillRepeatedly ( testing::Return ( &game ) );

    EXPECT_CALL(set, get_games())
                                 .Times ( 2 )
                                 .WillRepeatedly ( testing::Return ( &games ) );

    EXPECT_CALL(tie_break, get_status())
                                        .Times ( 4 )
                                        .WillRepeatedly ( testing::Return ( TieBreakStatus_NotStarted ) );

    EXPECT_CALL(set, get_tie_break())
                                     .Times ( 4 )
                                     .WillRepeatedly ( testing::Return ( &tie_break ) );

    EXPECT_CALL(counter, count_games_for_player(One,
        &games))
                .Times ( 1 )
                .WillOnce ( testing::Return ( 5 ) );

    EXPECT_CALL(counter, count_games_for_player(Two, &games))
                                                             .Times ( 1 )
                                                             .WillOnce ( testing::Return ( 4 ) );

    // Act
    std::stringstream ostream;
    sut.print ( ostream );

    // Assert
    std::string actual = ostream.str();
    std::string expected = "Player One 5 15\nPlayer Two 4 30\n";

    EXPECT_EQ(expected, actual);
=======
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
>>>>>>> Update from private repository
}
