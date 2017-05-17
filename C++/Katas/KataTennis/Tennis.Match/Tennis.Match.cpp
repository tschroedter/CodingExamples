<<<<<<< HEAD
// todo this is an ugly test class 
=======
>>>>>>> Update from private repository
//
// Tennis.Match.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "MemoryInfo.h"
#include "MemoryLeakTest.h"
<<<<<<< HEAD
#include "InputPlayerNames.h"
#include "IGamesCounter.h"
#include "GamesCounter.h"
#include "PlayerNameManager.h"
#include "ScoreBoard.h"
#include "MatchStatusToStringConverter.h"

void run_memory_leak_test ()
=======
#include "Logger.h"
#include "PlayMatch.h"
#include "BaseException.h"

#include "Hypodermic/ContainerBuilder.h"
#include "IOCContainerBuilder.h"
#include "IGameScore.h"
#include "IPlayerNameManager.h"
#include "ScoreBoard.h"

void memory_leak_test ()
>>>>>>> Update from private repository
{
    MemoryInfo mi {};
    mi.snapshot();

    std::cout << "Running memory leak test..." << "\n";

<<<<<<< HEAD
    int i = 0;
    while ( i < 1000 )
    {
        Tennis::Match::MemoryLeakTest test {};
=======
    using namespace Tennis::Match;
    IOCContainerBuilder builder;
    Container_Ptr container = builder.build();

    int i = 0;
    while ( i < 1000 )
    {
        using namespace Tennis::Logic;

        IPlayerNameManager_Ptr player_name_manager = container->resolve<IPlayerNameManager>();

        IMatch_Ptr match = container->resolve<IMatch>();
        match->initialize();

        IScoreBoard_Ptr score_board = container->resolve<IScoreBoard>();
        score_board->initialize(match->get_sets(),
            player_name_manager);

        MemoryLeakTest test
        { 
            match,
            score_board 
        };
>>>>>>> Update from private repository

        test.run();
        i++;
    }

    mi.snapshot();
    mi.calculate_deltas();
    mi.print_delta();
}

<<<<<<< HEAD
int get_int_1_or_2 ()
{
    int choice;
    do
    {
        std::cin >> choice;
    }
    while ( choice < 1 ||
        choice > 2 );

    return choice;
}

Tennis::Logic::Player ask_which_player_won_point ()
{
    using namespace Tennis::Logic;

    std::cout << "Which player won a point (1 or 2)? ";

    int choice = get_int_1_or_2();

    return choice == 1 ? One : Two;
}

void run_match ()
{
    using namespace Tennis::Logic;

    InputPlayerNames input {};

    std::string player_name_one = input.getPlayerName ( "1. Player name? " );
    std::string player_name_two = input.getPlayerName ( "2. Player name? " );

    MatchFactory factory {};

    std::unique_ptr<IMatch> match = factory.create();

    std::unique_ptr<ILogger> logger = std::make_unique<Logger> ( std::cout );

    std::unique_ptr<IPlayerNameManager> player_name_manager = std::make_unique<PlayerNameManager> (
                                                                                                   logger.get(),
                                                                                                   player_name_one,
                                                                                                   player_name_two );

    std::unique_ptr<IGamesCounter> games_counter = std::make_unique<GamesCounter>();

    ScoreBoard score_board
    {
        player_name_manager.get(),
        games_counter.get(),
        match->get_sets()
    };

    MatchStatus match_status;
    do
    {
        Player player = ask_which_player_won_point();

        match->won_point ( player );

        score_board.print ( std::cout );

        match_status = match->get_status();
    }
    while ( MatchStatus_PlayerOneWon != match_status &&
        MatchStatus_PlayerTwoWon != match_status );

    std::string status = MatchStatusToStringConverter {}.to_string ( match->get_status() );

    std::cout << status << "\n";
}

int main ()
{
    // run_memory_leak_test();

    run_match();

    return 0;
=======
void play_match ()
{
    using namespace Tennis::Match;
    IOCContainerBuilder builder;
    Container_Ptr container = builder.build();
    PlayMatch play_match { container };

    play_match.run();
}

int main ()
{
    Tennis::Logic::Logger logger { std::cout };

    int return_value = 0;

    try
    {
        // memory_leak_test();
        play_match();
    }
    catch ( Tennis::Logic::BaseException exception )
    {
        logger.error (
                      "Abnormal termination: "
                      + exception.get_error()
                      + "\n" );

        return_value = 1;
    }
    catch ( ... )
    {
        logger.error ( "Abnormal termination!!!\n" );

        return_value = 1;
    }

    return return_value;
>>>>>>> Update from private repository
}
