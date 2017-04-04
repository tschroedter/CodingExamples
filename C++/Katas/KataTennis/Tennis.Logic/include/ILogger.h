#pragma once

#include <string>

namespace Tennis
{
    namespace Logic
    {
        class ILogger
        {
        public:
            virtual ~ILogger () = default;

            virtual void debug ( std::string message ) const = 0;
            virtual void error ( std::string message ) const = 0;
            virtual void info ( std::string message ) const = 0;
        };
    };
};
