#pragma once
#include "Player.h"
#include "PossibleScores.h"
#include "GameStatus.h"

namespace Tennis
{
    namespace Logic
    {
        class IGame
        {
        public:
            virtual ~IGame () = default;

            virtual void won_point ( const Player player ) = 0;
            virtual GameStatus get_status () const = 0;
            virtual Scores get_score_for_player ( const Player player ) const = 0;
            virtual std::string get_score_for_player_as_string ( const Player player ) const = 0;
        };
    };
};
