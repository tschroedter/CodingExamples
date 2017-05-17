#pragma once
<<<<<<< HEAD

#pragma once
#include "include/IAwardPoints.h"
=======
#include "include/IAwardPoints.h"
#include "include/IAwardPointsFactory.h"
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        class AwardPointsFactory // todo interface
        {
        private:
=======
        class AwardPointsFactory
                : public IAwardPointsFactory
        {
>>>>>>> Update from private repository
        public:
            AwardPointsFactory ()
            {
            }

<<<<<<< HEAD
            IAwardPoints* create () const;
=======
            std::unique_ptr<IAwardPoints> create () const override;
>>>>>>> Update from private repository
        };
    }
}
