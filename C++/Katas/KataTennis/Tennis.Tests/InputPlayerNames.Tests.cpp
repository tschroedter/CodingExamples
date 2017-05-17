#include "stdafx.h"
#include <gtest/gtest.h>
#include "ScoreBoard.h"
#include <gmock/gmock-generated-function-mockers.h>
#include <strstream>
#include "InputPlayerNames.h"

TEST(InputPlayerNames, get_player_name_returns_name)
{
    using namespace Tennis::Logic;

    // Arrange
    std::stringstream ostream {};
    std::stringstream istream { "Joe" };

    InputPlayerNames sut
    {
        ostream,
        istream
    };

    // Act
    std::string actual = sut.get_player_name();

    // Assert
    EXPECT_EQ("Joe", actual);
}

TEST(InputPlayerNames, get_player_name_displays_default_text)
{
    using namespace Tennis::Logic;

    // Arrange
    std::stringstream ostream {};
    std::stringstream istream { "Joe" };

    InputPlayerNames sut
    {
        ostream,
        istream
    };

    // Act
    sut.get_player_name();

    // Assert
    std::string actual = ostream.str();
    EXPECT_EQ("Player name? ", actual);
}
