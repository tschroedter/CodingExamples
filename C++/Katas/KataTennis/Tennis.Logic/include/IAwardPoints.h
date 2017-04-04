#pragma once
#include "Player.h"

namespace Tennis
{
    namespace Logic
    {
        class IGameScore;
        class GameScore;

        class IAwardPoints
        {
        public:
            virtual ~IAwardPoints () = default;

            virtual void award_point (
                const Player player,
                IGameScore* scorePlayerOne,
                IGameScore* scorePlayerTwo ) = 0;
        };
    };
};
