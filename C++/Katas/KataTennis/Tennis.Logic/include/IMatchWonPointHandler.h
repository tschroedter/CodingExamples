#pragma once

<<<<<<< HEAD
=======
#include "ISets.h"

>>>>>>> Update from private repository
namespace Tennis
{
    namespace Logic
    {
        class IMatchWonPointHandler
        {
        public:
<<<<<<< HEAD
            virtual ~IMatchWonPointHandler() = default;

            virtual void won_point(const Player player) = 0;
=======
            virtual ~IMatchWonPointHandler () = default;

            virtual void initialize ( const ISets_Ptr sets ) = 0;
            virtual void won_point ( const Player player ) = 0;
>>>>>>> Update from private repository
        };
    };
};
