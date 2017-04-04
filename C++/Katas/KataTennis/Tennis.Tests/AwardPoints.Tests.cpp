#include "stdafx.h"
#include <gtest/gtest.h>
#include "AwardPoints.h"
#include "MockILogger.h"
#include "Scores.h"
#include "GameScore.h"

std::unique_ptr<Tennis::Logic::AwardPoints> create_sut () // todo return unique
{
    using namespace Tennis::Logic;

    std::unique_ptr<ILogger> logger = std::make_unique<MockILogger>();

    std::unique_ptr<AwardPoints> sut = std::make_unique<AwardPoints> ( std::move ( logger ) );

    return sut;
}

// Player One

TEST(AwardPoints, award_point_returns_15_to_Love_for_player_one_scores_at_Love_all)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one {};
    GameScore score_player_two {};
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( One,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::Fifteen, score_player_one.get_score());
    EXPECT_EQ(Scores::Love, score_player_two.get_score());
}

TEST(AwardPoints, award_point_returns_30_to_Love_for_player_one_scores_at_15_to_Love)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one { Fifteen };
    GameScore score_player_two {};
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( One,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::Thirty, score_player_one.get_score());
    EXPECT_EQ(Scores::Love, score_player_two.get_score());
}

TEST(AwardPoints, award_point_returns_40_to_Love_for_player_one_scores_at_30_to_Love)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one { Thirty };
    GameScore score_player_two {};
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( One,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::Forty, score_player_one.get_score());
    EXPECT_EQ(Scores::Love, score_player_two.get_score());
}

TEST(AwardPoints, award_point_returns_Advantage_to_Love_for_player_one_scores_at_40_to_Love)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one { Forty };
    GameScore score_player_two {};
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( One,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::Advantage, score_player_one.get_score());
    EXPECT_EQ(Scores::Love, score_player_two.get_score());
}

TEST(AwardPoints, award_point_returns_AdvantageWon_to_Love_for_player_one_scores_at_Advantage_to_Love)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one { Advantage };
    GameScore score_player_two {};
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( One,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::AdvantageWon, score_player_one.get_score());
    EXPECT_EQ(Scores::Love, score_player_two.get_score());
}

TEST(AwardPoints, award_point_returns_Advantage_to_Forty_for_player_one_scores_at_Forty_to_Forty)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one { Forty };
    GameScore score_player_two { Forty };
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( One,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::Advantage, score_player_one.get_score());
    EXPECT_EQ(Scores::Forty, score_player_two.get_score());
}

TEST(AwardPoints, award_point_returns_Advantage_Won_to_Forty_for_player_one_scores_at_Advantage_to_Forty)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one { Advantage };
    GameScore score_player_two { Forty };
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( One,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::AdvantageWon, score_player_one.get_score());
    EXPECT_EQ(Scores::Forty, score_player_two.get_score());
}

// Player Two

TEST(AwardPoints, award_point_returns_Love_to_15_for_player_two_scores_at_Love_all)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one {};
    GameScore score_player_two {};
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( Two,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::Love, score_player_one.get_score());
    EXPECT_EQ(Scores::Fifteen, score_player_two.get_score());
}

TEST(AwardPoints, award_point_returns_Love_to_30_for_player_two_scores_at_Love_to_15)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one {};
    GameScore score_player_two { Fifteen };
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( Two,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::Love, score_player_one.get_score());
    EXPECT_EQ(Scores::Thirty, score_player_two.get_score());
}

TEST(AwardPoints, award_point_returns_Love_to_40_for_player_two_scores_at_Love_to_30)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one {};
    GameScore score_player_two { Thirty };
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( Two,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::Love, score_player_one.get_score());
    EXPECT_EQ(Scores::Forty, score_player_two.get_score());
}

TEST(AwardPoints, award_point_returns_Love_to_Advantage_for_player_two_scores_at_Love_to_40)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one {};
    GameScore score_player_two { Forty };
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( Two,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::Love, score_player_one.get_score());
    EXPECT_EQ(Scores::Advantage, score_player_two.get_score());
}

TEST(AwardPoints, award_point_returns_Love_to_AdvantageWon_for_player_two_scores_at_Love_to_Advantage)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one {};
    GameScore score_player_two { Advantage };
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( Two,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::Love, score_player_one.get_score());
    EXPECT_EQ(Scores::AdvantageWon, score_player_two.get_score());
}

TEST(AwardPoints, award_point_return_Forty_to_Advantage_for_player_one_scores_at_Forty_to_Forty)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one { Forty };
    GameScore score_player_two { Forty };
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( Two,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::Forty, score_player_one.get_score());
    EXPECT_EQ(Scores::Advantage, score_player_two.get_score());
}

TEST(AwardPoints, award_point_return_Forty_to_AdvantageWon_for_player_one_scores_at_Forty_to_Advantage)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one { Forty };
    GameScore score_player_two { Advantage };
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( Two,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::Forty, score_player_one.get_score());
    EXPECT_EQ(Scores::AdvantageWon, score_player_two.get_score());
}

// Deuce

TEST(AwardPoints, award_point_return_Forty_to_Forty_for_player_one_scores_at_Forty_to_Advantage)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one { Forty };
    GameScore score_player_two { Advantage };
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( One,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::Forty, score_player_one.get_score());
    EXPECT_EQ(Scores::Forty, score_player_two.get_score());
}

TEST(AwardPoints, award_point_return_Forty_to_Forty_for_player_two_scores_at_Advantage_to_Forty)
{
    using namespace Tennis::Logic;

    // Arrange
    GameScore score_player_one { Advantage };
    GameScore score_player_two { Forty };
    std::unique_ptr<Tennis::Logic::AwardPoints> sut = create_sut();

    // Act
    sut->award_point ( Two,
                       &score_player_one,
                       &score_player_two );

    // Assert
    EXPECT_EQ(Scores::Forty, score_player_one.get_score());
    EXPECT_EQ(Scores::Forty, score_player_two.get_score());
}
