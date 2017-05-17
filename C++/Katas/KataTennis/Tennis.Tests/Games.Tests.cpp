#include "stdafx.h"
#include <gtest/gtest.h>
#include "Games.h"
#include <memory>
<<<<<<< HEAD

TEST(Games, newGame_returns_new_game)
=======
#include "MockIGames.h"
#include "MockIGame.h"

std::function<std::shared_ptr<Tennis::Logic::IGame> ()> create_factory ()
{
    return []
            {
                return std::make_shared<MockIGame>();
            };
}

Hypodermic::FactoryWrapper<Tennis::Logic::IGame> wrapper { create_factory() };

TEST(Games, create_new_game_returns_new_item)
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
<<<<<<< HEAD
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>();
    Games sut { std::move ( factory ) };

    // Act
    IGame* actual = sut.new_game();
=======
    Games sut { wrapper };

    // Act
    IGame_Ptr actual = sut.create_new_game();
>>>>>>> Update from private repository

    // Assert
    EXPECT_NE(nullptr, &actual);
}

<<<<<<< HEAD
TEST(Games, newGame_adds_new_game)
=======
TEST(Games, create_new_game_adds_new_item)
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected { 1 };
<<<<<<< HEAD
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>();
    Games sut { std::move ( factory ) };

    // Act
    sut.new_game();
=======
    Games sut { wrapper };

    // Act
    sut.create_new_game();
>>>>>>> Update from private repository

    // Assert
    EXPECT_EQ(expected, sut.get_length());
}

<<<<<<< HEAD
TEST(Games, get_length_returns_number_of_games)
=======
TEST(Games, get_number_of_games_returns_number_of_games)
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
<<<<<<< HEAD
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>();
    Games sut { std::move ( factory ) };
    sut.new_game();
    sut.new_game();

    // Act
    size_t actual = sut.get_length();
=======
    Games sut { wrapper };
    sut.new_item();
    sut.new_item();

    // Act
    size_t actual = sut.get_number_of_games();
>>>>>>> Update from private repository

    // Assert
    EXPECT_EQ(2, actual);
}

<<<<<<< HEAD
TEST(Games, getCurrentGame_returns_current_game)
=======
TEST(Games, get_current_game_returns_current_game)
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
<<<<<<< HEAD
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>();
    Games sut { std::move ( factory ) };
    sut.new_game();
=======
    Games sut { wrapper };
    sut.create_new_game();
>>>>>>> Update from private repository

    // Act
    auto actual = sut.get_current_game();

    // Assert
    EXPECT_NE(nullptr, actual);
}
