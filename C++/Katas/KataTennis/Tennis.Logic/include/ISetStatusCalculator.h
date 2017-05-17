#pragma once
#include "SetStatus.h"
<<<<<<< HEAD
=======
#include <memory>
#include "ISets.h"
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
        class ISetStatusCalculator
        {
        public:
<<<<<<< HEAD
            virtual ~ISetStatusCalculator() = default;

            virtual const SetStatus get_status() const = 0;
        };
    };
};
=======
            virtual ~ISetStatusCalculator () = default;

            virtual const SetStatus get_status ( const IGames_Ptr games,
                                                 const ITieBreak_Ptr tie_break ) const = 0;
        };

        typedef std::shared_ptr<ISetStatusCalculator> ISetStatusCalculator_Ptr;
    };
};
>>>>>>> Update from private repository
