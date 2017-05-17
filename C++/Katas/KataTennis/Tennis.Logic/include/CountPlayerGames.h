#pragma once

#include "Player.h"
#include "IGamesCounter.h"
#include "ITieBreakWinnerCalculator.h"
#include "ICountPlayerGames.h"

namespace Tennis
{
    namespace Logic
    {
        class CountPlayerGames
                : public ICountPlayerGames
        {
        private:
            IGamesCounter_Ptr m_counter;
            ITieBreakWinnerCalculator_Ptr m_calculator;

        public:
            CountPlayerGames (
                IGamesCounter_Ptr counter,
                ITieBreakWinnerCalculator_Ptr calculator )
                : m_counter ( counter )
                , m_calculator ( calculator )
            {
            }

            std::string count_games(
                const Player player,
                const IGames_Ptr games,
                const ITieBreak_Ptr tie_break) const override;

            int8_t calculate_games(
                const Player player,
                const IGames_Ptr games,
                const ITieBreak_Ptr tie_break) const override;
        };
    };
};
