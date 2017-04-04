#include "stdafx.h"
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "MockIGamesCounterr.h"
#include "MockIGame.h"
#include "MockIGames.h"
#include "MockITieBreak.h"
#include "SetWonPointHandler.h"

TEST(SetWonPointHandler, won_game_point_calls_current_game_won_point)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // 
    EXPECT_CALL(mock_game, get_status())
                                        .Times ( 1 )
                                        .WillOnce ( testing::Return ( GameStatus::NotStarted ) );

    EXPECT_CALL(mock_games, get_current_game())
                                               .Times ( 1 )
                                               .WillOnce ( testing::Return ( &mock_game ) );

    EXPECT_CALL(mock_game, won_point(One))
                                          .Times ( 1 );

    // Act
    sut.won_game_point ( One );
}

void won_game_point_calls_create_new_game_for_status_n_times (
    Tennis::Logic::GameStatus game_status,
    int times )
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // 
    EXPECT_CALL(mock_game, get_status())
                                        .Times ( 1 )
                                        .WillOnce ( testing::Return ( game_status ) );

    EXPECT_CALL(mock_games, get_current_game())
                                               .Times ( 1 )
                                               .WillOnce ( testing::Return ( &mock_game ) );

    EXPECT_CALL(mock_games, new_game())
                                       .Times ( times );

    // Act
    sut.won_game_point ( One );
}

TEST(SetWonPointHandler, won_game_point_creates_new_game_for_status_PlayerOneWon)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_new_game_for_status_n_times ( PlayerOneWon, 1 );
}

TEST(SetWonPointHandler, won_game_point_creates_new_game_for_status_PlayerOneTwo)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_new_game_for_status_n_times ( PlayerTwoWon, 1 );
}

TEST(SetWonPointHandler, won_game_point_does_not_create_new_game_for_status_NotStarted)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_new_game_for_status_n_times ( NotStarted, 0 );
}

TEST(SetWonPointHandler, won_game_point_does_not_create_new_game_for_status_InProgress)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_new_game_for_status_n_times ( InProgress, 0 );
}

TEST(SetWonPointHandler, won_game_point_does_not_create_new_game_for_status_Deuce)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_new_game_for_status_n_times ( Deuce, 0 );
}

TEST(SetWonPointHandler, won_game_point_does_not_create_new_game_for_status_AdvandtagePlayerOne)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_new_game_for_status_n_times ( AdvandtagePlayerOne, 0 );
}

TEST(SetWonPointHandler, won_game_point_does_not_create_new_game_for_status_AdvandtagePlayerTwo)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_new_game_for_status_n_times ( AdvandtagePlayerTwo, 0 );
}

TEST(SetWonPointHandler, won_game_point_does_not_create_new_game_for_status_GameStatus_Max)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_new_game_for_status_n_times ( GameStatus_Max, 0 );
}

TEST(SetWonPointHandler, won_tie_break_point_calls_tie_break_won_point_for_status_NotStarted)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // 
    EXPECT_CALL(mock_tie_break, get_status())
                                             .Times ( 1 )
                                             .WillOnce ( testing::Return ( TieBreakStatus_NotStarted ) );

    EXPECT_CALL(mock_tie_break, won_point(One))
                                               .Times ( 1 );

    // Act
    sut.won_tie_break_point ( One );
}

TEST(SetWonPointHandler, won_tie_break_point_calls_tie_break_won_point_for_status_InProgess)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // 
    EXPECT_CALL(mock_tie_break, get_status())
                                             .Times ( 1 )
                                             .WillOnce ( testing::Return ( TieBreakStatus_InProgress ) );

    EXPECT_CALL(mock_tie_break, won_point(One))
                                               .Times ( 1 );

    // Act
    sut.won_tie_break_point ( One );
}

TEST(SetWonPointHandler, won_tie_break_point_does_not_calls_tie_break_won_point_for_status_PlayerOneWon)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // 
    EXPECT_CALL(mock_tie_break, get_status())
                                             .Times ( 1 )
                                             .WillOnce ( testing::Return ( TieBreakStatus_PlayerOneWon ) );

    EXPECT_CALL(mock_tie_break, won_point(One))
                                               .Times ( 0 );

    // Act
    sut.won_tie_break_point ( One );
}

TEST(SetWonPointHandler, won_tie_break_point_does_not_calls_tie_break_won_point_for_status_PlayerTwoWon)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // 
    EXPECT_CALL(mock_tie_break, get_status())
                                             .Times ( 1 )
                                             .WillOnce ( testing::Return ( TieBreakStatus_PlayerTwoWon ) );

    EXPECT_CALL(mock_tie_break, won_point(One))
                                               .Times ( 0 );

    // Act
    sut.won_tie_break_point ( One );
}

TEST(SetWonPointHandler, won_tie_break_point_does_not_calls_tie_break_won_point_for_status_GameStatus_Max)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // 
    EXPECT_CALL(mock_tie_break, get_status())
                                             .Times ( 1 )
                                             .WillOnce ( testing::Return ( TieBreakStatus_GameStatus_Max ) );

    EXPECT_CALL(mock_tie_break, won_point(One))
                                               .Times ( 0 );

    // Act
    sut.won_tie_break_point ( One );
}

TEST(SetWonPointHandler, won_point_does_not_create_new_game_for_game_status_NotStarted)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // Assert
    EXPECT_CALL(mock_game, get_status())
                                        .Times ( 1 )
                                        .WillOnce ( testing::Return ( GameStatus::NotStarted ) );

    EXPECT_CALL(mock_games, get_current_game())
                                               .Times ( 1 )
                                               .WillOnce ( testing::Return ( &mock_game ) );

    EXPECT_CALL(mock_games, new_game())
                                       .Times ( 0 );

    // Act
    sut.won_point ( One );
}

TEST(SetWonPointHandler, won_point_does_not_create_new_game_for_game_status_InProgress)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // Assert
    EXPECT_CALL(mock_game, get_status())
                                        .Times ( 1 )
                                        .WillOnce ( testing::Return ( GameStatus::InProgress ) );

    EXPECT_CALL(mock_games, get_current_game())
                                               .Times ( 1 )
                                               .WillOnce ( testing::Return ( &mock_game ) );

    EXPECT_CALL(mock_games, new_game())
                                       .Times ( 0 );

    // Act
    sut.won_point ( One );
}

TEST(SetWonPointHandler, won_point_does_not_create_new_game_for_game_status_Deuce)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // Assert
    EXPECT_CALL(mock_game, get_status())
                                        .Times ( 1 )
                                        .WillOnce ( testing::Return ( GameStatus::Deuce ) );

    EXPECT_CALL(mock_games, get_current_game())
                                               .Times ( 1 )
                                               .WillOnce ( testing::Return ( &mock_game ) );

    EXPECT_CALL(mock_games, new_game())
                                       .Times ( 0 );

    // Act
    sut.won_point ( One );
}

TEST(SetWonPointHandler, won_point_does_not_create_new_game_for_game_status_AdvandtagePlayerOne)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // Assert
    EXPECT_CALL(mock_game, get_status())
                                        .Times ( 1 )
                                        .WillOnce ( testing::Return ( GameStatus::AdvandtagePlayerOne ) );

    EXPECT_CALL(mock_games, get_current_game())
                                               .Times ( 1 )
                                               .WillOnce ( testing::Return ( &mock_game ) );

    EXPECT_CALL(mock_games, new_game())
                                       .Times ( 0 );

    // Act
    sut.won_point ( One );
}

TEST(SetWonPointHandler, won_point_does_not_create_new_game_for_game_status_AdvandtagePlayerTwo)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // Assert
    EXPECT_CALL(mock_game, get_status())
                                        .Times ( 1 )
                                        .WillOnce ( testing::Return ( GameStatus::AdvandtagePlayerTwo ) );

    EXPECT_CALL(mock_games, get_current_game())
                                               .Times ( 1 )
                                               .WillOnce ( testing::Return ( &mock_game ) );

    EXPECT_CALL(mock_games, new_game())
                                       .Times ( 0 );

    // Act
    sut.won_point ( One );
}

TEST(SetWonPointHandler, won_point_does_not_create_new_game_for_game_status_PlayerOneWon)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // Assert
    EXPECT_CALL(mock_game, get_status())
                                        .Times ( 1 )
                                        .WillOnce ( testing::Return ( GameStatus::PlayerOneWon ) );

    EXPECT_CALL(mock_games, get_current_game())
                                               .Times ( 1 )
                                               .WillOnce ( testing::Return ( &mock_game ) );

    EXPECT_CALL(mock_games, new_game())
                                       .Times ( 1 );

    // Act
    sut.won_point ( One );
}

TEST(SetWonPointHandler, won_point_does_not_create_new_game_for_game_status_PlayerTwoWon)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // Assert
    EXPECT_CALL(mock_game, get_status())
                                        .Times ( 1 )
                                        .WillOnce ( testing::Return ( GameStatus::PlayerTwoWon ) );

    EXPECT_CALL(mock_games, get_current_game())
                                               .Times ( 1 )
                                               .WillOnce ( testing::Return ( &mock_game ) );

    EXPECT_CALL(mock_games, new_game())
                                       .Times ( 1 );

    // Act
    sut.won_point ( One );
}

TEST(SetWonPointHandler, won_point_does_not_create_new_game_for_game_status_GameStatus_Max)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // Assert
    EXPECT_CALL(mock_game, get_status())
                                        .Times ( 1 )
                                        .WillOnce ( testing::Return ( GameStatus::GameStatus_Max ) );

    EXPECT_CALL(mock_games, get_current_game())
                                               .Times ( 1 )
                                               .WillOnce ( testing::Return ( &mock_game ) );

    EXPECT_CALL(mock_games, new_game())
                                       .Times ( 0 );

    // Act
    sut.won_point ( One );
}

TEST(SetWonPointHandler, is_tie_break_Required_returns_false_for_0_0)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // Assert
    EXPECT_CALL(*mock_counter, count_games_for_player(One, &mock_games))
                                                                        .Times ( 1 )
                                                                        .WillOnce ( testing::Return ( static_cast<int8_t> ( 0 ) ) );

    EXPECT_CALL(*mock_counter, count_games_for_player(Two, &mock_games))
                                                                        .Times ( 1 )
                                                                        .WillOnce ( testing::Return ( static_cast<int8_t> ( 0 ) ) );

    // Act
    EXPECT_FALSE(sut.is_tie_break_Required());
}

TEST(SetWonPointHandler, is_tie_break_Required_returns_false_for_6_5)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // Assert
    EXPECT_CALL(*mock_counter, count_games_for_player(One, &mock_games))
                                                                        .Times ( 1 )
                                                                        .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    EXPECT_CALL(*mock_counter, count_games_for_player(Two, &mock_games))
                                                                        .Times ( 1 )
                                                                        .WillOnce ( testing::Return ( static_cast<int8_t> ( 5 ) ) );

    // Act
    EXPECT_FALSE(sut.is_tie_break_Required());
}

TEST(SetWonPointHandler, is_tie_break_Required_returns_false_for_5_6)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // Assert
    EXPECT_CALL(*mock_counter, count_games_for_player(One, &mock_games))
                                                                        .Times ( 1 )
                                                                        .WillOnce ( testing::Return ( static_cast<int8_t> ( 5 ) ) );

    EXPECT_CALL(*mock_counter, count_games_for_player(Two, &mock_games))
                                                                        .Times ( 1 )
                                                                        .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    // Act
    EXPECT_FALSE(sut.is_tie_break_Required());
}

TEST(SetWonPointHandler, is_tie_break_Required_returns_true_for_6_6)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // Assert
    EXPECT_CALL(*mock_counter, count_games_for_player(One, &mock_games))
                                                                        .Times ( 1 )
                                                                        .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    EXPECT_CALL(*mock_counter, count_games_for_player(Two, &mock_games))
                                                                        .Times ( 1 )
                                                                        .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    // Act
    EXPECT_TRUE(sut.is_tie_break_Required());
}

TEST(SetWonPointHandler, won_point_calls_won_game_point_for_normal_game)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // Assert
    EXPECT_CALL(*mock_counter, count_games_for_player(One, &mock_games))
                                                                        .Times ( 1 )
                                                                        .WillOnce ( testing::Return ( static_cast<int8_t> ( 0 ) ) );

    EXPECT_CALL(*mock_counter, count_games_for_player(Two, &mock_games))
                                                                        .Times ( 1 )
                                                                        .WillOnce ( testing::Return ( static_cast<int8_t> ( 0 ) ) );

    EXPECT_CALL(mock_game, get_status())
                                        .Times ( 1 )
                                        .WillOnce ( testing::Return ( GameStatus::InProgress ) );

    EXPECT_CALL(mock_games, get_current_game())
                                               .Times ( 1 )
                                               .WillOnce ( testing::Return ( &mock_game ) );

    EXPECT_CALL(mock_game, won_point(One))
                                          .Times ( 1 );

    // Act
    sut.won_point ( One );
}

TEST(SetWonPointHandler, won_point_calls_won_game_point_for_tie_break_game)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGamesCounter* mock_counter = new MockIGamesCounter();
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockIGame mock_game {};
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    SetWonPointHandler sut
    {
        std::move ( counter ),
        &mock_games,
        &mock_tie_break
    };

    // Assert
    EXPECT_CALL(*mock_counter, count_games_for_player(One, &mock_games))
                                                                        .Times ( 1 )
                                                                        .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    EXPECT_CALL(*mock_counter, count_games_for_player(Two, &mock_games))
                                                                        .Times ( 1 )
                                                                        .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    EXPECT_CALL(mock_tie_break, get_status())
                                             .Times ( 1 )
                                             .WillOnce ( testing::Return ( TieBreakStatus_InProgress ) );

    EXPECT_CALL(mock_tie_break, won_point(One))
                                               .Times ( 1 );

    // Act
    sut.won_point ( One );
}
