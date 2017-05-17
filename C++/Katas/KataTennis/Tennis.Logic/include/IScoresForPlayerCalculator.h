#pragma once

#pragma once
#include "Player.h"
#include <string>
#include "ISets.h"

namespace Tennis
{
    namespace Logic
    {
        class IScoresForPlayerCalculator
        {
        public:
            virtual ~IScoresForPlayerCalculator () = default;

            virtual std::string get_scores_for_player (
                const Player player,
                const ISets_Ptr sets ) const = 0;
        };

        typedef std::shared_ptr<IScoresForPlayerCalculator> IScoresForPlayerCalculator_Ptr;
    }
}
