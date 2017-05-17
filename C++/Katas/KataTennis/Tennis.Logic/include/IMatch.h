#pragma once
#include "MatchStatus.h"
#include "RequiredSetsToWin.h"
#include "Player.h"
<<<<<<< HEAD
#include "ISet.h"
=======
>>>>>>> Update from private repository
#include "ISets.h"

namespace Tennis
{
    namespace Logic
    {
        class IMatch
        {
        public:
<<<<<<< HEAD
            virtual ~IMatch() = default;

            virtual void initialize() = 0;
            virtual void won_point(Player player) = 0;
            virtual MatchStatus get_status() const = 0;
            virtual RequiredSetsToWin get_required_sets_to_win() const = 0;
            virtual ISets* get_sets() const = 0;
=======
            virtual ~IMatch () = default;

            virtual void initialize () = 0;
            virtual void won_point ( Player player ) = 0;
            virtual MatchStatus get_status () const = 0;
            virtual RequiredSetsToWin get_required_sets_to_win () const = 0;
            virtual ISets_Ptr get_sets () const = 0;
>>>>>>> Update from private repository
        };
    };
};
