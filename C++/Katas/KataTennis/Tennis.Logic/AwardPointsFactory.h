#pragma once

#pragma once
#include "include/IAwardPoints.h"

namespace Tennis
{
    namespace Logic
    {
        class AwardPointsFactory // todo interface
        {
        private:
        public:
            AwardPointsFactory ()
            {
            }

            IAwardPoints* create () const;
        };
    }
}
