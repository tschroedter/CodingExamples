#pragma once
#include "MatchStatus.h"
#include <memory>
#include "ISets.h"
#include "RequiredSetsToWin.h"

namespace Tennis
{
    namespace Logic
    {
        class IMatchStatusCalculator
        {
        public:
            virtual ~IMatchStatusCalculator () = default;

            virtual void initialize ( const ISets_Ptr sets ) = 0;
            virtual const MatchStatus get_status () const = 0;
            virtual void set_required_sets_to_win ( RequiredSetsToWin required_sets_to_win ) =0;
            virtual const RequiredSetsToWin get_required_sets_to_win() = 0;
        };

        typedef std::shared_ptr<IMatchStatusCalculator> IMatchStatusCalculator_Ptr;
    };
};
