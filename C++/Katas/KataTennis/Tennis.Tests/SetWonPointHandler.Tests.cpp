#include "stdafx.h"
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "MockIGame.h"
#include "MockIGames.h"
#include "MockITieBreak.h"
#include "SetWonPointHandler.h"
#include "MockIGamesCounter.h"

TEST(SetWonPointHandler, won_game_point_calls_current_game_won_point)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGame* mock_game = new MockIGame{};
    IGame_Ptr game ( mock_game );
    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    IGamesCounter_Ptr counter ( mock_counter );

    SetWonPointHandler sut
    {
        counter,
    };

    sut.intitialize ( games, tie_break );

    // Assert
    EXPECT_CALL(*mock_game, get_status())
                                         .Times ( 1 )
                                         .WillOnce ( testing::Return ( NotStarted ) );

    EXPECT_CALL(*mock_games, get_current_game())
                                                .Times ( 1 )
                                                .WillOnce ( testing::Return ( game ) );

    EXPECT_CALL(*mock_game, won_point(One))
                                           .Times ( 1 );

    // Act
    sut.won_game_point ( One );
}

void won_game_point_calls_create_create_new_game_for_status_n_times (
    Tennis::Logic::GameStatus game_status,
    int times )
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGame* mock_game = new MockIGame{};
    IGame_Ptr game ( mock_game );
    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    IGamesCounter_Ptr counter ( mock_counter );

    SetWonPointHandler sut
    {
        counter
    };

    sut.intitialize ( games, tie_break );

    // 
    EXPECT_CALL(*mock_game, get_status())
                                         .Times ( 1 )
                                         .WillOnce ( testing::Return ( game_status ) );

    EXPECT_CALL(*mock_games, get_current_game())
                                                .Times ( 1 )
                                                .WillOnce ( testing::Return ( game ) );

    EXPECT_CALL(*mock_games, create_new_game())
                                               .Times ( times )
                                               .WillOnce ( testing::Return ( game ) );

    // Act
    sut.won_game_point ( One );
}

TEST(SetWonPointHandler, won_game_point_creates_create_new_game_for_status_PlayerOneWon)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_create_new_game_for_status_n_times ( PlayerOneWon, 1 );
}

TEST(SetWonPointHandler, won_game_point_creates_create_new_game_for_status_PlayerOneTwo)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_create_new_game_for_status_n_times ( PlayerTwoWon, 1 );
}

TEST(SetWonPointHandler, won_game_point_does_not_create_create_new_game_for_status_NotStarted)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_create_new_game_for_status_n_times ( NotStarted, 0 );
}

TEST(SetWonPointHandler, won_game_point_does_not_create_create_new_game_for_status_InProgress)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_create_new_game_for_status_n_times ( InProgress, 0 );
}

TEST(SetWonPointHandler, won_game_point_does_not_create_create_new_game_for_status_Deuce)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_create_new_game_for_status_n_times ( Deuce, 0 );
}

TEST(SetWonPointHandler, won_game_point_does_not_create_create_new_game_for_status_AdvandtagePlayerOne)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_create_new_game_for_status_n_times ( AdvandtagePlayerOne, 0 );
}

TEST(SetWonPointHandler, won_game_point_does_not_create_create_new_game_for_status_AdvandtagePlayerTwo)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_create_new_game_for_status_n_times ( AdvandtagePlayerTwo, 0 );
}

TEST(SetWonPointHandler, won_game_point_does_not_create_create_new_game_for_status_GameStatus_Max)
{
    using namespace Tennis::Logic;

    won_game_point_calls_create_create_new_game_for_status_n_times ( GameStatus_Max, 0 );
}

TEST(SetWonPointHandler, won_tie_break_point_calls_tie_break_won_point_for_status_NotStarted)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGame mock_game {};
    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    IGamesCounter_Ptr counter ( mock_counter );

    SetWonPointHandler sut
    {
        counter
    };

    sut.intitialize ( games, tie_break );

    // Assert
    EXPECT_CALL(*mock_tie_break, get_status())
                                              .Times ( 1 )
                                              .WillOnce ( testing::Return ( TieBreakStatus_NotStarted ) );

    EXPECT_CALL(*mock_tie_break, won_point(One))
                                                .Times ( 1 );

    // Act
    sut.won_tie_break_point ( One );
}

TEST(SetWonPointHandler, won_tie_break_point_calls_tie_break_won_point_for_status_InProgess)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    IGamesCounter_Ptr counter ( mock_counter );

    SetWonPointHandler sut
    {
        counter
    };

    sut.intitialize ( games, tie_break );

    // Assert
    EXPECT_CALL(*mock_tie_break, get_status())
                                              .Times ( 1 )
                                              .WillOnce ( testing::Return ( TieBreakStatus_InProgress ) );

    EXPECT_CALL(*mock_tie_break, won_point(One))
                                                .Times ( 1 );

    // Act
    sut.won_tie_break_point ( One );
}

void test_won_tie_break_point_calls_tie_break_won_point_for_status (
    const Tennis::Logic::Player player,
    const Tennis::Logic::TieBreakStatus tie_break_status,
    const int calls_n_times )
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGame mock_game {};
    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    IGamesCounter_Ptr counter ( mock_counter );

    SetWonPointHandler sut
    {
        counter
    };

    sut.intitialize ( games, tie_break );

    // Assert
    EXPECT_CALL(*mock_tie_break, get_status())
                                              .Times ( 1 )
                                              .WillOnce ( testing::Return ( tie_break_status ) );

    EXPECT_CALL(*mock_tie_break, won_point(player))
                                                   .Times ( calls_n_times );

    // Act
    sut.won_tie_break_point ( player );
}

TEST(SetWonPointHandler, won_tie_break_point_does_not_calls_tie_break_won_point_for_status_PlayerOneWon)
{
    using namespace Tennis::Logic;

    test_won_tie_break_point_calls_tie_break_won_point_for_status (
                                                                   One,
                                                                   TieBreakStatus_PlayerOneWon,
                                                                   0 );
}

TEST(SetWonPointHandler, won_tie_break_point_does_not_calls_tie_break_won_point_for_status_PlayerTwoWon)
{
    using namespace Tennis::Logic;

    test_won_tie_break_point_calls_tie_break_won_point_for_status (
                                                                   One,
                                                                   TieBreakStatus_PlayerTwoWon,
                                                                   0 );
}

TEST(SetWonPointHandler, won_tie_break_point_does_not_calls_tie_break_won_point_for_status_GameStatus_Max)
{
    using namespace Tennis::Logic;

    test_won_tie_break_point_calls_tie_break_won_point_for_status (
                                                                   One,
                                                                   TieBreakStatus_GameStatus_Max,
                                                                   0 );
}

void test_won_point_calls_create_new_game_for_game_status (
    const Tennis::Logic::GameStatus game_status,
    const int calls_n_times )
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGame* mock_game = new MockIGame{};
    IGame_Ptr game ( mock_game );
    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    IGamesCounter_Ptr counter ( mock_counter );

    SetWonPointHandler sut
    {
        counter
    };

    sut.intitialize ( games, tie_break );

    // Assert
    EXPECT_CALL(*mock_game, get_status())
                                         .Times ( 1 )
                                         .WillOnce ( testing::Return ( game_status ) );

    EXPECT_CALL(*mock_games, get_current_game())
                                                .Times ( 1 )
                                                .WillOnce ( testing::Return ( game ) );

    EXPECT_CALL(*mock_games, create_new_game())
                                               .Times ( calls_n_times )
                                               .WillRepeatedly ( testing::Return ( game ) );

    // Act
    sut.won_point ( One );
}

TEST(SetWonPointHandler, won_point_does_not_create_create_new_game_for_game_status_NotStarted)
{
    using namespace Tennis::Logic;

    test_won_point_calls_create_new_game_for_game_status (
                                                          NotStarted,
                                                          0 );
}

TEST(SetWonPointHandler, won_point_does_not_create_create_new_game_for_game_status_InProgress)
{
    using namespace Tennis::Logic;

    test_won_point_calls_create_new_game_for_game_status (
                                                          InProgress,
                                                          0 );
}

TEST(SetWonPointHandler, won_point_does_not_create_create_new_game_for_game_status_Deuce)
{
    using namespace Tennis::Logic;

    test_won_point_calls_create_new_game_for_game_status (
                                                          Deuce,
                                                          0 );
}

TEST(SetWonPointHandler, won_point_does_not_create_create_new_game_for_game_status_AdvandtagePlayerOne)
{
    using namespace Tennis::Logic;

    test_won_point_calls_create_new_game_for_game_status (
                                                          AdvandtagePlayerOne,
                                                          0 );
}

TEST(SetWonPointHandler, won_point_does_not_create_create_new_game_for_game_status_AdvandtagePlayerTwo)
{
    using namespace Tennis::Logic;

    test_won_point_calls_create_new_game_for_game_status (
                                                          AdvandtagePlayerTwo,
                                                          0 );
}

TEST(SetWonPointHandler, won_point_does_not_create_create_new_game_for_game_status_PlayerOneWon)
{
    using namespace Tennis::Logic;

    test_won_point_calls_create_new_game_for_game_status (
                                                          PlayerOneWon,
                                                          1 );
}

TEST(SetWonPointHandler, won_point_does_not_create_create_new_game_for_game_status_PlayerTwoWon)
{
    using namespace Tennis::Logic;

    test_won_point_calls_create_new_game_for_game_status (
                                                          PlayerTwoWon,
                                                          1 );
}

TEST(SetWonPointHandler, won_point_does_not_create_create_new_game_for_game_status_GameStatus_Max)
{
    using namespace Tennis::Logic;

    test_won_point_calls_create_new_game_for_game_status (
                                                          GameStatus_Max,
                                                          0 );
}

TEST(SetWonPointHandler, is_tie_break_Required_returns_false_for_0_0)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    IGamesCounter_Ptr counter ( mock_counter );

    SetWonPointHandler sut
    {
        counter
    };

    sut.intitialize ( games, tie_break );

    // Assert
    EXPECT_CALL(*mock_counter, count_games_for_player(One, games))
                                                                  .Times ( 1 )
                                                                  .WillOnce ( testing::Return ( static_cast<int8_t> ( 0 ) ) );

    EXPECT_CALL(*mock_counter, count_games_for_player(Two, games))
                                                                  .Times ( 1 )
                                                                  .WillOnce ( testing::Return ( static_cast<int8_t> ( 0 ) ) );

    // Act
    EXPECT_FALSE(sut.is_tie_break_Required());
}

TEST(SetWonPointHandler, is_tie_break_Required_returns_false_for_6_5)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    IGamesCounter_Ptr counter ( mock_counter );

    SetWonPointHandler sut
    {
        counter
    };

    sut.intitialize ( games, tie_break );

    // Assert
    EXPECT_CALL(*mock_counter, count_games_for_player(One, games))
                                                                  .Times ( 1 )
                                                                  .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    EXPECT_CALL(*mock_counter, count_games_for_player(Two, games))
                                                                  .Times ( 1 )
                                                                  .WillOnce ( testing::Return ( static_cast<int8_t> ( 5 ) ) );

    // Act
    EXPECT_FALSE(sut.is_tie_break_Required());
}

TEST(SetWonPointHandler, is_tie_break_Required_returns_false_for_5_6)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    IGamesCounter_Ptr counter ( mock_counter );

    SetWonPointHandler sut
    {
        counter
    };

    sut.intitialize ( games, tie_break );

    // Assert
    EXPECT_CALL(*mock_counter, count_games_for_player(One, games))
                                                                  .Times ( 1 )
                                                                  .WillOnce ( testing::Return ( static_cast<int8_t> ( 5 ) ) );

    EXPECT_CALL(*mock_counter, count_games_for_player(Two, games))
                                                                  .Times ( 1 )
                                                                  .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    // Act
    EXPECT_FALSE(sut.is_tie_break_Required());
}

TEST(SetWonPointHandler, is_tie_break_Required_returns_true_for_6_6)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    IGamesCounter_Ptr counter ( mock_counter );

    SetWonPointHandler sut
    {
        counter
    };

    sut.intitialize ( games, tie_break );

    // Assert
    EXPECT_CALL(*mock_counter, count_games_for_player(One, games))
                                                                  .Times ( 1 )
                                                                  .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    EXPECT_CALL(*mock_counter, count_games_for_player(Two, games))
                                                                  .Times ( 1 )
                                                                  .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    // Act
    EXPECT_TRUE(sut.is_tie_break_Required());
}

TEST(SetWonPointHandler, won_point_calls_won_game_point_for_normal_game)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGame* mock_game = new MockIGame{};
    IGame_Ptr game ( mock_game );
    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    IGamesCounter_Ptr counter ( mock_counter );

    SetWonPointHandler sut
    {
        counter
    };

    sut.intitialize ( games, tie_break );

    // Assert
    EXPECT_CALL(*mock_counter, count_games_for_player(One, games))
                                                                  .Times ( 1 )
                                                                  .WillOnce ( testing::Return ( static_cast<int8_t> ( 0 ) ) );

    EXPECT_CALL(*mock_counter, count_games_for_player(Two, games))
                                                                  .Times ( 1 )
                                                                  .WillOnce ( testing::Return ( static_cast<int8_t> ( 0 ) ) );

    EXPECT_CALL(*mock_game, get_status())
                                         .Times ( 1 )
                                         .WillOnce ( testing::Return ( InProgress ) );

    EXPECT_CALL(*mock_games, get_current_game())
                                                .Times ( 1 )
                                                .WillOnce ( testing::Return ( game ) );

    EXPECT_CALL(*mock_game, won_point(One))
                                           .Times ( 1 );

    // Act
    sut.won_point ( One );
}

TEST(SetWonPointHandler, won_point_calls_won_game_point_for_tie_break_game)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    IGamesCounter_Ptr counter ( mock_counter );

    SetWonPointHandler sut
    {
        counter
    };

    sut.intitialize ( games, tie_break );

    // Assert
    EXPECT_CALL(*mock_counter, count_games_for_player(One, games))
                                                                  .Times ( 1 )
                                                                  .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    EXPECT_CALL(*mock_counter, count_games_for_player(Two, games))
                                                                  .Times ( 1 )
                                                                  .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    EXPECT_CALL(*mock_tie_break, get_status())
                                              .Times ( 1 )
                                              .WillOnce ( testing::Return ( TieBreakStatus_InProgress ) );

    EXPECT_CALL(*mock_tie_break, won_point(One))
                                                .Times ( 1 );

    // Act
    sut.won_point ( One );
}
