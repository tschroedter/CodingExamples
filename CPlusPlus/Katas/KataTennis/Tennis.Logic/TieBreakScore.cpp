#include <cstdint>
#include <string>
#include "include/TieBreakScore.h"

namespace Tennis
{
    namespace Logic
    {
        std::string TieBreakScore::to_string () const
        {
            return std::to_string ( m_score );
        }

        void TieBreakScore::won_point ()
        {
            m_score++;
        }

        uint8_t TieBreakScore::get_score () const
        {
            return m_score;
        }
    }
}
