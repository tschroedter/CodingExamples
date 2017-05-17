//
// Tennis.Match.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "MemoryInfo.h"
#include "MemoryLeakTest.h"
#include "Logger.h"
#include "PlayMatch.h"
#include "BaseException.h"

#include "Hypodermic/ContainerBuilder.h"
#include "IOCContainerBuilder.h"
#include "IGameScore.h"
#include "IPlayerNameManager.h"
#include "ScoreBoard.h"

void memory_leak_test ()
{
    MemoryInfo mi {};
    mi.snapshot();

    std::cout << "Running memory leak test..." << "\n";

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

        test.run();
        i++;
    }

    mi.snapshot();
    mi.calculate_deltas();
    mi.print_delta();
}

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
}
