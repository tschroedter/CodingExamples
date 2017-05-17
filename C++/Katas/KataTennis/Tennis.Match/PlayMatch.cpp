#include "stdafx.h"
#include <memory>
#include "IMatch.h"
#include "ScoreBoard.h"
#include "MatchStatusToStringConverter.h"
#include <iostream>
#include "InputPlayerNames.h"
#include "PlayMatch.h"
#include "PlayerNameManager.h"

namespace Tennis
{
    namespace Match
    {
        int PlayMatch::get_int_1_or_2 ()
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

        Logic::Player PlayMatch::ask_which_player_won_point ()
        {
            using namespace Logic;

            std::cout << "Which player won a point (1 or 2)? ";

            int choice = get_int_1_or_2();

            return choice == 1 ? One : Two;
        }

        void PlayMatch::run () const
        {
            using namespace Logic;

            InputPlayerNames input {};

            std::string player_name_one = input.get_player_name ( "1. Player name? " );
            std::string player_name_two = input.get_player_name ( "2. Player name? " );

            IPlayerNameManager_Ptr player_name_manager = m_container->resolve<IPlayerNameManager>();
            player_name_manager->set_player_name ( One, player_name_one );
            player_name_manager->set_player_name ( Two, player_name_two );

            IMatch_Ptr match = m_container->resolve<IMatch>();
            match->initialize();

            IScoreBoard_Ptr score_board = m_container->resolve<IScoreBoard>();
            score_board->initialize ( match->get_sets(), player_name_manager );

            MatchStatus match_status;
            do
            {
                Player player = ask_which_player_won_point();

                match->won_point ( player );

                score_board->print ( std::cout );

                match_status = match->get_status();
            }
            while ( MatchStatus_PlayerOneWon != match_status &&
                MatchStatus_PlayerTwoWon != match_status );

            std::string status = MatchStatusToStringConverter {}.to_string ( match->get_status() );

            std::cout << status << "\n";
        }
    }
}
