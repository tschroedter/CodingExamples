#pragma once
#include <string>
#include "BaseException.h"

namespace Tennis
{
    namespace Logic
    {
        class ContainerException
                :public BaseException
        {
        public:
            explicit ContainerException (
                const std::string error )
                : BaseException ( error )
            {
            }
        };
    };
};
