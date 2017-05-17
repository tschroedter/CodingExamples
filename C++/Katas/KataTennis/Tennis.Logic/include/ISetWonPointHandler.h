#pragma once

#include "Player.h"
#include <memory>
#include "IGames.h"
#include "ITieBreak.h"

namespace Tennis
{
    namespace Logic
    {
        class ISetWonPointHandler
        {
        public:
            virtual ~ISetWonPointHandler () = default;

            virtual void intitialize ( const IGames_Ptr games, const ITieBreak_Ptr tie_break ) = 0;
            virtual void won_game_point ( const Player player ) const = 0;
            virtual void won_tie_break_point ( const Player player ) const = 0;
            virtual void won_point ( const Player player ) const = 0;
            virtual bool is_tie_break_Required () const = 0;
        };

        typedef std::shared_ptr<ISetWonPointHandler> ISetWonPointHandler_Ptr;
    };
};
