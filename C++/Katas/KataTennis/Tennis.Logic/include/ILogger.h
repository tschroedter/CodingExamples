#pragma once

#include <string>
<<<<<<< HEAD
=======
#include <memory>
>>>>>>> Update from private repository

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
<<<<<<< HEAD
        };
=======
            virtual void warning ( std::string message ) const =0;
        };

        typedef std::shared_ptr<ILogger> ILogger_Ptr;
>>>>>>> Update from private repository
    };
};
