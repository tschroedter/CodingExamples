#pragma once
#include "IAwardPoints.h"

namespace Tennis
{
    namespace Logic
    {
        class IAwardPointsFactory
        {
        public:
            virtual ~IAwardPointsFactory () = default;

            virtual std::unique_ptr<IAwardPoints> create () const = 0;
        };
    }
}
