#pragma once

#include "ITieBreakScore.h"

namespace Tennis
{
    namespace Logic
    {
        class TieBreakScore
                : public ITieBreakScore
        {
        private:
            uint8_t m_score {};
        public:
            TieBreakScore ( uint8_t score = 0 )
                : m_score ( score )
            {
            }

            ~TieBreakScore ()
            {
            }

            std::string to_string () const override;

            void won_point () override;

            uint8_t get_score () const override;
        };
    };
};
