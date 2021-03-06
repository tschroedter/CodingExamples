#include "stdafx.h"
#include <gtest/gtest.h>
#include "Logger.h"

TEST(Logger, debug_writes_message_to_ostream)
{
    using namespace Tennis::Logic;

    // Arrange
    std::stringstream ostream;

    Logger sut { ostream };

    // Act
    sut.debug ( "Test" );

    // Assert
    std::string actual = ostream.str();

    EXPECT_EQ("DEBUG: Test\n", actual);
}

TEST(Logger, error_writes_message_to_ostream)
{
    using namespace Tennis::Logic;

    // Arrange
    std::stringstream ostream;

    Logger sut { ostream };

    // Act
    sut.error ( "Test" );

    // Assert
    std::string actual = ostream.str();

    EXPECT_EQ("ERROR: Test\n", actual);
}

TEST(Logger, info_writes_message_to_ostream)
{
    using namespace Tennis::Logic;

    // Arrange
    std::stringstream ostream;

    Logger sut { ostream };

    // Act
    sut.info ( "Test" );

    // Assert
    std::string actual = ostream.str();

    EXPECT_EQ("INFO: Test\n", actual);
}

TEST(Logger, warning_writes_message_to_ostream)
{
    using namespace Tennis::Logic;

    // Arrange
    std::stringstream ostream;

    Logger sut { ostream };

    // Act
    sut.warning ( "Test" );

    // Assert
    std::string actual = ostream.str();

    EXPECT_EQ("WARNING: Test\n", actual);
}
