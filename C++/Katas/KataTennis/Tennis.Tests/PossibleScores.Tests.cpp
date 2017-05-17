#include "stdafx.h"
#include <gtest/gtest.h>
#include "PossibleScores.h"

<<<<<<< HEAD
TEST(PossibleScores, previous_score_returns_UnknownForUnknown)
=======
void test_to_string (
    Tennis::Logic::Scores current_score,
    std::string expected )
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
    PossibleScores sut {};
<<<<<<< HEAD
    sut.m_current = Unknown;

    // Act
    sut.previous_score();

    // Assert
    EXPECT_EQ(Scores::Unknown, sut.m_current);
}

TEST(PossibleScores, previous_score_returns_LoveForLove)
=======
    sut.m_current = current_score;

    // Act
    std::string actual = sut.to_string();

    // Assert
    EXPECT_EQ(expected, actual);
}

void test_next_score (
    Tennis::Logic::Scores current_score,
    Tennis::Logic::Scores expected )
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
    PossibleScores sut {};
<<<<<<< HEAD
    sut.m_current = Love;

    // Act
    sut.previous_score();

    // Assert
    EXPECT_EQ(Scores::Love, sut.m_current);
}

TEST(PossibleScores, previous_score_returns_FifteenForFifteen)
=======
    sut.m_current = current_score;

    // Act
    sut.next_score();

    // Assert
    EXPECT_EQ(expected, sut.m_current);
}

void test_previous_score (
    Tennis::Logic::Scores current_score,
    Tennis::Logic::Scores expected
)
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
    PossibleScores sut {};
<<<<<<< HEAD
    sut.m_current = Fifteen;
=======
    sut.m_current = current_score;
>>>>>>> Update from private repository

    // Act
    sut.previous_score();

    // Assert
<<<<<<< HEAD
    EXPECT_EQ(Scores::Fifteen, sut.m_current);
}

TEST(PossibleScores, previous_score_returns_ThirtyForThirty)
{
    using namespace Tennis::Logic;

    // Arrange
    PossibleScores sut {};
    sut.m_current = Thirty;

    // Act
    sut.previous_score();

    // Assert
    EXPECT_EQ(Scores::Thirty, sut.m_current);
}

TEST(PossibleScores, previous_score_returns_Forty_for_Forty)
{
    using namespace Tennis::Logic;

    // Arrange
    PossibleScores sut {};
    sut.m_current = Forty;

    // Act
    sut.previous_score();

    // Assert
    EXPECT_EQ(Scores::Forty, sut.m_current);
}

TEST(PossibleScores, previous_score_returns_Deuce_for_Advantage)
{
    using namespace Tennis::Logic;

    // Arrange
    PossibleScores sut {};
    sut.m_current = Advantage;

    // Act
    sut.previous_score();

    // Assert
    EXPECT_EQ(Scores::Forty, sut.m_current);
=======
    EXPECT_EQ(expected, sut.m_current);
}

TEST(PossibleScores, previous_score_returns_UnknownForUnknown)
{
    using namespace Tennis::Logic;

    test_previous_score (
                         Unknown,
                         Unknown
                        );
}

TEST(PossibleScores, previous_score_returns_LoveForLove)
{
    using namespace Tennis::Logic;

    test_previous_score (
                         Love,
                         Love
                        );
}

TEST(PossibleScores, previous_score_returns_FifteenForFifteen)
{
    using namespace Tennis::Logic;

    test_previous_score (
                         Fifteen,
                         Fifteen
                        );
}

TEST(PossibleScores, previous_score_returns_ThirtyForThirty)
{
    using namespace Tennis::Logic;

    test_previous_score (
                         Thirty,
                         Thirty
                        );
}

TEST(PossibleScores, previous_score_returns_Forty_for_Forty)
{
    using namespace Tennis::Logic;

    test_previous_score (
                         Forty,
                         Forty
                        );
}

TEST(PossibleScores, previous_score_returns_Deuce_for_Advantage)
{
    using namespace Tennis::Logic;

    test_previous_score (
                         Advantage,
                         Forty
                        );
>>>>>>> Update from private repository
}

TEST(PossibleScores, previous_score_returns_AdvantageWon_for_AdvantageWon)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    PossibleScores sut {};
    sut.m_current = AdvantageWon;

    // Act
    sut.previous_score();

    // Assert
    EXPECT_EQ(Scores::AdvantageWon, sut.m_current);
}

TEST(PossibleScores, nextscore_returns_Unknown_for_Unknown)
{
    using namespace Tennis::Logic;

    // Arrange
    PossibleScores sut {};
    sut.m_current = Unknown;

    // Act
    sut.next_score();

    // Assert
    EXPECT_EQ(Scores::Unknown, sut.m_current);
}

TEST(PossibleScores, nextscore_returns_Fifteen_for_Love)
{
    using namespace Tennis::Logic;

    // Arrange
    PossibleScores sut {};
    sut.m_current = Love;

    // Act
    sut.next_score();

    // Assert
    EXPECT_EQ(Scores::Fifteen, sut.m_current);
}

TEST(PossibleScores, nextscore_returns_Thirty_for_Fifteen)
{
    using namespace Tennis::Logic;

    // Arrange
    PossibleScores sut {};
    sut.m_current = Fifteen;

    // Act
    sut.next_score();

    // Assert
    EXPECT_EQ(Scores::Thirty, sut.m_current);
}

TEST(PossibleScores, nextscore_returns_Forty_for_Thirty)
{
    using namespace Tennis::Logic;

    // Arrange
    PossibleScores sut {};
    sut.m_current = Thirty;

    // Act
    sut.next_score();

    // Assert
    EXPECT_EQ(Scores::Forty, sut.m_current);
}

TEST(PossibleScores, nextscore_returns_Deuce_for_Forty)
{
    using namespace Tennis::Logic;

    // Arrange
    PossibleScores sut {};
    sut.m_current = Forty;

    // Act
    sut.next_score();

    // Assert
    EXPECT_EQ(Scores::Advantage, sut.m_current);
}

TEST(PossibleScores, nextscore_returns_AdvantageWon_for_Advantage)
{
    using namespace Tennis::Logic;

    // Arrange
    PossibleScores sut {};
    sut.m_current = Advantage;

    // Act
    sut.next_score();

    // Assert
    EXPECT_EQ(Scores::AdvantageWon, sut.m_current);
}

TEST(PossibleScores, nextscore_returns_AdvantageWon_for_AdvantageWon)
{
    using namespace Tennis::Logic;

    // Arrange
    PossibleScores sut {};
    sut.m_current = AdvantageWon;

    // Act
    sut.next_score();

    // Assert
    EXPECT_EQ(Scores::AdvantageWon, sut.m_current);
=======
    test_previous_score (
                         AdvantageWon,
                         AdvantageWon
                        );
}

TEST(PossibleScores, next_score_returns_Unknown_for_Unknown)
{
    using namespace Tennis::Logic;

    test_next_score (
                     Unknown,
                     Unknown
                    );
}

TEST(PossibleScores, next_score_returns_Fifteen_for_Love)
{
    using namespace Tennis::Logic;

    test_next_score (
                     Love,
                     Fifteen
                    );
}

TEST(PossibleScores, next_score_returns_Thirty_for_Fifteen)
{
    using namespace Tennis::Logic;

    test_next_score (
                     Fifteen,
                     Thirty
                    );
}

TEST(PossibleScores, next_score_returns_Forty_for_Thirty)
{
    using namespace Tennis::Logic;

    test_next_score (
                     Thirty,
                     Forty
                    );
}

TEST(PossibleScores, next_score_returns_Deuce_for_Forty)
{
    using namespace Tennis::Logic;

    test_next_score (
                     Forty,
                     Advantage
                    );
}

TEST(PossibleScores, next_score_returns_AdvantageWon_for_Advantage)
{
    using namespace Tennis::Logic;

    test_next_score (
                     Advantage,
                     AdvantageWon
                    );
}

TEST(PossibleScores, next_score_returns_AdvantageWon_for_AdvantageWon)
{
    using namespace Tennis::Logic;

    test_next_score (
                     AdvantageWon,
                     AdvantageWon
                    );
>>>>>>> Update from private repository
}

TEST(PossibleScores, to_string_returns_0_for_rUnknown)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    PossibleScores sut {};
    sut.m_current = Unknown;

    // Act
    std::string actual = sut.to_string();

    // Assert
    EXPECT_EQ("Unknown", actual);
=======
    test_to_string (
                    Unknown,
                    "Unknown"
                   );
>>>>>>> Update from private repository
}

TEST(PossibleScores, to_string_returns_0_for_Love)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    PossibleScores sut {};
    sut.m_current = Love;

    // Act
    std::string actual = sut.to_string();

    // Assert
    EXPECT_EQ("0", actual);
=======
    test_to_string (
                    Love,
                    "0"
                   );
>>>>>>> Update from private repository
}

TEST(PossibleScores, to_string_returns_15_for_Fifteen)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    PossibleScores sut {};
    sut.m_current = Fifteen;

    // Act
    std::string actual = sut.to_string();

    // Assert
    EXPECT_EQ("15", actual);
=======
    test_to_string (
                    Fifteen,
                    "15"
                   );
>>>>>>> Update from private repository
}

TEST(PossibleScores, to_string_returns_30_for_Thirty)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    PossibleScores sut {};
    sut.m_current = Thirty;

    // Act
    std::string actual = sut.to_string();

    // Assert
    EXPECT_EQ("30", actual);
=======
    test_to_string (
                    Thirty,
                    "30"
                   );
>>>>>>> Update from private repository
}

TEST(PossibleScores, to_string_returns_40_for_Forty)
{
    using namespace Tennis::Logic;

<<<<<<< HEAD
    // Arrange
    PossibleScores sut {};
    sut.m_current = Forty;

    // Act
    std::string actual = sut.to_string();

    // Assert
    EXPECT_EQ("40", actual);
}

TEST(PossibleScores, to_string_returns_Advantage_for_rAdvantage)
{
    using namespace Tennis::Logic;

    // Arrange
    PossibleScores sut {};
    sut.m_current = Advantage;

    // Act
    std::string actual = sut.to_string();

    // Assert
    EXPECT_EQ("Advantage", actual);
}

TEST(PossibleScores, to_string_returns_Advantage_for_rAdvantageWon)
{
    using namespace Tennis::Logic;

    // Arrange
    PossibleScores sut {};
    sut.m_current = AdvantageWon;

    // Act
    std::string actual = sut.to_string();

    // Assert
    EXPECT_EQ("AdvantageWon", actual);
=======
    test_to_string (
                    Forty,
                    "40"
                   );
}

TEST(PossibleScores, to_string_returns_Advantage_for_Advantage)
{
    using namespace Tennis::Logic;

    test_to_string (
                    Advantage,
                    "Advantage"
                   );
}

TEST(PossibleScores, to_string_returns_Advantage_for_AdvantageWon)
{
    using namespace Tennis::Logic;

    test_to_string (
                    AdvantageWon,
                    "AdvantageWon"
                   );
>>>>>>> Update from private repository
}
