#include "stdafx.h"
#include <gtest/gtest.h>
#include "MatchFactory.h"

TEST(MatchFactory, create_returns_match)
{
    using namespace Tennis::Logic;

    // Arrange
    MatchFactory factory {};

    // Act
    std::unique_ptr<IMatch> actual = factory.create();

    // Assert
    EXPECT_NE(nullptr, actual.get());
}
