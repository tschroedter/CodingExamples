#pragma once

#include "TieBreak.h"

namespace Tennis
{
    namespace Logic
    {
        class TieBreakFactory // todo interface
        {
        private:
            std::unique_ptr<ILogger> m_logger;

        public:
            TieBreakFactory ( std::unique_ptr<ILogger> logger )
                : m_logger ( std::move ( logger ) )
            {
            }

            ITieBreak* create (); // todo release or unique_ptr
            static void release ( ITieBreak* tie_break );  // todo in se middle of doing stuff
        };
    }
}
