#pragma once
#include "ITieBreak.h"
#include "ITieBreakScore.h"
#include "TieBreakScore.h"

namespace Tennis
{
    namespace Logic
    {
        class TieBreak
                : public ITieBreak
        {
        private:
            std::unique_ptr<ILogger> m_logger;
            std::unique_ptr<ITieBreakScore> m_score_player_one;
            std::unique_ptr<ITieBreakScore> m_score_player_two;
        public:
            TieBreak ( std::unique_ptr<ILogger> logger )
                : m_logger ( std::move ( logger ) )
            {
                m_score_player_one = std::make_unique<TieBreakScore>();
                m_score_player_two = std::make_unique<TieBreakScore>();
            }

            ~TieBreak ()
            {
            }

            void won_point ( Player player ) override;
            uint8_t get_score ( Player player ) const override;
            TieBreakStatus get_status () const override;
        };
    }
}
