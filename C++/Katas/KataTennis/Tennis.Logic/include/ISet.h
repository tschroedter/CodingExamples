#pragma once
#include "Games.h"
#include "ITieBreak.h"
#include "SetStatus.h"

namespace Tennis
{
    namespace Logic
    {
        class ISet
        {
        public:
            virtual ~ISet () = default;

            virtual void won_point ( Player player ) = 0;
            virtual IGame* get_current_game () const = 0;
            virtual const IGames* get_games () const = 0;
            virtual size_t get_games_length () const = 0;
            virtual const ITieBreak* get_tie_break () const = 0;
            virtual const SetStatus get_status() const = 0;
        };
    };
};
