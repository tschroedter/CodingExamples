#pragma once

#pragma once
#include "Games.h"

namespace Tennis
{
    namespace Logic
    {
        class ITieBreakScore
        {
        public:
            virtual ~ITieBreakScore () = default;

            virtual std::string to_string () const = 0;
            virtual void won_point () = 0;
            virtual uint8_t get_score () const = 0;
        };
    };
};
