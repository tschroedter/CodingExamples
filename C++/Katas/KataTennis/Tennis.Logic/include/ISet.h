#pragma once
#include "IGames.h"
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

            virtual void initialize () = 0;
            virtual void won_point ( Player player ) = 0;
            virtual IGame_Ptr get_current_game () const = 0;
            virtual const IGames_Ptr get_games () const = 0;
            virtual size_t get_games_length () const = 0;
            virtual const ITieBreak_Ptr get_tie_break () const = 0;
            virtual const SetStatus get_status () const = 0;
            virtual const TieBreakStatus get_tie_break_status () const = 0;
        };

        typedef std::shared_ptr<ISet> ISet_Ptr;
    };
};
