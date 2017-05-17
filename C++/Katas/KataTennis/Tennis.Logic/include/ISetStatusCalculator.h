#pragma once
#include "SetStatus.h"
#include <memory>
#include "ISets.h"

namespace Tennis
{
    namespace Logic
    {
        class ISetStatusCalculator
        {
        public:
            virtual ~ISetStatusCalculator () = default;

            virtual const SetStatus get_status ( const IGames_Ptr games,
                                                 const ITieBreak_Ptr tie_break ) const = 0;
        };

        typedef std::shared_ptr<ISetStatusCalculator> ISetStatusCalculator_Ptr;
    };
};
