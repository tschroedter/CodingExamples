#include "stdafx.h"
#include <gtest/gtest.h>
#include "Games.h"
#include <memory>

TEST(Games, newGame_returns_new_game)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>();
    Games sut { std::move ( factory ) };

    // Act
    IGame* actual = sut.new_game();

    // Assert
    EXPECT_NE(nullptr, &actual);
}

TEST(Games, newGame_adds_new_game)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected { 1 };
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>();
    Games sut { std::move ( factory ) };

    // Act
    sut.new_game();

    // Assert
    EXPECT_EQ(expected, sut.get_length());
}

TEST(Games, get_length_returns_number_of_games)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>();
    Games sut { std::move ( factory ) };
    sut.new_game();
    sut.new_game();

    // Act
    size_t actual = sut.get_length();

    // Assert
    EXPECT_EQ(2, actual);
}

TEST(Games, getCurrentGame_returns_current_game)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>();
    Games sut { std::move ( factory ) };
    sut.new_game();

    // Act
    auto actual = sut.get_current_game();

    // Assert
    EXPECT_NE(nullptr, actual);
}
