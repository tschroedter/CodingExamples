#pragma once

#include "Player.h"
#include "ISet.h"
#include "ICurrentPlayerScoreCalculator.h"

namespace Tennis
{
    namespace Logic
    {
        class ISet;

        class CurrentPlayerScoreCalculator
                : public ICurrentPlayerScoreCalculator
        {
        private:
            const size_t REDUCE_TO_2_DIGITS = 2;

        public:
            std::string get_current_score_for_player (
                const Player player,
                const ISet_Ptr set ) const override;
        };
    };
};
