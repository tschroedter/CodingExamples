#pragma once

#include "include/Game.h"
#include "AwardPointsFactory.h"
<<<<<<< HEAD
=======
#include "include/IGameFactory.h"
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        class GameFactory // todo interface
        {
        private:
            AwardPointsFactory m_factory {};

        public:
            GameFactory ()
            {
            }

            IGame* create () const;
            static void release ( IGame* game );
=======
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
>>>>>>> Update from private repository
        };
    }
}
