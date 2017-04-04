#pragma once

#include "include/Game.h"
#include "AwardPointsFactory.h"

namespace Tennis
{
    namespace Logic
    {
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
        };
    }
}
