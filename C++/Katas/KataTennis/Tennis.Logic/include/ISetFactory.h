#pragma once
<<<<<<< HEAD
=======
#include "IContainerFactory.h"
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
        class ISet;

        class ISetFactory
<<<<<<< HEAD
        {
        public:
            virtual ~ISetFactory() = default;

            virtual ISet* create() = 0;
            virtual void release(ISet* set) = 0;
        };
    };
}
=======
                : public IContainerFactory<ISet>
        {
        public:
            virtual ~ISetFactory () = default;

            virtual ISet* create () override = 0;
            virtual void release ( ISet* set ) override = 0;
        };
    };
}
>>>>>>> Update from private repository
