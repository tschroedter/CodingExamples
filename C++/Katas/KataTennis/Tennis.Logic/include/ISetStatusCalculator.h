#pragma once
#include "SetStatus.h"

namespace Tennis
{
    namespace Logic
    {
        class ISetStatusCalculator
        {
        public:
            virtual ~ISetStatusCalculator() = default;

            virtual const SetStatus get_status() const = 0;
        };
    };
};