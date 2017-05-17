#pragma once

#include "Player.h"
#include "ISet.h"
#include "TieBreak.h"

namespace Tennis
{
    namespace Logic
    {
        class ICountPlayerGames
        {
        public:
            virtual ~ICountPlayerGames () = default;

            virtual int8_t calculate_games(
                const Player player,
                const IGames_Ptr games,
                const ITieBreak_Ptr tie_break) const = 0;
            
            virtual std::string count_games(
                const Player player,
                const IGames_Ptr games,
                const ITieBreak_Ptr tie_break) const = 0;
        };

        typedef std::shared_ptr<ICountPlayerGames> ICountPlayerGames_Ptr;
    };
};
