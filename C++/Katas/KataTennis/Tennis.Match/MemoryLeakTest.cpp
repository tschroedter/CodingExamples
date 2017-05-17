#include "stdafx.h"
#include <memory>
#include "IMatch.h"
#include "MemoryLeakTest.h"
#include "ScoreBoard.h"
#include "MatchStatusToStringConverter.h"
#include <iostream>
#include "PlayerNameManager.h"
#include "ITieBreakWinnerCalculator.h"

namespace Tennis
{
    namespace Match
    {
        void MemoryLeakTest::create_games_won (
            Logic::IMatch_Ptr match,
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
            Logic::IMatch_Ptr match,
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

            MatchStatus match_status = match->get_status();

            std::string status = MatchStatusToStringConverter::to_string ( match_status );

            std::cout << "Match Status: " << status << "\n";
        }

        void MemoryLeakTest::run () const
        {
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
        }
    }
}
