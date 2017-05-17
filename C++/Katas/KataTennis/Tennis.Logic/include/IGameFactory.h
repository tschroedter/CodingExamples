#pragma once

#include "IGame.h"
#include "IContainerFactory.h"

namespace Tennis
{
    namespace Logic
    {
        class IGameFactory
                : public IContainerFactory<IGame>
        {
        public:
            virtual ~IGameFactory () = default;
        };
    }
}
