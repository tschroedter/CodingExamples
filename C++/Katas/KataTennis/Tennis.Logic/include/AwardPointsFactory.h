#pragma once
#include "include/IAwardPoints.h"
#include "include/IAwardPointsFactory.h"

namespace Tennis
{
    namespace Logic
    {
        class AwardPointsFactory
                : public IAwardPointsFactory
        {
        public:
            AwardPointsFactory ()
            {
            }

            std::unique_ptr<IAwardPoints> create () const override;
        };
    }
}
