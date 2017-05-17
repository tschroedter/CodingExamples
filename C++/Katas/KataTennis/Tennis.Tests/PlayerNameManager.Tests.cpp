#include "stdafx.h"
#include <string>
#include <gtest/gtest.h>
#include "PlayerNameManager.h"
#include "MockILogger.h"
<<<<<<< HEAD

TEST(PlayerNameManager, constructor_sets_name_for_player_one)
=======
#include "PlayerException.h"

TEST(PlayerNameManager, get_player_name_returns_string_for_player_one)
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
<<<<<<< HEAD
    MockILogger logger {};

    PlayerNameManager sut
    {
        &logger,
        "Player One",
        "Player Two"
    };

    // Act
    std::string actual = sut.get_player_name ( One );
=======
    PlayerNameManager sut {};

    // Act
    auto actual = sut.get_player_name ( One );
>>>>>>> Update from private repository

    // Assert
    EXPECT_EQ("Player One", actual);
}

<<<<<<< HEAD
TEST(PlayerNameManager, constructor_sets_name_for_player_two)
=======
TEST(PlayerNameManager, get_player_name_returns_string_for_player_two)
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
<<<<<<< HEAD
    MockILogger logger {};

    PlayerNameManager sut
    {
        &logger,
        "Player One",
        "Player Two"
    };

    // Act
    std::string actual = sut.get_player_name ( Two );
=======
    PlayerNameManager sut {};

    // Act
    auto actual = sut.get_player_name ( Two );
>>>>>>> Update from private repository

    // Assert
    EXPECT_EQ("Player Two", actual);
}

<<<<<<< HEAD
TEST(PlayerNameManager, get_player_name_log_error_for_unknown_player)
=======
TEST(PlayerNameManager, set_player_name_sets_name_for_player_one)
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
<<<<<<< HEAD
    MockILogger logger {};

    PlayerNameManager sut
    {
        &logger,
        "Player One",
        "Player Two"
    };

    // Expect
    EXPECT_CALL(logger, error("Unknown Player type: -1"))
                                                         .Times ( 1 );

    // Act
    std::string actual = sut.get_player_name ( static_cast<Player> ( -1 ) );
=======
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
>>>>>>> Update from private repository
}
