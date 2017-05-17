#pragma once
#include "MatchStatus.h"
#include "RequiredSetsToWin.h"
#include "Player.h"
#include "ISets.h"

namespace Tennis
{
    namespace Logic
    {
        class IMatch
        {
        public:
            virtual ~IMatch () = default;

            virtual void initialize () = 0;
            virtual void won_point ( Player player ) = 0;
            virtual MatchStatus get_status () const = 0;
            virtual RequiredSetsToWin get_required_sets_to_win () const = 0;
            virtual ISets_Ptr get_sets () const = 0;
        };
    };
};
