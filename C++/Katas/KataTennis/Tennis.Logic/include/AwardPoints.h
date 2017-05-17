#pragma once
#include "Player.h"
#include "IAwardPoints.h"
<<<<<<< HEAD
#include "ILogger.h"
#include <memory>
=======
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        class IGameScore;

        class AwardPoints
                : public IAwardPoints
        {
        private:
            std::unique_ptr<ILogger> m_logger;

        public:
            AwardPoints ( std::unique_ptr<ILogger> logger )
                : m_logger ( std::move ( logger ) )
            {
            }

=======
        class AwardPoints
                : public IAwardPoints
        {
        public:
>>>>>>> Update from private repository
            ~AwardPoints ()
            {
            }

<<<<<<< HEAD
            void award_point(
=======
            void award_point (
>>>>>>> Update from private repository
                const Player player,
                IGameScore* scorePlayerOne,
                IGameScore* scorePlayerTwo ) override;
        };
    };
};
