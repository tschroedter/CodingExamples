#include "stdafx.h"
#include <gtest/gtest.h>
#include "PossibleScores.h"
#include "Game.h"
#include "MockILogger.h"

static void createDeuce ( Tennis::Logic::Game* sut )
{
    sut->won_point ( Tennis::Logic::One );
    sut->won_point ( Tennis::Logic::One );
    sut->won_point ( Tennis::Logic::One );
    sut->won_point ( Tennis::Logic::Two );
    sut->won_point ( Tennis::Logic::Two );
    sut->won_point ( Tennis::Logic::Two );
}

std::unique_ptr<Tennis::Logic::Game> create_sut ()
{
    using namespace Tennis::Logic;

    std::unique_ptr<ILogger> logger = std::make_unique<MockILogger>();
    std::unique_ptr<ILogger> logger1 = std::make_unique<MockILogger>();
    std::unique_ptr<IAwardPoints> award_points = std::make_unique<AwardPoints> ( move ( logger1 ) ); // todo next
    std::unique_ptr<IGameScore> game_score_one = std::make_unique<GameScore>();
    std::unique_ptr<IGameScore> game_score_two = std::make_unique<GameScore>();
    std::unique_ptr<Game> sut =
            std::make_unique<Game> (
                                    move ( logger ),
                                    move ( award_points ),
                                    move ( game_score_one ),
                                    move ( game_score_two ) );

    return sut;
}

TEST(Game, constructor_sets_default_value_for_game_status)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act
    GameStatus actual = sut->get_status();

    // Assert
    EXPECT_EQ(GameStatus::NotStarted, actual);
}

TEST(Game, won_point_changes_status_to_InProgress)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act
    sut->won_point ( Player::One );

    // Assert
    GameStatus actual = sut->get_status();

    EXPECT_EQ(GameStatus::InProgress, actual);
}

TEST(Game, won_point_does_not_changes_status_for_score_15_to_0)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( One );

    // Assert
    EXPECT_EQ(GameStatus::InProgress, sut->get_status());
}

TEST(Game, won_point_does_not_changes_status_for_score_15_to_15)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( One );
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::InProgress, sut->get_status());
}

TEST(Game, won_point_does_not_changes_status_for_score_30_to_0)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( One );
    sut->won_point ( One );

    // Assert
    EXPECT_EQ(GameStatus::InProgress, sut->get_status());
}

TEST(Game, won_point_does_not_changes_status_for_score_30_to_15)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( One );
    sut->won_point ( One );
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::InProgress, sut->get_status());
}

TEST(Game, won_point_does_not_changes_status_for_score_30_to_30)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( One );
    sut->won_point ( One );
    sut->won_point ( Two );
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::InProgress, sut->get_status());
}

TEST(Game, won_point_does_not_changes_status_for_score_40_to_0)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( One );
    sut->won_point ( One );
    sut->won_point ( One );

    // Assert
    EXPECT_EQ(GameStatus::InProgress, sut->get_status());
}

TEST(Game, won_point_does_not_changes_status_for_score_40_to_15)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( One );
    sut->won_point ( One );
    sut->won_point ( One );
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::InProgress, sut->get_status());
}

TEST(Game, won_point_does_not_changes_status_for_score_40_to_30)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( One );
    sut->won_point ( One );
    sut->won_point ( One );
    sut->won_point ( Two );
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::InProgress, sut->get_status());
}

TEST(Game, won_point_does_not_changes_status_for_score_0_to_15)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::InProgress, sut->get_status());
}

TEST(Game, won_point_does_not_changes_status_for_score_0_to_30)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( Two );
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::InProgress, sut->get_status());
}

TEST(Game, won_point_does_not_changes_status_for_score_15_to_30)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( One );
    sut->won_point ( Two );
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::InProgress, sut->get_status());
}

TEST(Game, won_point_does_not_changes_status_for_score_0_to_40)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( Two );
    sut->won_point ( Two );
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::InProgress, sut->get_status());
}

TEST(Game, won_point_does_not_changes_status_for_score_15_to_40)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( One );
    sut->won_point ( Two );
    sut->won_point ( Two );
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::InProgress, sut->get_status());
}

TEST(Game, won_point_does_not_changes_status_for_score_30_to_40)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( One );
    sut->won_point ( One );
    sut->won_point ( Two );
    sut->won_point ( Two );
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::InProgress, sut->get_status());
}

TEST(Game, won_point_changes_status_to_Deuce_for_score_40_to_40)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    createDeuce ( sut.get() );

    // Assert
    EXPECT_EQ(GameStatus::Deuce, sut->get_status());
}

TEST(Game, won_point_changes_status_to_PlayerOneWon_for_player_one_won_without_Deuce)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( One );
    sut->won_point ( One );
    sut->won_point ( One );
    sut->won_point ( One );

    // Assert
    EXPECT_EQ(GameStatus::PlayerOneWon, sut->get_status());
}

TEST(Game, won_point_changes_status_to_PlayerTwoWon_for_player_two_won_without_Deuce)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( Two );
    sut->won_point ( Two );
    sut->won_point ( Two );
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::PlayerTwoWon, sut->get_status());
}

TEST(Game, player_one_won_point_after_Deuce_changes_status_to_AdvantagePlayerOne)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    // Act    
    sut->won_point ( One );
    sut->won_point ( One );
    sut->won_point ( One );
    sut->won_point ( Two );
    sut->won_point ( Two );
    sut->won_point ( Two );
    sut->won_point ( One );

    // Assert
    EXPECT_EQ(GameStatus::AdvandtagePlayerOne, sut->get_status());
}

TEST(Game, player_two_won_point_after_Deuce_changes_status_to_AdvantagePlayerTwo)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();
    createDeuce ( sut.get() );

    // Act    
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::AdvandtagePlayerTwo, sut->get_status());
}

TEST(Game, player_one_won_point_after_Advantage_changes_status_to_PlayerOneWon)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();
    createDeuce ( sut.get() );

    // Act    
    sut->won_point ( One );
    sut->won_point ( One );

    // Assert
    EXPECT_EQ(GameStatus::PlayerOneWon, sut->get_status());
}

TEST(Game, player_two_won_point_after_Advantage_changes_status_to_PlayerTwoWon)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();
    createDeuce ( sut.get() );

    // Act    
    sut->won_point ( Two );
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::PlayerTwoWon, sut->get_status());
}

TEST(Game, player_one_won_point_after_Advantage_for_player_two_changes_status_to_Deuce)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();
    createDeuce ( sut.get() );
    sut->won_point ( Two );

    // Act    
    sut->won_point ( One );

    // Assert
    EXPECT_EQ(GameStatus::Deuce, sut->get_status());
}

TEST(Game, player_two_won_point_after_Advantage_for_player_one_changes_status_to_Deuce)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();
    createDeuce ( sut.get() );

    // Act    
    sut->won_point ( One );
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::Deuce, sut->get_status());
}

TEST(Game, won_point_handles_multiple_Advantage_Deuce_points)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();
    createDeuce ( sut.get() );

    // Act    
    sut->won_point ( One );
    sut->won_point ( Two );
    sut->won_point ( One );
    sut->won_point ( Two );
    sut->won_point ( One );
    sut->won_point ( Two );

    // Assert
    EXPECT_EQ(GameStatus::Deuce, sut->get_status());
}

TEST(Game, getScoreForPlayer_returns_score_for_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    sut->won_point ( One );

    // Act    
    Scores actual = sut->get_score_for_player ( One );

    // Assert
    EXPECT_EQ(Scores::Fifteen, actual);
}

TEST(Game, get_score_for_player_returns_score_for_player_two)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    sut->won_point ( Two );
    sut->won_point ( Two );

    // Act    
    Scores actual = sut->get_score_for_player ( Two );

    // Assert
    EXPECT_EQ(Scores::Thirty, actual);
}

TEST(Game, get_score_for_player_as_string_returns_score_as_string_for_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    sut->won_point ( One );

    // Act    
    std::string actual = sut->get_score_for_player_as_string( One );

    // Assert
    EXPECT_EQ("15", actual);
}

TEST(Game, get_score_for_player_as_string_returns_score_as_string_for_player_two)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Game> sut = create_sut();

    sut->won_point ( Two );
    sut->won_point ( Two );

    // Act    
    std::string actual = sut->get_score_for_player_as_string( Two );

    // Assert
    EXPECT_EQ("30", actual);
}
