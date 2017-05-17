#include "stdafx.h"
#include <gtest/gtest.h>
#include "MockILogger.h"
#include "TieBreak.h"

std::unique_ptr<Tennis::Logic::ITieBreak> create_sut ()
{
<<<<<<< HEAD
    std::unique_ptr<Tennis::Logic::ILogger> logger = std::make_unique<MockILogger>();

    std::unique_ptr<Tennis::Logic::ITieBreak> sut =
            std::make_unique<Tennis::Logic::TieBreak> ( std::move ( logger ) );
=======
    std::unique_ptr<Tennis::Logic::ITieBreak> sut =
            std::make_unique<Tennis::Logic::TieBreak>();
>>>>>>> Update from private repository

    return sut;
}

TEST(TieBreak, constructor_sets_default_value_for_score_for_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    // Act
    std::unique_ptr<ITieBreak> sut = create_sut();

    // Assert
    EXPECT_EQ(0, sut->get_score( Player::One ));
}

TEST(TieBreak, constructor_sets_default_value_for_score_for_player_two)
{
    using namespace Tennis::Logic;

    // Arrange
    // Act
    std::unique_ptr<ITieBreak> sut = create_sut();

    // Assert
    EXPECT_EQ(0, sut->get_score(Player::Two));
}

TEST(TieBreak, won_point_increases_score_for_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<ITieBreak> sut = create_sut();

    // Act
<<<<<<< HEAD
    sut->won_point ( Player::One );
=======
    sut->won_point ( One );
>>>>>>> Update from private repository

    // Assert
    EXPECT_EQ(1, sut->get_score(Player::One));
}

TEST(TieBreak, won_point_increases_score_for_player_one_twice)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<ITieBreak> sut = create_sut();

    // Act
<<<<<<< HEAD
    sut->won_point ( Player::One );
    sut->won_point ( Player::One );
=======
    sut->won_point ( One );
    sut->won_point ( One );
>>>>>>> Update from private repository

    // Assert
    EXPECT_EQ(2, sut->get_score(Player::One));
}

TEST(TieBreak, won_point_increases_score_for_player_two)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<ITieBreak> sut = create_sut();

    // Act
<<<<<<< HEAD
    sut->won_point ( Player::Two );
=======
    sut->won_point ( Two );
>>>>>>> Update from private repository

    // Assert
    EXPECT_EQ(1, sut->get_score(Player::Two));
}

TEST(TieBreak, won_point_increases_score_for_player_two_twice)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<ITieBreak> sut = create_sut();

    // Act
<<<<<<< HEAD
    sut->won_point ( Player::Two );
    sut->won_point ( Player::Two );
=======
    sut->won_point ( Two );
    sut->won_point ( Two );
>>>>>>> Update from private repository

    // Assert
    EXPECT_EQ(2, sut->get_score(Player::Two));
}

<<<<<<< HEAD
TEST(TieBreak, get_status_calls_calculate) // todo mock might be better
=======
TEST(TieBreak, get_status_calls_calculate)
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<ITieBreak> sut = create_sut();

    // Act
    TieBreakStatus actual = sut->get_status();

    // Assert
<<<<<<< HEAD
    EXPECT_EQ(TieBreakStatus_NotStarted, sut->get_score(Player::Two));
=======
    EXPECT_EQ(TieBreakStatus_NotStarted, actual);
>>>>>>> Update from private repository
}
