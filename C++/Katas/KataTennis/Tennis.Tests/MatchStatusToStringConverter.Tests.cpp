#include "stdafx.h"
#include <gtest/gtest.h>
#include "MatchStatusToStringConverter.h"

TEST(MatchStatusToStringConverter, to_string_returns_string_for_NotStarted)
{
    using namespace Tennis::Logic;

    // Arrange
    std::stringstream ostream;

    MatchStatusToStringConverter sut {};

    // Act
    std::string actual = sut.to_string ( MatchStatus_NotStarted );

    // Assert
    EXPECT_EQ("NotStarted", actual);
}

TEST(MatchStatusToStringConverter, to_string_returns_string_for_InProgress)
{
    using namespace Tennis::Logic;

    // Arrange
    std::stringstream ostream;

    MatchStatusToStringConverter sut {};

    // Act
    std::string actual = sut.to_string ( MatchStatus_InProgress );

    // Assert
    EXPECT_EQ("InProgress", actual);
}

TEST(MatchStatusToStringConverter, to_string_returns_string_for_PlayerOneWon)
{
    using namespace Tennis::Logic;

    // Arrange
    std::stringstream ostream;

    MatchStatusToStringConverter sut {};

    // Act
    std::string actual = sut.to_string ( MatchStatus_PlayerOneWon );

    // Assert
    EXPECT_EQ("PlayerOneWon", actual);
}

TEST(MatchStatusToStringConverter, to_string_returns_string_for_PlayerTwoWon)
{
    using namespace Tennis::Logic;

    // Arrange
    std::stringstream ostream;

    MatchStatusToStringConverter sut {};

    // Act
    std::string actual = sut.to_string ( MatchStatus_PlayerTwoWon );

    // Assert
    EXPECT_EQ("PlayerTwoWon", actual);
}

TEST(MatchStatusToStringConverter, to_string_returns_string_for_Max)
{
    using namespace Tennis::Logic;

    // Arrange
    std::stringstream ostream;

    MatchStatusToStringConverter sut {};

    // Act
    std::string actual = sut.to_string ( MatchStatus_Max );

    // Assert
    EXPECT_EQ("Max", actual);
}
