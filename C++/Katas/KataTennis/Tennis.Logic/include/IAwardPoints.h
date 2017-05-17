#pragma once
#include "Player.h"
#include <memory>

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

        typedef std::shared_ptr<IAwardPoints> IAwardPoints_Ptr;
    };
};
