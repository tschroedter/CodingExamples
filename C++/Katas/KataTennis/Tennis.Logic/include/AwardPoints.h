#pragma once
#include "Player.h"
#include "IAwardPoints.h"

namespace Tennis
{
    namespace Logic
    {
        class AwardPoints
                : public IAwardPoints
        {
        public:
            ~AwardPoints ()
            {
            }

            void award_point (
                const Player player,
                IGameScore* scorePlayerOne,
                IGameScore* scorePlayerTwo ) override;
        };
    };
};
