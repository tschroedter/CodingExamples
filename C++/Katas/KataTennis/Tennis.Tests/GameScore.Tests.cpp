#include "stdafx.h"
#include <gtest/gtest.h>
#include "GameScore.h"

TEST(GameScore, constructor_sets_default_value_for_score)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore sut {};

    // Act
    Scores actual = sut.get_score();

    // Assert
    EXPECT_EQ(Scores::Love, actual);
}

TEST(GameScore, constructor_sets_value_for_score)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore sut { Forty };

    // Act
    Scores actual = sut.get_score();

    // Assert
    EXPECT_EQ(Scores::Forty, actual);
}

TEST(GameScore, won_point_increases_score)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore sut {};

    // Act
    sut.won_point();

    // Assert
    EXPECT_EQ(Scores::Fifteen, sut.get_score());
}

TEST(GameScore, lost_point_decreases_score_for_advantage)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore sut { Advantage };

    // Act
    sut.lost_point();

    // Assert
    EXPECT_EQ(Scores::Forty, sut.get_score());
}

TEST(GameScore, lost_point_does_not_decreases_score_for_love)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore sut {};

    // Act
    sut.lost_point();

    // Assert
    EXPECT_EQ(Scores::Love, sut.get_score());
}

TEST(GameScore, lost_point_does_not_decreases_score_for_fifteen)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore sut { Fifteen };

    // Act
    sut.lost_point();

    // Assert
    EXPECT_EQ(Scores::Fifteen, sut.get_score());
}

TEST(GameScore, lost_point_does_not_decreases_score_for_forty)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore sut { Forty };

    // Act
    sut.lost_point();

    // Assert
    EXPECT_EQ(Scores::Forty, sut.get_score());
}

TEST(GameScore, lost_point_does_not_decreases_score_for_advantagewon)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore sut { AdvantageWon };

    // Act
    sut.lost_point();

    // Assert
    EXPECT_EQ(Scores::AdvantageWon, sut.get_score());
}

TEST(GameScore, to_string_returns_string_for_current_score)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore sut { Thirty };

    // Act
    sut.lost_point();

    // Assert
    EXPECT_EQ("30", sut.to_string());
}
