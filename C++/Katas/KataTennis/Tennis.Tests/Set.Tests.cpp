#include "stdafx.h"
#include <gtest/gtest.h>
#include "Set.h"
#include <gmock/gmock-generated-function-mockers.h>
#include "MockIGame.h"
#include "MockIGames.h"
#include <functional>
#include "MemoryInfo.h"
#include "MockILogger.h"
#include "GamesCounter.h"
#include "MockIGamesCounter.h"
#include "MockITieBreak.h"
#include "SetWonPointHandler.h"
#include "MockISetWonPointHandler.h"
#include "SetStatusCalculator.h"
#include "MockISetStatusCalculator.h"
#include "MockISet.h"
#include "Games.h"
#include "CountPlayerGames.h"
#include "TieBreakWinnerCalculator.h"
#include "Sets.h"
#include "TieBreak.h"

std::function<std::shared_ptr<Tennis::Logic::ISet>  ()> create_set ();
Hypodermic::FactoryWrapper<Tennis::Logic::ISet> wrapper_set { create_set() };
Tennis::Logic::ISets_Ptr sets = std::make_shared<Tennis::Logic::Sets> ( wrapper_set );

std::function<std::shared_ptr<Tennis::Logic::IGame>  ()> create_game ();
Hypodermic::FactoryWrapper<Tennis::Logic::IGame> wrapper_game { create_game() };
Tennis::Logic::IGames_Ptr games = std::make_shared<Tennis::Logic::Games> ( wrapper_game );

std::function<std::shared_ptr<Tennis::Logic::IGame>  ()> create_game ()
{
    return []
            {
                using namespace Tennis::Logic;

                IAwardPoints_Ptr award_points = std::make_shared<AwardPoints>();
                IGameScore_Ptr game_score_one = std::make_shared<GameScore>();
                IGameScore_Ptr game_score_two = std::make_shared<GameScore>();

                return std::make_shared<Game> ( award_points,
                                                game_score_one,
                                                game_score_two );
            };
}

std::function<std::shared_ptr<Tennis::Logic::ISet>  ()> create_set ()
{
    return []
            {
                using namespace Tennis::Logic;

                IGamesCounter_Ptr games_counter_calculator = std::make_shared<GamesCounter>();
                ITieBreakWinnerCalculator_Ptr tie_break_winner_calculator = std::make_shared<TieBreakWinnerCalculator>();
                ICountPlayerGames_Ptr count_player_games =
                        std::make_shared<CountPlayerGames> ( games_counter_calculator,
                                                             tie_break_winner_calculator );
                ISetStatusCalculator_Ptr calculator =
                        std::make_shared<SetStatusCalculator> ( count_player_games );

                IGamesCounter_Ptr games_counter = std::make_shared<GamesCounter>();
                ISetWonPointHandler_Ptr handler =
                        std::make_shared<SetWonPointHandler> ( games_counter );

                IGames_Ptr games =
                        std::make_shared<Games> ( wrapper_game );
                ITieBreak_Ptr tie_break =
                        std::make_shared<TieBreak>();

                ISet_Ptr set = std::make_shared<Set> (
                                                      calculator,
                                                      handler,
                                                      games,
                                                      tie_break );

                set->initialize();

                return set;
            };
}

Tennis::Logic::ISet_Ptr create_sut ()
{
    // todo this is more an integration test!!! not a unit test
    using namespace Tennis::Logic;

    IGames_Ptr games = std::make_shared<Games> ( wrapper_game );
    ISets_Ptr sets = std::make_shared<Sets> ( wrapper_set );

    IGamesCounter_Ptr counter_for_handler = std::make_shared<GamesCounter>();
    ILogger_Ptr tie_break_logger = std::make_shared<MockILogger>();
    ITieBreak_Ptr tie_break = std::make_shared<TieBreak>();

    ISetWonPointHandler_Ptr handler =
            std::make_shared<SetWonPointHandler> ( counter_for_handler );

    IGamesCounter_Ptr count_player_games_counter = std::make_shared<GamesCounter>();
    ITieBreakWinnerCalculator_Ptr count_player_games_winner_calculator = std::make_shared<TieBreakWinnerCalculator>();
    ICountPlayerGames_Ptr count_player_games =
            std::make_shared<CountPlayerGames> (
                                                count_player_games_counter,
                                                count_player_games_winner_calculator );

    ISetStatusCalculator_Ptr calculator =
            std::make_shared<SetStatusCalculator> (
                                                   count_player_games );

    ISet_Ptr sut = std::make_shared<Set> (
                                          calculator,
                                          handler,
                                          games,
                                          tie_break );

    sut->initialize();

    return sut;
}

TEST(Set, get_current_game_returns_a_current_game)
{
    using namespace Tennis::Logic;

    // Arrange
    ISet_Ptr sut = create_sut();

    // Act
    IGame_Ptr actual = sut->get_current_game();

    // Assert
    EXPECT_NE(nullptr, &actual);
}

TEST(Set, getGames_returns_all_games)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected { 1 };
    ISet_Ptr sut = create_sut();

    // Act
    size_t actual = sut->get_games()->get_number_of_games();

    // Assert
    EXPECT_EQ(expected, actual);
}

TEST(Set, won_point_increases_score_for_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    ISet_Ptr sut = create_sut();

    // Act
    sut->won_point ( One );

    // Assert
    Scores actual = sut->get_current_game()->get_score_for_player ( One );

    EXPECT_EQ(Scores::Fifteen, actual);
}

TEST(Set, won_point_increases_score_for_player_one_but_not_for_player_two)
{
    using namespace Tennis::Logic;

    // Arrange
    ISet_Ptr sut = create_sut();

    // Act
    sut->won_point ( One );

    // Assert
    Scores actual = sut->get_current_game()->get_score_for_player ( Two );

    EXPECT_EQ(Scores::Love, actual);
}

TEST(Set, won_point_increases_score_for_player_two)
{
    using namespace Tennis::Logic;

    // Arrange
    ISet_Ptr sut = create_sut();

    // Act
    sut->won_point ( Two );

    // Assert
    Scores actual = sut->get_current_game()->get_score_for_player ( Two );

    EXPECT_EQ(Scores::Fifteen, actual);
}

TEST(Set, won_point_increases_score_for_player_two_but_not_for_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    ISet_Ptr sut = create_sut();

    // Act
    sut->won_point ( Two );

    // Assert
    Scores actual = sut->get_current_game()->get_score_for_player ( One );

    EXPECT_EQ(Scores::Love, actual);
}

void make_player_win_game ( Tennis::Logic::ISet_Ptr set,
                            Tennis::Logic::Player player )
{
    set->won_point ( player );
    set->won_point ( player );
    set->won_point ( player );
    set->won_point ( player );
}

TEST(Set, won_point_creates_new_game_for_player_one_won_game)
{
    using namespace Tennis::Logic;

    // Arrange
    ISet_Ptr sut = create_sut();
    IGame_Ptr old_game = sut->get_current_game();

    // Act
    make_player_win_game ( sut, One );

    // Assert
    IGame_Ptr actual = sut->get_current_game();

    EXPECT_NE(&old_game, &actual);
}

TEST(Set, won_point_creates_new_game_for_player_two_won_game)
{
    using namespace Tennis::Logic;

    // Arrange
    ISet_Ptr sut = create_sut();
    IGame_Ptr old_game = sut->get_current_game();

    // Act
    make_player_win_game ( sut, Two );

    // Assert
    IGame_Ptr actual = sut->get_current_game();

    EXPECT_NE(old_game, actual);
}

TEST(Set, won_point_adds_new_game_to_games_for_player_one_won_game)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected = 2;
    ISet_Ptr sut = create_sut();

    // Act
    make_player_win_game ( sut, One );

    // Assert
    size_t actual = sut->get_games_length();

    EXPECT_EQ(expected, actual);
}

TEST(Set, won_point_adds_new_game_to_games_for_player_two_won_game)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected = 2;
    ISet_Ptr sut = create_sut();

    // Act
    make_player_win_game ( sut, One );

    // Assert
    size_t actual = sut->get_games_length();

    EXPECT_EQ(expected, actual);
}

TEST(Set, get_games_returns_games)
{
    using namespace Tennis::Logic;

    // Arrange
    MockISetStatusCalculator* mock_calculator = new MockISetStatusCalculator();
    ISetStatusCalculator_Ptr calculator ( mock_calculator );
    MockIGames* mock_games = new MockIGames();
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak();
    ITieBreak_Ptr tie_break ( mock_tie_break );
    MockISetWonPointHandler* mock_handler = new MockISetWonPointHandler();
    ISetWonPointHandler_Ptr handler ( mock_handler );

    Set sut
    {
        calculator,
        handler,
        games,
        tie_break
    };

    // Assert
    const IGames_Ptr actual = sut.get_games();

    // Act
    EXPECT_EQ(games, actual);
}

TEST(Set, won_point_calls_handlers)
{
    using namespace Tennis::Logic;

    // Arrange
    ISetStatusCalculator_Ptr calculator = std::make_shared<MockISetStatusCalculator>();
    IGames_Ptr games = std::make_shared<MockIGames>();
    ITieBreak_Ptr tie_break = std::make_shared<MockITieBreak>();
    MockISetWonPointHandler* mock_handler = new MockISetWonPointHandler();
    ISetWonPointHandler_Ptr handler ( mock_handler );

    Set sut
    {
        calculator,
        handler,
        games,
        tie_break
    };

    // Assert
    EXPECT_CALL(*mock_handler, won_point(One))
                                              .Times ( 1 );

    // Act
    sut.won_point ( One );
}

TEST(Set, get_status_calls_calculator)
{
    using namespace Tennis::Logic;

    // Arrange
    IGames_Ptr games = std::make_shared<MockIGames>();
    ITieBreak_Ptr tie_break = std::make_shared<MockITieBreak>();

    MockISetStatusCalculator* mock_calculator = new MockISetStatusCalculator();
    ISetStatusCalculator_Ptr calculator ( mock_calculator );
    ISetWonPointHandler_Ptr handler = std::make_shared<MockISetWonPointHandler>();

    Set sut
    {
        calculator,
        handler,
        games,
        tie_break
    };

    // Assert
    EXPECT_CALL(*mock_calculator, get_status(games, tie_break))
                                                               .Times ( 1 )
                                                               .WillOnce ( testing::Return ( SetStatus_NotStarted ) );

    // Act
    sut.get_status();
}

TEST(Set, get_tie_break_calls_tie_break)
{
    using namespace Tennis::Logic;

    // Arrange
    ISetStatusCalculator_Ptr calculator = std::make_shared<MockISetStatusCalculator>();
    ISetWonPointHandler_Ptr handler = std::make_shared<MockISetWonPointHandler>();
    IGames_Ptr games = std::make_shared<MockIGames>();
    ITieBreak_Ptr tie_break = std::make_shared<MockITieBreak>();

    Set sut
    {
        calculator,
        handler,
        games,
        tie_break
    };

    // Act
    const ITieBreak_Ptr actual = sut.get_tie_break();

    // Assert
    EXPECT_NE(nullptr, actual);
}

TEST(Set, get_tie_break_status_returns_status)
{
    using namespace Tennis::Logic;

    // Arrange

    ISetStatusCalculator_Ptr calculator = std::make_shared<MockISetStatusCalculator>();
    ISetWonPointHandler_Ptr handler = std::make_shared<MockISetWonPointHandler>();
    IGames_Ptr games = std::make_shared<MockIGames>();
    MockITieBreak* mock_tie_break = new MockITieBreak();
    ITieBreak_Ptr tie_break ( mock_tie_break );

    Set sut
    {
        calculator,
        handler,
        games,
        tie_break
    };

    // Assert
    EXPECT_CALL(*mock_tie_break, get_status())
                                              .Times ( 1 )
                                              .WillOnce ( testing::Return ( TieBreakStatus_InProgress ) );

    // Act
    const TieBreakStatus actual = sut.get_tie_break_status();

    // Assert
    EXPECT_EQ(TieBreakStatus_InProgress, actual);
}

TEST(Set, initialize_calls_games_and_handler)
{
    using namespace Tennis::Logic;

    // Arrange
    IGame_Ptr game = std::make_shared<MockIGame>();
    ISetStatusCalculator_Ptr calculator = std::make_shared<MockISetStatusCalculator>();
    MockISetWonPointHandler* mock_handler = new MockISetWonPointHandler{};
    ISetWonPointHandler_Ptr handler ( mock_handler );
    MockIGames* mock_games = new MockIGames();
    IGames_Ptr games ( mock_games );
    ITieBreak_Ptr tie_break = std::make_shared<MockITieBreak>();

    Set sut
    {
        calculator,
        handler,
        games,
        tie_break
    };

    // Assert
    EXPECT_CALL(*mock_games, create_new_game())
                                               .Times ( 1 )
                                               .WillRepeatedly ( testing::Return ( game ) );

    EXPECT_CALL(*mock_handler, intitialize(games, tie_break))
                                                             .Times ( 1 );

    sut.initialize();
}
