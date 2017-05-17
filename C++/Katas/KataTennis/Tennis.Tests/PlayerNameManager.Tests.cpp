#include "stdafx.h"
#include <string>
#include <gtest/gtest.h>
#include "PlayerNameManager.h"
#include "MockILogger.h"
#include "PlayerException.h"

TEST(PlayerNameManager, get_player_name_returns_string_for_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    PlayerNameManager sut {};

    // Act
    auto actual = sut.get_player_name ( One );

    // Assert
    EXPECT_EQ("Player One", actual);
}

TEST(PlayerNameManager, get_player_name_returns_string_for_player_two)
{
    using namespace Tennis::Logic;

    // Arrange
    PlayerNameManager sut {};

    // Act
    auto actual = sut.get_player_name ( Two );

    // Assert
    EXPECT_EQ("Player Two", actual);
}

TEST(PlayerNameManager, set_player_name_sets_name_for_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    PlayerNameManager sut {};

    // Act
    sut.set_player_name ( One, "One" );

    // Assert
    std::string actual = sut.get_player_name ( One );
    EXPECT_EQ("One", actual);
}

TEST(PlayerNameManager, set_player_name_sets_name_for_player_two)
{
    using namespace Tennis::Logic;

    // Arrange
    PlayerNameManager sut {};

    // Act
    sut.set_player_name ( Two, "Two" );

    // Assert
    std::string actual = sut.get_player_name ( Two );
    EXPECT_EQ("Two", actual);
}

TEST(PlayerNameManager, get_player_name_throws_for_unknown_player)
{
    using namespace Tennis::Logic;

    // Arrange
    PlayerNameManager sut {};

    // Act
    // Assert
    EXPECT_THROW(
        sut.get_player_name(static_cast<Player> (-1)),
        Tennis::Logic::PlayerException);
}
