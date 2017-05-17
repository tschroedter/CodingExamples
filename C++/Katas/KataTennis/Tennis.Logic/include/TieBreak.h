#pragma once
#include "ITieBreak.h"
#include "ITieBreakScore.h"
#include "TieBreakScore.h"
#include <memory>

namespace Tennis
{
    namespace Logic
    {
        class TieBreak
                : public ITieBreak
        {
        private:
            std::unique_ptr<ITieBreakScore> m_score_player_one;
            std::unique_ptr<ITieBreakScore> m_score_player_two;
        public:
            TieBreak ()
            {
                m_score_player_one = std::make_unique<TieBreakScore>();
                m_score_player_two = std::make_unique<TieBreakScore>();
            }

            void won_point ( const Player player ) override;
            uint8_t get_score ( const Player player ) const override;
            TieBreakStatus get_status () const override;
        };
    }
}
