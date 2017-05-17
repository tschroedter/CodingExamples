#pragma once
#include <string>
#include "BaseException.h"

namespace Tennis
{
    namespace Logic
    {
        class PlayerException
                : public BaseException
        {
        public:
            explicit PlayerException (
                const std::string error )
                : BaseException ( error )
            {
            }
        };
    };
};
