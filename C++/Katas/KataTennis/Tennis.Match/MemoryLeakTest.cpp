#include "stdafx.h"
#include <memory>
#include "IMatch.h"
<<<<<<< HEAD
#include "MatchFactory.h"
#include "MemoryLeakTest.h"
#include "ScoreBoard.h"
#include "MatchStatusToStringConverter.h"
=======
#include "MemoryLeakTest.h"
#include "ScoreBoard.h"
#include "MatchStatusToStringConverter.h"
#include <iostream>
#include "PlayerNameManager.h"
#include "ITieBreakWinnerCalculator.h"
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Match
    {
        void MemoryLeakTest::create_games_won (
<<<<<<< HEAD
            Tennis::Logic::IMatch* match,
=======
            Logic::IMatch_Ptr match,
>>>>>>> Update from private repository
            Logic::Player player,
            size_t games_scored_by_player )
        {
            for ( size_t i = 1 ; i <= games_scored_by_player ; i++ )
            {
                for ( size_t j = 1 ; j <= POINTS_PER_GAME ; j++ )
                {
                    match->won_point ( player );
                }
            }
        }

        void MemoryLeakTest::create_set_with_score (
<<<<<<< HEAD
            Tennis::Logic::IMatch* match,
=======
            Logic::IMatch_Ptr match,
>>>>>>> Update from private repository
            size_t games_scored_by_player_one,
            size_t games_scored_by_player_two )
        {
            size_t current_one = 0;
            size_t current_two = 0;
            size_t count = games_scored_by_player_one + games_scored_by_player_two;

            for ( size_t games = 0 ; games < count ; )
            {
                if ( current_one < games_scored_by_player_one )
                {
                    create_games_won (
                                      match,
                                      Logic::One,
                                      1 );
                    games++;
                    current_one++;
                }

                if ( current_two < games_scored_by_player_two )
                {
                    create_games_won (
                                      match,
                                      Logic::Two,
                                      1 );
                    games++;
                    current_two++;
                }
            }
        }

<<<<<<< HEAD
        void MemoryLeakTest::player_on_wins_tie_break ( Tennis::Logic::IMatch* match )
        {
            match->won_point ( Tennis::Logic::One );
            match->won_point ( Tennis::Logic::Two );
            match->won_point ( Tennis::Logic::One );
            match->won_point ( Tennis::Logic::Two );
            match->won_point ( Tennis::Logic::Two );
            match->won_point ( Tennis::Logic::One );
            match->won_point ( Tennis::Logic::One );
            match->won_point ( Tennis::Logic::One );
            match->won_point ( Tennis::Logic::One );
            match->won_point ( Tennis::Logic::One );
        }

        void MemoryLeakTest::print_status ( Tennis::Logic::IMatch* match )
        {
            using namespace Tennis::Logic;
=======
        void MemoryLeakTest::player_on_wins_tie_break ( Logic::IMatch_Ptr match )
        {
            match->won_point ( Logic::One );
            match->won_point ( Logic::Two );
            match->won_point ( Logic::One );
            match->won_point ( Logic::Two );
            match->won_point ( Logic::Two );
            match->won_point ( Logic::One );
            match->won_point ( Logic::One );
            match->won_point ( Logic::One );
            match->won_point ( Logic::One );
            match->won_point ( Logic::One );
        }

        void MemoryLeakTest::print_status ( Logic::IMatch_Ptr match )
        {
            using namespace Logic;
>>>>>>> Update from private repository

            MatchStatus match_status = match->get_status();

            std::string status = MatchStatusToStringConverter::to_string ( match_status );

            std::cout << "Match Status: " << status << "\n";
        }

        void MemoryLeakTest::run () const
        {
<<<<<<< HEAD
            Logic::MatchFactory factory {};

            std::unique_ptr<Logic::IMatch> match = factory.create();

            std::unique_ptr<Logic::IGamesCounter> counter = std::make_unique<Logic::GamesCounter>();

            Logic::Logger logger { std::cout }; // todo shared ptr

            Logic::PlayerNameManager player_name_manager {
                &logger,
                "John",
                "Bill" };

            Logic::GamesCounter games_counter {};

            Logic::ScoreBoard score_board // todo factory
            {
                &player_name_manager,
                &games_counter,
                match->get_sets()
            };

            // first set 6:6
            create_set_with_score ( match.get(), 6, 6 );
            score_board.print ( std::cout );
            print_status ( match.get() );

            // first set - tiebreak points
            player_on_wins_tie_break ( match.get() );
            score_board.print ( std::cout );
            print_status ( match.get() );

            // second set 4:6
            create_set_with_score ( match.get(), 4, 6 );
            score_board.print ( std::cout );
            print_status ( match.get() );

            // third set 4:6
            create_set_with_score ( match.get(), 4, 6 );
            score_board.print ( std::cout );
            print_status ( match.get() );
=======
            using namespace Logic;

            // first set 6:6
            create_set_with_score ( m_match, 6, 6 );
            m_score_board->print ( std::cout );
            print_status ( m_match );

            // first set - tiebreak points
            player_on_wins_tie_break ( m_match );
            m_score_board->print ( std::cout );
            print_status ( m_match );

            // second set 4:6
            create_set_with_score ( m_match, 4, 6 );
            m_score_board->print ( std::cout );
            print_status ( m_match );

            // third set 4:6
            create_set_with_score ( m_match, 4, 6 );
            m_score_board->print ( std::cout );
            print_status ( m_match );
>>>>>>> Update from private repository
        }
    }
}
