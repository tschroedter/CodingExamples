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
<<<<<<< HEAD
            virtual ~IMatchFactory() = default;

            virtual std::unique_ptr<IMatch> create() = 0;
=======
            virtual ~IMatchFactory () = default;

            virtual std::unique_ptr<IMatch> create () = 0;
>>>>>>> Update from private repository
        };
    }
}
