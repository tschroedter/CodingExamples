#include "stdafx.h"
#include <gtest/gtest.h>
#include "BaseException.h"

TEST(BaseException, get_error_returns_string)
{
    using namespace Tennis::Logic;

    // Arrange
    // Act
    BaseException sut { "Message" };

    // Assert
    EXPECT_EQ("Message", sut.get_error());
}
