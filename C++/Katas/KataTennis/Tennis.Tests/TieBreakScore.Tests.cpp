#include "stdafx.h"
#include <gtest/gtest.h>
#include "TieBreakScore.h"

TEST(TieBreakScore, constructor_sets_default_value_for_score)
{
    using namespace Tennis::Logic;

    // Arrange
    uint8_t expected = 0;

    TieBreakScore sut {};

    // Act
    uint8_t actual = sut.get_score();

    // Assert
    EXPECT_EQ(expected, actual);
}

TEST(TieBreakScore, constructor_sets_score_to_given_value)
{
    using namespace Tennis::Logic;

    // Arrange
    uint8_t expected = 5;

    TieBreakScore sut { static_cast<uint8_t> ( 5 ) };

    // Act
    uint8_t actual = sut.get_score();

    // Assert
    EXPECT_EQ(expected, actual);
}

TEST(TieBreakScore, won_point_increases_score_by_one)
{
    using namespace Tennis::Logic;

    // Arrange
    uint8_t expected = 1;

    TieBreakScore sut {};

    // Act
    sut.won_point();

    // Assert
    EXPECT_EQ(expected, sut.get_score());
}

TEST(TieBreakScore, won_point_increases_score_by_one_multiple_times)
{
    using namespace Tennis::Logic;

    // Arrange
    uint8_t expected = 3;

    TieBreakScore sut {};

    // Act
    sut.won_point();
    sut.won_point();
    sut.won_point();

    // Assert
    EXPECT_EQ(expected, sut.get_score());
}

TEST(TieBreakScore, to_string_returns_score_as_string)
{
    using namespace Tennis::Logic;

    // Arrange
    TieBreakScore sut {};

    // Act
    sut.won_point();

    // Assert
    EXPECT_EQ("1", sut.to_string());
}
