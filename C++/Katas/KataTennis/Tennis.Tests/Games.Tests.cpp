#include "stdafx.h"
#include <gtest/gtest.h>
#include "Games.h"
#include <memory>
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
{
    using namespace Tennis::Logic;

    // Arrange
    Games sut { wrapper };

    // Act
    IGame_Ptr actual = sut.create_new_game();

    // Assert
    EXPECT_NE(nullptr, &actual);
}

TEST(Games, create_new_game_adds_new_item)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected { 1 };
    Games sut { wrapper };

    // Act
    sut.create_new_game();

    // Assert
    EXPECT_EQ(expected, sut.get_length());
}

TEST(Games, get_number_of_games_returns_number_of_games)
{
    using namespace Tennis::Logic;

    // Arrange
    Games sut { wrapper };
    sut.new_item();
    sut.new_item();

    // Act
    size_t actual = sut.get_number_of_games();

    // Assert
    EXPECT_EQ(2, actual);
}

TEST(Games, get_current_game_returns_current_game)
{
    using namespace Tennis::Logic;

    // Arrange
    Games sut { wrapper };
    sut.create_new_game();

    // Act
    auto actual = sut.get_current_game();

    // Assert
    EXPECT_NE(nullptr, actual);
}
