#include "stdafx.h"
#include <gtest/gtest.h>
#include "Set.h"
#include <gmock/gmock-generated-function-mockers.h>
#include "MockIGame.h"
#include "MockIGames.h"
#include <functional>
#include "MemoryInfo.h"
#include "TieBreakFactory.h"
#include "MockILogger.h"
#include "GamesCounter.h"
#include "MockIGamesCounterr.h"
#include "MockITieBreak.h"
#include "SetWonPointHandler.h"
#include "MockISetWonPointHandler.h"
#include "SetStatusCalculator.h"
#include "MockISetStatusCalculator.h"

std::unique_ptr<Tennis::Logic::Set> createSet ()
{
    using namespace Tennis::Logic;

    std::unique_ptr<IGamesCounter> counter_for_calculator = std::make_unique<GamesCounter>();
    std::unique_ptr<IGamesCounter> counter_for_handler = std::make_unique<GamesCounter>();
    std::unique_ptr<GameFactory> game_factory = std::make_unique<GameFactory>();
    std::unique_ptr<IGames> games = std::make_unique<Games> ( std::move ( game_factory ) );
    std::unique_ptr<ILogger> logger = std::make_unique<MockILogger>();
    std::unique_ptr<TieBreakFactory> tie_break_factory = std::make_unique<TieBreakFactory> ( std::move ( logger ) );
    std::unique_ptr<ILogger> tie_break_logger = std::make_unique<MockILogger>();
    std::unique_ptr<ITieBreak> tie_break = std::make_unique<TieBreak> ( std::move ( tie_break_logger ) );

    std::unique_ptr<ISetWonPointHandler> handler =
            std::make_unique<SetWonPointHandler> (
                                               std::move ( counter_for_handler ),
                                               games.get(),
                                               tie_break.get() );

    std::unique_ptr<ISetStatusCalculator> calculator =
            std::make_unique<SetStatusCalculator> (
                                                   std::move ( counter_for_calculator ),
                                                   games.get(),
                                                   tie_break.get() );

    std::unique_ptr<Set> sut = std::make_unique<Set> (
                                                      std::move ( calculator ),
                                                      std::move ( handler ),
                                                      std::move ( games ),
                                                      std::move ( tie_break ) );

    return sut;
}

TEST(Set, get_current_gamereturns_a_current_game)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Set> sut = createSet();

    // Act
    IGame* actual = sut->get_current_game();

    // Assert
    EXPECT_NE(nullptr, &actual);
}

TEST(Set, getGames_returns_all_games)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected { 1 };
    std::unique_ptr<Set> sut = createSet();

    // Act
    size_t actual = sut->get_games()->get_length();

    // Assert
    EXPECT_EQ(expected, actual);
}

TEST(Set, won_point_increases_score_for_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Set> sut = createSet();

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
    std::unique_ptr<Set> sut = createSet();

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
    std::unique_ptr<Set> sut = createSet();

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
    std::unique_ptr<Set> sut = createSet();

    // Act
    sut->won_point ( Two );

    // Assert
    Scores actual = sut->get_current_game()->get_score_for_player ( One );

    EXPECT_EQ(Scores::Love, actual);
}

void make_player_win_game ( Tennis::Logic::Set* set,
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
    std::unique_ptr<Set> sut = createSet();
    IGame* old_game = sut->get_current_game();

    // Act
    make_player_win_game ( sut.get(), One );

    // Assert
    IGame* actual = sut->get_current_game();

    EXPECT_NE(&old_game, &actual);
}

TEST(Set, won_point_creates_new_game_for_player_two_won_game)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Set> sut = createSet();
    IGame* old_game = sut->get_current_game();

    // Act
    make_player_win_game ( sut.get(), Two );

    // Assert
    IGame* actual = sut->get_current_game();

    EXPECT_NE(old_game, actual);
}

TEST(Set, won_point_adds_new_game_to_games_for_player_one_won_game)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected = 2;
    std::unique_ptr<Set> sut = createSet();

    // Act
    make_player_win_game ( sut.get(), One );

    // Assert
    size_t actual = sut->get_games_length();

    EXPECT_EQ(expected, actual);
}

TEST(Set, won_point_adds_new_game_to_games_for_player_two_won_game)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected = 2;
    std::unique_ptr<Set> sut = createSet();

    // Act
    make_player_win_game ( sut.get(), One );

    // Assert
    size_t actual = sut->get_games_length();

    EXPECT_EQ(expected, actual);
}

TEST(Set, get_games_returns_games)
{
    using namespace Tennis::Logic;

    // Arrange
    MockISetStatusCalculator* mock_calculator = new MockISetStatusCalculator();
    std::unique_ptr<ISetStatusCalculator> calculator ( mock_calculator );
    MockIGames* mock_games = new MockIGames();
    std::unique_ptr<IGames> games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak();
    std::unique_ptr<ITieBreak> tie_break ( mock_tie_break );
    MockISetWonPointHandler* mock_handler = new MockISetWonPointHandler();
    std::unique_ptr<ISetWonPointHandler> handler ( mock_handler );

    Set sut
    {
        std::move ( calculator ),
        std::move ( handler ),
        std::move ( games ),
        std::move ( tie_break )
    };

    // Assert
    const IGames* actual = sut.get_games();

    // Act
    EXPECT_EQ(mock_games, actual);
}

TEST(Set, won_point_calls_handlers)
{
    using namespace Tennis::Logic;

    // Arrange
    MockISetStatusCalculator* mock_calculator = new MockISetStatusCalculator();
    std::unique_ptr<ISetStatusCalculator> calculator ( mock_calculator );
    MockIGame mock_game {};
    MockIGames* mock_games = new MockIGames();
    std::unique_ptr<IGames> games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak();
    std::unique_ptr<ITieBreak> tie_break ( mock_tie_break );
    MockISetWonPointHandler* mock_handler = new MockISetWonPointHandler();
    std::unique_ptr<ISetWonPointHandler> handler ( mock_handler );

    Set sut
    {
        std::move ( calculator ),
        std::move ( handler ),
        std::move ( games ),
        std::move ( tie_break )
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
    MockISetStatusCalculator* mock_calculator = new MockISetStatusCalculator();
    std::unique_ptr<ISetStatusCalculator> calculator ( mock_calculator );
    MockIGame mock_game {};
    MockIGames* mock_games = new MockIGames();
    std::unique_ptr<IGames> games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak();
    std::unique_ptr<ITieBreak> tie_break ( mock_tie_break );
    MockISetWonPointHandler* mock_handler = new MockISetWonPointHandler();
    std::unique_ptr<ISetWonPointHandler> handler ( mock_handler );

    Set sut
    {
        std::move ( calculator ),
        std::move ( handler ),
        std::move ( games ),
        std::move ( tie_break )
    };

    // Assert
    EXPECT_CALL(*mock_calculator, get_status())
                                               .Times ( 1 )
                                               .WillOnce ( testing::Return ( SetStatus_NotStarted ) );

    // Act
    sut.get_status();
}

TEST(Set, get_tie_break_calls_tie_break)
{
    using namespace Tennis::Logic;

    // Arrange
    MockISetStatusCalculator* mock_calculator = new MockISetStatusCalculator();
    std::unique_ptr<ISetStatusCalculator> calculator ( mock_calculator );
    MockIGame mock_game {};
    MockIGames* mock_games = new MockIGames();
    std::unique_ptr<IGames> games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak();
    std::unique_ptr<ITieBreak> tie_break ( mock_tie_break );
    MockISetWonPointHandler* mock_handler = new MockISetWonPointHandler();
    std::unique_ptr<ISetWonPointHandler> handler ( mock_handler );

    Set sut
    {
        std::move ( calculator ),
        std::move ( handler ),
        std::move ( games ),
        std::move ( tie_break )
    };

    // Act
    const ITieBreak* actual = sut.get_tie_break();

    // Assert
    EXPECT_NE(nullptr, actual);
}
