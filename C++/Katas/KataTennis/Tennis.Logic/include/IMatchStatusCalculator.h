#pragma once
#include "MatchStatus.h"

namespace Tennis
{
    namespace Logic
    {
        class IMatchStatusCalculator
        {
        public:
            virtual ~IMatchStatusCalculator() = default;

            virtual const MatchStatus get_status() const = 0;
        };
    };
};
