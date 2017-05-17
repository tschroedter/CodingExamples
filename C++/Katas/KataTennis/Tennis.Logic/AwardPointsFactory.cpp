#include "include/IAwardPoints.h"
#include <memory>
<<<<<<< HEAD
#include <iostream>
#include "include/Logger.h"
#include "include/AwardPoints.h"
#include "AwardPointsFactory.h"
=======
#include "include/AwardPoints.h"
#include "include/AwardPointsFactory.h"
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        IAwardPoints* AwardPointsFactory::create () const
        {
            std::unique_ptr<ILogger> loggerAwardPoints = std::make_unique<Logger> ( std::cout );

            IAwardPoints* awardPoints = new AwardPoints ( std::move ( loggerAwardPoints ) );

            return awardPoints;
=======
        std::unique_ptr<IAwardPoints> AwardPointsFactory::create () const
        {
            std::unique_ptr<IAwardPoints> award_points = std::make_unique<AwardPoints> ();

            return award_points;
>>>>>>> Update from private repository
        }
    }
}
