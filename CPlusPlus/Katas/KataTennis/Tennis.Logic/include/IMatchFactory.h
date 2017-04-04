#pragma once
#include <memory>
#include "IMatch.h"

namespace Tennis
{
    namespace Logic
    {
        class IMatchFactory
        {
        public:
            virtual ~IMatchFactory() = default;

            virtual std::unique_ptr<IMatch> create() = 0;
        };
    }
}
