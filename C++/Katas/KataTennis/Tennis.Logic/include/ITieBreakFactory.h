#pragma once
#include "ITieBreak.h"

namespace Tennis
{
    namespace Logic
    {
        class ITieBreakFactory
        {
        public:
            virtual ~ITieBreakFactory () = default;

            virtual ITieBreak* create () = 0;
            virtual void release ( ITieBreak* tie_break ) = 0;
        };
    }
}
