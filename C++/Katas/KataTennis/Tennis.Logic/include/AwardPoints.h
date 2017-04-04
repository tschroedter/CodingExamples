#pragma once
#include "Player.h"
#include "IAwardPoints.h"
#include "ILogger.h"
#include <memory>

namespace Tennis
{
    namespace Logic
    {
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

            ~AwardPoints ()
            {
            }

            void award_point(
                const Player player,
                IGameScore* scorePlayerOne,
                IGameScore* scorePlayerTwo ) override;
        };
    };
};
