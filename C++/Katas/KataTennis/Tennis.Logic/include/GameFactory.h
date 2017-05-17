#pragma once

#include "include/Game.h"
#include "include/IAwardPointsFactory.h"
#include "include/IGameFactory.h"

namespace Tennis
{
    namespace Logic
    {
        class GameFactory
                :public IGameFactory
        {
        private:
            std::shared_ptr<IAwardPointsFactory> m_factory;

        public:
            GameFactory ( std::shared_ptr<IAwardPointsFactory> factory )
                : m_factory ( std::move ( factory ) )
            {
            }

            ~GameFactory ()
            {
                m_factory.reset();
            }

            IGame* create () override;
            void release ( IGame* game ) override;
        };
    }
}
