#include "include/IAwardPoints.h"
#include <memory>
#include <iostream>
#include "include/Logger.h"
#include "include/AwardPoints.h"
#include "AwardPointsFactory.h"

namespace Tennis
{
    namespace Logic
    {
        IAwardPoints* AwardPointsFactory::create () const
        {
            std::unique_ptr<ILogger> loggerAwardPoints = std::make_unique<Logger> ( std::cout );

            IAwardPoints* awardPoints = new AwardPoints ( std::move ( loggerAwardPoints ) );

            return awardPoints;
        }
    }
}
