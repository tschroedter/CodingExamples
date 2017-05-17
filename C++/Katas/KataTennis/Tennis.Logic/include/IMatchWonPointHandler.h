#pragma once

#include "ISets.h"

namespace Tennis
{
    namespace Logic
    {
        class IMatchWonPointHandler
        {
        public:
            virtual ~IMatchWonPointHandler () = default;

            virtual void initialize ( const ISets_Ptr sets ) = 0;
            virtual void won_point ( const Player player ) = 0;
        };
    };
};
