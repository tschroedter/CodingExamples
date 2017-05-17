#include "stdafx.h"
#include <string>
#include <gtest/gtest.h>
#include "GamesCounter.h"
#include "MockIGames.h"
<<<<<<< HEAD

void winOneGameForPlayer ( Tennis::Logic::IGame* game, Tennis::Logic::Player player )
{
    game->won_point ( player );
    game->won_point ( player );
    game->won_point ( player );
    game->won_point ( player );
}
=======
#include "Games.h"
#include "MockIGame.h"
#include "Game.h"
>>>>>>> Update from private repository

TEST(GamesCounter, count_games_for_player_returns_number_of_games_won_by_player_one_for_one_game_won_by_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    int8_t expected = static_cast<int8_t> ( 1 );

<<<<<<< HEAD
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>();
    Games games { std::move ( factory ) };
    games.new_game();
    winOneGameForPlayer ( games.get_current_game(), One );

    GamesCounter sut {};

    // Act
    const int8_t actual = sut.count_games_for_player ( One,
                                                       &games );
=======
    MockIGame* mock_game = new MockIGame{};
    IGame_Ptr game ( mock_game );

    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );

    GamesCounter sut {};

    EXPECT_CALL(*mock_games,
        get_number_of_games())
                              .Times ( 1 )
                              .WillOnce ( testing::Return ( static_cast<size_t> ( 1 ) ) );

    EXPECT_CALL(*mock_games,
        get_game_at_index(0))
                             .Times ( 1 )
                             .WillOnce ( testing::Return ( game ) );

    EXPECT_CALL(*mock_game,
        get_status())
                     .Times ( 1 )
                     .WillOnce ( testing::Return ( PlayerOneWon ) );

    // Act
    const int8_t actual = sut.count_games_for_player ( One,
                                                       games );
>>>>>>> Update from private repository

    // Assert
    EXPECT_EQ(expected, actual);
}

TEST(GamesCounter, count_games_for_player_returns_number_of_games_won_by_player_two_for_one_game_won_by_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    int8_t expected = static_cast<int8_t> ( 0 );

<<<<<<< HEAD
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>();
    Games games { std::move ( factory ) };
    games.new_game();
    winOneGameForPlayer ( games.get_current_game(), One );

    GamesCounter sut {};

    // Act
    const int8_t actual = sut.count_games_for_player ( Two,
                                                       &games );
=======
    MockIGame* mock_game = new MockIGame{};
    IGame_Ptr game ( mock_game );

    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );

    GamesCounter sut {};

    EXPECT_CALL(*mock_games,
        get_number_of_games())
                              .Times ( 1 )
                              .WillOnce ( testing::Return ( static_cast<size_t> ( 1 ) ) );

    EXPECT_CALL(*mock_games,
        get_game_at_index(0))
                             .Times ( 1 )
                             .WillOnce ( testing::Return ( game ) );

    EXPECT_CALL(*mock_game,
        get_status())
                     .Times ( 1 )
                     .WillOnce ( testing::Return ( PlayerOneWon ) );

    // Act
    const int8_t actual = sut.count_games_for_player ( Two,
                                                       games );
>>>>>>> Update from private repository

    // Assert
    EXPECT_EQ(expected, actual);
}

<<<<<<< HEAD
TEST(GamesCounter, count_games_for_player_returns_number_of_games_won_by_player_one_for_one_game_won_by_player_two)
=======
TEST(GamesCounter, count_games_for_player_returns_number_of_games_won_by_player_two_for_one_game_won_by_player_two)
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
<<<<<<< HEAD
    int8_t expected = static_cast<int8_t> ( 0 );

    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>();
    Games games { std::move ( factory ) };
    games.new_game();
    winOneGameForPlayer ( games.get_current_game(), Two );

    GamesCounter sut {};

    // Act
    const int8_t actual = sut.count_games_for_player ( One,
                                                       &games );
=======
    int8_t expected = static_cast<int8_t> ( 1 );

    MockIGame* mock_game = new MockIGame{};
    IGame_Ptr game ( mock_game );

    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );

    GamesCounter sut {};

    EXPECT_CALL(*mock_games,
        get_number_of_games())
                              .Times ( 1 )
                              .WillOnce ( testing::Return ( static_cast<size_t> ( 1 ) ) );

    EXPECT_CALL(*mock_games,
        get_game_at_index(0))
                             .Times ( 1 )
                             .WillOnce ( testing::Return ( game ) );

    EXPECT_CALL(*mock_game,
        get_status())
                     .Times ( 1 )
                     .WillOnce ( testing::Return ( PlayerTwoWon ) );

    // Act
    const int8_t actual = sut.count_games_for_player ( Two,
                                                       games );
>>>>>>> Update from private repository

    // Assert
    EXPECT_EQ(expected, actual);
}

<<<<<<< HEAD
TEST(GamesCounter, count_games_for_player_returns_number_of_games_won_by_player_two_for_one_game_won_by_player_two)
=======
TEST(GamesCounter, count_games_for_player_returns_number_of_games_won_by_player_one_for_one_game_won_by_player_two)
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
<<<<<<< HEAD
    int8_t expected = static_cast<int8_t> ( 1 );

    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>();
    Games games { std::move ( factory ) };
    games.new_game();
    winOneGameForPlayer ( games.get_current_game(), Two );

    GamesCounter sut {};

    // Act
    const int8_t actual = sut.count_games_for_player ( Two,
                                                       &games );
=======
    int8_t expected = static_cast<int8_t> ( 0 );

    MockIGame* mock_game = new MockIGame{};
    IGame_Ptr game ( mock_game );

    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );

    GamesCounter sut {};

    EXPECT_CALL(*mock_games,
        get_number_of_games())
                              .Times ( 1 )
                              .WillOnce ( testing::Return ( static_cast<size_t> ( 1 ) ) );

    EXPECT_CALL(*mock_games,
        get_game_at_index(0))
                             .Times ( 1 )
                             .WillOnce ( testing::Return ( game ) );

    EXPECT_CALL(*mock_game,
        get_status())
                     .Times ( 1 )
                     .WillOnce ( testing::Return ( PlayerTwoWon ) );

    // Act
    const int8_t actual = sut.count_games_for_player ( One,
                                                       games );
>>>>>>> Update from private repository

    // Assert
    EXPECT_EQ(expected, actual);
}
